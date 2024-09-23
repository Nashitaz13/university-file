#ifndef __CSOLDIER_H__
#define __CSOLDIER_H__

#include "CDynamicObject.h"
#include "CAnimation.h"

enum SOLDIER_STATE
{
	S_IS_JOGGING = 0, //Chay
	S_IS_STANDING = 1, //Dung lai va ban dan
	S_IS_JUMP = 2, // Nhay
	S_IS_DIE = 3
};

class CSoldier : public CDynamicObject, public CAnimation
{
public:
	CSoldier(void);
	CSoldier(const std::vector<int>& info);
	~CSoldier();
	std::string ClassName(){return __CLASS_NAME__(CSoldier);};
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	//virtual void ChangeFrame(float deltaTime);
	virtual void OnCollision(float deltatime, std::vector<CGameObject*>* listObjectCollision);
	virtual void MoveUpdate(float deltaTime);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
	void setJump(bool jump);
	void Init();
protected:

	void BulletUpdate(float deltaTime);
	SOLDIER_STATE m_stateCurrent;
	void SetFrame(float deltaTime);
	bool m_isShoot;
	//Tham so dung de test
	float m_waitForChangeSprite;
	bool m_jump;
	int m_countRepeat;
};

#endif // !__CSOLDIER_H__
