#include "CManagementTexture.h"
#include "CFileUtil.h"

CManagementTexture::CManagementTexture()
{
	this->m_listTexure = new std::hash_map<int, std::hash_map<int, CTexture*>*>();
}

void CManagementTexture::LoadAllResourceFromFile(const std::string& filePath)
{
	int idObjectType;
	std::string pathItem;
	std::hash_map<int, CTexture*>* listTexureOfObject;
	typedef pair<int, std::hash_map<int, CTexture*>*> Pair;
	std::vector<std::string> result = CFileUtil::GetInstance()->LoadFromFile(filePath); //Load tat ca cac duong dan tu nguon
	std::vector<std::string> item; //Lay tung item trong result
	for (int i = 0; i < result.size(); i++)
	{
		item = CFileUtil::GetInstance()->Split(result.at(i).c_str(), ',');
		idObjectType = atoi(item.at(0).c_str());
		pathItem = item.at(1).c_str();
		//Xu ly
		listTexureOfObject = this->LoadAllTextureFromFile(pathItem);
		if(listTexureOfObject->size() > 0)
		{
			this->m_listTexure->insert(Pair(idObjectType, listTexureOfObject));
		}
	}
}

std::hash_map<int, CTexture*>*& CManagementTexture::LoadAllTextureFromFile(const std::string& fileItem)
{
	int idObject;
	std::string pathItem;
	CTexture* texture;
	std::hash_map<int, CTexture*>* listTexureOfObject = new std::hash_map<int, CTexture*>();
	typedef pair<int, CTexture*> Pair;
	std::vector<std::string> result = CFileUtil::GetInstance()->LoadFromFile(fileItem); //Load tat ca cac duong dan tu nguon
	std::vector<std::string> item; //Lay tung item trong result
	for (int i = 0; i < result.size(); i++)
	{
		item = CFileUtil::GetInstance()->Split(result.at(i).c_str(), ',');
		idObject = atoi(item.at(0).c_str());
		pathItem = item.at(1).c_str();
		//Tao CTexture
		texture = new CTexture();
		if((texture->LoadImageFromFile(pathItem, D3DCOLOR_XRGB(255,0,255))));
		{
			listTexureOfObject->insert(Pair(idObject, texture));
		}
	}
	return listTexureOfObject;
}

CTexture* CManagementTexture::GetTextureByID(int id, int idType)
{
	std::hash_map<int, hash_map<int, CTexture*>*>::iterator its = this->m_listTexure->find(idType);
	if(its != this->m_listTexure->end())
	{
		std::hash_map<int, CTexture*>* listTexure = its->second;
		if(listTexure->size() > 0)
		{
			std::hash_map<int, CTexture*>::iterator it = listTexure->find(idType* 1000 + id);
			if(it != listTexure->end())
			{
				CTexture* texture = it->second;
				if(texture)
				{
					return texture;
				}
			}
		}
	}
	return nullptr;
}

CManagementTexture::~CManagementTexture()
{
	if(this->m_listTexure != nullptr)
		delete m_listTexure;
}