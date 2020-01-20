#define _USE_MATH_DEFINES

#include <iostream>
#include <sstream>
#include <math.h>
#include "Parallel.h"

namespace Lab {
	Parallel::Parallel(float fstSide, float sndSide, float Angle) : pSide_(sndSide), Rhomb(fstSide, Angle)
	{
		cout << "Parallel finally called!\n";
	}

	Parallel::Parallel() : Parallel(0, 0, 0)
	{
	}

	void Parallel::Set(float fstSide, float sndSide, float Angle)
	{
		if (!CanSet(fstSide) || !CanSet(sndSide))
			throw std::runtime_error("Invalid sides' values!");

		if (!CanSetAngle(Angle))
			throw std::runtime_error("Invalid angle value!");

		this->Side_ = fstSide;
		this->pSide_ = sndSide;
		this->cAngle_ = Angle;
	}

	float Parallel::GetSecondSide()
	{
		return pSide_;
	}

	float Parallel::GetPerimeter()
	{
		return 2 * (GetSecondSide() + GetSecondSide());
	}

	float Parallel::GetArea()
	{
		return (float)sin(GetAngle() * M_PI / 180) * GetSecondSide() * GetWidth();
	}

	string Parallel::ToString()
	{
		stringstream strout;

		strout << GetWidth();
		strout << " x ";
		strout << GetSecondSide();
		strout << " [";
		strout << cAngle_;
		strout << "]";

		return strout.str();
	}

	Parallel::~Parallel()
	{
		cout << "Parallel destroyed!" << endl;
	}
}
