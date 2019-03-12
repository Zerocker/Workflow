#include <iomanip>
#include <algorithm>
#include "Aeroflot.h"

void Fill(Aeroflot * List)
{
	// ���-�� �������� � �������
	for (size_t i = 0; i < Size; i++)
	{
		// ������ �������� ��� ������� ���� � ���������
		cout << "�" << i + 1 << " > ";
		cin >> List[i].Dest >> List[i].Code >> List[i].Type;
	}
}

void WriteBin(Aeroflot * In, string filename)
{
	// ��������� �������� ���� ��� ������
	ofstream fout(filename, ios::binary);
	
	// ���� ���� ����������� . . . 
	if (fout.is_open())
	{
		// ���-�� �������� � �������
		for (size_t i = 0; i < Size; i++)
		{
			// ���������� ��������� �� ������� � ����
			fout.write(reinterpret_cast<char*>(&In[i]), sizeof(In[i]));
		}
	}
	// ��������� ����
	fout.close();
}

void ReadBin(Aeroflot * Out, string filename)
{
	// ��������� �������� ���� ��� ������
	ifstream fin(filename, ios::binary);
	
	// ���� ���� ����������� . . . 
	if (fin.is_open())
	{
		// ���-�� �������� � �������
		for (size_t i = 0; i < Size; i++)
		{
			// ������ ��������� �� ����� � ���������� � � ������
			fin.read(reinterpret_cast<char*>(&Out[i]), sizeof(Out[i]));
		}
	}
	// ��������� ����
	fin.close();
}

void Debug(Aeroflot * List)
{
	// ���-�� �������� � �������
	for (size_t i = 0; i < Size; i++)
	{
		// ����� ����� ������ ���������
		cout << setw(16) << List[i].Dest;
		// . . .
		cout << setw(16) << List[i].Code;
		// . . .
		cout << setw(16) << List[i].Type << endl;
	}
}

void Sort(Aeroflot * List)
{
	// ������� ���������� (�� ������ �����)
	auto Lambda = [](const Aeroflot& Up, const Aeroflot& Down)
	{
		return Up.Code < Down.Code;
	};

	// �-��� ���������� �������
	sort(List, List + Size, Lambda);
}

void Check(Aeroflot* List)
{
	// ����������� ����
	while (true)
	{
		string Input;			// ������, ����. �������������
		bool Found = false;		// ���� �� ��-� � ����� �������?

		// ���� � ����������
		cout << endl << "������� ����� ����������: " << Input;
		cin >> Input; cin.ignore();

		// ���� ������ - exit
		if (Input == "exit")
		{
			cout << "�������� �������� . . ." << endl;
			break;	// ����� �� ����� while
		}

		// ���-�� �������� � �������
		for (size_t i = 0; i < Size; i++)
		{
			// ���� ���� ������ ���������� ��������� � ����. �������
			if (List[i].Dest == Input)
			{
				// ��-� (���������) ������(�)
				Found = true;	
				// ����� � ����
				cout << "�" << i + 1 << " >>";
				cout << setw(16) << List[i].Code;
				cout << setw(16) << List[i].Type << endl;
			}
		}
		
		// ���� �� ������� ���������
		if (!Found)
			// ����� ���������...
			cout << "������ �� ������� . . . " << endl;
	}
}