#ifndef ARRAY_H
#define ARRAY_H

#include <iostream>
#include <iomanip>
#include <string>
#include <vector>

/*
This class describes a 2x2 math matrix.
It includes:
	1. Basic math operations, such as
	   addition, subtraction, multiplication of matrices

	2. Finding the determinant;

	3. Transpose, find the inverse matrix, create a diagonal,
	   fill with one specific or random value;

	4. Output matrix as string value.

	Gauss elimination and Gauss-Jordan method were used to
	calculate the determinant and inverse matrix, respectively.
*/

using namespace std;
using UserMethod = double(*)(double, double);	// Placeholder for lambda

namespace lab {

	// Basic types for Matrix class
	typedef vector<double> array_t;
	typedef vector<vector<double>> matr_t;
	
	class Matrix {
	private:
		matr_t core_;	// The Matrix
		
	private:
		/*	Gauss elimination */
		matr_t gauss();
		
		/*	Checks if two matrices can be multiplied */
		static bool canMultiply(const Matrix &First, const Matrix &Second);
		
		/*	Checks if two matrices are the same size */
		static bool isSameSize(const Matrix &First, const Matrix &Second);
		
		/*	Performs operations on the elements of two matrices */
		void makeMath(Matrix &Result, const Matrix &Object, UserMethod function);

	public:
		/*	Constructor */
		Matrix() { core_ = matr_t(2, array_t(2, 0)); }
		/*	Constructor */
		Matrix(size_t rows, size_t cols) { core_ = matr_t(rows, array_t(cols, 0)); }
		/*	Constructor */
		Matrix(matr_t &Name) { core_ = Name; }
		
		/*	Gets the number of rows in the matrix */
		size_t rows() const { return core_.size(); }
		/*	Gets the number of elements in the row */
		size_t cols(size_t index = 0) const { return core_[index].size(); }

		/*	Access to a single element in the matrix */
		double get(size_t row, size_t col) const { return core_[row][col]; }
		/*	Access to a single row in the matrix */
		array_t get(size_t row) const { return core_[row]; }
		
		/*	Math operations */
		Matrix operator+ (const Matrix &Object);
		Matrix operator- (const Matrix &Object);
		Matrix operator* (const Matrix &Object);
		Matrix operator* (double value);

		/*	Math operations */
		void operator+= (const Matrix &Object);
		void operator-= (const Matrix &Object);
		void operator*= (const Matrix &Object);
		void operator*= (double value);

		/*	Calculates the determinant */
		double det();
		/*	Transposes the matrix */
		void transpose();
		/*	Fills a matrix with one value */
		void fill(double value = 0);
		/*	Fills a matrix with a random value */
		void random(double min = -100.00, double max = 100.00);
		/*	Makes the matrix diagonal */
		void diag();
		/*	Makes the inverse matrix */
		void inverse();

		/*	Output as string */
		string str(unsigned short width = 6, unsigned short pointPos = 1) const;
		/*	Output as string */
		string str(array_t List, unsigned short width = 6, unsigned short pointPos = 1) const;
	};
}

#endif // !ARRAY_H

