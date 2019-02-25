#include <iostream>
#include <fstream>
#include "Array.h"

using namespace std;

// Размер статического массива
constexpr u32 staticSize = UINT16_MAX;
// Размер динамического массива
static u32 Size;

int main()
{
	setlocale(LC_ALL, "Rus");
	srand(static_cast <u32> (time(NULL)));
	ofstream file("array.txt", ios::trunc);
	
	// Размер для массивов
	cout << "Введите кол-во эл-тов для двух массивов: ";
	cin >> Size;

	/***/
	file << fixed << setprecision(3);
	file << "Размер двух массивов: " << Size << endl;
	
	// Создание массивов
	float sArray[staticSize];
	float *dArray = new float[Size];
	
	// Заполнение массивов
	fillArray(sArray, Size);
	fillArray(dArray, Size);

	/***/
	file << "Статический массив: \n";
	outputArray(sArray, Size, file);
	file << "Динамический массив: \n";
	outputArray(dArray, Size, file);

	/***/
	file << "\n * Сумма элементов массива с нечетными номерами * \n";
	file << "Для статического: " << findOddSum(sArray, Size) << endl;
	file << "Для динамического: " << findOddSum(dArray, Size) << endl;
	
	/***/
	file << "\n * Сумма элементов массива, расположенных между первым и последним отрицательными элементами * \n";
	file << "Для статического: " << findNegSum(sArray, Size) << endl;
	file << "Для динамического: " << findNegSum(dArray, Size) << endl;

	// Сжатие массивов
	squeezeArray(sArray, Size);
	squeezeArray(dArray, Size);

	/***/
	file << "\n * Сжатие массивов * \n";
	file << "Статический массив: \n";
	outputArray(sArray, Size, file);
	file << "Динамический массив: \n";
	outputArray(dArray, Size, file);

	// Завершение программы
	file.close();
	cout << "Результат сохранен в файле array.txt . . . " << endl;
	system("pause");
}
