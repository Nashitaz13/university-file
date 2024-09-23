#ifndef __CWALL_TURRET_H__
#define __CWALL_TURRET_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CBulletN.h"

enum WALLTURRET_SHOOT_STATE
{
	W_IS_SHOOTING_DOWN = 0,//ban xuong
	W_IS_SHOOTING_UP = 1,//ban len
	W_IS_SHOOTING_NORMAL = 2,//Ban ngang
	W_IS_SHOOTING_DIAGONAL_UP_X = 3,//len 30 do
	W_IS_SHOOTING_DIAGONAL_UP_2X = 4,//len 60 do
	W_IS_SHOOTING_DIAGONAL_DOWN_X = 5,//Xuongg 30 do
	W_IS_SHOOTING_DIAGONAL_DOWN_2X = 6,//xuong 60 do
	W_IS_SHOOTING_START = 7,
	W_IS_DIE = 8,
};

class CWallTurret : public CStaticObject, public CAnimation
{
public:
	CWallTurret(void);
	CWallTurret(const std::vector<int>& info);
	~CWallTurret();
	std::string ClassName(){return __CLASS_NAME__(CWallTurret);};
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	void Init();
	void BulletUpdate(float deltaTime);
	double GetShootAngle(D3DXVECTOR2 posContraFlowWT, double angleIncrease);
	void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	WALLTURRET_SHOOT_STATE m_stateCurrent;
	void SetFrame();
	bool m_isShoot;
	//Tham so dung de test
public:
	int m_bulletCount; //So luong vien dan da ban ra
	float m_timeDelay;
	float m_waitForShoot;
	double m_oldangle;
	double m_totalCurr;
	double m_space;
	bool m_direction;//quay sang ben trai hai phai
	bool m_IsCre;
	//test 
	double checkAngleContraAndWallTurret(D3DXVECTOR2, double);
	double round2(double);
};

#endif // !__CWALL_TURRET_H__
