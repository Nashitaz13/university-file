#ifndef __CDefenseCannonGun_H__
#define __CDefenseCannonGun_H__

#include "CAnimation.h"
#include "CStaticObject.h"
#include "CBulletDefenseCannon.h"

enum DC_GUN_STATE
{
	DC_GUN_NORMAL = 0,
	DC_GUN_IS_DIE = 2
};
class CDefenseCannonGun : public CStaticObject, public CAnimation
{
public:
	CDefenseCannonGun(void);
	CDefenseCannonGun(bool );
	CDefenseCannonGun(bool, int, int);
	CDefenseCannonGun(const std::vector<int>& info);
	~CDefenseCannonGun();
	std::string ClassName(){ return __CLASS_NAME__(CDefenseCannonGun); };
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
	bool m_IsGunLeft;
protected:
	void Init(int, int);
	void BulletUpdate(float deltaTime);
	void SetFrame(bool isGunLeft);
	bool m_isShoot;
	//Tham so dung de test
	DC_GUN_STATE m_stateCurrent;
	// Mau cua doi tuong
public:
	//Phai co mot bien de giu nhung vien dan ma Boss Gun da ban ra
	//std::vector<CBullet*> m_listBullet;
	int m_bulletCount; //So luong vien dan da ban ra
	float m_timeDelay;
};

#endif // !__CDefenseCannonGun_H__
