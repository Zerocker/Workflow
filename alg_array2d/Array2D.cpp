#include "Array2D.h"

// Ф-ция для заполнения массива случайными числами
void fillArray(i32** Array, u32 Size)
{
	for (u32 i = 0; i < Size; i++)
	{
		for (u32 j = 0; j < Size; j++)
		{
			Array[i][j] = I32_MIN + 
				(rand() % static_cast<i32>(I32_MAX - I32_MIN + 1));
		}
	}
}

// Ф-ция для вывода массива в виде строки
string toString(i32** Array, u32 Size)
{
	stringstream strout;
	
	for (u32 i = 0; i < Size; i++)
	{
		for (u32 j = 0; j < Size; j++)
		{
			strout << setw(5);
			strout << Array[i][j];
		}
		strout << endl;
	}
	return strout.str();
}

/* Ф-ция для нахождения максимума среди сумм эл-тов диагоналей, параллельных главной диагонали матрицы. */
i32 findMaxSum(i32 ** Array, u32 Size)
{
	// Максимальная сумма диагоналей 
	i32 maxSum = -INT32_MAX;

	// (i - смещение по диагонали)
	for (u32 i = 1; i < Size; i++)
	{
		// Сумма эл-тов диагонали, ниже главной
		i32 underSum = 0;	
		// Сумма эл-тов диагонали, выше главной
		i32 aboveSum = 0;

		// Походимся по индексам диагоналей
		/*
			j   k+i------->
			|	a   [a]	  a
			|	a	 a	 [a]
			∨	a	 a    a

			j+i  k-------->
			 |	 a   a	 a
			 |	[a]	 a	 a
			 ∨	 a	[a]  a

		*/
		for (u32 j = 0, k = j; j < Size - i; j++, k++)
		{
			// Добавляем в сумму эл-ты нижней диагонали
			underSum += Array[j + i][k];
			// Добавляем в сумму эл-ты верхней диагонали
			aboveSum += Array[j][k + i];
		}

		// Сравниваем значение макс. суммы со значениями сумм двух диагоналей
		maxSum = (maxSum < underSum) ? underSum : maxSum;
		maxSum = (maxSum < aboveSum) ? aboveSum : maxSum;
	}
	// Возвращаем макс. сумму
	return maxSum;
}

/* 	Ф-ция для нахождения произведения эл-тов в тех строках, которые не содержат отрицательных элементов. */
i32 multUnsigned(i32 ** Array, u32 Size)
{
	// Рез-т умножения
	i32 Result = 1;
	// Кол-во положительных строк
	u32 count = 0;

	// Ф-ция для проверки,
	// cодержатся ли в строке массива отриц. эл-ты
	auto hasSigned = [&Size](i32 * List)
	{
		// Проходимя по эл-там строки
		for (u32 i = 0; i < Size; i++)
			// Если хотя бы один эл-т отрицательный
			if (List[i] < 0) return true;
		return false;
	};

	/***/
	for (u32 i = 0; i < Size; i++)
	{
		// Проверяем, является ли строка положительной
		if (!hasSigned(Array[i]))
		{
			/***/
			for (u32 j = 0; j < Size; j++)
			{
				// Перемножаем эл-т на рез-т
				Result *= Array[i][j];
			}
			// Увеличиваем кол-во положительных строк
			count++;
		}
	}
	
	// Если в массиве нет полож. строк...
	if (count == 0)
		// . . . то возвращаем ноль
		return 0;
	// Возвращаем рез-т умножения
	return Result;
}