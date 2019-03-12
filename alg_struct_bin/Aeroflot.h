#pragma once
#include <iostream>
#include <string>
#include <fstream>
#include "Types.h"

using namespace std;

constexpr u16 Size = 4;

struct Aeroflot
// Структура
{
	u16 Code;		// Номер рейса
	string Type;	// Тип самолёта
	string Dest;	// Пункт назначения
};

// Заполнение структур в массиве
void Fill(Aeroflot* List);

// Запись массива структур в файл
void WriteBin(Aeroflot* In, string filename);

// Чтение массива структур в файл
void ReadBin(Aeroflot* Out, string filename);

// Вывод массива структур в консоль
void Debug(Aeroflot* List);

// Сортировка массива по номеру рейса
void Sort(Aeroflot* List);

// Наличие структуры с нужным пунктом
void Check(Aeroflot* List);
