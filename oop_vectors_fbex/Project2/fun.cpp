#include <iostream>

#include <fstream>
#include <string>
#include <sstream>

#include <iomanip>
#include <ctime>
#include <vector>
#include "fun.h"
#include "error.h"


namespace Fun {

	using namespace std;
	const int maxNum = 400.0;
	
	/* Описание ошибок */
	errorHandler FILE_IS_NOT_EXISTS = { 1, "This file can't be opened, 'cause it's not exists" };
	errorHandler IS_BINARY_FILE = { 2, "This file can't be opened, 'cause it's not binary file" };

	/* Создание вектора*/
	array1d createVector(int number) {
		array1d list(number);
		for (size_t i = 0; i < number; i++) {
			list[i] = (float)rand() / (float)(RAND_MAX / maxNum);
		}
		return list;
	}

	/* Создание двойного вектора*/
	array2d createMatrix(int row, int col) {
		array2d list(row);
		srand(time(0));
		for (size_t i = 0; i < row; i++) {
			list[i] = createVector(col);
		}
		return list;
	}

	void array2file(const array2d &Arr, const string &fileName, unsigned short point) {
		ofstream File(fileName);

		if (File.is_open()) {
			File << fixed << setprecision(point);
			
			for (size_t i = 0; i < Arr.size(); i++) {
				for (size_t j = 0; j < Arr[i].size(); j++) {
					//File << setw(8);
					File << Arr[i][j];
					if (j != Arr[i].size() - 1)
						File << ',';
				}
				if (i != Arr.size() - 1)
					File << endl;
			}
		}
		File.close();
	}

	array2d file2array(const string &fileName) {
		array2d Result;
		ifstream File(fileName);
		string Line;

		while (!File.eof()) {
			array1d tempArr;
			string tempStr;
			
			File >> Line;
			istringstream ss(Line);
			
			while (getline(ss, tempStr, ','))
				tempArr.push_back(stof(tempStr));
			Result.push_back(tempArr);

		}
		return Result;
	}

	void array2bin(const array2d &Arr, const string &fileName) {
		ofstream File(fileName, ios::binary);

		if (File.is_open()) {

			unsigned short Rows = Arr.size();
			unsigned short Cols = Arr[0].size();

			/* Размеры матрицы */
			File.write((char*)&Rows, sizeof(Rows));		// Первые 4 байта
			File.write((char*)&Cols, sizeof(Cols));		// Вторые 4 байта

			for (size_t i = 0; i < Arr.size(); i++) {
				for (size_t j = 0; j < Arr[i].size(); j++) {
					File.write((char*)&Arr[i][j], sizeof(Arr[i][j]));
				}
			}
		}
		File.close();
	}

	array2d bin2array(const string &fileName) {
		array2d Result;
		ifstream File(fileName, ios::binary);
		
		if (!File.is_open())
		{
			throw FILE_IS_NOT_EXISTS;
		}
		
		/* Размеры матрицы */
		unsigned short Rows, Cols;
		File.read((char*)&Rows, sizeof(Rows));		// Первые 4 байта
		File.read((char*)&Cols, sizeof(Cols));		// Вторые 4 байта


		for (size_t i = 0; i < Rows; i++) {
			array1d Vector;
			for (size_t j = 0; j < Cols; j++) {
				float Temp;
				File.read((char*)&Temp, sizeof(Temp));
				Vector.push_back(Temp);
			}
			Result.push_back(Vector);
		}
		return Result;
	}
	
	/* Вывод двойного вектора на экран*/
	void printMass(array2d array, int width, int after_point) {
		cout << fixed << setprecision(after_point);
		for (auto x : array) {
			for (auto y : x) {
				cout << setw(width) << y;
			}
			cout << endl;
		}
	}
}