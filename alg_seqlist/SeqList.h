#pragma once
#include <iostream>
#include <algorithm>
#include "Types.h"

using namespace std;

constexpr i32 MaxSize = 100;

template <class T>
class SeqList
{
public:
	SeqList()
		: Size(0) {}

	i8 GetSize()
	{
		return Size;
	}
	
	bool isEmpty()
	{
		return Size == 0;
	}
	
	bool Find(T &Item)
	{
		for (i8 i = 0; i < Size; i++)
		{
			if (Item == List[i])
			{
				return true;
			}
		}
		return false;
	}
	
	T Get(i8 Index)
	{
		if (Index >= Size)
		{
			cerr << "Get method: Index is out of range!" << endl;
			system("pause");
		}

		return List[Index];
	}

	void Insert(const T &Item)
	{
		if (Size + 1 > MaxSize)
		{
			cerr << "Insert method: overflow!" << endl;
			system("pause");
			return;
		}
		List[Size] = Item;
		Size++;
	}

	void Delete(const T &Item)
	{
		i8 i = 0;
		while (i < Size && !(Item == List[i])) i++;
		if (i < Size)
		{
			while (i < Size - 1)
			{
				List[i] = List[i + 1];
				i++;
			}
			Size--;
		}
	}

	T Get(const T &Item)
	{
		i8 i = 0;
		while (i < Size && !(Item == List[i])) i++;
		return List[i];
	}
	
	T DeleteFront()
	{
		if (Size == 0)
		{
			cerr << "DeleteFront method: null size!" << endl;
			system("pause");
			return;
		}
		T Item = List[0];
		Delete(Item);

		return Item;
	}

private:
	T List[MaxSize];
	i8 Size;
};