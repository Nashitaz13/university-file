#ifndef _CROCK_CUT_BULLET_
#define _CROCK_CUT_BULLET_

#include "CBullet.h"
#include "CSprite.h"
#include  "CRockman.h"

class CRockCutBullet : public CBullet
{
public:
	CRockCutBullet(CRockman* master);

	~CRockCutBullet();

	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox();

	
	void Destroy() override;

private:
	CRockman*	_master;
	Vector2		_oldPosition;
	Vector2		_defaultVelocity, _defaultAccelerate;

	int			_timeDelay;
	bool		_isChangedState;
	int			_timeReturn;

	float CheckCollision(CGameObject* obj1, CBox staticBox, CDirection &normalX, CDirection &normalY, float frameTime);
	void Find();
};
#endif //_CCUTMAN_BULLET_