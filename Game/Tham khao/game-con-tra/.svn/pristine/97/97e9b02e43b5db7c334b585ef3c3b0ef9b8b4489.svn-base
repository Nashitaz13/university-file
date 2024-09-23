#include "CLoadBackGround.h"
#include "CFileUtil.h"
#include "CCamera.h"
#include "CDrawObject.h"

CLoadBackGround::CLoadBackGround()
{
	this->m_listEffectBackground = new std::hash_map<int, CEffect_Background*>();
	this->m_listBackGroundImage = new std::hash_map<int, std::string>();
	this->m_listBackGroundMatrix = new std::hash_map<int, std::string>();
	this->m_listQuadTree = new std::hash_map<int, std::string>();
	this->m_imageCurr = new CTexture();
	this->m_drawImg = new CSprite();
	this->m_quadTree = new CQuadTree();
	this->m_matrix = nullptr;
	this->m_cols = 0;
	this->m_rows = 0;
	this->m_idCurrent = 10;
}

CLoadBackGround::~CLoadBackGround()
{
	this->DeleteMatrix();
}

void CLoadBackGround::Draw()
{
	RECT rectRS;
	D3DXVECTOR3 pos;
	//if(this->m_listBackGroundMatrix)
	//	this->m_matrix = this->m_listBackGroundMatrix->find(this->m_idCurrent)->second;
	if(this->m_matrix != nullptr)
	{
		std::vector<int> listIDObj;
		this->m_quadTree->GetListObjectOnScreen(CCamera::GetInstance()->GetBound(),
													this->m_quadTree->GetRoot(),
													listIDObj);
		if(!listIDObj.empty())
		{
			int size = listIDObj.size();
			int row;
			int col;
			D3DXVECTOR3 posCenter;
			for (int i = 0; i < size; i++)
			{
				row = listIDObj.at(i) / this->m_cols;
				col = listIDObj.at(i) % this->m_cols;
				//Ve tung tile len man hinh
				rectRS.left = (this->m_matrix[row][col] % this->m_tileCols) * this->m_tileWidth;
				rectRS.right = rectRS.left + this->m_tileWidth;
				rectRS.top = (this->m_matrix[row][col] / this->m_tileCols) * this->m_tileHeight;
				rectRS.bottom = rectRS.top + this->m_tileHeight;
				pos.x = col * this->m_tileHeight;
				pos.y = (this->m_rows - row - 1) * this->m_tileWidth;
				pos.z = 0;
				//Lay toa do tam
				posCenter.x = pos.x + this->m_tileWidth/2;
				posCenter.y = pos.y + this->m_tileHeight/2;
				posCenter.z = 0;
				//Transform
				posCenter = CCamera::GetInstance()->GetPointTransform(posCenter.x, posCenter.y);
				//Lay toa do de ve sau khi transform
				pos.x = posCenter.x -  this->m_tileWidth/2;
				pos.y = posCenter.y - this->m_tileHeight/2;
				this->m_drawImg->draw(this->m_imageCurr, &rectRS, pos, D3DCOLOR_XRGB(255,255,225), false);
			}
		}

		//Ve hieu ung ra man hinh
		if (this->m_backGroundEffectCurr)
		{
			CDrawObject::GetInstance()->Draw(this->m_backGroundEffectCurr);
		}
	

		//for (int i = 0; i < this->m_rows; i++)
		//{
		//	for (int j = 0; j < this->m_cols; j++)
		//	{
		//		//Ve tung tile len man hinh
		//		rectRS.left = (this->m_matrix[i][j] % this->m_tileCols) * this->m_tileWidth;
		//		rectRS.right = rectRS.left + this->m_tileWidth;
		//		rectRS.top = (this->m_matrix[i][j] / this->m_tileCols) * this->m_tileHeight;
		//		rectRS.bottom = rectRS.top + this->m_tileHeight;
		//		pos.x = j * this->m_tileHeight;
		//		pos.y = (this->m_rows - i) * this->m_tileWidth;
		//		pos.z = 0;
		//		pos = CCamera::GetInstance()->GetPointTransform(pos.x, pos.y);
		//		this->m_drawImg->draw(this->m_imageCurr, &rectRS, pos, D3DCOLOR_XRGB(255,255,225), false);
		//	}
		//}
	}
}

void CLoadBackGround::LoadAllResourceFromFile()
{
	LoadAllTextureFromFile(__Level_Image__);
	LoadAllMatrixFromFile(__Level_Map__);
	LoadAllQuadTreeFromFile(__Level_QuadTree__);
	CreateBackGroundEffect();
}

void CLoadBackGround::LoadAllTextureFromFile(std::string filePath)
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
		//m_imageCurr = new CTexture();
		/*if((m_imageCurr->LoadImageFromFile(pathItem, NULL)));
		{
			this->m_listBackGroundImage->insert(Pair(mapID, m_imageCurr));
		}*/
		this->m_listBackGroundImage->insert(Pair(mapID, pathItem));
	}
}

void CLoadBackGround::LoadAllMatrixFromFile(std::string filePath)
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
		//this->LoadMatrix(pathItem);
		this->m_listBackGroundMatrix->insert(Pair(mapID, pathItem));
	}
}

//Load tat ca cac QuadTree tu file
void CLoadBackGround::LoadAllQuadTreeFromFile(std::string filePath)
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

