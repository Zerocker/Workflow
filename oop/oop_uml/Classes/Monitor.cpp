#include <iostream>
#include "Monitor.h"

Monitor::Monitor(string Name, float Diagonal, color Type)
{
	SetName(Name);
	SetDiagonal(Diagonal);
	SetColor(Type);
}

Monitor::Monitor()
{
	_Name = "Noname";
	_Diagonal = 0;
	_Color = None;
}


void Monitor::SetName(string Name)
{
	Name != "" ? _Name = Name : throw runtime_error("Empty name for Mouse!");
}

void Monitor::SetDiagonal(float Inch)
{
	Inch > 0 ? _Diagonal = Inch : throw runtime_error("Invalid value for Diagonal!");
}

void Monitor::SetColor(color Type) 
{
	_Color = Type;
}

string Monitor::GetName() const
{
	return _Name;
}

float Monitor::GetDiagonal() const
{
	return _Diagonal;
}

color Monitor::GetColor() const
{
	return _Color;
}

Monitor::~Monitor()
{
	cout << _Name << " removed!" << endl;
}