#ifndef __CWEAPON_H__
#define __CWEAPON_H__

#include "CDynamicObject.h"
#include "CExplosionEffect.h"
#include "CBulletItem.h"

class CWeapon : public CDynamicObject
{
public:
	CWeapon(void);
	CWeapon(D3DXVECTOR2 position, int id);
	CWeapon(const std::vector<int>& info);
	~CWeapon();
	std::string ClassName(){return __CLASS_NAME__(CWeapon);};
	virtual void MoveUpdate(float deltaTime);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	void SetID(int id);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
	void Init();
protected:
	double m_angle;
public:
	STATE_BULLET_ITEM m_stateItem;
};

#endif // !__CWEAPON_H__
