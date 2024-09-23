#ifndef __CGAMEOBJECT__H__
#define __CGAMEOBJECT__H__

#include "CGlobal.h"

enum LAYER
{
	PLAYER = 0,
	ENEMY = 1
};

class CGameObject
{
protected:
	int m_id;//each object has a ID to identified with other object
	int m_idType; // Thuoc loai doi tuong nao
	int m_idImage;
	D3DXVECTOR2 m_pos;//position of object
	float m_posZ;//xet thang nao ve tren. mac dinh  = 0
	bool m_isALive;//life or die??
	int m_height;//height of object and uses to draw.
	int m_width;

	bool m_isAnimatedSprite;//default = false, but when object iherit IAnimatedSprite-> True;
	bool m_left;//Direction. Default left
	RECT *m_rectRS;//NULL if object hasn't animated sprite
	LAYER m_layer; //Doi tuong thuoc mot trong 2 lop: player, enemy
	RECT m_rect;//xen trong Quadtree
	// Mau cua doi tuong
	int m_HP;
public:
	std::vector<CGameObject*> m_listBullet;
	bool m_allowShoot;

	// TT
	int m_countEffect; // Gioi han so lan xuat hien hieu ung effect
public:
	virtual std::string ClassName() = 0;
	CGameObject(void);
	CGameObject(const std::vector<int>& info);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision) = 0;
	virtual D3DXVECTOR2 GetPos(){ return this->m_pos; };
	virtual LAYER GetLayer(){return this->m_layer;};
	virtual void SetLayer(LAYER layer){this->m_layer = layer;};
	int GetID(){ return this->m_id; };
	int GetIDType(){ return this->m_idType; };
	bool GetDirection(){ return this->m_left; };
	int GetWidth(){ return this->m_width; };
	int GetHeight(){ return this->m_height; };
	bool IsAlive(){ return this->m_isALive; };
	/*virtual void SetPos(D3DXVECTOR2 pos){
		this->m_pos = pos;
	};
	virtual void SetAlive(bool isAlive){ this->m_isALive = isAlive; };*/

	virtual void SetPos(D3DXVECTOR2 pos);
	virtual void SetAlive(bool alive);
	virtual void SetLeft(bool left);
	virtual Box GetBox();
	virtual RECT* GetBound();
	virtual RECT* GetRectRS();
	~CGameObject(void);
};

#endif // !__OBJECT_GAME__H__