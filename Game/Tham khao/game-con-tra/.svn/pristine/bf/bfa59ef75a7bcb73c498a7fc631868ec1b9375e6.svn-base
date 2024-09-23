#include "CLoadGameObject.h"
#include "CFileUtil.h"
#include "CCamera.h"
#include "CDrawObject.h"
#include "CFactoryDynamicObject.h"
#include "CFactoryStaticObject.h"
#include <algorithm> 

CLoadGameObject::CLoadGameObject()
{
	this->m_listGameObject = new std::vector<CGameObject*>();
	this->m_listQuadTree = new std::hash_map<int, std::string>();
	this->m_listAllGameObject = new std::hash_map<int,std::string>();
	this->m_quadTree = new CQuadTree();
}

void CLoadGameObject::LoadReSourceFromFile()
{
	LoadQuadTreeFromFile(__QuadTree_Path__);
	LoadGameObjectFromFile(__Map_Path__);
}

void CLoadGameObject::LoadQuadTreeFromFile(const std::string& filePath)
{
	int mapID;
	std::string pathItem;
	typedef pair<int, std::string> Pair;
	std::vector<std::string> result = CFileUtil::GetInstance()->LoadFromFile(filePath); //Load tat ca cac duong dan tu nguon
	std::vector<std::string> item; //Lay tung item trong result
	for (int i = 0; i < result.size(); i++)
	{
		item = CFileUtil::GetInstance()->Split(result.at(i).c_str(), ',');
		mapID = atoi(item.at(0).c_str());
		pathItem = item.at(1).c_str();
		//Tao CTexture
		//this->m_quadTree->ReBuildQuadTree(pathItem);
		this->m_listQuadTree->insert(Pair(mapID, pathItem));
	}
}

//Xen trong quadtree va khoi tao doi tuong
void CLoadGameObject::CreateObjectOnScreen()
{
	// danh sach tam.
	std::vector<int> m_oldListIdObject;
	m_oldListIdObject.swap(this->m_listIdObject);
	this->m_listIdObject.clear();

	if(this->m_quadTree)
	{ 
		// Lay ra danh sach id cua doi tuong dinh voi viewPort.
		this->m_quadTree->GetListObjectOnScreen(CCamera::GetInstance()->GetBound(), 
			this->m_quadTree->GetRoot(),
			m_listIdObject); 

		if (m_listIdObject.size() != 0)
		{
			// Duyet qua tung phan tu cua d/s cac doi tuong tren man hinh..
			// Neu doi tuong trong ds moi nay
			// - Co trong moi + co trong cu => thuc hien update
			// - Moi co + cu k co => thuc hien ve doi tuong do ra
			// - Moi k co + cu co => xoa doi tuong ra khoi d/s can ve

			// xoa dt khoi d/s
			vector<CGameObject*>::iterator it;

			// Duyet moi trong cu
			for (int j = 0; j < m_oldListIdObject.size(); j++)
			{
				// List moi co, ma cu k co
				// Thuc hien xoa doi tuong khoi node.
				if (!contains(m_listIdObject, m_oldListIdObject.at(j)))
				{
					for (it=m_listGameObject->begin(); it!=m_listGameObject->end();)
					{
						if (*it == this->m_listObjectCurr.find(m_oldListIdObject.at(j))->second)
						{
							//Xoa doi tuong cu ra khoi danh sach.
							it = this->m_listGameObject->erase(it);
						}
						else
							++it;
					}
				}
			}

			// Duyet cu trong moi
			for (int i = 0; i < m_listIdObject.size(); i++)
			{
				// m_listIdObject la ds moi
				// m_oldListIdObject la ds cu.

				// Co trong moi nhung k ton tai trong cu
				if (!contains(m_oldListIdObject, m_listIdObject.at(i)))
				{
					//NO bo cho nay sau khi goi change map no trung doi tuong
					// Them doi tuong vao d/s
					if(this->m_listObjectCurr.find(m_listIdObject.at(i)) != this->m_listObjectCurr.end())
					{
						this->m_listGameObject->push_back(this->m_listObjectCurr.find(m_listIdObject.at(i))->second);
					}
					else
					{
						int count =0;
					}

					// Ve no ra
					this->Draw();
				} 
				else // Co trong cu, va co trong moi, thuc hien update
				{
					// Ve no ra
					//this->Draw();
				}

			}
		}
	}

}

