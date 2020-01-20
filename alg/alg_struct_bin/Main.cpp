#include <iostream>
#include "Aeroflot.h"
#include "Types.h"

int main()
{
	setlocale(LC_ALL, "Rus");

	/* Название файла */
	string Filename("output.bin");

	/* Массив из структур */
	Aeroflot* Init = new Aeroflot[Size];
	Aeroflot* Data = new Aeroflot[Size];

	Fill(Init);
	cout << endl << "Данные:" << endl;
	Debug(Init);
	
	Sort(Init);
	cout << endl << "После сортировки:" << endl;
	Debug(Init);
	
	WriteBin(Init, Filename);

	delete[] Init;
	
	/***********************************/

	ReadBin(Data, Filename);
	
	Check(Data);
	
	delete[] Data;
}