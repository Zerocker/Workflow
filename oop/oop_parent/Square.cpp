#include <iostream>
#include <sstream>
#include "Square.h"

namespace Lab
{
	Square::Square(float Side)
	{
		if (!CanSet(Side))
			throw std::runtime_error("Invalid side value!");

		Side_ = Side;
		cout << "Square called!\n";
	}

	Square::Square() : Square(0)
	{
	}

	Square::Square(const Square &Object) : Side_(Object.Side_)
	{
	}

	void Square::operator=(const Square &Object)
	{
		Side_ = Object.Side_;
	} 

	Square::Square(Square &&Object)
	{
		Side_ = Object.Side_;
	}

	void Square::operator=(Square &&Object)
	{
		Side_ = Object.Side_;
	}

	float Square::GetWidth()
	{
		return Side_;
	}

	void Square::Set(float Side)
	{
		if (!CanSet(Side))
			throw std::runtime_error("Invalid side value!");
		
		this->Side_ = Side;
	}

	float Square::GetArea()
	{
		return GetWidth() * GetWidth();
	}

	float Square::GetPerimeter()
	{
		return 2 * (GetWidth() + GetWidth());
	}

	string Square::ToString()
	{
		stringstream strout;

		strout << GetWidth();
		strout << " x ";
		strout << GetWidth();

		return strout.str();
	}

	bool Square::CanSet(float value)
	{
		if (value < 0)
			return false;
		return true;
	}

	Square::~Square()
	{
		cout << "Square destroyed!" << endl;
	}
}