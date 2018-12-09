#ifndef PC_H
#define PC_H

#include <iostream>
#include <string>
#include "CPU.h"
#include "Memory.h"
#include "Keyboard.h"
#include "Mouse.h"
#include "Monitor.h"

using namespace std;

class PC {
public:
	PC();
	PC(string Name, CPU * Model, Memory * Type);
	~PC();
	
	void SetCPU(CPU * Model);
	void SetMemory(Memory * Type);

	void ConnectMonitor(Monitor * Model);
	
	void ConnectKeyboard(Keyboard * Model);
	void ConnectMouse(Mouse * Model);

	void DisconnectKeyboard();
	void DisconnectMouse();

protected:
	string _Name;
	CPU* _Processor;
	Memory* _Memory;
	
	Keyboard* _KeyBoard;
	Mouse* _Mouse;
	Monitor* _SendTo;
};

#endif // !PC_H



