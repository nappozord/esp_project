#include <stdio.h>
#include <string>
#include <vector>

using namespace std;

struct struttura {
	string ssid;
	int rssi;
	int seq_nr;
	double timestamp;
	bool operator<(const struttura& a) const {
		return rssi > a.rssi;
	}
};

struct position {
	int x;
	int y;
};

struct esps {																					//facciamo un vettore di strutture anziché
	string esp_n;																				//una struttura di vettori (più facile da
	position pos;																				//gestire (?))
	vector<struttura> dati;
};

class User {
	string mac;

public:

	vector<esps> espini;

	User(string mac, string esp_nr, string ssid, int rssi, int seq_nr, double timestamp, int x, int y);       //costruttore

	void append_probe(string esp_nr, string ssid, int rssi, int seq_nr, double timestamp, int x, int y);      //aggiunge una probe dato un esp

	string get_mac();                                                                           //ritorna il mac dell'utente

	vector<string> get_esp_list();                                                              /*ritorna la lista degli esp che hanno
																								 trovato questo utente*/

	vector<struttura> get_esp_sniff(string esp_nr);                                                     /*ritorna la lista delle probe dell'utente
																								 rilevate da un singolo esp*/

	struct position get_esp_pos(string esp_nr);

	void delete_dati(string esp_nr);

	void delete_esp();

	void cycle_esp();
};

