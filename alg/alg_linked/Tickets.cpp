#include "Tickets.hpp"
#include <sstream>
#include <iomanip>

bool operator==(const Ticket & First, const Ticket & Second)
{
	return First.Number == Second.Number && First.DepartureTime == Second.DepartureTime;
}

string StringTicket(const Ticket& Object)
{
	stringstream strout;

	strout << left << setw(6) << setfill(' ') << Object.Number;
	strout << left << setw(12) << setfill(' ') << Object.Destination;
	strout << left << setw(16) << setfill(' ') << Object.Passanger;
	strout << left << setw(12) << setfill(' ') << Object.DepartureTime;

	return strout.str();
}
