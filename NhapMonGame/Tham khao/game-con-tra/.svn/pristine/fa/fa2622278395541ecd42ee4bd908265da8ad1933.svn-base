#ifndef __CDEFENSE_CANNON_H__
#define __CDEFENSE_CANNON_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CSniperBoss.h"
#include "CDefenseCannonGun.h"
#include "CDefenseCannonTurret.h"


enum DEFENSE_CANNON_STATE
{
	DC_NORMAL = 0,//Ban dau
	DC_FIRE_ONE_GUN = 1,//Bi no 1 sung
	DC_FIRE_TWO_GUN = 2,//Bi no 2 sung
	DC_FIRE_TURRECT = 4,
	DC_IS_DIE = 11,//chet
	DC_IS_DIE_1 = 5,
	DC_IS_DIE_2 = 6,
	DC_IS_DIE_3 = 7,
	DC_IS_DIE_4 = 8,
	DC_IS_DIE_5 = 9,
	DC_IS_DIE_6 = 10,
	DC_GUNLEFT_DIE = 12,
	DC_GUNRIGHT_DIE = 13
};

class CDefenseCannon : public CStaticObject, public CAnimation
{
public:
	CDefenseCannon(void);
	CDefenseCannon(const std::vector<int>& info);
	~CDefenseCannon();
	std::string ClassName(){ return __CLASS_NAME__(CDefenseCannon); };
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
	//
	CSniperBoss* sniper;
	CDefenseCannonGun* gunLeft;
	CDefenseCannonGun* gunRight;
	CDefenseCannonTurret* turrect;
	//
protected:
	void Init();
	void BulletUpdate(float deltaTime);
	DEFENSE_CANNON_STATE m_stateCurrent;
	void SetFrame(float deltaTime);
	//Tham so dung de test
	int m_count;
	float m_timeCreateExplosion; //Thoi gian sinh hieu ung tiep theo
	float m_oldFrame; //Sprite truoc do;
public:
	////Phai co mot bien de giu nhung vien dan ma Boss da ban ra
	//std::vector<CBullet*> m_listBullet;
	//int m_bulletCount; //So luong vien dan da ban ra
	float m_timeDelay;
};
#endif // !__CDEFENSE_CANNON_H__