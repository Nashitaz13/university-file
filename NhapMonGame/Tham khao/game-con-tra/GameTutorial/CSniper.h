#ifndef __CSNIPER_H__
#define __CSNIPER_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CBulletN.h"
#include "CEnemyEffect.h"

enum SNIPER_SHOOT_STATE
{
	SN_IS_SHOOTING_DOWN = 0,
	SN_IS_SHOOTING_UP = 1,
	SN_IS_SHOOTING_NORMAL = 2,
	SN_IS_SHOOTING_DIAGONAL_UP = 3,
	SN_IS_SHOOTING_DIAGONAL_DOWN = 4,
	SN_IS_HIDING = 5,
	SN_IS_DIE = 6
};

class CSniper : public CStaticObject, public CAnimation
{
public:
	CSniper(void);
	CSniper(const std::vector<int>& info);
	~CSniper();
	std::string ClassName(){return __CLASS_NAME__(CSniper);};
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	void Init();
	void BulletUpdate(float deltaTime);
	SNIPER_SHOOT_STATE m_stateCurrent;
	void SetFrame(float deltaTime);
	bool m_isShoot;
	//Tham so dung de test
public:
	// Hieu ung no
	CEnemyEffect* effect;

	int m_bulletCount; //So luong vien dan da ban ra
	float m_timeDelay;
	float m_waitForChangeSprite;
	float m_waitForShoot;
};

#endif // !__CSNIPER_H__
