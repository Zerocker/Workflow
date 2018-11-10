#include <iostream>
#include <sstream>
#include <string>
#include <math.h>
#include <ctime>
#include "Array.h"

using namespace std;

namespace lab {

	/* ------------------------------------------------------------------- */
	//	Private methods
	/* ------------------------------------------------------------------- */

	matr_t Matrix::gauss() {
		matr_t Arr = core_;

		size_t Size = Arr.size();
		for (size_t i = 0; i < Size; i++) {
			double maxItem = fabs(Arr[i][i]);
			size_t maxIndex = i;

			/*	Find max element and its index */
			for (size_t k = i; k < Size; k++) {
				if (fabs(Arr[k][i]) > maxItem) {
					maxItem = fabs(Arr[k][i]);
					maxIndex = k;
				}
			}

			/*	Swap rows */
			for (size_t k = i; k < Size; k++) {
				swap(Arr[maxIndex][k], Arr[i][k]);
			}

			/* To triangular matrix */
			for (size_t k = i + 1; k < Size; k++) {
				double Temp = -Arr[k][i] / Arr[i][i];
				for (size_t j = i; j < Size; j++) {
					if (i == j) {
						Arr[k][j] = 0;
					}
					else {
						Arr[k][j] += Temp * Arr[i][j];
					}
				}
			}
		}
		return Arr;
	}

	bool Matrix::canMultiply(const Matrix &First, const Matrix &Second) {
		size_t fstCols = First.cols();
		size_t sndRows = Second.rows();

		if (fstCols != sndRows)
			return false;
		return true;
	}

	bool Matrix::isSameSize(const Matrix &First, const Matrix &Second) {
		size_t fstRows = First.rows();
		size_t fstCols = First.cols();
		size_t sndRows = Second.rows();
		size_t sndCols = Second.cols();

		if ((fstRows != sndRows) || (fstCols != sndCols))
			return false;
		return true;
	}

	void Matrix::makeMath(Matrix &Result, const Matrix &Object, UserMethod function)
	{
		for (size_t i = 0; i < this->rows(); ++i) {
			for (size_t j = 0; j < this->cols(i); ++j)
			{
				double Addend1 = this->get(i, j);
				double Addend2 = Object.get(i, j);
				Result.core_[i][j] = function(Addend1, Addend2);
			}
		}
	}

	/* ------------------------------------------------------------------- */
	//	Public methods
	/* ------------------------------------------------------------------- */

	/*	Operators (this)	************************************************/

	void Matrix::operator+= (const Matrix &Object) {
		if (!isSameSize(*this, Object))
			throw runtime_error("* Invalid sizes! *");

		auto Add = [](double addend1, double addend2)->double {
			return addend1 + addend2;
		};
		makeMath(*this, Object, Add);
		
		/*for (size_t i = 0; i < this->rows(); ++i) {
			for (size_t j = 0; j < this->cols(i); ++j)
			{
				double Addend1 = this->get(i, j);
				double Addend2 = Object.get(i, j);
				this->core_[i][j] = Addend1 + Addend2;
			}
		}*/
	}

	void Matrix::operator-= (const Matrix &Object) {
		if (!isSameSize(*this, Object))
			throw runtime_error("* Invalid sizes! *");

		auto Sub = [](double addend1, double addend2)->double {
			return addend1 - addend2;
		};
		
		makeMath(*this, Object, Sub);
	}

	void Matrix::operator*= (const Matrix &Object) {
		if (!canMultiply(*this, Object))
			throw runtime_error("* Invalid sizes! *");
		
		Matrix Result(this->rows(), Object.cols());

		for (size_t i = 0; i < this->rows(); i++) {
			for (size_t j = 0; j < Object.cols(); j++) {
				for (size_t k = 0; k < Object.rows(); k++)
				{
					Result.core_[i][j] += this->get(i, k) * Object.get(k, j);
				}
			}
		}

		this->core_ = Result.core_;
	}

	void Matrix::operator*= (double value) {
		for (size_t i = 0; i < this->rows(); ++i) {
			for (size_t j = 0; j < this->cols(i); ++j)
			{
				this->core_[i][j] *= 2;
			}
		}
	}

	/*	Operators (objects)	************************************************/

	Matrix Matrix::operator+ (const Matrix &Object) {
		Matrix New(Object.rows(), Object.cols());

		auto Add = [](double addend1, double addend2)->double {
			return addend1 + addend2;
		};
		makeMath(New, Object, Add);
		
		return New;
	}

	Matrix Matrix::operator- (const Matrix &Object) {
		Matrix New(Object.rows(), Object.cols());

		auto Sub = [](double addend1, double addend2)->double {
			return addend1 + addend2;
		};
		makeMath(New, Object, Sub);

		return New;
	}

