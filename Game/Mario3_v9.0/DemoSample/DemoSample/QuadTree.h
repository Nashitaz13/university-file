#ifndef __QUADTREE_H__
#define __QUADTREE_H__

#include "BasicObject.h"
//#include "GameDefaultConstant.h"
#include <vector>

using namespace std;

#pragma region Node

class Node
{
public:
	Node();
	Node(RECT* range);
	Node(RECT* range, vector<BasicObject*>& objectList);
	~Node();
	vector<vector<BasicObject*>> listobjectInNode;
	void assign(vector<BasicObject*>& objectList);
	vector<BasicObject*> getObjects(const RECT& cameraRange);
	void release();
	void ThemObjectVaoNode(Node*, BasicObject*, bool);

	/// Xóa object kh?i Node
	void XoaObjectKhoiNode(BasicObject*);

private:
	bool isSplitable();
	bool isEnoughBoundary();
	RECT* caculateSubNodeRange(int index, const RECT& baseRect);

private:
	vector<BasicObject*> nodeObjects_;

	// Sub node indexes signed as
	// 2 3
	// 0 1
	Node* subNode_[4];

	RECT* range_;
};

#pragma endregion

#pragma region Tree

class QuadTree
{
public:
	Node* root_;
public:
	QuadTree();
	QuadTree(RECT* range);
	~QuadTree();

	void assign(vector<BasicObject*>& objectList);
	void getListObject(RECT);

	/// Thêm m?t object vào QuadTree
	/// true : them ob vao cuoi list, false: them ob vao dau list
	void ThemObjectVaoQuadtree(BasicObject*, bool);
private:
	vector<BasicObject*> assignedObjects_;
	RECT FixCamera();
};

extern QuadTree* quadtree;


#pragma endregion

#endif
