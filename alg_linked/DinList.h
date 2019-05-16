#include <iostream>
#include "Node.hpp"
using namespace std;

//������������ ������ LinkedList
template <typename T>
class LinkedList
{
private:
	Node<T> *front,*rear;
	Node<T> *prevPtr,*currPtr;
	int size;
	int position;
//�������� ������ �������� � �������� �����
	Node<T> *GetNode(const T &item, Node<T>* nextPtr);
	void FreeNode(Node <T> *p);
	//���������� ������ L � ������� ������
	void CopyList(const LinkedList<T> &L);
public:
    LinkedList(void);
	LinkedList(const LinkedList<T> &L);

	~LinkedList(void);

	LinkedList<T> &operator = (const LinkedList<T> &L);

	int ListSize(void)const { return size; };
	//������ ����������� ������
	void Reset(int pos=0);
	void Next(void);
	int CurrentPosition(void)const { return position; };
	//������ �������
	void InsertFront(const T &item);
	void InsertRear(const T &item);
	void InsertAt(const T &item);
	void InsertAfter(const T &item);
	//������ ��������
	void DeleteFront(void);
	void DeleteAt(void);
	//����������/�������� ������
	T& Data(void);
	//������� ������
	void ClearList(void);
};

//���������� ������ LinkedList
template <typename T>
LinkedList<T>:: LinkedList(void):front(nullptr), rear(nullptr),
	prevPtr(nullptr),currPtr(nullptr),size(0), position(-1)
{}
//���������� L � ������� ������
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

//����������� �����������, ����������� ������� CopyList
//template <typename T>
//LinkedList::LinkedList(const LinkedList<T> &L)
//{
//	CopyList(L);
//}
//�������� ���� ����� �� ������
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
//���������� �����������
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
//������ ����������� ������.Reset ������������� �������
//��������� � ������� pos
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
//����� Next
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
//������ � ������ ������
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
//������ ������� ��� ������
//������� item � ������� ������� ������
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
//������� ���� � ������ ������: ������ ����, ���� ���
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
//������� ���� � ����� ������
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
//������� ���� ����� currPtr ������:� ������,� �����,������
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
//�������� ���� �� ������� ������� ������
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
//�������� ���� �� ������ ������
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
//�������� ����
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
