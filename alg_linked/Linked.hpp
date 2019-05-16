#include <iostream>
#include <sstream>
#include "Node.hpp"
#include "Common.hpp"

template <class T>
class LinkedList
{
public:
    ///
	LinkedList();
	LinkedList(const LinkedList<T> *list);
	~LinkedList();

	int Size() const { return size; }
	int Position() const { return position; }
	int Find(const T& item);

	void Reset(int index = 0);
	void Next();
	
	void InsertFront(const T &item);
	void InsertEnd(const T &item);
	void InsertAt(const T &item);
	void InsertAfter(const T &item);
	
	void DeleteAt(int index);
	void DeleteFront();
	void DeleteAt();
	void Clear();
	
	T& Data();
	T& Data(int index);
	std::string ToString();
	
private:
	Node<T>* GetNode(const T& item, Node<T>* nextPtr);
	void FreeNode(Node <T>* p);
	void Copy(const LinkedList<T>* L);

private:
	Node<T> *front, *end;
	Node<T> *prev_ptr, *curr_ptr;
	int size;
	int position;
};

//------------------------------------------------------//
//------------------------------------------------------//
//------------------------------------------------------//

template <typename T>
LinkedList<T>::LinkedList()
{
	front = nullptr;
	end = nullptr;
	curr_ptr = nullptr;
	prev_ptr = nullptr;
	size = 0;
	position = 0;
}

template <typename T>
void LinkedList<T>::Copy(const LinkedList<T>* list)
{
	Node<T>* p = list->front;

	while (p != nullptr)
	{
		InsertEnd(p->data);
		p = p->NextNode();
	}
}

template<typename T>
LinkedList<T>::LinkedList(const LinkedList<T>* list)
{
	Copy(list);
}

template <typename T>
void LinkedList<T>::Clear()
{
	Node<T>* currPosition, * nextPosition;
	currPosition = front;
	while (currPosition != nullptr)
	{
		nextPosition = currPosition->NextNode();
		FreeNode(currPosition);
		currPosition = nextPosition;
	}
	front = end = nullptr;
	size = 0;
	position = -1;
}

template <typename T>
LinkedList<T>::~LinkedList()
{
	Clear();
	delete curr_ptr, prev_ptr, front, end;
}

//------------------------------------------------------//

template <typename T>
void LinkedList<T>::Reset(int index)
{
	if (front == nullptr)
		return;

	if (index < 0 || index > size - 1)
		throw std::exception("index is out of range!");

	if (index == 0)
	{
		prev_ptr = nullptr;
		curr_ptr = front;
		position = 0;
	}
	else
	{
		prev_ptr = nullptr;
		curr_ptr = front->NextNode();
		for (position = 1; position != index; position++)
		{
			prev_ptr = curr_ptr;
			curr_ptr = curr_ptr->NextNode();
		}
	}
}

template <typename T>
void LinkedList<T>::Next()
{
	if (curr_ptr != nullptr)
	{
		prev_ptr = curr_ptr;
		curr_ptr = curr_ptr->NextNode();
		position++;
	}
}

template <typename T>
T& LinkedList<T>::Data()
{
	if (size == 0 || curr_ptr == nullptr)
		throw std::exception("size is zero or curr_ptr is nullptr!");

	return curr_ptr->data;
}

template<class T>
T& LinkedList<T>::Data(int index)
{
	int count = 0;
	for (curr_ptr = front; curr_ptr; curr_ptr = curr_ptr->NextNode())
	{
		if (count == index) return curr_ptr->data;
		count++;
	}
}

template<class T>
int LinkedList<T>::Find(const T & item)
{
	curr_ptr = front;
	int index = 0;

	while (curr_ptr != nullptr)
	{
		if (curr_ptr->data == item)
			return index;
		index++;
		curr_ptr = curr_ptr->NextNode();
	}
	return -1;
}

template<class T>
void LinkedList<T>::DeleteAt(int index)
{
	curr_ptr = front;
	prev_ptr = nullptr;

	for (int i = 0; i < index; i++)
	{
		prev_ptr = curr_ptr;
		curr_ptr = curr_ptr->NextNode();
	}
	size--;
	prev_ptr = curr_ptr->NextNode();	
}

template<class T>
std::string LinkedList<T>::ToString()
{
	curr_ptr = front;
	std::stringstream strout;

	while (curr_ptr != nullptr)
	{
		strout << curr_ptr->data << std::endl;
		curr_ptr = curr_ptr->NextNode();
	}
	return strout.str();
}

//------------------------------------------------------//

template <typename T>
void LinkedList<T>::InsertAt(const T & item)
{
	Node<T>* newNode;
	if (prev_ptr == nullptr)
	{
		newNode = GetNode(item, front);
		front = newNode;
	}
	else
	{
		newNode = GetNode(item, nullptr);
		prev_ptr->InsertAfter(newNode);
	}
	if (prev_ptr == end)
	{
		end = newNode;
		position = size;
	}
	curr_ptr = newNode;
	size++;
}

template <typename T>
void LinkedList<T>::InsertFront(const T & item)
{
	front = GetNode(item, front);
	if (end == nullptr)
		end = front;
	curr_ptr = front;
	prev_ptr = nullptr;
	position = 0;
	size++;
}

template <typename T>
void LinkedList<T>::InsertEnd(const T & item)
{
	Node <T>* newNode;
	if (front == nullptr)
		InsertFront(item);
	else
	{
		newNode = GetNode(item, nullptr);
		end->InsertAfter(newNode);
		prev_ptr = end;
		curr_ptr = newNode;
		end = newNode;
		position = size;
		size++;
	}
}

template <typename T>
void LinkedList<T>::InsertAfter(const T & item)
{
	Node <T>* newNode;
	if (curr_ptr == nullptr)
		throw std::exception("curr_ptr is nullptr!");

	else
	{
		newNode = GetNode(item, nullptr);
		if (curr_ptr == front)
		{
			front->InsertAfter(newNode);
			position = 1;
		}
		else
		{
			if (curr_ptr == end)
			{
				end->InsertAfter(newNode);
				end = newNode;
			}
			else
				curr_ptr->InsertAfter(newNode);
			position++;
		}
	}
	prev_ptr = curr_ptr;
	curr_ptr = newNode;
	size++;
}

//------------------------------------------------------//

template <typename T>
void LinkedList<T>::DeleteAt(void)
{
	Node <T>* p;

	if (curr_ptr == nullptr)
		throw std::exception("delete error: curr_ptr is null!");

	if (prev_ptr == nullptr)
	{
		p = front;
		front = front->NextNode();
	}
	else
	{
		p = prev_ptr->DeleteAfter();
	}

	if (p == end)
	{
		end = prev_ptr;
		position--;
	}
	curr_ptr = p->NextNode();
	FreeNode(p);
	size = size - 1;
}

template <typename T>
void LinkedList<T>::DeleteFront(void)
{
	Node <T>* p;
	if (front == nullptr)
		throw std::exception("list is empty!");

	p = front;
	front = front->NextNode();
	FreeNode(p);
	size--;
	prev_ptr = nullptr;
	curr_ptr = front;
	position = 0;
}

template <typename T>
Node <T>* LinkedList<T>::GetNode(const T & item, Node<T> * nextPtr)
{
	Node <T>* newNode;
	newNode = new Node <T>(item, nextPtr);
	if (newNode == nullptr)
		throw std::exception("new item's pointer is null!");
	return newNode;
}

template <typename T>
void LinkedList<T>::FreeNode(Node<T> * p)
{
	delete(p);
}