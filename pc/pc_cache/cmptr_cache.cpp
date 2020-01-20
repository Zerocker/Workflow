#include <cstdio>
#include <cstdint>
#include <ctime>
#include "cmptr_cache.h"

// Заполнение массива случайными числами
void fill(i32 *arr, u32 value)
{
	srand(time(NULL));
	for (u32 i = 0; i < value; i++)
	{
		arr[i] = rand() % 0xB0BA;
	}
}

int main()
{
	u32 lengthMod;			// Кол-во эл-тов
	clock_t tClock;			// Счётчик
	float cTime = 0;		// Время выполнения операции
	float oldTime = 0;		// Старое время выполнения

	// Массив для вычислений в кэше
	i32 *masterArray = new i32[SIZE / sizeof(i32)];
	
	// Кортеж для хранения значений кэша
	tuple cache;

	/***/
	printf("Finding the L1 (per core) and L2 cache . . .\n\n");
	printf(" | %8s | %8s | \n", "kB", "ms");
	printf(" -----------------------\n");
		   
	for (size_t i = 0; i < sizeof(sizes) / sizeof(u32); i++)
	{
		lengthMod = sizes[i] - 1;

		for (size_t j = 0; j < TIMES; j++)
		{
			// Точка отсчёта времени
			tClock = clock();

			for (size_t k = 0; k < REPS; k++)
			{
				masterArray[(k * 16) & lengthMod / sizeof(i32)]++;
			}

			// Вычисляем время выполнения в миллисекундах
			cTime = (float)(clock() - tClock);

			// Определяем один раз первое старое время выполнения
			if (oldTime == 0) oldTime = cTime;
		}
		/***/
		printf(" | %8d | %8.0f | \n", sizes[i] / 1024, cTime / TIMES);

		if (oldTime / cTime <= 0.6F) cache.push_back(sizes[i - 1] / 1024);

		// Текущее время становиться старым
		oldTime = cTime;
	}
	
	// Очищаем массив
	delete[] masterArray;

	/***/
	printf(" -----------------------\n\n");
	printf("> L1 = %d kB (per core), L2 = %d kb\n", cache[0], cache[1]);

	system("pause");
}
