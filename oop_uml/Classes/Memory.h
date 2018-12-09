#ifndef MEMORY_H
#define MEMORY_H

#include <iostream>
#include <string>

using namespace std;

class Memory
{
public:
	Memory(unsigned short RAM_Size, unsigned short HDD_Size);
	Memory();
	~Memory();

	void SetRAM(unsigned short Megabytes);
	void SetHDD(unsigned short Gigabytes);

	unsigned short GetRAM() const;
	unsigned short GetHDD() const;

protected:
	unsigned short _RAM;	// in MB
	unsigned short _HDD;	// in GB
};

#endif // !MEMORY_H





