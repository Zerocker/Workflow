#pragma once
template <class T>
class Node
{
public:
	// Конструктор
	Node(const T& item, Node<T> *nextPtr = nullptr)
		: data(item), next(nextPtr) {}

	// Возвращает указатель next
	Node<T> * NextNode() const
	{
		return next;
	}

	// Вставляет узел ptr после текущего узла
	void InsertAfter(Node<T> *ptr)
	{
		ptr->next = next;
		next = ptr;
	}

	// Удаляет узел, следующий за текущим,
	// и возвращает адрес этого узла
	Node<T>* DeleteAfter()
	{
		if (next == nullptr) return nullptr;
		
		Node<T>* temp = next;
		next = temp->next;
		return temp;
	}

	// Деструктор
	~Node()
	{
		delete next;
	}

private:
	Node<T>* next;
public:
	T data;
};
