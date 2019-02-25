#include <iostream>
#include "Array2D.h"

int main()
{
	setlocale(LC_ALL, "Rus");
	srand(static_cast <int> (time(NULL)));
	ofstream fout("array2D.txt", ios::trunc);
	
	// Задание размерности
	u32 Size;
	cout << "Введите размер для квадратной матрицы: ";
	cin >> Size;

	// Создание массива
	i32** dArray = new i32*[Size];
	for (u32 i = 0; i < Size; i++)
		dArray[i] = new i32[Size];
	// Заполнение массива
	fillArray(dArray, Size);
	
	fout << "Массив размерности " << Size << " :" << endl;
	fout << toString(dArray, Size);
	fout << "Перемножение строк с только положительными эл-тами: ";
	fout << multUnsigned(dArray, Size) << endl;
	fout << "Максимум сумм диагоналей: ";
	fout << findMaxSum(dArray, Size) << endl;

	fout.close();
	cout << "Готово. Результат вычислений находится в файле array2D.txt!" << endl;
	system("pause");
}