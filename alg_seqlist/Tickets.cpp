#include "Tickets.h"
#include <sstream>
#include <iomanip>

bool operator==(const Ticket & First, const Ticket & Second)
{
	return First.Number == Second.Number && First.DepartureTime == Second.DepartureTime;
}