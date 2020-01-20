#pragma once
template <class T>
class Node
{
public:
	// �����������
	Node(const T& item, Node<T> *nextPtr = nullptr)
		: data(item), next(nextPtr) {}

	// ���������� ��������� next
	Node<T> * NextNode() const
	{
		return next;
	}

	// ��������� ���� ptr ����� �������� ����
	void InsertAfter(Node<T> *ptr)
	{
		ptr->next = next;
		next = ptr;
	}

	// ������� ����, ��������� �� �������,
	// � ���������� ����� ����� ����
	Node<T>* DeleteAfter()
	{
		if (next == nullptr) return nullptr;
		
		Node<T>* temp = next;
		next = temp->next;
		return temp;
	}

	// ����������
	~Node()
	{
		delete next;
	}

private:
	Node<T>* next;
public:
	T data;
};
