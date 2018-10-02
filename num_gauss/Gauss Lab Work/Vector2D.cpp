/*
	THE INCREDIBLY CRAFTED FILE HEADER
	VECTOR2D SOURCE
*/
#include <iostream>
#include <iomanip>
#include <ctime>
#include <vector>
#include "vector2d.h"


using namespace std;
const int maxNum = 100.0;


/* Создание простого вектора */
cVector createRandomVector(unsigned number) {
	cVector Arr(number);
	for (size_t i = 0; i < number; i++) {
		Arr[i] = (float)rand() / (float)(maxNum);
	}
	return Arr;
}

/* Создание двойного вектора */
cMatrix createRandomMatrix(unsigned row, unsigned col) {
	cMatrix Arr(row);
	srand(time(0));
	for (size_t i = 0; i < row; i++) {
		Arr[i] = createRandomVector(col);
	}
	return Arr;
}

/* Вывод простого вектора на экран */
void printArray(cVector Arr, int after_point) {
	cout << fixed << setprecision(after_point);
	for (auto x : Arr) {
		cout << setw(10) << x;
	}
	cout << "\n";
}

/* Вывод двойного вектора на экран */
void printArray(cMatrix Arr, int after_point) {
	cout << fixed << setprecision(after_point);
	for (auto x : Arr) {
		for (auto y : x) {
			cout << setw(10) << y;
		}
		cout << endl;
	}
	cout << "\n";
}
