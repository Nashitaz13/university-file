#ifndef __CSOLDIERSHOOT_H__
#define __CSOLDIERSHOOT_H__

#include "CDynamicObject.h"
#include "CAnimation.h"

enum SOLDIER_SHOOT_STATE
{
	SS_IS_JOGGING = 0, //Chay
	SS_IS_STANDING = 1, //Dung lai va ban dan
	SS_IS_JUMP = 2, // Nhay
	SS_IS_DIE = 3
};

class CSoldierShoot : public CDynamicObject, public CAnimation
{
public:
	CSoldierShoot(void);
	CSoldierShoot(const std::vector<int>& info);
	~CSoldierShoot();
	std::string ClassName(){ return __CLASS_NAME__(CSoldierShoot); };
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltatime, std::vector<CGameObject*>* listObjectCollision);
	virtual void MoveUpdate(float deltaTime);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
	void setJump(bool jump);
	void Init();
protected:
	void BulletUpdate(float deltaTime);
	SOLDIER_SHOOT_STATE m_stateCurrent;
	void SetFrame(float deltaTime);
	bool m_isShoot;
	//Tham so dung de test
	float m_waitForChangeSprite;
	bool m_jump;
	int m_countRepeat;
public:
	int m_bulletCount; //So luong vien dan da ban ra
	float m_timeDelay;
	float m_timeDelayBullet;
	bool m_flag;
};

#endif // !__CSOLDIERSHOOT_H__
