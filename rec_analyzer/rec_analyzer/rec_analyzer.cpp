#include "pch.h"
#include <iostream>
#include <cstdio>
#include <algorithm>
#include <fstream>
#include <string>
#include <vector>
#include <sstream>
#include <thread>
#include "triangulation.hpp"
#include "user.hpp"
#include <chrono>
#include <Windows.h>

using namespace std;
using namespace std::this_thread;     // sleep_for, sleep_until
using namespace std::chrono_literals; // ns, us, ms, s, h, etc.
using std::chrono::system_clock;

vector<User> people;
vector<string> mac;
vector<string> mac_connected;

void analyzer(string esp_nr, int x, int y) {
	char filename[50];
	vector<string>::iterator it;
	string s, word, ssid;
	int rssi, seq_nr;
	double timestamp;

	sprintf_s(filename, "./rec_%s.txt", esp_nr.c_str());
	ifstream filestream(filename, std::ios_base::in);

	if (!filestream) 
		return;
		
	int flag = 0;

	while (!filestream.eof())
	{
		while (getline(filestream, s))
		{
			if (s != "") {
				stringstream token(s);
				getline(token, word, ',');
				rssi = stoi(word);                      //prendo l'rssi, se è maggiore di -80 (circa 11 metri), non contarlo
				if (rssi > -80) {
					getline(token, word, ',');
					timestamp = stod(word);                 //prendo il timestamp
					getline(token, word, ',');
					seq_nr = stoi(word);                    //prendo il seq_nr
					getline(token, word, ',');
					ssid = word;                            //prendo l'ssid
					getline(token, word, ',');
					it = find(mac.begin(), mac.end(), word);
					if (it != mac.end()) {   
						//se il mac non è nuovo appendo al vettore di strutture
						auto index = distance(mac.begin(), it);
						people.at(index).append_probe(esp_nr, ssid, rssi, seq_nr, timestamp, x, y);
					}
					else {   
						//se il mac è nuovo creo un nuovo User
						mac.push_back(word);
						people.push_back(*new User(word, esp_nr, ssid, rssi, seq_nr, timestamp, x, y));
					}
				}
			}
		}
	}
	filestream.close();
	remove(filename);
}

void check_file(string esp_nr) {
	char filename[50];

	sprintf_s(filename, "./rec_%s.txt", esp_nr.c_str());
	ifstream filestream(filename, std::ios_base::in);

	if (!filestream)
	{
		string ss;
		ifstream mac_file("./mac_list.txt");
		ofstream temp;
		temp.open("temp.txt", std::ofstream::out | std::ofstream::app);
		while (getline(mac_file, ss)) {
			if (ss.find(esp_nr) != string::npos)
				ss = "";
			temp << ss << endl;
		}
		mac_file.close();
		remove("./mac_list.txt");
		temp.close();
		int res = rename("./temp.txt", "./mac_list.txt");
		return;
	}
}

void stampa_dispositivi() {                         //stampa per ogni user le probe rilevate divise per esp
	int num;
	ofstream myfile2;
	myfile2.open("./output.txt", std::ofstream::out);
	for (auto it = people.begin(); it != people.end(); it++) {
		myfile2 << "\t\t\tUSER MAC: " << it->get_mac() << endl;
		for (auto i = it->espini.begin(); i != it->espini.end(); i++) {
			num = 0;
			myfile2 << "\t\t\t\tESP_" << i->esp_n << endl;
			myfile2 << "RSSI\t\tTIMESTAMP\tSEQ NR\t\tSSID" << endl;
			for (auto k = i->dati.begin(); k != i->dati.end(); k++) {
				myfile2 << i->dati.at(num).rssi << "\t\t" << i->dati.at(num).timestamp << "\t\t" << i->dati.at(num).seq_nr << "\t\t" << i->dati.at(num).ssid << endl;
				num++;
			}
		}
		myfile2 << "\n" << endl;
	}
	myfile2.close();
}

void registerPosition() {
	const time_t now = time(0);   // get time now
	char dt[30];
	ctime_s(dt, sizeof dt, &now);
	cout << "TIME NOW: " << dt << "\n";
	std::ofstream myfile;
	myfile.open("./time_and_space.txt", std::ofstream::app);
	auto timenow = system_clock::to_time_t(system_clock::now());
	myfile << dt << "," << endl;
	myfile.close();
	// Ciclo tra tutti gli User registrati negli XX secondi di scan
	for (auto it = people.begin(); it != people.end(); it++) {
		// Se uno User non è stato sniffato da 3 o più ESP, viene automaticamente scartato
		if (it->get_esp_list().size() < 3) {
		}
		else {
			it->cycle_esp();
		}
	}
	myfile.open("./time_and_space.txt", std::ofstream::app);
	myfile << ";" << endl;
	myfile.close();
}

int main(int argc, const char * argv[]) {
	HWND console = GetConsoleWindow();
	RECT r;
	GetWindowRect(console, &r);
	//MoveWindow(console, 0, /*300*/0, /*500*/0, /*300*/0, TRUE);
	ShowWindow(console, SW_HIDE);

	string esp_nr;
	string x, y;
	vector<int> x_n;
	vector<int> y_n;
	string line;
	ifstream myfile;
	remove("./mac_list.txt");
	int file_lenght_pre = 0;
	int file_lenght_post = 0;
	//l'analyzer dopo che ha letto i file rec_x ne elimina il contenuto
	while (true) {
		myfile.open("./mac_list.txt", std::ios_base::in);
		while (getline(myfile, line))
		{
			if (line != "") {
				stringstream token(line);
				getline(token, esp_nr, ',');
				mac_connected.push_back(esp_nr);
				getline(token, x, ':');
				x_n.push_back(stoi(x));
				getline(token, y, ':');
				y_n.push_back(stoi(y));
			}
		}
		myfile.close();
		for (int j = 0; j < mac_connected.size(); j++) {
			analyzer(mac_connected[j], x_n[j], y_n[j]);
		}
		cout << "\n-----------------------------------------------------\n" << endl;
		if (!mac_connected.empty()) registerPosition();
		people.clear();
		mac.clear();
		sleep_for(60s);
		for (int j = 0; j < mac_connected.size(); j++) {
			check_file(mac_connected[j]);
		}
		mac_connected.clear();
	}

	return 0;
}
