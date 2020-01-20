#ifndef CPU_H
#define CPU_H

#include <iostream>
#include <string>

using namespace std;

class CPU
{
public:
	CPU(string Name, unsigned short Cores, float MHz);
	CPU();
	~CPU();
	
	void SetName(string Name);
	void SetCores(unsigned short Count);
	void SetFreq(float MHz);

	string GetName() const;
	unsigned short GetCores() const;
	float GetFreq() const;

protected:
	string _Name;
	unsigned short _Cores;
	float _Freq;
};

#endif // !CPU_H



