#include "CQuadNode.h"

struct IDGreater{
	bool operator()(CGameObject* lx, CGameObject* rx) const {
		return lx->_id < rx->_id;
	}
};

CQuadNode::CQuadNode()
{
	_nodeLT = NULL;
	_nodeRT = NULL;
	_nodeLB = NULL;
	_nodeRB = NULL;
}

CQuadNode::CQuadNode(int id, Vector2 position, Vector2 size, vector<int> objectIDs, map<int, CGameObject*> &objects)
{
	_nodeLT = NULL;
	_nodeRT = NULL;
	_nodeLB = NULL;
	_nodeRB = NULL;

	_id = id;
	_position = position;
	_size = size;

	// Lọc đối tượng và mang vào node
	for (int i = 0; i < objectIDs.size(); i++)
	{
		map<int, CGameObject*>::iterator re;
		re = objects.find(objectIDs[i]);

		if (re != objects.end())
			_objects.push_back(re->second);
	}
}

CQuadNode::~CQuadNode()
{
	SAFE_DELETE(_nodeLT);
	SAFE_DELETE(_nodeRT);
	SAFE_DELETE(_nodeLB);
	SAFE_DELETE(_nodeRB);
}

void CQuadNode::GetObjectsIn(Rect viewport, vector<CGameObject*>* objects)
{
	CBox thisBox = GetBox();
	CBox objBox;
	objBox._x = viewport.left;
	objBox._y = viewport.top;
	objBox._width = viewport.right - viewport.left;
	objBox._height = viewport.top - viewport.bottom;
	objBox._vx = objBox._vy = 0.0f;

	if (thisBox.IntersecWith(objBox))
	{
		// Nếu không có các node con, thêm các đối tượng hiện tại mà node đang giữ vào objects
		if (!_nodeLT && !_nodeRT&& !_nodeLB&&!_nodeRB)
		{
			if (_objects.size() > 0)
			{
				for (int i = 0; i < _objects.size(); i++)
				if (objBox.IntersecWith(_objects[i]->GetCollideRegion()))
					(*objects).push_back(_objects[i]);
				std::sort(objects->begin(), objects->end(), IDGreater());						// Sắp xếp lại các đối tượng
				objects->erase(std::unique(objects->begin(), objects->end()), objects->end());	// Xóa  các phần tử giống nhau trong danh sách
			}
		}
		else
		{
			_nodeLT->GetObjectsIn(viewport, objects);
			_nodeRT->GetObjectsIn(viewport, objects);
			_nodeLB->GetObjectsIn(viewport, objects);
			_nodeRB->GetObjectsIn(viewport, objects);
		}
	}
}

void CQuadNode::AddNode(CQuadNode* node)
{
	if (_id * 4 + 1 == node->_id)
	{
		_nodeRT = node;
		return;
	}
	if (_id * 4 + 2 == node->_id)
	{
		_nodeLT = node;
		return;
	}
	if (_id * 4 + 3 == node->_id)
	{
		_nodeLB = node;
		return;
	}
	if (_id * 4 + 4 == node->_id)
	{
		_nodeRB = node;
		return;
	}
	if (_nodeRT != NULL)
		_nodeRT->AddNode(node);

	if (_nodeRT != NULL)
		_nodeLT->AddNode(node);

	if (_nodeRB != NULL)
		_nodeRB->AddNode(node);

	if (_nodeLB != NULL)
		_nodeLB->AddNode(node);
}

CBox CQuadNode::GetBox()
{
	return CBox(_position.x, _position.y, _size.x, _size.y, 0.0f, 0.0f);
}