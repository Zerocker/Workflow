#include <iostream>
#include <vector>
#include <algorithm>
#include "sort.hpp"

using namespace std;
using namespace lab;

int main()
{
	std::srand(std::time(nullptr));
	vector<float> list(6);
	
	cout << "bubble sort: \n";
	fill(list);
	cout << to_string(list);
	bubble_sort(list);
	cout << to_string(list) << endl;

	cout << "insert sort: \n";
	fill(list);
	cout << to_string(list);
	insert_sort(list);
	cout << to_string(list) << endl;

	cout << "gnome sort: \n";
	fill(list);
	cout << to_string(list);
	gnome_sort(list);
	cout << to_string(list) << endl;

	cout << "selection sort: \n";
	fill(list);
	cout << to_string(list);
	selection_sort(list);
	cout << to_string(list) << endl;
		
	cout << "quick sort: \n";
	fill(list);
	cout << to_string(list);
	quick_sort(list, 0, list.size() - 1);
	cout << to_string(list) << endl;
}