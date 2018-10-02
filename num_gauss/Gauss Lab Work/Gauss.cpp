/*
	GAUSS SOURCE
*/
#include <iostream>
#include <iomanip>
#include <cmath>
#include "Gauss.h"
#include "Vector2D.h"

cVector mathGauss(cMatrix Arr, cVector Brr) {
	/* ��� ������������� ��������� �� ����*/

	const float epsValue = 0.001;
	size_t Size = Arr.size();

	/* ���������� ������� �������� � ���� */
	auto column = Brr.begin();
	for (auto &row : Arr) {
		row.push_back(*column++);
	}

	/* --------------> ������ ��� ������ ������ <-------------- */

	for (size_t i = 0; i < Size; i++) {
		float maxItem = fabs(Arr[i][i]);
		size_t maxIndex = i;

		/* ����� �������� �������� ������� */
		for (size_t k = i + 1; k < Size; k++) {
			if (fabs(Arr[k][i]) > maxItem) {
				maxItem = fabs(Arr[k][i]);
				maxIndex = k;
			}
		}

		if (maxItem < epsValue) {
			cout << "Error!" << endl;
			return {0};
		}

		/* ������������ ���������*/
		for (size_t k = i; k < Size + 1; k++) {
			std::swap(Arr[maxIndex][k], Arr[i][k]);
			
			/*float Temp = Arr[maxIndex][k];
			Arr[maxIndex][k] = Arr[i][k];
			Arr[i][k] = Temp;*/
		}

		/* ���������� � ������������ ���� */
		for (size_t k = i + 1; k < Size; k++) {
			float Temp = -Arr[k][i] / Arr[i][i];
			for (size_t j = i; j < Size + 1; j++) {
				if (i == j) {
					Arr[k][j] = 0;
				}
				else {
					Arr[k][j] += Temp * Arr[i][j];
				}
			}
		}
	}
	
	/* ����� ������� */
	cVector Rrr(Size);
	for (int i = Size - 1; i >= 0; i--) {
		Rrr[i] = Arr[i][Size] / Arr[i][i];

		for (int k = i - 1; k >= 0; k--) {
			Arr[k][Size] -= Arr[k][i] * Rrr[i];
		}
	}
	return Rrr;
}

/* ������������ ������ ������� */
cVector mathResidual(cMatrix Arr, cVector Brr, cVector Rrr) {
	size_t Size = Arr.size();
	cVector Err(Size);

	for (size_t i = 0; i < Size; i++) {
		float Temp = 0.0;
		for (size_t j = 0; j < Size; j++) {
			Temp += Arr[i][j] * Rrr[j];
		}
		Err[i] = Brr[i] - Temp;
	}
	return Err;
}

/* ���������� �������� ������� ������� � �������� */
unsigned compareResidualValues(cVector Err, float value) {
	size_t count = 0;
	size_t Size = Err.size();
	for (size_t i = 0; i < Size; i++) {
		if (fabs(Err[i]) < value) {
			count++;
		}
	}
	if (count == Size)
		return 1;
	else
		return 0;
}

/*	����� ������� ���������, ������� �� ����� ����
	������� ������, ������� � ���� ������� �������
	�� ������� ��������, �� ����� */
void printLinSys(cMatrix Arr, cVector Brr, int after_point) {

	cout << fixed << setprecision(after_point);

	for (size_t i = 0; i < Arr.size(); i++) {
		for (size_t j = 0; j < Arr.size(); j++) {

			cout << setw(10) << Arr[i][j] ;
			if (j == Arr.size() - 1) {
				cout << setw(5) << "|";
			}
		}
		cout << setw(10) << Brr[i] << endl;
	}
}