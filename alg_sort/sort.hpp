#pragma once
#include <iostream>
#include <vector>
#include <iomanip>
#include <sstream>

namespace lab {

	void fill(std::vector<float> &arr)
	{
		for (auto i = 0; i < arr.size(); i++)
		{
			float min = 5.56;
			float max = 10.241;

			arr[i] = min + static_cast <float> (rand()) / (static_cast <float> (RAND_MAX / (max - min)));
		}
	}

	template<typename T>
	void bubble_sort(std::vector<T>& arr)
	{
		for (std::size_t i = 0; i < arr.size() - 1; i++)
		{
			for (std::size_t j = 0; j < arr.size() - i - 1; j++)
			{
				if (arr[j + 1] < arr[j])
				{
					std::swap(arr[j], arr[j + 1]);
				}
			}
		}
	}

	template<typename T>
	void insert_sort(std::vector<T>& arr)
	{
		for (std::size_t i = 1; i < arr.size(); i++)
		{
			T temp = arr[i];
			std::size_t j = i;

			while (j > 0 && arr[j - 1] > temp)
			{
				arr[j] = arr[j - 1];
				j--;
			}
			arr[j] = temp;
		}
	}

	template<typename T>
	void gnome_sort(std::vector<T>& arr)
	{
		for (std::size_t i = 0; i + 1 < arr.size(); i++)
		{
			if (arr[i] > arr[i + 1])
			{
				std::swap(arr[i], arr[i + 1]);
				if (i != 0) i -= 2;
			}
		}
	}


	template<typename T>
	void selection_sort(std::vector<T>& arr)
	{
		for (std::size_t i = 0; i < arr.size() - 1; i++)
		{
			T max = arr[i];
			std::size_t min = i;

			for (std::size_t j = i + 1; j < arr.size(); j++)
			{
				if (arr[j] < arr[min])
					min = j;
			}
			std::swap(arr[i], arr[min]);
		}
	}

	template<typename T>
	void quick_sort(std::vector<T>& arr, int start, int end)
	{
		int i = start;
		int j = end;
		T pivot = arr[(i + j) / 2];

		while (i <= j)
		{
			while (arr[i] < pivot)
				i++;
			while (arr[j] > pivot)
				j--;

			if (i <= j)
			{
				std::swap(arr[i], arr[j]);
				i++;
				j--;
			}
		}

		if (j > start) quick_sort(arr, start, j);
		if (i < end) quick_sort(arr, i, end);
	}

	template<typename T>
	std::string to_string(std::vector<T>& arr)
	{
		std::stringstream strout;
		for (auto item: arr)
		{
			strout << std::fixed << std::setprecision(3);
			strout << std::setw(10) << item;
		}
		strout << std::endl;
		return strout.str();
	}
}