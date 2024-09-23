//-----------------------------------------------------------------------------
// File: CEnemy.h
//
// Desc: Định nghĩa lớp CEnemy là lớp ảo dùng chung cho các đối tượng Enemy
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_H_
#define _CENEMY_H_

#include "CGameObject.h"
#include "CBullet.h"

class CRockman;

class CEnemy :public CMoveableObject
{
public:
	CEnemy();

	~CEnemy();

	//-----------------------------------------------------------------------------
	// Xử lý bắn của đối tượng Enemy
	//-----------------------------------------------------------------------------
	virtual vector<CBullet*> Fire();

	virtual void Update(CGameTime* gameTime) override;

	virtual void Render(CGameTime* gameTime, CGraphics* graphic) override;

	virtual void Update(CGameTime* gameTime, CRockman* rockman);
	
	virtual CEnemy* ToValue();

	unsigned int GetScore();
protected:

	unsigned int _score;
};

#endif // !_CENEMY_H_