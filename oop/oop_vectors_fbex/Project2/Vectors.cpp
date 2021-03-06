#include <iostream>
#include <vector>
#include "fun.h"
#include "error.h"
	
using namespace std;
using namespace Fun;

int main()
{
	int col, row;
	string fileName;
	//cout << "Set the matrices dimensions: ";
	//cin >> col >> row;
	cout << "Enter the name of file: ";
	cin >> fileName;

	/*array2d List = createMatrix(col, row);
	array2bin(List, fileName);
	
	system("cls");
	
	cout << "Your matrix is:" << endl;
	printMass(List);*/

	array2d arrayFile;
	try {
		arrayFile = bin2array(fileName);
	}
	catch (errorHandler& error) {
		if (error.id == 1)
			cout << error.about << endl;
		if (error.id == 2)
			cout << error.about << endl;
		return -1;
	}
	
	cout << endl << "Matrix from File is:" << endl;
	printMass(arrayFile);
	
	system("pause");
}
