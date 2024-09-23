#pragma once
class node
{
private:
		int data;
		node* next;
public:
	node(void);
	node(int);
	~node(void);
	friend class danhsach;
	node* TaoNode(int);
};