// tt
bool CLoadGameObject::contains(std::vector<int> v, int x)
{
	if(std::find(v.begin(), v.end(), x) != v.end()) {
		/* v contains x */
		return true;
	} else {
		/* v does not contain x */
		return false;
	}
}

CGameObject* CLoadGameObject::CreateObject(const std::vector<int>& info)
{
	if(!info.empty())
	{
		int idObj = info.at(0);
		int idTypeObj = idObj / 1000;
		switch (idTypeObj)
		{
		case 12:
			{
				return CFactoryDynamicObject::GetInstance()->CreateObject(info);
				break;
			}
		case 11: case 13: case 14: case 15: case 16: case 17:
			{
				return CFactoryStaticObject::GetInstance()->CreateObject(info);
				break;
			}
		default:
			break;
		}
	}
}

//Kiem tra neu doi tuong nao trong list ko ton tai trong man hinh thi xoa di
void CLoadGameObject::DeleteObjectOutScreen(float deltaTime)
{
	//if(this->m_listGameObject)
	//{
	//	CGameObject* gameObj;
	//	std::vector<int> lisObjectInfo;
	//	int size = 0;
	//	int idObject;
	//	bool allowErase = true;
	//	for (std::hash_map<int, CGameObject*>::iterator it = this->m_listGameObject->begin(); 
	//			it != this->m_listGameObject->end();
	//			++it)
	//	{
	//		size = this->m_listIdObject.size();
	//		if(size != 0)
	//		{
	//			idObject = it->first;
	//			allowErase = true;
	//			for (int i = 0; i < size; i++)
	//			{
	//				if(this->m_listIdObject.at(i) == idObject)
	//				{
	//					allowErase = false;
	//					break;
	//				}
	//			}
	//			gameObj = it->second;
	//			if(allowErase)
	//			{
	//				gameObj->~CGameObject();
	//				//m_listGameObject->erase(it);
	//			}
	//			else
	//			{
	//				gameObj->Update(deltaTime);
	//			}
	//		}
	//		else
	//		{
	//			this->m_listGameObject->clear();
	//		}
	//		//lisObjectInfo = this->m_listInfoCurr.find(it->first)->second;
	//		//if(lisObjectInfo.empty())
	//		//{
	//		//	//Khong ton tai doi tuong do trong screen
	//		//	gameObj = it->second;
	//		//	gameObj->~CGameObject();
	//		//	m_listGameObject->erase(it);
	//		//}
	//		//else
	//		//{
	//		//	//Update doi tuong
	//		//	it->second->Update(deltaTime);
	//		//}
	//	}
	//}
}

void CLoadGameObject::Draw()
{
	if(this->m_listGameObject)
	{
		for (std::vector<CGameObject*>::iterator it = this->m_listGameObject->begin(); 
			it != this->m_listGameObject->end();
			++it)
		{
			CGameObject* gameObj = *it;
			if(gameObj && gameObj->IsAlive() && gameObj->GetIDType() != 14)
				CDrawObject::GetInstance()->Draw(gameObj);
		}
	}
}

// cai dat, cap nhat vi tri doi tuong trong quadtree.
void CLoadGameObject::Update(float deltaTime)
{
	this->CreateObjectOnScreen();
	//this->DeleteObjectOutScreen(deltaTime);
	//Update doi tuong
	if(this->m_listGameObject)
	{
		for (std::vector<CGameObject*>::iterator it = this->m_listGameObject->begin(); 
			it != this->m_listGameObject->end();
			++it)
		{
			CGameObject* gameObj = *it;
			gameObj->Update(deltaTime, this->m_listGameObject);
		}
	}
}

