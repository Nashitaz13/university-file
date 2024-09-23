#pragma once
class st
{
private: 
	int top,m; 
	int sta[100]; 
public:
	st(void);
	~st(void);
    int isempty();
    int isfull(); 
    void push(int a); 
    void pop(int &a);
    void print();
};

