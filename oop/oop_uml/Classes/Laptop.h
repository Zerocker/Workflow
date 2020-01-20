#ifndef LAPTOP_H
#define LAPTOP_H

#include <iostream>
#include "PC.h"
#include "../Colors.h"

class Laptop : public PC {
public:
	Laptop(string Name, color Chroma, float Weight, CPU * Model, Memory * Type);
	Laptop();
	~Laptop();

	void SetName(string Name);
	string GetName() const;

protected:
	string _Name;
	color _Color;
	float _Weight;
};

#endif // !LAPTOP_H

