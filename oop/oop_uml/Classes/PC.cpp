#include <iostream>
#include "PC.h"


PC::PC()
{
	_Name = "Computer";
	_Processor = nullptr;
	_Memory = nullptr;
	_KeyBoard = nullptr;
	_Mouse = nullptr;
	_SendTo = nullptr;
}

PC::PC(string Name, CPU * Model, Memory * Type)
{
	Name != "" ? _Name = Name : throw runtime_error("Empty name for PC!");
	_Processor = Model;
	_Memory = Type;
	_KeyBoard = nullptr;
	_Mouse = nullptr;
	_SendTo = nullptr;
}

void PC::ConnectMonitor(Monitor * Model)
{
	_SendTo = Model;
}

void PC::ConnectKeyboard(Keyboard * Model)
{
	_KeyBoard = Model;
}

void PC::ConnectMouse(Mouse * Model)
{
	_Mouse = Model;
}

void PC::DisconnectKeyboard()
{
	_KeyBoard = nullptr;
}

void PC::DisconnectMouse() 
{
	_Mouse = nullptr;
}

void PC::SetCPU(CPU * Model)
{
	_Processor = Model;
}

void PC::SetMemory(Memory * Type)
{
	_Memory = Type;
}

PC::~PC()
{
	delete _Processor;
	delete _Memory;
}
