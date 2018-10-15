#include <iostream>
#include <iomanip>
#include <vector>
#include <cmath>
#include "Array.h"

using namespace std;

/*	Функция для создания блоков из матрицы */
cMatrix split(const cMatrix &Arr, size_t eSize, const unsigned short key) {
	size_t defSize = Arr.size();
	size_t gapSize = defSize - eSize;

	cMatrix Mrr(eSize, cArray(eSize, 0.0));
	cMatrix Nrr(eSize, cArray(gapSize, 0.0));
	cMatrix Prr(gapSize, cArray(eSize, 0.0));
	cMatrix Qrr(gapSize, cArray(gapSize, 0.0));
	
	for (size_t i = 0; i < defSize; i++) {
		for (size_t j = 0; j < defSize; j++) {
			
			if ((i < eSize) && (j < eSize))
				Mrr[i][j] = Arr[i][j];

			else if ((i < eSize) && (eSize <= j < defSize))
				Nrr[i][j - eSize] = Arr[i][j];

			else if ((eSize <= i < defSize) && (j < eSize))
				Prr[i - eSize][j] = Arr[i][j];

			else if ((eSize <= i < defSize) && (eSize <= j < defSize))
				Qrr[i - eSize][j - eSize] = Arr[i][j];

		}
	}

	switch (key) {
	case 1:
		return Mrr;
	case 2:
		return Nrr;
	case 3:
		return Prr;
	case 4:
		return Qrr;
	default:
		cout << "Wrong key value!";
		break;
	}
}

/*	Функция для cоединения 4 матриц в одну матрицу */
cMatrix merge(const cMatrix &X, const cMatrix &Y, const cMatrix &U, const cMatrix &V) {
	
	/* Иниц-я работает, если только финальная обратная матрица квадратная!*/
	size_t eSize = X.size();
	size_t gapSize = U.size();
	size_t finalSize = eSize + gapSize;
	cMatrix Rrr(finalSize, cArray(finalSize, 0.0));

	for (size_t i = 0; i < finalSize; i++) {
		for (size_t j = 0; j < finalSize; j++) {
			
			if ((i < eSize) && (j < eSize))
				Rrr[i][j] = X[i][j];

			else if ((i < eSize) && (eSize <= j < finalSize))
				Rrr[i][j] = Y[i][j - eSize];

			else if ((eSize <= i < finalSize) && (j < eSize))
				Rrr[i][j] = U[i - eSize][j];

			else if ((eSize <= i < finalSize) && (eSize <= j < finalSize))
				Rrr[i][j] = V[i - eSize][j - eSize];
		}
	}

	return Rrr;
}

/*	Функция для сложения 2-х матриц одинаковой размерности */
cMatrix sub(const cMatrix &Arr, const cMatrix &Brr) {
	cMatrix Rrr(Arr.size(), cArray(Brr.size(), 0.0));
	
	for (size_t i = 0; i < Rrr.size(); i++) {
		for (size_t j = 0; j < Rrr[i].size(); j++) {
				Rrr[i][j] = Arr[i][j] - Brr[i][j];
		}
	}
	return Rrr;
}

/*	Функция для умножения матрицы на матрицу */
cMatrix mul(const cMatrix &Arr, const cMatrix &Brr) {
	size_t arrRows = Arr.size();
	size_t arrCols = Arr[0].size();
	size_t brrRows = Brr.size();
	size_t brrCols = Brr[0].size();
	cMatrix Result(arrRows, cArray(brrCols));
	
	/* Проверка размерностей матриц */
	if (arrCols != brrRows) {
		cout << "Error ID_01" << endl;
		return { {0} };
	}

	for (size_t i = 0; i < arrRows; i++) {
		for (size_t j = 0; j < brrCols; j++) {
			for (size_t k = 0; k < brrRows; k++) {
				Result[i][j] += Arr[i][k] * Brr[k][j];
			}
		}
	}
	return Result;
}

