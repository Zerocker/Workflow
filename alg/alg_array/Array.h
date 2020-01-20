#pragma once
#include <iostream>
#include <iomanip>
#include <cmath>
#include <sstream>
#include <string>
#include "Types.h"

using namespace std;

constexpr float USR_MIN = -9.9F;
constexpr float USR_MAX = 9.9F;

// Заполнение массива случайными числами
void fillArray(float *Array, u32 &Size)
{
	// Перебираем массив
	for (size_t i = 0; i < Size; i++)
	{
		// Присваиваем эл-ту массива случаное число
		Array[i] = USR_MIN + static_cast <float> (rand()) 
			/ (static_cast <float> (RAND_MAX / (USR_MAX - USR_MIN)));
	}
}

// Вывод массива в файл
void outputArray(float *Array, u32 &Size, ofstream& File)
{
	for (size_t i = 0; i < Size; i++)
	{
		File << "| ";
		File << setw(7);
		File << fixed << setprecision(3);
		File << Array[i] << " ";
	}
	File << "|\n";
}

// Нахождение суммы элементов массива с нечетными номерами
float findOddSum(float *Array, u32 &Size)
{
	float Result = 0;	// Сумма эл-тов с нечетными номерами

	// Перебиваем массив
	for (size_t i = 0; i < Size; i++)
	{
		// Если индекс - нечетный
		if (i % 2 != 0)
			// Складываем эл-т к сумме
			Result += Array[i];
	}
	
	return Result;
}

// Нахождение суммы элементов массива, расположенных между первым и последним отрицательными элементами
float findNegSum(float *Array, u32 &Size)
{
	u32 first;			// Индекс первого отриц-ого эл-та
	u32 last;			// Индекс последнего отриц-ого эл-та
	float Result = 0;	// Сумма эл-тов
	
	// Перебираем эл-ты массива с начала
	for (first = 0; first < Size; first++)
	{
		// Находим индекс первого отриц-ого эл-та
		if (Array[first] < 0) break;
	}

	// Перебираем эл-ты массива с конца
	for (last = Size - 1; last > first; last--)
	{
		// Находим индекс последнего отриц-ого эл-та
		if (Array[last] < 0) break;
	}

	// Перебираем эл-ты между первым и последним отриц-ым эл-том
	for (size_t i = first + 1; i < last; i++)	
	{
		// Складываем эл-т к сумме
		Result += Array[i];
	}

	return Result;
}

// Сжатие массива путём удаления элементов, модуль которых не превышает 1.
void squeezeArray(float *Array, u32 &Size)
{
	// Итератор и кол-во удал. эл-тов
	size_t i = 0, j = i;

	// Перебираем массив
	for (; i < Size; i++)
	{
		// Если модуль >= 1
		if (fabs(Array[i]) >= 1)
			// То перемещаем эл-ты массива вправо
			Array[i - j] = Array[i];
		else
			// Или же увеличиваем кол-во удал. эл-тов
			j++;
	}

	// Перебираем массив c другим начальным индексем
	// (кол-во эл-тов массива - кол-во удал. эл-тов)
	for (i = Size - j; i < Size; i++)
		// Остатки в массиве обнуляем
		Array[i] = 0.0F;
}