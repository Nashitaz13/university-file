#ifndef __CANIMATION_H__
#define __CANIMATION_H__

#include "Include.h"
#include "CGlobal.h"

class CAnimation
{
public:
	CAnimation();
	~CAnimation();
protected:
	float m_elapseTimeChangeFrame;
	float m_currentTime;
	int m_increase;
	int m_totalFrame;
	int m_currentFrame;
	int m_column;
	virtual void ChangeFrame(float deltaTime);
	virtual RECT*& UpdateRectResource(int rsHeight, int rsWidth);
};

#endif // !__CANIMATION_H__
