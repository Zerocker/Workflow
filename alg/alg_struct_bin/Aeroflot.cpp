#include <iomanip>
#include <algorithm>
#include "Aeroflot.h"

void Fill(Aeroflot * List)
{
	// Кол-во структур в массиве
	for (size_t i = 0; i < Size; i++)
	{
		// Вводим значения для каждого поля в структуре
		cout << "№" << i + 1 << " > ";
		cin >> List[i].Dest >> List[i].Code >> List[i].Type;
	}
}

void WriteBin(Aeroflot * In, string filename)
{
	// Открываем бинарный файл для записи
	ofstream fout(filename, ios::binary);
	
	// Если файл открывается . . . 
	if (fout.is_open())
	{
		// Кол-во структур в массиве
		for (size_t i = 0; i < Size; i++)
		{
			// Записываем структуру из массива в файл
			fout.write(reinterpret_cast<char*>(&In[i]), sizeof(In[i]));
		}
	}
	// Закрываем файл
	fout.close();
}

void ReadBin(Aeroflot * Out, string filename)
{
	// Открываем бинарный файл для чтения
	ifstream fin(filename, ios::binary);
	
	// Если файл открывается . . . 
	if (fin.is_open())
	{
		// Кол-во структур в массиве
		for (size_t i = 0; i < Size; i++)
		{
			// Читаем структуру из файла и записываем её в массив
			fin.read(reinterpret_cast<char*>(&Out[i]), sizeof(Out[i]));
		}
	}
	// Закрываем файл
	fin.close();
}

void Debug(Aeroflot * List)
{
	// Кол-во структур в массиве
	for (size_t i = 0; i < Size; i++)
	{
		// Вывод полей каждой структуры
		cout << setw(16) << List[i].Dest;
		// . . .
		cout << setw(16) << List[i].Code;
		// . . .
		cout << setw(16) << List[i].Type << endl;
	}
}

void Sort(Aeroflot * List)
{
	// Условие сортировки (по номеру рейса)
	auto Lambda = [](const Aeroflot& Up, const Aeroflot& Down)
	{
		return Up.Code < Down.Code;
	};

	// Ф-ция сортировки массива
	sort(List, List + Size, Lambda);
}

void Check(Aeroflot* List)
{
	// Бесконечный цикл
	while (true)
	{
		string Input;			// Строка, введ. пользователем
		bool Found = false;		// Есть ли эл-т с таким пунктом?

		// Ввод с клавиатуры
		cout << endl << "Введите пункт назначения: " << Input;
		cin >> Input; cin.ignore();

		// Если строка - exit
		if (Input == "exit")
		{
			cout << "Проверка окончена . . ." << endl;
			break;	// Выход из цикла while
		}

		// Кол-во структур в массиве
		for (size_t i = 0; i < Size; i++)
		{
			// Если поле пункта назначения совпадает с введ. строкой
			if (List[i].Dest == Input)
			{
				// Эл-т (структура) найден(а)
				Found = true;	
				// Вывод в файл
				cout << "№" << i + 1 << " >>";
				cout << setw(16) << List[i].Code;
				cout << setw(16) << List[i].Type << endl;
			}
		}
		
		// Если не найдена структура
		if (!Found)
			// Вывод сообщения...
			cout << "Ничего не найдено . . . " << endl;
	}
}