void CLoadGameObject::LoadGameObjectFromFile(const std::string& filePath) 
{
	this->m_listAllGameObject->clear();
	//
	int mapID;
	std::string pathItem;
	typedef pair<int, std::string> Pair;
	std::vector<std::string> result = CFileUtil::GetInstance()->LoadFromFile(filePath); //Load tat ca cac duong dan tu nguon
	std::vector<std::string> item; //Lay tung item trong result
	std::vector<std::string> data; //Luu du lieu lay len tu mot file
	for (int i = 0; i < result.size(); i++)
	{
		item = CFileUtil::GetInstance()->Split(result.at(i).c_str(), ',');
		mapID = atoi(item.at(0).c_str());
		pathItem = item.at(1).c_str();
		//Load thong tin info
		//std::hash_map<int, CGameObject*> listInfo = this->LoadGameObjectInfo(pathItem);
		this->m_listAllGameObject->insert(Pair(mapID, pathItem));
	}
}

std::hash_map<int, CGameObject*> CLoadGameObject::LoadGameObjectInfo(const std::string& filePath)
{
	std::hash_map<int, CGameObject*> listInfo;
	std::vector<std::string> data = CFileUtil::GetInstance()->LoadFromFile(filePath);
	std::vector<std::string> item;
	typedef pair<int, CGameObject*> Pair;
	if(!data.empty())
	{
		int size = data.size();
		int iDObjectInMap;
		for (int i = 0; i < size; i++)
		{
			CGameObject* gameObj;
			std::vector<int> info;
			item = CFileUtil::GetInstance()->Split(data.at(i).c_str(), '\t');
			if(!item.empty())
			{
				int sizeItem = item.size();
				int temp;
				iDObjectInMap = atoi(item.at(0).c_str());
				for (int j = 1; j < sizeItem; j++)
				{
					info.push_back(atoi(item.at(j).c_str()));
				}
				gameObj = this->CreateObject(info);
				listInfo.insert(Pair(iDObjectInMap, gameObj));
			}

		}
	}
	return listInfo;
}

void CLoadGameObject::ChangeMap(const int& idMap)
{
	//Xoa nhung doi tuong con trong viewport map truoc
	this->m_listIdObject.clear();
	//
	if(this->m_listQuadTree)
	{
		this->m_quadTree->Clear();
		this->m_quadTree = nullptr;
		this->m_quadTree = new CQuadTree();
		std::hash_map<int, std::string>::iterator it = this->m_listQuadTree->find(idMap);
		if(it != this->m_listQuadTree->end())
		{
			this->m_quadTree->ReBuildQuadTree(it->second);
		}
		else
		{
			throw;
		}
	}
	if(this->m_listAllGameObject)
	{
		this->m_listObjectCurr.clear();
		std::hash_map<int, std::string>::iterator it = this->m_listAllGameObject->find(idMap);
		if(it != this->m_listAllGameObject->end())
		{
			this->m_listObjectCurr = this->LoadGameObjectInfo(it->second);
		}
		else
		{
			throw;
		}
	}
}

void CLoadGameObject::Reset(const int& idMap)
{
	//Lam rong danh sach doi tuong trong listGameObject- cac doi tuong co tren man hinh
	if (this->m_listGameObject)
		m_listGameObject->clear();
	//
	if (this->m_listAllGameObject)
	{
		this->m_listObjectCurr.clear();
		std::hash_map<int, std::string>::iterator it = this->m_listAllGameObject->find(idMap);
		if (it != this->m_listAllGameObject->end())
		{
			this->m_listObjectCurr = this->LoadGameObjectInfo(it->second);
		}
		else
		{
			throw;
		}
	}
	//Load lai danh sach cac doi tuong tren man hinh
	// TT
	this->CreateObjectOnScreen();
	int x = 0;
}

CLoadGameObject::~CLoadGameObject()
{
	if(this->m_listGameObject)
		delete m_listGameObject;
	if(this->m_listAllGameObject)
		delete m_listAllGameObject;
	if(this->m_listQuadTree)
		delete m_listQuadTree;
}
