#include <iostream>
#include <fstream>
#include <iomanip>
#include <sstream>
#include <string>
#include <vector>
#include "Time.h"

using namespace std;

/* -------------------------------> * TIME CLASS * <------------------------------- */
/* -------------------------------> PUBLIC <------------------------------- */

/*	Constructor */
Time::Time() {
	set();
}

/*	Constructor */
Time::Time(unsigned short newH, unsigned short newM, unsigned short newS) {
	set(newH, newM, newS);
}

/*	Constructor */
Time::Time(const string & time) {
	set(time);
}

/*	Setting the clock. Format: HH, MM, SS */
void Time::set(unsigned short hours, unsigned short minutes, unsigned short seconds) {

	try {
		if (isCorrect(hours, minutes, seconds)) {
			seconds_ = seconds;
			minutes_ = minutes;
			hours_ = hours;
		}
	}
	catch (const exception & name) {
		cerr << name.what() << endl;
	}
}

/* Setting the clock. Format: HH:MM:SS */
void Time::set(const string & time) 
{
	unsigned short _newS, _newM, _newH;
	sscanf_s(time.c_str(), "%hu:%hu:%hu", &_newS, &_newM, &_newH);
	set(_newS, _newM, _newH);
}

/*	Synchronisation with the current time */
void Time::sync()
{
	/* Get current time on *poor* computer */
	time_t currentTime = time(0);
	struct tm * Now = localtime(& currentTime);
	
	hours_ = Now->tm_hour;
	minutes_ = Now->tm_min;
	seconds_ = Now->tm_sec;
}

/*	Resetting the clock	*/
void Time::clear() 
{
	set();
}

/*	Converting seconds in HH:MM:SS */
void Time::convertSeconds(unsigned int many_seconds) 
{
	clear();
	hours_ = (many_seconds / 3600) % 24;
	minutes_ = many_seconds % 3600 / 60;
	seconds_ = many_seconds % 60;
}

/*	Converting minutes in HH:MM:SS */
void Time::convertMinutes(unsigned int many_minutes) 
{
	clear();
	hours_ = (many_minutes / 60) % 24;
	minutes_ = many_minutes % 60;
}

/* Addition of two time objects */
Time Time::operator+ (Time Addend) const
{
	Time Sum;
	/* Add first and second times */
	unsigned int newSec = (this->seconds_ + Addend.seconds_);
	unsigned int newMin = (this->minutes_ + Addend.minutes_);
	unsigned int newHrs = (this->hours_ + Addend.hours_);

	/* Correction */
	Sum.seconds_ = newSec % 60;
	Sum.minutes_ = (newSec / 60) + (newMin % 60);
	Sum.hours_ = (newMin / 60) + (newHrs % 24);
	return Sum;
}

/* Addition with a time object */
void Time::operator+= (Time Addend)
{
	/* Add first and second times */
	unsigned int newSec = (this->seconds_ + Addend.seconds_);
	unsigned int newMin = (this->minutes_ + Addend.minutes_);
	unsigned int newHrs = (this->hours_ + Addend.hours_);

	/* Correction */
	this->seconds_ = newSec % 60;
	this->minutes_ = (newSec / 60) + (newMin % 60);
	this->hours_ = (newMin / 60) + (newHrs % 24);
}

/* Multiply by number */
void Time::operator*= (unsigned int value)
{
	unsigned int newInSec = this->inSeconds();
	newInSec *= value;

	/* Correction */
	this->convertSeconds(newInSec);
}

/*	Your time is... */
string Time::str() const {
	stringstream output;

	string floatZero_A = "";
	string floatZero_B = "";
	string floatZero_C = "";
	if (minutes_ < 10)
		floatZero_A = "0";
	if (seconds_ < 10)
		floatZero_B = "0";
	if (hours_ < 10)
		floatZero_C = "0";

	output << floatZero_C << hours_ << ":";
	output << floatZero_A << minutes_ << ":";
	output << floatZero_B << seconds_ << endl;

	return output.str();
}

/* -------------------------------> PRIVATE METHODS <------------------------------- */

/*	Checking time values */
bool Time::isCorrect(unsigned short hours, unsigned short minutes, unsigned short seconds)
{
	size_t count = 0;
	if (((hours > -1) && (hours < 24)))
		++count;
	else
		throw runtime_error("* Invalid hours value! *");

	if (((minutes > -1) && (minutes < 60)))
		++count;
	else
		throw runtime_error("* Invalid minutes value! *");

	if (((seconds > -1) && (seconds < 60)))
		++count;
	else
		throw runtime_error("* Invalid seconds value! *");
		
	count == 3 ? true : false;
}