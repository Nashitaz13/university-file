#ifndef __CBulletF_H__
#define __CBulletF_H__

#include "CBullet.h"

class CBullet_F : public CBullet
{
public:
	CBullet_F(void);
	CBullet_F(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset);
	CBullet_F(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction);
	~CBullet_F();
	virtual void MoveUpdate(float DeltaTime);
	virtual std::string ClassName(){return __CLASS_NAME__(CBullet_F);};
	virtual void Update(float DeltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*> _listObjectCollision);
	virtual void OnCollision(float deltaTime, std::hash_map<int, CGameObject*>* listObjectCollision);
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();
	virtual Box GetBox();
	virtual void Init(); // khoi tao vi tri ban dau cua vien dan.
private:
	double m_angle;
	D3DXVECTOR2 m_center;
	double m_rotation;
	D3DXVECTOR2 m_offset;
};

#endif // !__CBulletF_H__
