#ifndef __CSUBARM_H__
#define __CSUBARM_H__

#include "CDynamicObject.h"
#include "CMove.h"

enum SUB_ARM_TYPE
{
	SUB_ARM_FIRST = 0, //Dau canh tay
	SUB_ARM_COMPONENT = 1 //Cac thanh phan
};

class CSubArm : public CDynamicObject
{
public:
	CSubArm();
	~CSubArm();
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void MoveUpdate(float deltaTime);
	virtual RECT* GetRectRS();
	virtual Box GetBox();
	virtual void Init();
	void SetArmType(SUB_ARM_TYPE type){this->m_armType = type;};
	bool Move(D3DXVECTOR2 posCenter, float radian, double vecAngle, double angleStart, double angleEnd, bool direction, float deltaTime, std::vector<CGameObject*>* listObjectCollision);//
	bool Move(D3DXVECTOR2 posCenter, float radian, double vecAngle, bool direction, float deltaTime, std::vector<CGameObject*>* listObjectCollision);//
	bool Move(D3DXVECTOR2 posCenter, float radian, double angleStart, double angleEnd, float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	//Di chuyen cho node 1 len xuong(up_down)
	bool Move(D3DXVECTOR2 posCenter, float radian, double vecAngle, double angleStart, double angleEnd, float deltaTime, std::vector<CGameObject*>* listObjectCollision);//
	//di chuyen pop_up
	void Move(float rotation, D3DXVECTOR2 posStart, D3DXVECTOR2 posEnd, float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	//Tinh test quay tay 
	void Move(D3DXVECTOR2 posCenter, float radian, float angle, double vecAngle, float deltaTime, std::vector<CGameObject*>* listObjectCollision);//
	//Tinh Test Flow
	void Move(float rotation, D3DXVECTOR2 posCenter, float radian, double vecAngle, float deltaTime, std::vector<CGameObject*>* listObjectCollision);//
	float WaitForAppear;
	float GetAngle();
	void SetAngle(float);
	void SetVectorAngle(float);
protected:
	void BulletUpdate(float deltaTime);//Update dan cho dau canh tay
	float m_timeDelayWaitShoot;//thoi gian cho ban dan cho dau canh tay
	D3DXVECTOR2 m_posCenter; //vi tri tam quay
	double m_rotation; //Goc quay cua tam dan
	float m_radian; //ban kinh quay
	double m_angle; //goc quay cua cuc nho
	double m_angleDefault; //
	float m_curveCurr; //cung quay
	float m_waitForHandAppear;
	SUB_ARM_TYPE m_armType; //Kieu cua cuc nho
public:
	int m_bulletCount;
	bool m_isShoot;//co dc ban hay ko
};

#endif // !__CSUBARM_H__
