#pragma once
#include <iostream>
#include <sstream>
#include <iomanip>
#include <fstream>
#include <string>
/*------------------*/
#include "Common.hpp"
#include "Linked.hpp"

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
		Storage = new LinkedList<T>();

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

			Storage->InsertAt(Temp);
		}

		File.close();
	}

	void Add(T & Item)
	{
		Storage->InsertAfter(Item);
	}

	void Remove(T & Item)
	{
		int position = Storage->Find(Item);
		Storage->DeleteAt(position);
	}

	T Pop(u16 Number, string Time)
	{
		T Temp{ Number, "", "", Time };
		
		int position = Storage->Find(Temp);
		
		T Item = Storage->Data(position);
		
		Storage->DeleteAt(position);
		
		return Item;
	}
	
	string ToString() const
	{
		stringstream strout;

		for (int i = 0; i < Storage->Size(); i++)
		{
			T Item = Storage->Data(i);
			strout << i+1 << ": ";
			strout << left << setw(6) << setfill(' ') << Item.Number;
			strout << left << setw(12) << setfill(' ') << Item.Destination;
			strout << left << setw(16) << setfill(' ') << Item.Passanger;
			strout << left << setw(12) << setfill(' ') << Item.DepartureTime;
			strout << endl;
		}
		return strout.str();
	}

private:
	LinkedList<T> * Storage;
};

string StringTicket(const Ticket& Object);