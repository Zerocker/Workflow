#pragma once
#include <iostream>
#include <string>
#include <fstream>
#include "Types.h"

using namespace std;

constexpr u16 Size = 4;

struct Aeroflot
// ���������
{
	u16 Code;		// ����� �����
	string Type;	// ��� �������
	string Dest;	// ����� ����������
};

// ���������� �������� � �������
void Fill(Aeroflot* List);

// ������ ������� �������� � ����
void WriteBin(Aeroflot* In, string filename);

// ������ ������� �������� � ����
void ReadBin(Aeroflot* Out, string filename);

// ����� ������� �������� � �������
void Debug(Aeroflot* List);

// ���������� ������� �� ������ �����
void Sort(Aeroflot* List);

// ������� ��������� � ������ �������
void Check(Aeroflot* List);
