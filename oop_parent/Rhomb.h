#ifndef RHOMB_H
#define RHOMB_H

#include <string>
#include "Square.h"

namespace Lab
{
	class Rhomb : public Square{
	public:
		/*	Constructor */
		Rhomb(float Side, float Angle);
		/*	Constructor */
		Rhomb();
		/*	Destructor */
		~Rhomb();
		
		/*	Sets a new angle */
		void SetAngle(float Angle);
		/*	Sets a new side and angle */
		void Set(float Side, float Angle);
		/*	Returns the angle value */
		float GetAngle();
		/*	Returns the side value */
		float GetSide();

		/*	Calculates the area of a shape */
		float GetArea();
		/*	Returns the size of a shape as string value */
		string ToString();

	protected:
		// Rhombus' angle
		float cAngle_;
		/*	Checks if a new angle value can be defined */
		bool CanSetAngle(float degrees);
		/* Protected constructor */
		//Rhomb(float newAngle);
	};
}
#endif // RHOMB_H