#ifndef TIME_H
#define	TIME_H

#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

class Time 
{
private:
	unsigned short seconds_;		// seconds (0...59)
	unsigned short minutes_;		// minutes (0...59)
	unsigned short hours_;			// hours (0...23)

	/*	Checking time values */
	static bool isCorrect(unsigned short hours, unsigned short minutes, unsigned short seconds);

public:
	/*	Constructor */
	Time();
	/*	Constructor */
	Time(unsigned short newH, unsigned short newM, unsigned short newS);
	/*	Constructor */
	Time(const string & time);

	/*	Setting the clock. Format: HH, MM, SS */
	void set(unsigned short hours = 0, unsigned short minutes = 0, unsigned short seconds = 0);
	/*	Setting the clock. Format: HH:MM:SS */
	void set(const string & time);

	// Set seconds separately
	void set_s(unsigned short seconds) { set(0, 0, seconds); }
	// Set minutes separately 
	void set_m(unsigned short minutes) { set(0, minutes); }
	// Set hours separately
	void set_h(unsigned short hours) { set(hours); }

	/*	Synchronisation with the current time */
	void sync();
	/*	Resetting the clock	*/
	void clear();

	/*	Your time is... */
	string str() const;
	
	/*	Converting seconds in HH:MM:SS */
	void convertSeconds(unsigned int many_seconds);
	
	/*	Converting minutes in HH:MM:SS */
	void convertMinutes(unsigned int many_minutes);

	/* Addition of two time objects */
	Time operator+ (Time Addend) const;
	/* Addition with a time object */
	void operator+= (Time Addend);
	/* Multiply by number */
	void operator*= (unsigned int value);

	/*	Getting time in seconds, minutes or hours */
	unsigned int inSeconds() const { return (hours_ * 3600) + (minutes_ * 60) + (seconds_); }
	unsigned int inMinutes() const { return (hours_ * 60) + (minutes_);  }
	unsigned int inHours() const { return (hours_); }

	/*	Getting separately seconds, minutes or hours */
	unsigned short seconds() const { return seconds_; }
	unsigned short minutes() const { return minutes_; }
	unsigned short hours() const { return hours_; }
};

#endif // TIME_H



