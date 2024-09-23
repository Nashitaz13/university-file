#include "Quadtree.h"
#include "World.h"
#include "GlobalObject.h"

#define FOR(v) for(int i = 0; i < v; ++i)
#define FORJ(v) for(int j = 0; j < v; ++j)
#define SAFE_RELEASE(ptr)	if(ptr){delete ptr; ptr = nullptr;}
#define NUM_OF_SUBNODE 4
#define NUM_OF_NODE_PER_ROW 3
#define NODE_MAX_OBJECT 50
#define RESOLUTION_WIDTH ViewPort->_Width // Buffer width.
#define RESOLUTION_HEIGHT ViewPort->_Height // Buffer height.
#define MIN(a, b)	(a > b ? b : a)
#define MAX(a, b)	(a > b ? a : b)

class Default
{
public:
	static bool checkIfBounded(const RECT* a, const RECT* b)
	{
		// Check overlapse
		if ((a->right < b->left)||  (a->left >b->right)
			|| (a->bottom > b->top) || (a->top < b->bottom))
		{
			return false;
		}
		return true;
	}
};

#pragma region Node

Node::Node()
{
	FOR(NUM_OF_SUBNODE)
		subNode_[i] = 0;
}


Node::Node(RECT* range) : range_(range)
{
	FOR(NUM_OF_SUBNODE)
		subNode_[i] = 0;
}


Node::Node(RECT* range, vector<BasicObject*>& objectList) : range_(range)
{
	this->assign(objectList);
}


Node::~Node()
{
	SAFE_RELEASE(range_);
}


// =====================================
// Name: Node:release()
// Desc: Delete all sub node from "this".
// De-recurred release method
// =====================================
void Node::release()
{
	vector<Node*> nodeList;
	nodeList.push_back(this);

	while (!nodeList.empty()) {
		if (nodeList.back()->subNode_[0] != 0) {

			Node* checkingNode = nodeList.back();
			nodeList.pop_back();

			FOR(NUM_OF_SUBNODE)
				nodeList.push_back(checkingNode->subNode_[i]);
			}
		else {
			SAFE_RELEASE(nodeList.back());
			nodeList.pop_back();
		}
	}
}


// Phan vector object duoc truyen vao vao cac node con.
// Phuong thuc da duoc khu de quy.
// =====================================
void Node::assign(vector<BasicObject*>& objectList)
{
	// List hỗ trợ khử đệ quy
	// 1. Node hiện hành là Node cuối cùng của List (nodeList.back())
	// 2. Khi đã kết thúc xử lý ở Node hiện hành, remove Node đó ra khỏi List (nodeList.pop_back())
	// 3. Quay lại tiếp tục xử lý ở Node cuối cùng của List
	vector<Node*> nodeList;

	/// 1. Xử lý trên Node cuối cùng của List (nodeList.back())
	nodeList.push_back(this);

	// Lập vòng lặp xử lý trên nodeList
	while (true) {

	AGAIN:
		// Kiểm tra các object trong list object có overlap với Node hiện hành hay k
		// Thêm toàn bộ object overlap với Node hiện hành vào list object của Node đó
		FOR(objectList.size())
			if (Default::checkIfBounded(nodeList.back()->range_, &objectList[i]->getRECT()))
			{
				// Thêm object vào list object của Node hiện hành
				nodeList.back()->nodeObjects_.push_back(objectList[i]);
			}

		if (nodeList.back()->isSplitable()) {

		PARENT_SPLIT:
			// Bắt đầu khởi tạo Node con với khung bao tương ứng
			// Mỗi Node con đều được phân phối object vào trong nó từ listObject của Node hiện hành
			FOR(NUM_OF_SUBNODE)
				if (nodeList.back()->subNode_[i] == 0) {
				nodeList.back()->subNode_[i] = new Node(caculateSubNodeRange(i, *nodeList.back()->range_));
				objectList = nodeList.back()->nodeObjects_;			// Lấy list object của node hiện hành phân phối vào node con
				nodeList.push_back(nodeList.back()->subNode_[i]);	// Thêm node con vào cuối List để tiếp tục xét.
				goto AGAIN;
				}
			// Kiểu gì sau khi toàn bộ list object của Node hiện hành cũng sẽ được phân phối hết vào 4 node con
			// Nên có thể yên tâm làm empty list object của Node hiện hành
			nodeList.back()->nodeObjects_.clear();
		}
		// Kết thúc xử lý với Node hiện hạnh, loại bỏ nó ra khỏi nodeList
		nodeList.pop_back();

		// Tiếp tục xử lý với Node cuối của nodeList nếu còn node
		if (nodeList.size() == 0)
			break;
		else
			goto PARENT_SPLIT;
	}

}

