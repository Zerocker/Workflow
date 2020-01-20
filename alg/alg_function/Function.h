#pragma once
#include "Types.h"

float Function(float A, float B, float C, float X)
{
	float Result;

	if ((C < 0) && (X != 0.0))
	{
		Result = (-A * X - C);
	}
	else if ((C > 0) && (X == 0.0))
	{
		Result = (X - A) / (C * (-1));
	}
	else
	{
		Result = (B * X) / (C - A);
	}

	return Result;
}