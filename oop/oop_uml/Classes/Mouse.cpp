#include <iostream>
#include "Mouse.h"

Mouse::Mouse(string Name, unsigned short DPI, color Chroma)
{
	Name != "" ? _Name = Name : throw runtime_error("Empty name for Mouse!");
	_DPI = DPI;
	_Color = Chroma;
}

Mouse::Mouse()
{
	_Name = "Noname";
	_DPI = 0;
	_Color = None;
}

void Mouse::SetName(string Name)
{
	Name != "" ? _Name = Name : throw runtime_error("Empty name for Mouse!");
}

void Mouse::SetDPI(unsigned short Value)
{
	_DPI = Value;
}

void Mouse::SetColor(color Chroma)
{
	_Color = Chroma;
}

string Mouse::GetName() const
{
	return _Name;
}

unsigned short Mouse::GetDPI() const
{
	return _DPI;
}

color Mouse::GetColor() const
{
	return _Color;
}

Mouse::~Mouse()
{
	cout << _Name << " removed!" << endl;
}
