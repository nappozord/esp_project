// Serverv2.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <winsock2.h>
#include <stdio.h>
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <WS2tcpip.h>
#include <iphlpapi.h>
#include <atlstr.h>

#include <algorithm>
#include <chrono>
#include <vector>
#include <cstdlib>
#include <iostream>
#include <set>
#include <string>
#include <fstream>
#include <ctime>
#include <iomanip>
#include <thread>
#include <future>

// Need to link with Ws2_32.lib
#pragma comment(lib, "Ws2_32.lib")
#pragma comment(lib, "iphlpapi.lib")
#pragma warning(disable:4996) 

#define bzero(b,len) (memset((b), '\0', (len)), (void) 0)  

//using namespace std;
using std::set;
using std::cout;
using std::endl;
using std::string;
using std::runtime_error;

char clock_proto[] = "Give me your clock please";

void open_analyzer() {
	system("start analyzer/rec_analyzer.exe");
}

void open_position(char mac_esp[6]) {
	char command[50];
	sprintf(command, "start positioner.exe %s", mac_esp);
	system(command);
	printf("OK");
}

void open_room() {
	system("start room_map.exe");
}

void open_gui() {
	system("start gui.exe");
}

int wmain(void)
{
	HWND console = GetConsoleWindow();
	RECT r;
	ShowWindow(console, SW_HIDE);

	remove("room.txt");

	std::thread room = std::thread(open_room);
	room.join();

	std::thread gui = std::thread(open_gui);
	gui.join();

	system("netsh wlan connect ssid=\"myssid\" name=\"myssid\" interface=\"Wi-Fi\"");
	system("netsh int ip set address \"Wi-Fi\" static 192.168.4.151 255.255.255.0 192.168.4.1 1");
	system("NetSh Advfirewall set allprofiles state off");

	std::thread analyzer = std::thread(open_analyzer);
	analyzer.join();

	auto startTime = std::chrono::high_resolution_clock::now();

	//----------------------
	// Initialize Winsock.
	WSADATA wsaData;
	int iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != NO_ERROR) {
		wprintf(L"WSAStartup failed with error: %ld\n", iResult);
		return 10;
	}
	//----------------------
	// Create a SOCKET for listening for
	// incoming connection requests.
	SOCKET listenfd;
	listenfd = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (listenfd == INVALID_SOCKET) {
		wprintf(L"socket failed with error: %ld\n", WSAGetLastError());
		WSACleanup();
		return 11;
	}
	int n;
	int count = 1;

	char size[20];
	char sendBuff[1025];
	char recvBuff[100000];

	//----------------------
	// The sockaddr_in structure specifies the address family,
	// IP address, and port for the socket that is being bound.
	sockaddr_in serv_addr, cli_addr;

	struct in_addr dstip;

	int cli_addr_len = (int)sizeof(cli_addr);

	memset(&serv_addr, '0', sizeof(serv_addr));
	memset(sendBuff, '0', sizeof(sendBuff));

	serv_addr.sin_family = AF_INET;
	serv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_addr.sin_port = htons(15100);

	bind(listenfd, (SOCKADDR *)& serv_addr, sizeof(serv_addr));
	//----------------------
	// Listen for incoming connection requests.
	// on the created socket
	if (listen(listenfd, 1) == SOCKET_ERROR) {
		wprintf(L"listen failed with error: %ld\n", WSAGetLastError());
		closesocket(listenfd);
		WSACleanup();
		return 12;
	}

	std::vector<string> mac_array;
	char filename[30];
	std::vector<string> connected_mac;

	//----------------------
	// Create a SOCKET for accepting incoming requests.
	SOCKET connfd;

	while (true) {

		std::cout << "Server Session: " << count << std::endl;
		wprintf(L"Waiting for client to connect...\n");

		//----------------------
		// Accept the connection.
		connfd = accept(listenfd, (SOCKADDR *)& cli_addr, &cli_addr_len);
		if (connfd == INVALID_SOCKET) {
			wprintf(L"accept failed with error: %ld\n", WSAGetLastError());
			closesocket(listenfd);
			WSACleanup();
			return 13;
		}

		char ip_address[INET_ADDRSTRLEN];
		inet_ntop(AF_INET, &cli_addr.sin_addr.s_addr, ip_address, INET_ADDRSTRLEN);

		IPAddr srcip = 0;
		dstip.s_addr = inet_addr(ip_address);
		unsigned char mac_esp_v2[6];
		ULONG MacAddr[2];
		ULONG PhyAddrLen = 6;
		SendARP((IPAddr)dstip.S_un.S_addr, srcip, MacAddr, &PhyAddrLen);
		BYTE *bMacAddr = (BYTE*)&MacAddr;
		for (int i = 0; i < (int)PhyAddrLen; i++) {
			mac_esp_v2[i] = (char)bMacAddr[i];
		}

		
		char mac_esp_ultimate[20];

		sprintf(mac_esp_ultimate, "%.2X-%.2X-%.2X-%.2X-%.2x-%.2X", mac_esp_v2[0], mac_esp_v2[1], mac_esp_v2[2], mac_esp_v2[3], mac_esp_v2[4], mac_esp_v2[5]);

		printf("Connected to ESP with MAC: %s\n", mac_esp_ultimate);

		std::vector<string>::const_iterator it;
		it = std::find(mac_array.begin(), mac_array.end(), mac_esp_ultimate);

		std::ifstream esp_mac("./mac_list.txt");
		if (esp_mac) {
			std::string ss;
			int flag = 1;
			while (getline(esp_mac, ss)) {
				if (ss.find(mac_esp_ultimate) == std::string::npos)
					flag = 1;
				else {
					flag = 0;
					break;
				}
			}
			//Mac c'è nel file FLAG = 0, altrimenti FLAG = 1
			if (flag == 1 && it != mac_array.end()) {
				mac_array.erase(it);
			}
		}
		esp_mac.close();

		std::vector<string>::const_iterator it2;
		it2 = std::find(mac_array.begin(), mac_array.end(), mac_esp_ultimate);

		if (it2 == mac_array.end()) {
			mac_array.push_back(mac_esp_ultimate);
			std::thread position(open_position, mac_esp_ultimate);
			position.join();
		}

		sprintf(filename, "rec_%s.txt", mac_esp_ultimate);

		// CREO O APRO FILE LOG PER ESP CONNESSO
		std::ofstream fout;
		fout.open(filename, std::ofstream::out | std::ofstream::app);

		if (!fout) {
			std::cerr << " can't open input - " << filename << endl;
			return 1;
		}

		bzero(recvBuff, sizeof(recvBuff));
		bzero(size, sizeof(size));

		n = 0;

		recv(connfd, size, sizeof(size), 0);
		if (strcmp(size, clock_proto) == 0) {
			auto duration = std::chrono::high_resolution_clock::now() - startTime;
			auto elapsedTime = std::chrono::duration_cast<std::chrono::milliseconds>(duration).count();
			sprintf(sendBuff, "%g", (double)elapsedTime);
			send(connfd, sendBuff, strlen(sendBuff), 0);
		}
		else {
			printf("Size of client buf = %d\n", atoi(size));

			int i; char c;
			for (i = 0; i < atoi(size); i++) {
				recv(connfd, &c, sizeof(char), 0);
				recvBuff[i] = c;
			}

			printf("Sending response...\n");

			bzero(sendBuff, sizeof(sendBuff));
			auto duration = std::chrono::high_resolution_clock::now() - startTime;
			auto elapsedTime = std::chrono::duration_cast<std::chrono::milliseconds>(duration).count();
			sprintf(sendBuff, "%g", (double)elapsedTime);

			send(connfd, sendBuff, strlen(sendBuff), 0);

			fout << recvBuff << endl;
		}

		closesocket(connfd);
		printf("Closed connection with esp32!\n\n");

		count++;
	}

	WSACleanup();
	return 0;
}