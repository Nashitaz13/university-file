#ifndef __CGAMEOBJECT__H__
#define __CGAMEOBJECT__H__

#include "CGlobal.h"
#include "Include.h"

class CGameObject
{
public:
	int m_id;//each object has a ID to identified with other object
	int m_idImage;
	D3DXVECTOR2 m_pos;//position of object
	float m_posZ;//xet thang nao ve tren. mac dinh  = 0
	bool m_isALive;//life or die??
	int m_height;//height of object and uses to draw.
	int m_width;

	bool m_isAnimatedSprite;//default = false, but when object iherit IAnimatedSprite-> True;
	bool m_left;//Direction. Default left
	RECT *m_rectRS;//NULL if object hasn't animated sprite

	RECT m_rect;//xen trong Quadtree

public:
	virtual std::string ClassName() = 0;
	CGameObject(void);
	CGameObject(std::vector<std::string> arr);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*> listObjectCollision);
	virtual D3DXVECTOR2 GetPos(){ return this->m_pos; };
	virtual RECT GetRect();
	virtual RECT* GetRectRS();
	~CGameObject(void);
};

#endif // !__OBJECT_GAME__H__