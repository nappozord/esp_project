#include "pch.h"
#include <iostream>
#include <algorithm>
#include <fstream>
#include <string>
#include <vector>
#include <sstream>
#include <thread>
#include "triangulation.hpp"
//#include <unistd.h>
#include "user.hpp"


using namespace std;

User::User(string mac, string esp_nr, string ssid, int rssi, int seq_nr, double timestamp, int x, int y) {
    this->mac = mac;
    this->espini.push_back(*new esps());
    auto it = espini.end();
    it--;
    it->esp_n = esp_nr;
	it->pos.x = x;
	it->pos.y = y;
    struttura dato;
    dato.ssid = ssid;
    dato.rssi = rssi;
    dato.seq_nr = seq_nr;
    dato.timestamp = timestamp;
    it->dati.push_back(dato);
}

void User::append_probe(string esp_nr, string ssid, int rssi, int seq_nr, double timestamp, int x, int y) {
    for (auto it = espini.begin(); it != espini.end(); it++) {
        if (it->esp_n == esp_nr) {                                  //scansiona tutti gli esp che hanno già rilevato questo utente
            /*it->dati.ssid.push_back(ssid);                        //se esiste già l'espino che lo ha appena rilevato si appendono i
            it->dati.rssi.push_back(rssi);                          //dati alla struttura di quell'espino e ritorna
            it->dati.seq_nr.push_back(seq_nr);
            it->dati.timestamp.push_back(timestamp);*/
            struttura dato;
            dato.ssid = ssid;
            dato.rssi = rssi;
            dato.seq_nr = seq_nr;
            dato.timestamp = timestamp;
            it->dati.push_back(dato);
            return;
        }
    }
    this->espini.push_back(*new esps());                           //se esce dal for vuol dire che l'espino che lo ha appena rilevato
    auto iter = espini.end();                                      //non esiste ancora, quindi lo crea e mette i dati nella sua struttura
    iter--;
    iter->esp_n = esp_nr;
	iter->pos.x = x;
	iter->pos.y = y;
    struttura dato;
    dato.ssid = ssid;
    dato.rssi = rssi;
    dato.seq_nr = seq_nr;
    dato.timestamp = timestamp;
    iter->dati.push_back(dato);
}

string User::get_mac() {
    return mac;
}

vector<string> User::get_esp_list() {
    vector<string> vectesp;
    for (auto it = espini.begin(); it != espini.end(); it++) vectesp.push_back(it->esp_n);
    return vectesp;
}

vector<struttura> User::get_esp_sniff(string esp_nr) {
    vector<struttura> vuota;
    for (auto it = espini.begin(); it != espini.end(); it++) if (it->esp_n == esp_nr)  vuota = it->dati;
    return vuota;
}

struct position User::get_esp_pos(string esp_nr) {
	struct position pos;
	for (auto it = espini.begin(); it != espini.end(); it++) if (it->esp_n == esp_nr) pos = it->pos;
	return pos;
}

void User::delete_dati(string esp_nr) {
	for (auto it = espini.begin(); it != espini.end(); it++) {
		if (it->esp_n == esp_nr) {
			it->dati.erase(it->dati.begin());
		}
	}
}

void User::delete_esp() {
	espini.erase(espini.begin());
}

void User::cycle_esp() {
	int esp_count = 0;
	int rssiTmp[3] = { -1, -1, -1 }; 
	int xTmp[3];
	int yTmp[3];
	int seq_nrTmp = -1;
	for (auto it = espini.begin(); it != espini.end(); it++) {
		sort(it->dati.begin(), it->dati.end());
	}

	while (esp_count != 3 && espini.size() >= 3) {
		auto vect_esp = get_esp_list();
		esp_count = 0;
		// Ciclo tra tutte le ESP dell'User
		for (auto k = vect_esp.begin(); k != vect_esp.end(); k++) {
			// Ciclo tra tuttE le istanze dell'ESP e becco un seq_nr
			// vedo se la stessa seq_nr è presente negli altri esp, altrimenti
			// cancello l'istanza dall'esp di riferimento e vado alla prossima
			auto vect_struct = get_esp_sniff(*k);
			for (auto x = vect_struct.begin(); x != vect_struct.end(); x++) {
				if (rssiTmp[0] == -1) {
					rssiTmp[0] = x->rssi;
					seq_nrTmp = x->seq_nr;
					xTmp[0] = get_esp_pos(*k).x;
					yTmp[0] = get_esp_pos(*k).y;
					esp_count++;
					break;
				}
				else {
					if (x->seq_nr > seq_nrTmp - 200 && x->seq_nr < seq_nrTmp + 200) {
						rssiTmp[esp_count] = x->rssi;
						xTmp[esp_count] = get_esp_pos(*k).x;
						yTmp[esp_count] = get_esp_pos(*k).y;
						esp_count++;
						break;
					}
				}
			}
			// Se trovo tre esp con lo stesso seq_nr, non c'è bisogno di
			// scannerizzarne altre
			if (esp_count == 3)
				break;
		}
		// Cancello l'istanza dalla struttura dati
		if (esp_count < 3) {
			rssiTmp[0] = -1;
			rssiTmp[1] = -1;
			rssiTmp[2] = -1;
			string a = get_esp_list().front();
			delete_dati(a);
		}
		// Se l'esp non ha più istanze, la cancello e passo alla prossima
		auto front = get_esp_list().front();
		if (get_esp_sniff(front).size() == 0) {
			delete_esp();
			esp_count = 0;
		}
	}

	if(rssiTmp[0] != -1 && rssiTmp[1] != -1 && rssiTmp[2] != -1)
		triangulation(this->get_mac(), xTmp[0], yTmp[0], rssiTmp[0], xTmp[1], yTmp[1], rssiTmp[1], xTmp[2], yTmp[2], rssiTmp[2]);

}