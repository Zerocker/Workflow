#ifndef PARALLEL_H
#define PARALLEL_H

#include <string>
#include "Rhomb.h"

namespace Lab
{
	class Parallel : public Rhomb
	{
	public:
		/*	Constructor */
		Parallel(float fstSide, float sndSide, float Angle);
		/*	Constructor */
		Parallel();
		/*	Destructor */
		~Parallel();

		/*	Returns the second side value */
		float GetSecondSide();
		/*	Calculates the area of a shape */
		float GetArea();
		/*	Calculates the perimeter of a shape */
		float GetPerimeter();
		/*	Returns the size of a shape as string value */
		string ToString();

		/*	Sets a new sides and new angle */
		void Set(float fstSide = 0, float sndSide = 0, float Angle = 0);

	private:
		// Parallel's second side
		float pSide_;
	};
}
#endif // PARALLEL_H