#include <iostream>
#include <fstream>
#include <string>
/*-----------------*/
#include "Tickets.h"
#include "Types.h"

int main(int argc, char **argv)
{
	string Filename = "Tickets.txt";
	AnotherList<Ticket> Tickets(Filename);
	cout << "* Init *" << endl;
	cout << Tickets.ToString();

	Ticket New { 7271, "New York", "S.S. Colby", "01.04.2019 12:21" };
	Tickets.Add(New);
	cout << endl << "* Added a new ticket *" << endl;
	cout << Tickets.ToString();

	Ticket Old{ 7591, "London", "M.S. Bawerman", "02.04.2019 12:13" };
	Tickets.Remove(Old);
	cout << endl << "* Removed a ticket *" << endl;
	cout << Tickets.ToString();

	Ticket Item = Tickets.Pop(3236, "03.04.2019 04:20");
	cout << endl << "* Got a ticket: " << Tickets.ToString(Item) << " *" << endl;
	cout << Tickets.ToString();

	system("pause");
}