// Thêm một object vào Node
void Node::ThemObjectVaoNode(Node *node, BasicObject* ob, bool _ThemVaoSau)
{
	vector<Node*> nodeList;
	nodeList.push_back(this);
	while (true) {

		Node* checkingNode = nodeList.back();
		// Nếu ob nằm trong khung bao của Node thì tiếp tục xử lý
		if (Default::checkIfBounded(checkingNode->range_, &ViewPort->getRECT()))
		{
			if (checkingNode->subNode_[0] != 0)
			{
				nodeList.pop_back();
				FORJ(NUM_OF_SUBNODE)
					nodeList.push_back(checkingNode->subNode_[j]);
			}
			else
			{
				
				if (_ThemVaoSau)
					nodeList[0]->nodeObjects_.push_back(ob);
				else
					nodeList[0]->nodeObjects_.insert(nodeList[0]->nodeObjects_.begin(), ob);
				return;
			}

		}
		else nodeList.pop_back();

		if (!nodeList.empty())
			continue;
	}	
}

/// Xóa object khỏi Node
void Node::XoaObjectKhoiNode(BasicObject* ob)
{
	vector<Node*> nodeList;
	nodeList.push_back(this);
	while (true) {

		Node* checkingNode = nodeList.back();
		// Nếu ob nằm trong khung bao của Node thì tiếp tục xử lý
		if (Default::checkIfBounded(checkingNode->range_, &ViewPort->getRECT()))
		{
			if (checkingNode->subNode_[0] != 0)
			{
				nodeList.pop_back();
				FORJ(NUM_OF_SUBNODE)
					nodeList.push_back(checkingNode->subNode_[j]);
			}
			else
			{
				for (int k = 0; k < nodeList.size(); k++)
				{
					FOR(nodeList[k]->nodeObjects_.size()) {
						vector<BasicObject*>* checkingList = &nodeList[k]->nodeObjects_;
						if (checkingList->at(i) == ob)
						{
							checkingList->erase(checkingList->begin() + i);
							return;
						}
					}
				}
				
			}
				
		}
		else nodeList.pop_back();
			
		if (!nodeList.empty())
			continue;
	}
}

// Lay ve tat ca cac object chua trong "this" 
// va cac [node con cua "this" - co cham voi viewport cua camera , thong qua "cameraRange"]
// =====================================
vector<BasicObject*> Node::getObjects(const RECT& cameraRange)
{
	vector<Node*> nodeList;
	nodeList.push_back(this);
	vector<BasicObject*> result;

	while (true) {

		Node* checkingNode = nodeList.back();

		// If the node range is bounded with current camera view port.
		if (Default::checkIfBounded(&cameraRange, checkingNode->range_)) {

			// If it have the sub nodes.
			if (checkingNode->subNode_[0] != 0)
				#pragma region Replace the node by it subnodes
			{
				nodeList.pop_back();
				FORJ(NUM_OF_SUBNODE)
					nodeList.push_back(checkingNode->subNode_[j]);
			}
#pragma endregion
			else
				#pragma region Add storing objects into result list
			{

				for (int k = 0; k < nodeList.size();k++)
				{
					FOR(nodeList[k]->nodeObjects_.size()) {
						vector<BasicObject*>* checkingList = &nodeList[k]->nodeObjects_;
						if (checkingList->at(i) != 0)
						{
							
							result.push_back(checkingList->at(i));
						}
						else {
							checkingList->erase(checkingList->begin() + i);
							i--;
						}
					}
				}
				return result;
			}
#pragma endregion

		}
		else nodeList.pop_back();

		if (!nodeList.empty())
			continue;

		return result;
	}
}

