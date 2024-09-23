#ifndef __CGAME_OVER_ITEM_H__
#define __CGAME_OVER_ITEM_H__

#include "CStaticObject.h"
#include "CSingleton.h"
#include "CTexture.h"
#include "CSprite.h"

#define __Game_Over_Item__ "..\\Resource\\Image\\BackGround\\gameover.PNG"
class CGameOverItem : public CSingleton<CGameOverItem>
{
public:
	CGameOverItem(void);
	CGameOverItem(const std::vector<int>& info);
	~CGameOverItem();
	std::string ClassName(){ return __CLASS_NAME__(CGameOverItem); };
	void Draw(); 
	void SetPos(D3DXVECTOR3 pos);
protected:
	void Init();
	D3DXVECTOR3 m_pos;
	CTexture* m_imageCurr; //Lay texture trong bo dem, can dung lop managertexture
	CSprite* m_drawImg; //Dung de ve anh len man hinh, can dung lop managerSprite
public:
	float m_timeDelay;
};

#endif // !__CGAME_OVER_ITEM_H__
