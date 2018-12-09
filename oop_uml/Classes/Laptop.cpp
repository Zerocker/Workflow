#include <iostream>
#include "Laptop.h"

Laptop::Laptop(string Name, color Chroma, float Weight, CPU * Model, Memory * Type)
{
	Name != "" ? _Name = Name : throw runtime_error("Empty name for Laptop!");
	Weight > 0 ? _Weight = Weight : throw runtime_error("Invalid Weight value!");
	_Color = Chroma;
	_Processor = Model;
	_Memory = Type;
}

Laptop::Laptop()
{
	_Name = "Noname";
	_Weight = 0;
	_Color = None;
	_Processor = nullptr;
	_Memory = nullptr;
}

void Laptop::SetName(string Name)
{
	Name != "" ? _Name = Name : throw runtime_error("Empty name for Mouse!");
}

string Laptop::GetName() const
{
	return _Name;
}

Laptop::~Laptop()
{
	cout << "* " << _Name << " removed!" << endl;
}
