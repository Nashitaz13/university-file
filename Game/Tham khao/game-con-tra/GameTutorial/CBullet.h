#ifndef __CBULLET_H__
#define __CBULLET_H__

#include "CDynamicObject.h"
#include "CAnimation.h"

enum SHOOT
{
	IS_NORMAL = 0,
	IS_UP = 1,
	IS_DOWN = 2,
	IS_DIAGONAL_UP = 3,
	IS_DIAGONAL_DOWN = 4
};


class CBullet : public CDynamicObject, public CAnimation
{
public:
	CBullet(void);
	CBullet(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset);
	CBullet(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction);
	~CBullet(void);
public:
	virtual void MoveUpdate(float DeltaTime);// overide IMOVE
	virtual std::string ClassName(){return __CLASS_NAME__(CBullet);};
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* _listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();
	virtual Box GetBox();
	void SetDirection(bool direction){this->m_left = direction;};
	void SetOffset(D3DXVECTOR2 offset){this->m_offset = offset;};
	void SetRotation(double rotation){this->m_rotation = rotation;};
	virtual void Init(); //Khoi tao vi tri ban dau cua vien dan
	bool m_isContra;
	void SetV(float _vx, float _vy);
protected:
	D3DXVECTOR2 m_offset; //Vi tri cua vien dan so voi contra
	double m_rotation; //Goc ban
};

#endif // !__CBULLET_H__
