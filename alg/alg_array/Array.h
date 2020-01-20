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

// ���������� ������� ���������� �������
void fillArray(float *Array, u32 &Size)
{
	// ���������� ������
	for (size_t i = 0; i < Size; i++)
	{
		// ����������� ��-�� ������� �������� �����
		Array[i] = USR_MIN + static_cast <float> (rand()) 
			/ (static_cast <float> (RAND_MAX / (USR_MAX - USR_MIN)));
	}
}

// ����� ������� � ����
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

// ���������� ����� ��������� ������� � ��������� ��������
float findOddSum(float *Array, u32 &Size)
{
	float Result = 0;	// ����� ��-��� � ��������� ��������

	// ���������� ������
	for (size_t i = 0; i < Size; i++)
	{
		// ���� ������ - ��������
		if (i % 2 != 0)
			// ���������� ��-� � �����
			Result += Array[i];
	}
	
	return Result;
}

// ���������� ����� ��������� �������, ������������� ����� ������ � ��������� �������������� ����������
float findNegSum(float *Array, u32 &Size)
{
	u32 first;			// ������ ������� �����-��� ��-��
	u32 last;			// ������ ���������� �����-��� ��-��
	float Result = 0;	// ����� ��-���
	
	// ���������� ��-�� ������� � ������
	for (first = 0; first < Size; first++)
	{
		// ������� ������ ������� �����-��� ��-��
		if (Array[first] < 0) break;
	}

	// ���������� ��-�� ������� � �����
	for (last = Size - 1; last > first; last--)
	{
		// ������� ������ ���������� �����-��� ��-��
		if (Array[last] < 0) break;
	}

	// ���������� ��-�� ����� ������ � ��������� �����-�� ��-���
	for (size_t i = first + 1; i < last; i++)	
	{
		// ���������� ��-� � �����
		Result += Array[i];
	}

	return Result;
}

// ������ ������� ���� �������� ���������, ������ ������� �� ��������� 1.
void squeezeArray(float *Array, u32 &Size)
{
	// �������� � ���-�� ����. ��-���
	size_t i = 0, j = i;

	// ���������� ������
	for (; i < Size; i++)
	{
		// ���� ������ >= 1
		if (fabs(Array[i]) >= 1)
			// �� ���������� ��-�� ������� ������
			Array[i - j] = Array[i];
		else
			// ��� �� ����������� ���-�� ����. ��-���
			j++;
	}

	// ���������� ������ c ������ ��������� ��������
	// (���-�� ��-��� ������� - ���-�� ����. ��-���)
	for (i = Size - j; i < Size; i++)
		// ������� � ������� ��������
		Array[i] = 0.0F;
}