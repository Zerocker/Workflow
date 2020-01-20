#include <iostream>
#include "Keyboard.h"

Keyboard::Keyboard(string Name, unsigned short KeysCount, color Chroma)
{
	Name != "" ? _Name = Name : throw runtime_error("Empty name for Keyboard!");
	_KeysCount = KeysCount;
	_Color = Chroma;
}

Keyboard::Keyboard()
{
	_Name = "Noname";
	_KeysCount = 0;
	_Color = None;
}

void Keyboard::SetName(string Name)
{
	Name != "" ? _Name = Name : throw runtime_error("Empty name for Keyboard!");
}

void Keyboard::SetKeysCount(unsigned short Count)
{
	_KeysCount = Count;
}

void Keyboard::SetColor(color Chroma)
{
	_Color = Chroma;
}

string Keyboard::GetName() const
{
	return _Name;
}

unsigned short Keyboard::GetKeysCount() const
{
	return _KeysCount;
}

color Keyboard::GetColor() const
{
	return _Color;
}

Keyboard::~Keyboard()
{
	cout << _Name << " removed!" << endl;
}

