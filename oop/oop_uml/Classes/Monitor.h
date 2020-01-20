#ifndef MONITOR_H
#define MONITOR_H

#include <iostream>
#include <string>
#include "../Colors.h"

using namespace std;

class Monitor
{
public:
	Monitor(string Name, float Diagonal, color Type);
	Monitor();
	~Monitor();

	void SetName(string Name);
	void SetDiagonal(float Inch);
	void SetColor(color Type);

	string GetName() const;
	float GetDiagonal() const;
	color GetColor() const;

	void Output(string Message) { cout << "Monitor displays: " << Message << endl; }

protected:
	string _Name;
	float _Diagonal;
	color _Color;
};

#endif // !MONITOR_H