void CLoadBackGround::ChangeBackGround(int idBackGround)
{
	//this->LoadMatrix(filePath); //Load lai noi dung cua matrix
	this->Clear();
	this->m_imageCurr = new CTexture();
	this->m_quadTree = new CQuadTree();
	this->m_idCurrent = idBackGround;
	if(this->m_listBackGroundImage != nullptr)
	{
		//Kiem tra danh sach matrix
		std::hash_map<int, std::string>::iterator it1 = this->m_listBackGroundMatrix->find(idBackGround);
		if(it1 != this->m_listBackGroundMatrix->end())
		{
			this->LoadMatrix(it1->second);
		}
		//
		//Kiem tra danh sach duong dan background
		std::hash_map<int, std::string>::iterator it = this->m_listBackGroundImage->find(idBackGround);
		if(it != this->m_listBackGroundImage->end())
		{
			this->m_imageCurr->LoadImageFromFile(it->second, NULL);
			if(this->m_imageCurr)
			{
				this->m_tileCols = this->m_imageCurr->GetImageWidth() / this->m_tileWidth;
				this->m_tileRows = this->m_imageCurr->GetImageHeight() / this->m_tileHeight;
			}
		}
		//
		//Kiem tra danh sach quadtree
		std::hash_map<int, std::string>::iterator it2 = this->m_listQuadTree->find(idBackGround);
		if(it2 != this->m_listQuadTree->end())
		{
			this->m_quadTree->ReBuildQuadTree(it2->second);
		}

		//
		//Kiem tra danh sach Effect
		std::hash_map<int, CEffect_Background*>::iterator it3 = this->m_listEffectBackground->find(idBackGround);
		if (it3 != this->m_listEffectBackground->end())
		{
			this->m_backGroundEffectCurr = it3->second;
		}
		
	}
}

void CLoadBackGround::CreateBackGroundEffect()
{
	//Hien tai minh chi co 3 cai effect, nen chi tao 3 cai thoi, may hieu chinh cho nay di
	//Hinh nhu effect 1 vs 2 co 1 cot ma, phai ko 1, 3 chi co 1 cot, 2 hang, con 2 thi 3 cot 1 hang
	CEffect_Background* eff = new CEffect_Background();
	eff->Init(1, 2, 6528, 448, 0, 1, 1);
	eff->SetPos(D3DXVECTOR2(eff->GetWidth()/2, eff->GetHeight()/2));
	CEffect_Background* eff1 = new CEffect_Background();
	eff1->Init(3, 3, 512, 4352,0, 2, 2);
	eff1->SetPos(D3DXVECTOR2(eff1->GetWidth() / 2, eff1->GetHeight() / 2));
	CEffect_Background* eff2 = new CEffect_Background();
	eff2->Init(1, 2, 4224, 448, 0, 1, 3);
	eff2->SetPos(D3DXVECTOR2(eff2->GetWidth() / 2, eff2->GetHeight() / 2));
	typedef pair<int, CEffect_Background*> Pair;
	this->m_listEffectBackground->insert(Pair(10, eff));
	this->m_listEffectBackground->insert(Pair(11, eff1));
	this->m_listEffectBackground->insert(Pair(12, eff2));
}

void CLoadBackGround::Update(float deltaTime)
{
	if (this->m_backGroundEffectCurr)
		this->m_backGroundEffectCurr->Update(deltaTime);
}

bool CLoadBackGround::InitMatrix()
{
	if(this->m_cols != 0 && this->m_rows != 0)
	{
		this->m_matrix = new int*[this->m_rows];
		for (int i = 0; i < this->m_rows; i++)
		{
			this->m_matrix[i] = new int[this->m_cols]; 
		}
		return true;
	}
	return false;
}

void CLoadBackGround::LoadMatrix(std::string filePath)
{
	std::vector<std::string> value = CFileUtil::GetInstance()->LoadFromFile(filePath);
	std::vector<std::string> result; //Luu chuoi sau khi duoc cat
	for (int i = 0; i < value.size(); i++)
	{
		result = CFileUtil::GetInstance()->Split(value.at(i).c_str(), '\t');
		if(i == 0)
		{
			this->m_rows = std::atoi(result.at(0).c_str());
			this->m_cols = std::atoi(result.at(1).c_str());
			this->InitMatrix();
		}else if(i == 1)
		{
			this->m_tileWidth = std::atoi(result.at(0).c_str());
			this->m_tileHeight = std::atoi(result.at(1).c_str());
		}else
		{
			for (int j = 0; j < result.size(); j++)
			{
				this->m_matrix[i-2][j] = atoi(result.at(j).c_str());
			}
		}
	}
}

void CLoadBackGround::DeleteMatrix()
{
	if(this->m_matrix != nullptr)
	{
		for (int i = 0; i < this->m_rows; i++)
		{
			delete this->m_matrix[i];
		}
		delete this->m_matrix;
		this->m_matrix = nullptr;
	}
}

void CLoadBackGround::Clear()
{
	if(this->m_matrix)
		this->DeleteMatrix();
	if(this->m_quadTree)
	{
		this->m_quadTree->Clear();
		this->m_quadTree =nullptr;
	}
	if(this->m_imageCurr)
	{	
		delete this->m_imageCurr;
		this->m_imageCurr = nullptr;
	}
}