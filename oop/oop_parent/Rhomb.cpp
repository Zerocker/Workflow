#define _USE_MATH_DEFINES

#include <iostream>
#include <sstream>
#include <math.h>
#include "Rhomb.h"

namespace Lab {
	
	Rhomb::Rhomb(float Side, float Angle) : Square(Side)
	{
		if (!CanSetAngle(Angle))
			throw std::runtime_error("Invalid angle value!");

		cAngle_ = Angle;
		cout << "Rhomb called!\n";
	}

	Rhomb::Rhomb() : Rhomb(0, 0)
	{
	}

	float Rhomb::GetSide()
	{
		return GetWidth();
	}
	

	void Rhomb::SetAngle(float Angle)
	{
		if (!CanSetAngle(Angle))
			throw std::runtime_error("Invalid angle value!");

		this->cAngle_ = Angle;
	}

	void Rhomb::Set(float Side, float Angle)
	{
		if (!CanSet(Side))
			throw std::runtime_error("Invalid side value!");

		this->Side_ = Side;
		SetAngle(Angle);
	}
	
	float Rhomb::GetAngle()
	{
		return cAngle_;
	}

	float Rhomb::GetArea()
	{
		return (float)sin(GetAngle() * M_PI / 180) * GetWidth() * GetWidth();
	}
	
	string Rhomb::ToString()
	{
		stringstream strout;

		strout << GetWidth();
		strout << " x ";
		strout << GetWidth();
		strout << " [";
		strout << cAngle_;
		strout << "]";

		return strout.str();
	}

	bool Rhomb::CanSetAngle(float degrees)
	{
		if ((degrees < 0.0) || (degrees > 181.0))
			return false;
		else
			return true;
	}

	Rhomb::~Rhomb()
	{
		cout << "Rhomb destroyed!" << endl;
	}
}