/*	Функция для создания обратной матрицы 3x3 и далее */
cMatrix inv3(cMatrix Arr) {
	/*	Метод Жордана-Гаусса	*/

	unsigned short oldSize = Arr.size();
	unsigned short newSize = Arr.size() << 1;
	cMatrix Rrr(oldSize, cArray(oldSize, 0.0));

	Arr.resize(newSize);
	for (size_t i = 0; i < Arr.size(); i++) {
		Arr[i].resize(newSize);
	}

	for (size_t i = 0; i < oldSize; i++) {
		for (size_t j = 0; j < newSize; j++) {
			if (j == (i + oldSize))
				Arr[i][j] = 1.0;
		}
	}

	for (size_t i = oldSize; i > 1; i--) {
		if (Arr[i - 1][1] < Arr[i][1]) {
			for (size_t j = 0; j < newSize; j++) {
				swap(Arr[i][j], Arr[i - 1][j]);
			}
		}
	}

	for (size_t i = 0; i < oldSize; i++) {
		for (size_t j = 0; j < newSize; j++) {
			if (j != i) {
				double Temp = Arr[j][i] / Arr[i][i];
				for (size_t k = 0; k < newSize; k++) {
					Arr[j][k] -= Arr[i][k] * Temp;
				}
			}
		}
	}

	for (size_t i = 0; i < oldSize; i++) {
		double Temp = Arr[i][i];
		for (size_t j = 0; j < newSize; j++) {
			Arr[i][j] = Arr[i][j] / Temp;
		}
	}

	for (size_t i = 0; i < oldSize; i++) {
		for (size_t j = oldSize; j < newSize; j++) {
			Rrr[i][j - oldSize] = Arr[i][j];
		}
	}

	return Rrr;
}

/*	Функция для создания обратной матрицы 2х2 */
cMatrix inv2(const cMatrix &Arr) {
	cMatrix Rrr(Arr.size(), cArray(Arr.size(), 0.0));
	double det = Arr[0][0] * Arr[1][1] - Arr[1][0] * Arr[0][1];

	Rrr[0][0] = Arr[1][1] / det;
	Rrr[0][1] -= Arr[0][1] / det;
	Rrr[1][0] -= Arr[1][0] / det;
	Rrr[1][1] = Arr[0][0] / det;

	return Rrr;
}

/*	Функция для создания блочной матрицы X */
cMatrix makeX(const cMatrix &M, const cMatrix &N, const cMatrix &P, const cMatrix &Q) {
	cMatrix Temp = sub(M, mul(N, mul(inv2(Q), P)));
	return inv3(Temp);
}

/*	Функция для создания блочной матрицы V */
cMatrix makeV(const cMatrix &M, const cMatrix &N, const cMatrix &P, const cMatrix &Q) {
	cMatrix Temp = sub(Q, mul(P, mul(inv3(M), N)));
	return inv2(Temp);
}

/*	Функция для создания блочной матрицы U */
cMatrix makeU(const cMatrix &V, const cMatrix &P, const cMatrix &M) {
	cMatrix Temp = mul(V, mul(P, inv3(M)));
	for (size_t i = 0; i < Temp.size(); i++) {
		for (size_t j = 0; j < Temp[i].size(); j++) {
			Temp[i][j] *= (-1.0);
		}
	}
	return Temp;
}

/*	Функция для создания блочной матрицы Y */
cMatrix makeY(const cMatrix &X, const cMatrix &N, const cMatrix &Q) {
	cMatrix Temp = mul(X, mul(N, inv3(Q)));
	for (size_t i = 0; i < Temp.size(); i++) {
		for (size_t j = 0; j < Temp[i].size(); j++) {
			Temp[i][j] *= (-1.0);
		}
	}
	return Temp;
}

/*	Функция для вывода вектора */
void print(const cArray &Arr) {
	cout << fixed << setprecision(2);
	for (auto &x : Arr) {
		cout << setw(7) << x;
	}
	cout << endl;
}
/*	Функция для вывода матрицы */
void print(const cMatrix &Mrr) {
	cout << fixed << setprecision(2);
	for (auto &x : Mrr) {
		for (auto &y : x) {
			cout << setw(7) << y;
		}
		cout << endl;
	}
}