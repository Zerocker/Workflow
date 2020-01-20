#include <iostream>
#include "Array.h"

using namespace std;

int main()
{
	//ssetlocale(LC_ALL, "UTF-8");

	const size_t unitSize = 3;
	cMatrix Default = 
				{{1, 0, 0, -2, 9},
				{0, 1, 0, 1, -3},
				{0, 0, 1, 2, 3},
				{-1, -5, -7, 8, 6},
				{-1, -8, 8, -9, 1}};

	/* Создаем блочные матрицы */
	cMatrix M = split(Default, unitSize, 1);
	cMatrix N = split(Default, unitSize, 2);
	cMatrix P = split(Default, unitSize, 3);
	cMatrix Q = split(Default, unitSize, 4);

	/* Вычисляем обратные блочные матрицы */
	cMatrix X = makeX(M, N, P, Q);
	cMatrix V = makeV(M, N, P, Q);
	cMatrix U = makeU(V, P, M);
	cMatrix Y = makeY(X, N, Q);

	/* Полученные матрицы соединяем вместе */
	cMatrix Result = merge(X, Y, U, V);
	
	cout << "Default matrix:" << endl;
	print(Default);
	cout << endl << "Inverse matrix:" << endl;
	print(Result);
	system("pause");
}