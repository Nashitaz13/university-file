#ifndef __CBulletLaze_H__
#define __CBulletLaze_H__

#include "CBullet.h"


enum LAZE_STATE
{
	LAZ_IS_NORMAL = 0,
	LAZ_IS_DIE = 1
};
class CBulletLaze : public CBullet
{
public:
	CBulletLaze(void);
	CBulletLaze(const std::vector<int>& info);
	CBulletLaze(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset);
	CBulletLaze(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction);
	~CBulletLaze(void);
public:
	virtual void MoveUpdate(float DeltaTime);
	virtual std::string ClassName(){ return __CLASS_NAME__(CBulletLaze); };
	virtual void Update(float DeltaTime);
	virtual void Update(float DeltaTime, std::vector<CGameObject*>* _listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void SetFrame();
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();
	virtual Box GetBox();
	virtual void Init();
protected:
	// khoi tao vi tri ban dau cua vien dan.
	LAZE_STATE m_stateCurrent;
	D3DXVECTOR2 m_offset;//Vi tri cua vien dan so voi Sung
	double m_rotation;//Goc ban dan
	double m_timeDelay;
	float m_time;
};

#endif // !__CBulletLaze_H__
