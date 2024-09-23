#include "conio.h"
#include "stdio.h"
#include "stdlib.h"
#include "iostream"

using namespace std;

typedef struct cautruccay
{
	int key;
	struct cautruccay *left;
	struct cautruccay *right;
}TNODE;

typedef TNODE * TREE;
//TNODE *root;
//khoi tao cay
void Create_tree(TREE &t)
{
	t = NULL;
}
//khoi tao 1 node
TNODE *Create_node(int x)
{
	TNODE *p = new TNODE;
	if (!p)
	{
		cout<<"\nKo du bo nho!";
		exit(1);
	}
	else
	{
		p->key = x;
		p->left = p->right =NULL;
	}
	return p;
}
//them 1 node tu 1 node da co cau truc 
int Insert_node(TREE &t,TNODE *x)
{
	if(t)
	{
		if(t->key == x->key)
			return 0;
		else
			if(t->key > x->key)
				return Insert_node(t->left,x);
			else 
				return Insert_node(t->right,x);
	}
	else
	{
		t = x;
		return 1;
	}
}
//them mot truong node vao cay
int Insert_tree(TREE &t,int x)
{
	if (t)
	{
		if(t->key == x)
			return 0;
		else
			if(t->key > x)
				return Insert_tree(t->left,x);
			else 
				return Insert_tree(t->right,x);
	}
	t = new TNODE;
	if(!t)
		return -1;
	t->key = x;
	t->left = t->right = NULL;
	return 1;
}
//tim mot node
TNODE *Search_node(TREE &t ,int x)
{
	int fount ;//tim thay
	TNODE *p = new TNODE;
	while (p && fount==0)
	{
		if(p->key == x)
			fount = 1;
		else
		{
			if(t->key >x)
				p = p->left;
			else
				p = p->right;
		}
	}
	return p;
}

/*TNODE *Recursive_search_node(TREE &t,int x)
{
	if (t)
	{
		if(t->key == x)
			return t;
		else
			if(t->key > x)
				return Recursive_search_node(t->left,x);
			else
				return Recursive_search_node(t->right,x);
	}
	return NULL;
}*/

//Nhap cay
void Input_tree(TREE &t)
{
	int x,i=1;
	do
	{
		cout<<"\nInput node at "<<i<<": ";
		cin>>x;
		if(x>0)
		{
			Insert_tree(t,x);
			i++;
		}
	} while (x>0);
}
//copy cay
void Copy_tree(TREE &t1,TREE &t)
{
	if (t)
	{
		Insert_tree(t1,t->key);
		Copy_tree(t1,t->left);
		Copy_tree(t1,t->right);
	}
}
//phan tu the mang
void Alternative(TREE &p,TREE &t)
{
	if (t->left)
	{
		Alternative(p,t->left);
	}
	else
	{
		p->key = t->key;
		p = t;
		t = t->right;
	}
}
//xoa mot node 
void Delete_node(TREE &t,int x)
{
	if (t)
	{
		if(t->key > x)
			Delete_node(t->left,x);
		else
			Delete_node(t->right,x);
	}
	else
	{
		TNODE *p;
		p = t;
		if(t->left == NULL)
			t = t->right;
		else
			if(t->right == NULL)
				t = t->left;
			else
				Alternative(p,t->right);
		delete p;
	}
}
//duyet thu tu truoc cay
void NLR_preorder(TREE &t)
{
	if (t)
	{
		cout<<"  "<<t->key;
		NLR_preorder(t->left);
		NLR_preorder(t->right);
	}
}
//duyet thu tu giua cay
void LNR_inorder(TREE &t)
{
	if (t)
	{
		LNR_inorder(t->left);
		cout<<"    "<<t->key;
		LNR_inorder(t->right);
	}
}
//duyet thu tu sau cay
void LRN_postorder(TREE &t)
{
	if (t)
	{
		LRN_postorder(t->left);
		LRN_postorder(t->right);
		cout<<"    "<<t->key;
	}
}
//xoa het cay
void Remove_all_tree(TREE &t)
{
	if (t)
	{
		Remove_all_tree(t->left);
		Remove_all_tree(t->right);
		delete t;
		t = NULL;
	}
}
//sao chep cay
void Copy_tree(TREE &t,TREE &t1)
{
	if (t)
	{
		Insert_tree(t1,t->key);
		Copy_tree(t->left,t1);
		Copy_tree(t->right,t1);
	}
}
//chieu cao cua cay
int Hight_tree(TREE &t)
{
	if (t)
	{
		if(Hight_tree(t->left) > Hight_tree(t->right))
			return Hight_tree(t->left)+1;
		else
			return Hight_tree(t->right)+1;
	}
	else
	{
		return 0;
	}
}
//in node co do cao la h
void In_node_hight(TREE &t,int h)
{
	if (t)
	{
		if(h<2)
			cout<<"   "<<t->key;
		else
		{
			In_node_hight(t->left,h-1);
			In_node_hight(t->right,h-1);
		}
	}
}
/*
lam them
dem node la
tim node la so nguyen to
xoa node la so nguyen to...
*/
int main()
{
	TREE t,t1;
	Create_tree(t);
	Create_tree(t1);
	/*
	viet tum lum het
	may thim tu viet lai nhe 
	"-"
	*/
	return 0;
}