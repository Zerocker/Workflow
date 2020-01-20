#ifndef SQUARE_H
#define SQUARE_H

#include <string>

namespace Lab 
{
	using namespace std;
	
	class Square {
	public:
		/*	Constructor */
		Square(float Side);
		/*	Default constructor */
		Square();
		/*	Copy constructor */
		Square(const Square &Object);
		void operator=(const Square &Object);
		/*	Move constructor */
		Square(Square &&Object);
		void operator=(Square &&Object);
		/*	Destructor */
		~Square();

		/*	Sets a new side */
		void Set(float Side);
		/*	Returns the side value (as width) */
		float GetWidth();

		/*	Calculates the area of a shape */
		float GetArea();
		/*	Calculates the perimeter of a shape */
		float GetPerimeter();
		/*	Returns the size of a shape as string value */
		string ToString();

	protected:
		// Square's side
		float Side_;	
		/*	Checks if a new side value can be defined */
		static bool CanSet(float value);
	};
}

#endif // RECT_H