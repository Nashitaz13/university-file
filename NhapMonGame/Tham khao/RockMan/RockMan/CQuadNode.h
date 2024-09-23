//-----------------------------------------------------------------------------
// File: CQuadNode.h
//
// Desc: Định nghĩa lớp CQuadNode, cây tứ phân giúp duyệt đối tượng nhanh hơn
//
//-----------------------------------------------------------------------------
#ifndef _CQUAD_NODE_H_
#define _CQUAD_NODE_H_

#include <map>
#include <set>
#include <vector>
#include <algorithm>
#include <iostream>

#include "CGameObject.h"
#include "DSUtil.h"

using namespace std;

class CQuadNode
{
public:
	CQuadNode();
	//-----------------------------------------------------------------------------
	// Khởi tạo đối tượng CQuadNode với các đối số
	// + id: ID của node
	// + position: Vị trí góc trái trên của node
	// + size: Kích thước của node
	// + objectIDs: Danh sách các ID nằm trong node
	// + objects: Danh sách các đối tượng cần lọc dựa trên objects để đưa vào node
	//-----------------------------------------------------------------------------
	CQuadNode(int id, Vector2 position, Vector2 size, vector<int> objectIDs, map<int, CGameObject*> &objects);
	~CQuadNode();

	//-----------------------------------------------------------------------------
	// Lấy danh sách các đối tượng nằm trong vùng va chạm
	// + viewport: Vùng va chạm 
	// + objects: Danh sách các đối tượng nằm trong viewport
	//-----------------------------------------------------------------------------
	void GetObjectsIn(Rect viewport, vector<CGameObject*>* objects);

	void AddNode(CQuadNode* node);
	CBox GetBox();

private:
	CQuadNode* _nodeLT;			// Node con trái trên
	CQuadNode* _nodeRT;			// Node con phải trên
	CQuadNode* _nodeLB;			// Node con dưới trái
	CQuadNode* _nodeRB;			// Node con dưới phải

	vector<CGameObject*> _objects;	// Danh sách các đối tượng của node
	int		_id;				// ID của node
	Vector2 _position;			// Tọa độ trái trên của node
	Vector2 _size;				// Kích thước của node

};

#endif // !_CQUAD_NODE_H_