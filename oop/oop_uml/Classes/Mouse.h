#ifndef MOUSE_H
#define MOUSE_H

#include <iostream>
#include <string>
#include "../Colors.h"

using namespace std;

class Mouse
{
public:
	Mouse(string Name, unsigned short DPI, color Type);
	Mouse();
	~Mouse();

	void SetName(string Name);
	void SetDPI(unsigned short Value);
	void SetColor(color Type);

	string GetName() const;
	unsigned short GetDPI() const;
	color GetColor() const;

protected:
	string _Name;
	unsigned short _DPI;
	color _Color;
};

#endif // !MOUSE_H