#include <iomanip>
#include <cmath>
#include <fstream>
#include "Function.h"

using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");

	float startX, stopX, stepX;
	float A, B, C;

	cout << "Введите X нач., X кон. и шаг dX: ";
	cin >> startX >> stopX >> stepX;
	cout << "Введите A, B и C: ";
	cin >> A >> B >> C;

	ofstream file("output.txt", ios::trunc);

	file << "Xin: " << startX << endl;
	file << "Xout: " << stopX << endl;
	file << "dX: " << stepX << endl;
	file << "A: " << A << endl;
	file << "B: " << B << endl;
	file << "C: " << C << endl;
	file << " -------------------------" << endl;

	float Result;

	file << " | " << setw(9) << "x";
	file << " | " << setw(9) << "f(x)" << " |\n";
	for (float X = startX; X <= stopX; X += stepX)
	{
		Result = Function(A, B, C, X);
		
		file << fixed << setprecision(3);
		file << " | " << setw(9) << X;
		file << " | " << setw(9) << Result << " |\n";
	}

	file << " -------------------------" << endl;
	
	for (float X = startX; X <= stopX; X += stepX)
	{
		i32 iA = static_cast<i32>(A);
		i32 iB = static_cast<i32>(B);
		i32 iC = static_cast<i32>(C);
		
		Result = Function(A, B, C, X);

		if (iA | iB | iC == 0)
			Result = static_cast<i32>(Result);

		file << " | " << setw(9) << X;
		file << " | " << setw(9) << Result << " |\n";
	}

	file << " -------------------------" << endl;

	file.close();
	cout << endl << "Готово. Результат вычислений находится в файле output.txt!" << endl;
	system("pause");
}
