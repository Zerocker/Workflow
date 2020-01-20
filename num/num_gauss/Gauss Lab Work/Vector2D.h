/* 
	THE INCREDIBLY CRAFTED FILE HEADER
	VECTOR2D HEADER 
*/
#ifndef VECTOR2D_H
#define VECTOR2D_H

#include <iostream>
#include <vector>

using namespace std;
typedef vector<float> cVector;
typedef vector<vector<float> > cMatrix;

cVector createRandomVector(unsigned number);
cMatrix createRandomMatrix(unsigned row, unsigned col);

void printArray(cVector Arr, int after_point = 2);
void printArray(cMatrix Arr, int after_point = 2);

#endif // VECTOR2D_H
