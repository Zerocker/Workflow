#include <iostream>
#include <sstream>
#include "Rect.h"

namespace Lab
{
	Rect::Rect(float fstSide, float sndSide) : Square(fstSide)
	{
		if (!CanSet(sndSide))
			throw std::runtime_error("Invalid side value!");
		
		cSide_ = sndSide;
		cout << "Rect called!\n";
	}
	
	Rect::Rect() : Rect(0, 0)
	{
	}

	float Rect::GetHeight()
	{
		return cSide_;
	}

	float Rect::GetArea()
	{
		return GetWidth() * GetHeight();
	}

	float Rect::GetPerimeter()
	{
		return 2 * (GetWidth() + GetHeight());
	}

	string Rect::ToString()
	{
		stringstream strout;

		strout << GetWidth();
		strout << " x ";
		strout << GetHeight();

		return strout.str();
	}

	void Rect::Set(float fstSide, float sndSide)
	{
		if (!CanSet(fstSide) || !CanSet(sndSide))
			throw std::runtime_error("Invalid side value!");
		
		this->Side_ = fstSide;
		this->cSide_ = sndSide;
	}

	Rect::~Rect()
	{
		cout << "Rect destroyed!" << endl;
	}
}