#ifndef __CBulletMechanicalAlien_H__
#define __CBulletMechanicalAlien_H__

#include "CBullet.h"

class CBulletMechanicalAlien : public CBullet
{
public:
	CBulletMechanicalAlien(void);
	CBulletMechanicalAlien(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset);
	CBulletMechanicalAlien(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction);
	~CBulletMechanicalAlien(void);
public:
	virtual void MoveUpdate(float DeltaTime);
	virtual std::string ClassName(){ return __CLASS_NAME__(CBulletMechanicalAlien); };
	virtual void Update(float DeltaTime);
	virtual void Update(float DeltaTime, std::vector<CGameObject*>* _listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void SetFrame();
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();
	virtual Box GetBox();
protected:
	virtual void Init(); // khoi tao vi tri ban dau cua vien dan.
	D3DXVECTOR2 m_offset;//Vi tri cua vien dan so voi Sung
	double m_rotation;//Goc ban dan
	double m_timeDelay;
};

#endif // !__CBulletMechanicalAlien_H__
