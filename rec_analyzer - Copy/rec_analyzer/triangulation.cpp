// triangulation.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <sstream>
#include <fstream>
#include <stdlib.h>
#include <string>
#include <ctime>
#include <stdio.h>
#include <iostream>
#include <cmath>
#include <chrono>
#include <gsl/gsl_vector.h>
#include <gsl/gsl_multiroots.h>

using namespace std;
using namespace std::chrono_literals; // ns, us, ms, s, h, etc.
using std::chrono::system_clock;

struct rparams {
	double ax, ay, ar;
	double bx, by, br;
	double cx, cy, cr;
};

struct resolution {
	double x0, x1, res;
};

static int rosenbrock_f(const gsl_vector* x, void* params, gsl_vector* f) {
	double ax = ((struct rparams*)params)->ax;
	double ay = ((struct rparams*)params)->ay;
	double ar = ((struct rparams*)params)->ar;
	double bx = ((struct rparams*)params)->bx;
	double by = ((struct rparams*)params)->by;
	double br = ((struct rparams*)params)->br;
	const double x0 = gsl_vector_get(x, 0);
	const double x1 = gsl_vector_get(x, 1);
	const double y0 = ((x0 - ax)*(x0 - ax)) + ((x1 - ay)*(x1 - ay)) - (ar*ar);
	const double y1 = ((x0 - bx)*(x0 - bx)) + ((x1 - by)*(x1 - by)) - (br*br);
	gsl_vector_set(f, 0, y0);
	gsl_vector_set(f, 1, y1);

	return GSL_SUCCESS;
}

static int print_state(size_t iter, gsl_multiroot_fsolver* s) {
	printf("iter = %3u x = % .3f % .3f f(x) = % .3e % .3e\n", iter, gsl_vector_get(s->x, 0), gsl_vector_get(s->x, 1),
		gsl_vector_get(s->f, 0), gsl_vector_get(s->f, 1));
	return 0;
}

static struct resolution solver(float i, float j, struct rparams p) {

	struct resolution res;

	const gsl_multiroot_fsolver_type* T;
	gsl_multiroot_fsolver *s;

	int status;
	size_t iter = 0;

	const size_t n = 2;
	gsl_multiroot_function f = { &rosenbrock_f, 2, &p };

	double x_init[2] = { i, j };
	gsl_vector *x = gsl_vector_alloc(n);

	gsl_vector_set(x, 0, x_init[0]);
	gsl_vector_set(x, 1, x_init[1]);

	T = gsl_multiroot_fsolver_hybrids;
	s = gsl_multiroot_fsolver_alloc(T, 2);
	gsl_multiroot_fsolver_set(s, &f, x);

	//print_state(iter, s);

	do {
		iter++;
		status = gsl_multiroot_fsolver_iterate(s);
		//print_state(iter, s);
		if (status) break;
		status = gsl_multiroot_test_residual(s->f, 1e-3);
	} while (status == GSL_CONTINUE && iter < 1000);

	//printf("status = %s\n", gsl_strerror(status));

	res.x0 = gsl_vector_get(s->x, 0);
	res.x1 = gsl_vector_get(s->x, 1);

	res.res = ((res.x0 - p.cx)*(res.x0 - p.cx)) + ((res.x1 - p.cy)*(res.x1 - p.cy)) - (p.cr*p.cr);

	//printf("SOLUTION with %.3f, %.3f: %.3f\n\n", res.x0, res.x1, res.res);

	gsl_multiroot_fsolver_free(s);
	gsl_vector_free(x);

	return res;
}

//RSSI-To-METERS FUNCION, CPP PORTING DONE

static double calculateDistance(int rssi) {

	int txPower = -55; //hard coded power value. Usually ranges between -50 to -60

	if (rssi == 0) {
		return -1.0;
	}

	float ratio = rssi * 1.0 / txPower;

	if (ratio < 1.0) {
		return std::pow(ratio, 10);
	}
	else {
		double distance = (0.8229884)*std::pow(ratio, 7.0525179) + 0.1820634;
		return distance;
	}
}

int triangulation(string mac, int posxA, int posyA, int rssiA, int posxB, int posyB, int rssiB, int posxC, int posyC, int rssiC) {

	/*posxA = 0;
	posyA = 0;
	rssiA = -50;
	posxB = 2;
	posyB = 2;
	rssiB = -55;
	posxC = 0;
	posyC = 4;
	rssiC = -60;*/

	double rA = calculateDistance(rssiA);
	double rB = calculateDistance(rssiB);
	double rC = calculateDistance(rssiC);

	//printf("rA = %.2f, rB = %.2f, rC = %.2f\n\n", rA, rB, rC);

	struct rparams p = { (double)posxA, (double)posyA, rA, (double)posxB, (double)posyB, rB, (double)posxC, (double)posyC, rC };
	struct resolution res0 = solver(-50, -60, p);
	struct resolution res1 = solver(50, 60, p);
	std::ofstream myfile;
	myfile.open("./time_and_space.txt", std::ofstream::app);
	string room_x, room_y;
	std::ifstream room;
	room.open("./room.txt");
	getline(room, room_x, ',');
	getline(room, room_y);
	room.close();

	if (abs(res0.res) < abs(res1.res)) {
		if (res0.x0 > stoi(room_x) || res0.x1 > stoi(room_y) || res0.x1 < 0 || res0.x0 < 0) {
			myfile.close();
			return 0;
		}
		else {
			cout << "HIT WITH MAC " << mac << "POSITION: " << res0.x0 << ", " << res0.x1 << endl;
			myfile << mac << "," << res0.x0 + 0.01 << "," << res0.x1 + 0.01 << ",";
		}
	}
	else {
		if (res1.x0 > stoi(room_x) || res1.x1 > stoi(room_y) || res1.x1 < 0 || res1.x0 < 0) {
			myfile.close();
			return 0;
		}
		else {
			cout << "HIT WITH MAC " << mac << "POSITION: " << res1.x0 << ", " << res1.x1 << endl;
			myfile << mac << "," << res1.x0 + 0.01 << "," << res1.x1 + 0.01 << ",";
		}
	}
	myfile.close();
	return 0;
}