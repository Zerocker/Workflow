#ifndef FUN_H
#define FUN_H

#include <iostream>
#include <fstream>
#include <string>
#include <vector>

namespace Fun {
	
	using namespace std;

	typedef vector<vector<float>> array2d;
	typedef vector<float> array1d;

	array1d createVector(int number);

	array2d createMatrix(int row, int col);

	void array2file(const array2d &Arr, const string &fileName, unsigned short point = 2);
	array2d file2array(const string &fileName);

	void array2bin(const array2d &Arr, const string &fileName);
	array2d bin2array(const string &fileName);

	void printMass(array2d array, int width = 8, int after_point = 2);
}

#endif // FUN_H
