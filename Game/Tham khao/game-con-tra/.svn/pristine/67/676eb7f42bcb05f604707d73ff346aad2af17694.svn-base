#ifndef __CBulletScubaSolider_H__
#define __CBulletScubaSolider_H__

#include "CBullet.h"

class CBullet_ScubaSolider : public CBullet
{
public:
	CBullet_ScubaSolider(void);
	CBullet_ScubaSolider(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset);
	CBullet_ScubaSolider(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction);
	~CBullet_ScubaSolider(void);
public:
	virtual void MoveUpdate(float DeltaTime);
	virtual std::string ClassName(){ return __CLASS_NAME__(CBullet_ScubaSolider); };
	virtual void Update(float DeltaTime);
	virtual void Update(float DeltaTime, std::vector<CGameObject*>* _listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();
	virtual Box GetBox();
	void SetIsFirstBullet(bool);
protected:
	virtual void Init(); // khoi tao vi tri ban dau cua vien dan.
	D3DXVECTOR2 m_offset;//Vi tri cua vien dan so voi Sung
	double m_rotation;//Goc ban dan
	bool m_isFirstBullet;	// co phai la vien dan dau tien k.
public:
	double m_time;
};

#endif // !__CBulletScubaSolider_H__
