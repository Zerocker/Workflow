#include <iostream>
#include "Node.hpp"
using namespace std;

//Спецификация класса LinkedList
template <typename T>
class LinkedList
{
private:
	Node<T> *front,*rear;
	Node<T> *prevPtr,*currPtr;
	int size;
	int position;
//закрытые методы создания и удаления узлов
	Node<T> *GetNode(const T &item, Node<T>* nextPtr);
	void FreeNode(Node <T> *p);
	//Копировать список L в текущий список
	void CopyList(const LinkedList<T> &L);
public:
    LinkedList(void);
	LinkedList(const LinkedList<T> &L);

	~LinkedList(void);

	LinkedList<T> &operator = (const LinkedList<T> &L);

	int ListSize(void)const { return size; };
	//Методы прохождения списка
	void Reset(int pos=0);
	void Next(void);
	int CurrentPosition(void)const { return position; };
	//Методы вставки
	void InsertFront(const T &item);
	void InsertRear(const T &item);
	void InsertAt(const T &item);
	void InsertAfter(const T &item);
	//Методы удаления
	void DeleteFront(void);
	void DeleteAt(void);
	//возвратить/изменить данные
	T& Data(void);
	//очистка списка
	void ClearList(void);
};

//Реализация класса LinkedList
template <typename T>
LinkedList<T>:: LinkedList(void):front(nullptr), rear(nullptr),
	prevPtr(nullptr),currPtr(nullptr),size(0), position(-1)
{}
//Копировать L в текущий список
template <typename T>
void LinkedList<T>::CopyList(const LinkedList<T> &L)
{
	Node<T> *p= L.front;
	

	while (p!=nullptr)
	{
		InsertRear(p->data);
		p = p->NextNode();
	}
}

template<typename T>
inline LinkedList<T>::LinkedList(const LinkedList<T>& L)
{
	CopyList(L);
}

//Конструктор копирования, реализуется методом CopyList
//template <typename T>
//LinkedList::LinkedList(const LinkedList<T> &L)
//{
//	CopyList(L);
//}
//Удаление всех узлов из списка
template <typename T>
void LinkedList<T>:: ClearList(void)
{
	Node<T> *currPosition, *nextPosition;
	currPosition = front;
	while (currPosition != nullptr)
	{
      nextPosition = currPosition->NextNode();
	  FreeNode(currPosition );
	  currPosition = nextPosition;
	}
	front = rear = nullptr;
	size = 0;
	position = -1;
}
//Реализация деструктора
template <typename T>
LinkedList<T>::~LinkedList(void)
{ 
	ClearList();
	delete currPtr, prevPtr, front, rear;
}
template<typename T>
inline LinkedList<T>& LinkedList<T>::operator=(const LinkedList<T>& L)
{
	CopyList(L);
}
//Методы прохождения списка.Reset устанавливает текущее
//положение в позицию pos
template <typename T>
void LinkedList<T>::Reset(int pos)
{
	int startPos;
	if (front==nullptr)
		return;

	if (pos < 0 || pos > size-1)
	{
		cerr <<"pos is mistake" <<pos << endl;
		return;
	}
	if (pos==0)
	{
		prevPtr = nullptr;
		currPtr = front;
		position = 0;
	}
	else
	{
		prevPtr = nullptr;
		currPtr = front->NextNode();
		startPos = 1;
		for (position = startPos; position != pos; position++)
		{
			prevPtr = currPtr;
			currPtr = currPtr-> NextNode();
		}
	}
}
//Метод Next
template <typename T>
void LinkedList<T>::Next(void)
{
	if (currPtr != nullptr)
	{
		prevPtr = currPtr;
		currPtr = currPtr->NextNode();
		position++;
	}
}
//Доступ к данным класса
template <typename T>
T& LinkedList<T>:: Data(void)
{
	if (size == 0 || currPtr == nullptr)
	{
		cerr << "Data: Mistake!" << endl;
		exit(1);
	}
	return currPtr->data;
}
//Методы вставки для списка
//вставка item в текущую позицию списка
template <typename T>
void LinkedList<T>::InsertAt(const T& item)
{
	Node<T> *newNode;
	if (prevPtr == nullptr)
	{
		newNode = GetNode(item,front);
		front = newNode;
	}
	else
	{
		newNode = GetNode(item, nullptr);
		prevPtr->InsertAfter(newNode);
	}
	if (prevPtr == rear)
	{
		rear = newNode;
		position = size;
	}
	currPtr = newNode;
	size++;
}
//Вставка узла в голову списка: список пуст, либо нет
template <typename T>
void LinkedList<T>::InsertFront(const T& item)
{
	front = GetNode(item, front);
	if (rear == nullptr)
		rear = front;
	currPtr = front;
	prevPtr = nullptr;
	position = 0;
	size++;
}
//Вставка узла в хвост списка
template <typename T>
void LinkedList<T>::InsertRear(const T& item)
{
	Node <T> *newNode;
	if (front == nullptr)
		InsertFront(item);
	else
	{
		newNode = GetNode(item, nullptr);
		rear -> InsertAfter(newNode);
		prevPtr = rear;
		currPtr = newNode;
		rear = newNode;
		position = size;
		size++;
	}
}
//Вставка узла после currPtr списка:в голову,в хвост,внутрь
template <typename T>
void LinkedList<T>::InsertAfter(const T& item)
{
	Node <T> *newNode;
	if (currPtr == nullptr)
		return;
	else
	{
        newNode = GetNode(item, nullptr);
		if (currPtr == front)
		{ 
			front -> InsertAfter(newNode);
			position = 1;
		}
		else
		{
			if (currPtr == rear)
			{ 
				rear -> InsertAfter(newNode);
				rear = newNode;
			}
			else
			  currPtr -> InsertAfter(newNode);
			position++;
		}
	}
	prevPtr = currPtr;
	currPtr = newNode;
	size++;
}
//Удаление узла из текущей позиции списка
template <typename T>
void LinkedList<T>::DeleteAt(void)
{
	Node <T> *p;

	if (currPtr == nullptr)
	{
		cerr << "Mistake delete" << endl;
		exit(1);
	}
	if (prevPtr == nullptr)
	{
		p = front;
		front = front-> NextNode();
	}
	else
	
		p = prevPtr-> DeleteAfter();

		if (p == rear)
		{
			rear = prevPtr;
			position--;
		}
		currPtr = p->NextNode();
		FreeNode(p);
		size = size - 1;
}
//Удаление узла из головы списка
template <typename T>
void LinkedList<T>::DeleteFront(void)
{
	Node <T> *p;
	if (front == nullptr)
	{
		cerr << "List is empty" << endl;
		exit(1);
	}
	p = front;
	front = front->NextNode();
	FreeNode(p);
	size--;
	prevPtr = nullptr;
	currPtr = front;
	position = 0;
}
//Создание узла
template <typename T>
Node <T>* LinkedList<T>::GetNode(const T &item, Node<T> *nextPtr)
{
	Node <T> *newNode;
	newNode = new Node <T> (item,nextPtr);
	if (newNode == nullptr)
	{
		cerr << "Mistake mamory" << endl;
		exit(1);
	}
	return newNode;
}
template <typename T>
void LinkedList<T>::FreeNode(Node<T> *p)
{
	delete(p);
}
