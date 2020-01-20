#ifndef KEYBOARD_H
#define KEYBOARD_H

#include <iostream>
#include <string>
#include "../Colors.h"

using namespace std;

class Keyboard
{
public:
	Keyboard(string Name, unsigned short KeysCount, color Chroma);
	Keyboard();
	~Keyboard();

	void SetName(string Name);
	void SetKeysCount(unsigned short Count);
	void SetColor(color Chroma);

	string GetName() const;
	unsigned short GetKeysCount() const;
	color GetColor() const;

protected:
	string _Name;
	unsigned short _KeysCount;
	color _Color;
};

#endif // !KEYBOARD_H



