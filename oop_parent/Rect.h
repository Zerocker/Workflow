#ifndef RECT_H
#define RECT_H

#include <string>
#include "Square.h"

namespace Lab
{
	class Rect : public Square{
	public:
		/*	Constructor */
		Rect(float fstSide, float sndSide);
		/*	Constructor */
		Rect();
		/*	Destructor */
		~Rect();

		/*	Sets a two new sides */
		void Set(float fstSide, float sndSide);
		/*	Returns the side value (as height) */
		float GetHeight();
	
		/*	Calculates the area of a shape */
		float GetArea();
		/*	Calculates the perimeter of a shape */
		float GetPerimeter();
		/*	Returns the size of a shape as string value */
		string ToString();

	protected:
		// Rect's second side
		float cSide_;
		/* Protected constructor */
		//Rect(float newSide);
	};

}
#endif // RECT_H
