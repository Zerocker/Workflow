/*
	THE INCREDIBLY CRAFTED FILE HEADER
	GAUSS HEADER
*/
#ifndef GAUSS_H
#define GAUSS_H

#include <iostream>
#include "Vector2D.h"

using namespace std;

cVector mathGauss(cMatrix Arr, cVector Brr);
cVector mathResidual(cMatrix Arr, cVector Brr, cVector Rrr);
unsigned compareResidualValues(cVector Err, float value);
void printLinSys(cMatrix Arr, cVector Brr, int after_point = 1);

#endif // GAUSS_H
