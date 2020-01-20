#pragma once
#include <iostream>
#include <sstream>
#include <iomanip>
#include <fstream>
#include <string>
/*------------------*/
#include "SeqList.h"

using namespace std;

struct Ticket
{
	u16 Number;
	string Destination;
	string Passanger;
	string DepartureTime;
};

bool operator==(const Ticket & First, const Ticket & Second);

template <typename T>
class AnotherList
{
public:
	AnotherList(string Path)
	{
		List = new SeqList<T>;

		ifstream File(Path);
		T Temp;

		if (!File.is_open())
		{
			cerr << "File is not found!" << endl;
			system("pause");
		}

		while (!(File.eof()))
		{
			string Seporator;

			File >> Temp.Number;
			getline(File, Seporator);
			getline(File, Temp.Destination);
			getline(File, Temp.Passanger);
			getline(File, Temp.DepartureTime);
			getline(File, Seporator);

			List->Insert(Temp);
		}

		File.close();
	}

	void Add(T & Item)
	{
		List->Insert(Item);
	}

	void Remove(T & Item)
	{
		List->Delete(Item);
	}

	T Pop(u16 Number, string Time)
	{
		T Temp{ Number, "", "", Time };
		T Item;

		if (List->Find(Temp))
		{
			Item = List->Get(Temp);
			List->Delete(Item);
		}

		return Item;
	}
	
	string ToString() const
	{
		stringstream strout;

		for (i8 i = 0; i < List->GetSize(); i++)
		{
			T Item = List->Get(i);
			strout << i + 1 << ": ";
			strout << left << setw(6) << setfill(' ') << Item.Number;
			strout << left << setw(12) << setfill(' ') << Item.Destination;
			strout << left << setw(16) << setfill(' ') << Item.Passanger;
			strout << left << setw(12) << setfill(' ') << Item.DepartureTime;
			strout << endl;
		}
		return strout.str();
	}

	string ToString(const T & Object) const
	{
		stringstream strout;

		T Item = List->Get(Object);
		strout << left << setw(6) << setfill(' ') << Item.Number;
		strout << left << setw(12) << setfill(' ') << Item.Destination;
		strout << left << setw(16) << setfill(' ') << Item.Passanger;
		strout << left << setw(12) << setfill(' ') << Item.DepartureTime;

		return strout.str();
	}

private:
	SeqList<T> * List;
};