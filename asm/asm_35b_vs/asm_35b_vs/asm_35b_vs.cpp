#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	int asmX, asmY, asmZ;
	int Result = 0;
	int Debug = 404;

	cout << "Введите числа X, Y и Z: ";
	cin >> asmX >> asmY >> asmZ;

	__asm {
		; *Без использования условных переходов!*
		; z / 2
		mov eax, asmZ;		Z
		sar eax, 1;			Z /= 2
		adc eax, 0;			Округляем Z с избытком, если остаток = 1
		push eax;			Z->stack

		; c1 = x + y + z / 2
		mov eax, asmX;		X
		mov ebx, asmY;		Y
		pop ecx;			Temp = Z < -stack
		add eax, ebx;		X *= Y
		add eax, ecx;		X *= Temp
		push eax;			X->stack(queue0)

		; c2 = x * y * z
		mov eax, asmX;		X
		mov ebx, asmY;		Y
		mov ecx, asmZ;		Z
		imul eax, ebx;		X += Y
		imul eax, ecx;		X += Z
		push eax;			X->stack(queue1)

		; Поиск большего числа из пары c1 и c2
		pop ebx;			c1 < -queue1
		pop eax;			c2 < -queue0

		cmp eax, ebx;		Сравниваем c1 и c2(допустим c1 > c2)
		cmovl eax, ebx;		Если c1 < c2, то c1 = c2
		;					иначе c1 не изменяется

		; Вывод результата
		imul eax, eax;		max * max
		add eax, 1;			max += 1
		mov Result, eax;	Вывод результата
	}

	//cout << "Debug: " << Debug << endl;
	cout << "Результат: " << Result << endl;
	system("pause");
}