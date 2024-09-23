#ifndef __CLOADGAMEOBJECT_H__
#define __CLOADGAMEOBJECT_H__

#include "CGlobal.h"
#include "CGameObject.h"
#include "CQuadTree.h"
#include "CSingleton.h"

#define __Map_Path__ "..\\Resource\\File\\Map\\LevelMap.csv"
#define __QuadTree_Path__ "..\\Resource\\File\\Map\\LevelQuadTree.csv"

class CLoadGameObject : public CSingleton<CLoadGameObject> 
{
	friend class CSingleton<CLoadGameObject> ;
public:
	CLoadGameObject();
	~CLoadGameObject();
	std::vector<CGameObject*>* GetListGameObjectOnScreen(){return this->m_listGameObject;};
	void CreateObjectOnScreen();
	void Draw();
	void LoadReSourceFromFile();
	void Update(float deltaTime);
	void ChangeMap(const int& );
	void Reset(const int&);
protected:
	//Luu danh sach doi tuong khi xen viewport

	// TT
	// Danh sach cac doi tuong dinh voi viewport.
	// Danh sach nay de ve doi tuong ra.
	std::vector<CGameObject*>* m_listGameObject;

	// D/s tat ca cac duong link chua file map.
	std::hash_map<int, std::string>* m_listAllGameObject;
	// hash map<stt cua man`, stt cua obj trong node, doi tuong game>

	// list quadtree
	std::hash_map<int, std::string>* m_listQuadTree;
	// <stt map, quadtree cua map>

	// List id cua doi tuong tren viewPort.
	std::vector<int> m_listIdObject;

	//Luu quad tree hien tai
	CQuadTree* m_quadTree;

	// d/s cac doi tuong cua map hien tai.
	std::hash_map<int, CGameObject*> m_listObjectCurr;

	void LoadQuadTreeFromFile(const std::string&);
	void LoadGameObjectFromFile(const std::string&);
	void DeleteObjectOutScreen(float deltaTime);
	CGameObject* CreateObject(const std::vector<int>&);
	std::hash_map<int, CGameObject*> LoadGameObjectInfo(const std::string&);

	// TT
	bool contains(std::vector<int> v, int x);

	int count = 0;
};

#endif // !__CLOADGAMEOBJECT_H__