	Matrix Matrix::operator* (const Matrix &Object) {
		if (!canMultiply(*this, Object))
			throw runtime_error("* Invalid sizes! *");
		
		Matrix Result(this->rows(), Object.cols());

		for (size_t i = 0; i < this->rows(); i++) {
			for (size_t j = 0; j < Object.cols(); j++) {
				for (size_t k = 0; k < Object.rows(); k++)
				{
					Result.core_[i][j] += this->get(i, k) * Object.get(k, j);
				}
			}
		}
		return Result;
	}

	Matrix Matrix::operator* (double value) {
		Matrix New(this->rows(), this->cols());

		for (size_t i = 0; i < this->rows(); ++i) {
			for (size_t j = 0; j < this->cols(i); ++j)
			{
				double newItem = this->get(i, j);
				New.core_[i][j] = newItem * value;
			}
		}
		return New;
	}

	/*	Basic methods	************************************************/

	double Matrix::det() {
		matr_t Temp = gauss();
		double result = 1;
		
		for (size_t i = 0; i < rows(); ++i) {
			result *= Temp[i][i];
		}

		return round(result);
	}

	void Matrix::transpose() {
		matr_t temp_(cols(), array_t(rows()));

		for (size_t i = 0; i < rows(); i++) {
			for (size_t j = 0; j < cols(); j++)
			{
				temp_[j][i] = core_[i][j];
			}
		}
		core_ = temp_;
	}

	void Matrix::fill(double value) {
		for (auto &row : core_) {
			for (auto &item : row) {
				item = value;
			}
		}
	}

	void Matrix::random(double min, double max) {
		srand(time(NULL));

		for (auto &row : core_) {
			for (auto &item : row) {
				item = min + ((double)rand()) / max;
			}
		}
	}

	void Matrix::diag() {
		for (size_t i = 0; i < rows(); ++i) {
			for (size_t j = 0; j < cols(i); ++j)
			{
				if (i != j)
					core_[i][j] = 0;
			}
		}
	}

	void Matrix::inverse() {
		/*	Personal frankenstein */
		
		/* Trick or treat */
		if (this->det() == 0)
			throw runtime_error("* Inverse matrix doesn't exists! *");

		size_t oldSize = rows();
		size_t newSize = rows() * 2;

		/* Let's make the matrix like a monster. */
		core_.resize(newSize);
		for (auto &item : core_) {
			item.resize(newSize);
		}
		for (size_t i = 0; i < oldSize; i++) {
			core_[i][i + oldSize] = 1.0;
		}
		
		/*	Swap rows for augmented matrix */
		for (int i = (oldSize - 1); i > 0; --i) {
			if (core_[i - 1][0] < core_[i][0]) {
				for (size_t j = 0; j < newSize; ++j) {
					swap(core_[i][j], core_[i - 1][j]);
				}
			}
		}

		/*	Do the math! */
		for (size_t i = 0; i < oldSize; i++) {
			for (size_t j = 0; j < newSize; j++) {
				if (j != i)
				{
					double Temp = core_[j][i] / core_[i][i];
					for (size_t k = 0; k < newSize; k++) 
					{
						core_[j][k] -= core_[i][k] * Temp;
					}
				}
			}
		}

		/*	Almost done... */
		for (size_t i = 0; i < oldSize; i++) {
			double Temp = core_[i][i];
			for (size_t j = 0; j < newSize; j++) {
				core_[i][j] = core_[i][j] / Temp;
			}
		}

		/*	Remove unnecessary rows */
		for (size_t i = newSize - 1; i > oldSize - 1; --i) {
			core_.erase(core_.begin() + i);
		}
		
		/*	Remove unnecessary cols */
		for (size_t i = 0; i < oldSize; ++i) {
			for (size_t j = 0; j < oldSize; ++j)
			{
				core_[i].erase(core_[i].begin() + 0);
			}
		}
	}

	/*	Output	************************************************/

	string Matrix::str(unsigned short width, unsigned short pointPos) const {
		stringstream strout;
		
		for (size_t i = 0; i < rows(); ++i) {
			for (size_t j = 0; j < cols(i); ++j)
			{
				strout << fixed << setprecision(pointPos);
				strout << setw(width);
				strout << core_[i][j];
			}
			strout << endl;
		}
		return strout.str();
	}

	string Matrix::str(array_t List, unsigned short width, unsigned short pointPos) const {
		stringstream strout;
		
		for (auto &item: List)
		{
				strout << fixed << setprecision(pointPos);
				strout << setw(width);
				strout << item;
		}
		strout << endl;
		return strout.str();
	}
}