#include <iostream>
#include "Memory.h"

Memory::Memory(unsigned short RAM_Size, unsigned short HDD_Size)
	: _RAM(RAM_Size), _HDD(HDD_Size) {}

Memory::Memory()
{
	_RAM = 0;
	_HDD = 0;
}


void Memory::SetRAM(unsigned short Megabytes)
{
	_RAM = Megabytes;
}

void Memory::SetHDD(unsigned short Gigabytes)
{
	_HDD = Gigabytes;
}

unsigned short Memory::GetRAM() const
{
	return _RAM;
}

unsigned short Memory::GetHDD() const
{
	return _HDD;
}

Memory::~Memory()
{
	cout << "Memory removed!" << endl;
}