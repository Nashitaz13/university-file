#ifndef __CLifeItem_H__
#define	__CLifeItem_H__

#include "CStaticObject.h"
#include "CSingleton.h"
#include "CTexture.h"
#include "CSprite.h"


#define __Life_Item__ "..\\Resource\\Image\\Object\\Bullet\\LifeItem.png"
class CLifeItem : public CSingleton<CLifeItem>
{
public:
	CLifeItem(void);
	std::string ClassName(){ return __CLASS_NAME__(CLifeItem); };
	~CLifeItem();
	void Draw(); //
	void Update(float deltaTime);
	D3DXVECTOR3 GetPos();
	void SetPos(D3DXVECTOR3 pos);
	void SetAlive(bool);
protected: 
	void Init();
	D3DXVECTOR3 m_pos;
	CTexture* m_imageCurr; //Lay texture trong bo dem, can dung lop managertexture
	CSprite* m_drawImg; //Dung de ve anh len man hinh, can dung lop managerSprite
	bool m_isAlive;
};
#endif