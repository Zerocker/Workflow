#include <iostream>
#include "CPU.h"

CPU::CPU(string Name, unsigned short Cores, float MHz)
{
	Name != "" ? _Name = Name : throw runtime_error("Empty name for CPU!");
	Cores > 0 ? _Cores = Cores : throw runtime_error("Cores for CPU must be > 0!");
	MHz > 0 ? _Freq = MHz : throw runtime_error("Negative freq for CPU!");
}

CPU::CPU()
{
	_Name = "Noname";
	_Freq = 0;
	_Cores = 0;
}

void CPU::SetName(string Name)
{
	Name != "" ? _Name = Name : throw runtime_error("Empty name for CPU!");
}

void CPU::SetCores(unsigned short Count)
{
	Count > 0 ? _Cores = Count : throw runtime_error("Cores for CPU must be > 0!");
}

void CPU::SetFreq(float MHz)
{
	MHz > 0 ? _Freq = MHz : throw runtime_error("Negative freq for CPU!");
}

string CPU::GetName() const
{
	return _Name;
}

unsigned short CPU::GetCores() const
{
	return _Cores;
}

float CPU::GetFreq() const
{
	return _Freq;
}


CPU::~CPU()
{
	cout << _Name << " removed!" << endl;
}