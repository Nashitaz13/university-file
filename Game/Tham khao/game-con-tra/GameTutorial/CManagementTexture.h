#ifndef __CMANAGEMENT_TEXTURE_H__
#define __CMANAGEMENT_TEXTURE_H__

#include "CGlobal.h"
#include "CSingleton.h"
#include "CTexture.h"
#include <hash_map>

/**
 Lop nay dung de quan ly tat ca cac resource trong Game
 Noi dung:
	+ Cac phuong thuc cho phep add resource vao
	+ Cac phuong thuc get resource
	+ ...
*/

#define __Texture_Path__ "..\\Resource\\Contra\\..PNG";

class CManagementTexture : public CSingleton<CManagementTexture>
{
	friend class CSingleton<CManagementTexture>;
public:
	~CManagementTexture();
	CTexture* GetTextureByID(int id, int idType); //Lay mot CTexture theo ID cua Object
	void LoadAllResourceFromFile(const std::string&); //Dung de load tat ca cac duong dan cua cac file
protected:
	CManagementTexture();
	std::hash_map<int, std::hash_map<int, CTexture*>*>* m_listTexure; //Dung de luu tat cac texture trong Game
	std::hash_map<int, CTexture*>*& LoadAllTextureFromFile(const std::string&); //Khoi tao texture, va luu vao trong list
};

#endif // __CMANAGEMENT_TEXTURE_H__!
