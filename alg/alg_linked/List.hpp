#pragma once
#include <string>
#include "Node.hpp"
#include "Common.hpp"

using namespace std;

template <class T>
class LinkedList
{
public:

	// --- [������������ � ���������] --------------------------------- //

	// ����������� ��� ����������
	LinkedList()
	{
		front = nullptr;
		rear = nullptr;
		prev_ptr = nullptr;
		curr_ptr = nullptr;
		size = 0;
		position = -1;
	}

	// ����������� �����������
	LinkedList(const LinkedList* List)
	{
		Copy(List);
	}
	
	// ����������
	~LinkedList()
	{
		Clear();
		delete front, rear, prev_ptr, curr_ptr;
	}

	// �������� �����������
	void operator==(const LinkedList* List)
	{
		Copy(List);
	}

	// --- [������ � ��������] --------------------------------- //
	
	// ���������� ������ ������
	u32 Size() const
	{
		return size;
	}
	
	// �������� �� ������ ������
	bool IsEmpty() const
	{
		return size == 0;
	}

	// ������������� ������� ��������� � ������� index
	void SetPosition(u32 index)
	{
		if (front == nullptr) return;
		if (index < 0 || index > size - 1) throw exception("LinkedList::Reset - invalid index!");
		
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
	
	// ������������� ��������� ������� ���������
	void Next()
	{
		if (curr_ptr != nullptr)
		{
			prev_ptr = curr_ptr;
			curr_ptr = curr_ptr->NextNode();
			position++;
		}
	}
	
	// ���������� ������� �������
	u32 Position() const
	{
		return position;
	}

	// ���������� ���� �� ������� �������
	T& CurrentItem()
	{
		if (size == 0 || curr_ptr == nullptr)
		{
			throw exception("LinkedList::Data - invalid current pointer or size is zero!");
		}
		return curr_ptr->data;
	}

	// --- [������ �������] --------------------------------- //

	// ��������� ���� � ������� ������� ������
	void InsertAt(const T& Item)
	{
		Node<T>* newNode;
		if (prev_ptr == nullptr)
		{
			newNode = GetNode(Item, front);
			front = newNode;
		}
		else
		{
			newNode = GetNode(Item);
			prev_ptr->InsertAfter(newNode);
		}
		if (prev_ptr == rear)
		{
			rear = newNode;
			position = size;
		}
		curr_ptr = newNode;
		size++;
	}

	// ��������� ���� ����� curr_ptr � ������ 
	// (� ������, � ����� ��� ������)
	void InsertAfter(const T& Item)
	{
		Node <T>* newNode;
		if (curr_ptr == nullptr)
			return;
			//throw exception("LinkedList::InsertAfter - curr_ptr is null!");
		else
		{
			newNode = GetNode(Item);
			if (curr_ptr == front)
			{
				front->InsertAfter(newNode);
				position = 1;
			}
			else
			{
				if (curr_ptr == rear)
				{
					rear->InsertAfter(newNode);
					rear = newNode;
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
	
	// ��������� ���� � ������ ������
	void InsertFront(const T& Item)
	{
		front = GetNode(Item, front);
		if (rear = nullptr)
			rear = front;
		
		curr_ptr = front;
		prev_ptr = nullptr;
		position = 0;
		size++;
	}
	
	// ��������� ���� � ����� ������
	void InsertEnd(const T &Item)
	{
		Node<T>* newNode;
		
		if (front == nullptr)
			InsertFront(Item);
		else
		{
			newNode = GetNode(Item);
			rear->InsertAfter(newNode);
			prev_ptr = rear;
			curr_ptr = newNode;
			rear = newNode;
			position = size;
			size++;
		}
	}
	
	// --- [������ ��������] --------------------------------- //
	
	// ������� ���� �� ������ ������
	T DeleteFront()
	{
		Node <T>* ptr;
		if (front == nullptr) 
			throw exception("LinkedList::DeleteFront - head pointer is null (maybe list is empty)!");

		ptr = front;
		front = front->NextNode();
		FreeNode(ptr);
		size--;
		prev_ptr = nullptr;
		curr_ptr = front;
		position = 0;
	}

	// ������� ���� �� ������� ������� ������
	void DeleteAt()
	{
		Node <T>* ptr;

		if (curr_ptr == nullptr)
			throw exception("LinkedList::DeleteAt - current pointer is null!");
		
		if (prev_ptr == nullptr)
		{
			ptr = front;
			front = front->NextNode();
		}
		else
			ptr = prev_ptr->DeleteAfter();

		if (ptr == rear)
		{
			rear = prev_ptr;
			position--;
		}

		curr_ptr = ptr->NextNode();
		FreeNode(ptr);
		size--;
	}

	// ������� ��� ���� �� ������
	void Clear()
	{
		Node<T>* currPosition = front, * nextPosition;
		while (currPosition != nullptr)
		{
			nextPosition = currPosition->NextNode();
			FreeNode(currPosition);
			currPosition = nextPosition;
		}
		front = rear = nullptr;
		size = 0;
		position = -1;
	}

private:
	// ������� ����� ���� (?)
	Node<T>* GetNode(const T& item, Node<T>* nextptr = nullptr)
	{
		Node <T>* newNode = new Node <T>(item, nextptr);
		if (newNode == nullptr) throw exception("LinkedList::GetNode - newNode pointer is null!");
		return newNode;
	}

	// ������� ���� (?)
	void FreeNode(Node<T>* p)
	{
		delete(p);
	}

	// �������� ������ List � ������� ������
	void Copy(const LinkedList<T>* List)
	{
		Node<T>* ptr = List->front;
		while (ptr != nullptr)
		{
			InsertEnd(ptr->data);
			ptr = ptr->NextNode();
		}

		/*
		if (position == -1)
			return;

		curr_ptr = front;
		prev_ptr = nullptr;

		for (int pos = 0; pos != position; pos++)
		{
			prev_ptr = curr_ptr;
			curr_ptr = curr_ptr->NextNode();
			size++;
			position++;
		}*/
	}

private:
	// . . .
	Node<T> * front, * rear;
	// . . .
	Node<T> * prev_ptr, * curr_ptr;
	// . . .
	u32 size, position;
};