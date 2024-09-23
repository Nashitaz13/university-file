#ifndef __CLOAD_BACK_GROUND_H__
#define __CLOAD_BACK_GROUND_H__

#include "CGlobal.h"
#include "CSingleton.h"
#include "CTexture.h"
#include "CSprite.h"
#include <hash_map>
#include "CQuadTree.h"
#include "CEffectBackground.h"

#define __Level_Map__ "..\\Resource\\File\\BackGround\\MapBackGround.csv"
#define __Level_Image__ "..\\Resource\\File\\BackGround\\ImageBackGround.csv"
#define __Level_QuadTree__ "..\\Resource\\File\\BackGround\\QuadTreeBackGround.csv"

class CLoadBackGround : public CSingleton<CLoadBackGround> 
{
	friend class CSingleton<CLoadBackGround>;
public:
	~CLoadBackGround();
	void LoadAllResourceFromFile();
	void ChangeBackGround(int idBackGround);
	void Draw(); //
	void Update(float deltaTime);
protected:
	int m_idCurrent; //BackGround hien tai
	int** m_matrix; //Dung de luu lai ma tran
	int m_cols; //So cot ma tran
	int m_rows; //So dong ma tran
	int m_tileHeight; // Chieu rong cua tile
	int m_tileWidth; // Chieu dai cua tile
	int m_tileCols; //So luong tile tren chieu dai cua Image
	int m_tileRows; //So luong tile tren chieu rong cua Image
	CTexture* m_imageCurr; //Lay texture trong bo dem, can dung lop managertexture
	CSprite* m_drawImg; //Dung de ve anh len man hinh, can dung lop managerSprite
	CQuadTree* m_quadTree; // Luu quadtree hien tai
	CEffect_Background* m_backGroundEffectCurr; //Effect hien tai
	std::hash_map<int, CEffect_Background*>* m_listEffectBackground; //Su dung de luu danh sach cac hieu ung
	std::hash_map<int, std::string>* m_listQuadTree; //Su dung de luu danh sach quadtree
	std::hash_map<int, std::string>* m_listBackGroundImage; //Su dung de luu tat ca cac tileMap Image
	std::hash_map<int, std::string>* m_listBackGroundMatrix; //Su dung de luu tat ca cac tileMap Matrix
	void CreateBackGroundEffect();
	void LoadAllTextureFromFile(std::string);
	void LoadAllQuadTreeFromFile(std::string);
	void LoadAllMatrixFromFile(std::string);
	bool InitMatrix();
	void LoadMatrix(std::string filePath);
	void DeleteMatrix();
	void Clear(); //Xoa noi dug hien tai
	CLoadBackGround();
};

#endif // !__CLOAD_BACK_GROUND_H__