// Kiem tra lieu node hien tai co the chia nho duoc nua hay khong.
bool Node::isSplitable()
{
	LONG node_W = range_->right - range_->left;
	LONG node_H = range_->top - range_->bottom;

	bool tooManyObject = nodeObjects_.size() > NODE_MAX_OBJECT;
	bool sizeBigEnough = MIN(node_W, node_H) > (NUM_OF_NODE_PER_ROW* MAX(RESOLUTION_WIDTH, RESOLUTION_HEIGHT));
	return (tooManyObject && sizeBigEnough);

}
// Kiểm tra boundary của node có thể split được nữa k
bool Node::isEnoughBoundary()
{
	LONG node_W = range_->right - range_->left;
	LONG node_H = range_->top - range_->bottom;
	return MIN(node_W, node_H) > (NUM_OF_NODE_PER_ROW * MAX(RESOLUTION_WIDTH, RESOLUTION_HEIGHT));
}

// Tính khung bao của Node con tương ứng với index của nó.
RECT* Node::caculateSubNodeRange(int index, const RECT& baseRect)
{
	RECT* result = new RECT();
	LONG node_W = (baseRect.right - baseRect.left) / NUM_OF_NODE_PER_ROW;
	LONG node_H = (baseRect.top - baseRect.bottom) / NUM_OF_NODE_PER_ROW;

	result->left = baseRect.left + node_W * (index % NUM_OF_NODE_PER_ROW);
	result->right = result->left + node_W;
	result->bottom = baseRect.bottom + node_H * (index / NUM_OF_NODE_PER_ROW);
	result->top = result->bottom + node_H;
	int a = ViewPort->_Width;
	int b = ViewPort->_Height;
	return result;
}

#pragma endregion

#pragma region Tree

QuadTree::QuadTree()
{
}

// Tao quadtree voi kich thuoc nhu "range".
// Luu y: "range" phai la hinh vuong va bao het map.
QuadTree::QuadTree(RECT* range)
{
	root_ = new Node(range);
}


QuadTree::~QuadTree()
{
	root_->release();
	SAFE_RELEASE(root_);
}

// Assign cac object vao quadtree.
void QuadTree::assign(vector<BasicObject*>& objectList)
{
	assignedObjects_ = objectList;
	root_->assign(objectList);
}

// Lay tat ca cac object tu cac node con co "range" cham voi viewport cua camera
void QuadTree::getListObject(RECT range)
{
	// Lay object tu cac node con.
	vector<BasicObject*> drawObjects = root_->getObjects(range);
	vector<BasicObject*> temp;
	range = FixCamera();
	// Loai bo cac object duoc lay len nhung khong xuat hien trong viewport cua camera.
	FOR(drawObjects.size())
		if (Default::checkIfBounded(&range, &(drawObjects[i]->BasicObject::getRECT())) || drawObjects[i]->type == Type::ot_ground)
			temp.push_back(drawObjects[i]);

	prelistObject = drawObjects;
	listObject = temp;
}
RECT QuadTree::FixCamera()
{
	float l = ViewPort->_X - (ViewPort->_Width / 4);
	float t = ViewPort->_Y;
	float r = ViewPort->_X + ViewPort->_Width + (ViewPort->_Width / 4);
	float b = ViewPort->_Y - ViewPort->_Height;
	RECT temp = { l,t,r,b };
	return temp;
}
void QuadTree::ThemObjectVaoQuadtree(BasicObject* ob, bool _ThemVaoSau)
{
	root_->ThemObjectVaoNode(root_, ob, _ThemVaoSau);
}


QuadTree* quadtree;
#pragma endregion