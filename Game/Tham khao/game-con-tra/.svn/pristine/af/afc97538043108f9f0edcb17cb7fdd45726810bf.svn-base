#ifndef __CBOSSARM_H__
#define __CBOSSARM_H__

#include "CDynamicObject.h"
#include "CMove.h"
#include "CSubArm.h"

enum BOSS_ARM_STATE
{
	BAS_IS_POPUP = 0,
	BAS_IS_UP_DOWN = 1,
	BAS_IS_ROTATE = 2,
	BAS_IS_FLOW = 3,
	BAS_IS_DIE = 4
};
class CBossArm : public CDynamicObject
{
public:
	CBossArm(D3DXVECTOR2, bool);
	~CBossArm();
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void MoveUpdate(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual RECT* GetRectRS();
	virtual Box GetBox();
	virtual void Init();
	void Move(float curve, float deltaTime);
	void Draw();
public:
	/*CSubArm* subArmOne;
	CSubArm* subArmTwo;
	CSubArm* subArmThree;
	CSubArm* subArmFour;
	CSubArm* subArmFive;*/
	CSubArm** subArms;
	double vecIncreate;
	void SetAngle(float);
	//
protected:
	BOSS_ARM_STATE m_stateCurrent;
	float m_timeCurr;
	bool m_isChangeDirection; //Cuc dau tien doi huong, delay
	bool m_isArmLeft;//La canh tay ben trai
	D3DXVECTOR2 m_posOfBoss;
	float m_timeDelayUpDown;
	float m_timeDelayRotate;
	float m_timeDelayFlow;
	float m_timeDelay;
};

#endif // !__CBOSSARM_H__
