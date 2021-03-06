#include <iostream>
#include <string>
#include "Classes/Monitor.h"
#include "Classes/Mouse.h"
#include "Classes/Keyboard.h"
#include "Classes/Laptop.h"
#include "Classes/PC.h"

using namespace std;

int main()
{	
	cout << " [CLASSES] " << endl << endl;

	//	1. Objects creation
	CPU *Core =			new CPU("'Intel'", 4, 2.7);
	Memory *MemUnit =	new Memory(4096, 1024);
	Monitor *Output1 =	new Monitor("'LG'", 21.5, White);
	Monitor *Output2 =	new Monitor("'Benq'", 22.5, White);
	Keyboard *Input1 =	new Keyboard("'Keyboard'", 104, Gray);
	Mouse *Input2 =		new Mouse("'Mouse'", 800, White);
	PC *Workstation =	new PC("'PC'", Core, MemUnit);
	Laptop *Portable =  new Laptop("'Swift'", Blue, 1.5, Core, MemUnit);
	
	//	2. "Building a PC"
	Workstation->ConnectMonitor(Output1);
	Workstation->ConnectKeyboard(Input1);
	Workstation->ConnectMouse(Input2);
	
	//	3. Manipulation with the objects we've created
	Workstation->ConnectMonitor(Output2);
	Output1->SetColor(White);
	Input1->SetColor(Red);
	Input2->SetName("Oklick");
	Output2->Output("Hello again!");
	Portable->SetName("Extensa");
	cout << "Laptop's name: " << Portable->GetName() << endl;

	// 4. Check aggregation and composition between classes
	Workstation->DisconnectKeyboard();
	Workstation->DisconnectMouse();
	Portable->DisconnectMouse();		// a.k.a. turn off touchpad

	cout << endl << " [DESTRUCTORS] " << endl;
}