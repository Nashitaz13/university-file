#ifndef __CGROUND_CANON_H__
#define __CGROUND_CANON_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CBulletN.h"

enum GROUNDCANON_SHOOT_STATE
{
	G_IS_SHOOTING_NORMAL = 0,
	G_IS_SHOOTING_DIAGONAL_UP_X = 1,
	G_IS_SHOOTING_DIAGONAL_UP_2X = 2,
	G_IS_SHOOTING_DIE = 3
};

class CGroundCanon : public CStaticObject, public CAnimation
{
public:
	CGroundCanon(void);
	CGroundCanon(const std::vector<int>& info);
	~CGroundCanon();
	std::string ClassName(){ return __CLASS_NAME__(CGroundCanon); };
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	void Init();
	void BulletUpdate(float deltaTime);
	GROUNDCANON_SHOOT_STATE m_stateCurrent;
	void SetFrame();
	bool m_isShoot;
	void MoveUp(float deltaTime);
	void MoveDown(float deltaTime);
	bool m_moveUpComplete; //U sung da xuat hien
	//Tham so dung de test
public:

	int m_bulletCount; //So luong vien dan da ban ra
	float m_waitForShoot; // Thoi gian de duoc ban dan
	float m_timeDelay;
	float m_heightMax;
};

#endif // !__CGROUND_CANON_H__
