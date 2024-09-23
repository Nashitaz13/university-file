#ifndef _CBOOMROCKMAN_BULLET_
#define _CBOOMROCKMAN_BULLET_

#include "CBullet.h"
#include "CSprite.h"
#include "ResourceManager.h"
#include "CRockman.h"
#include "CollisionInfo.h"

#define ROCK_BOOM_BULLET_VERLOCITY_X		65.0f/1000.0f
#define ROCK_BOOM_BULLET_VERLOCITY_Y		235.0f/1000.0f
#define ROCK_BOOM_BULLET_ACCELERATE_X		0.0075f/1000.0f
#define ROCK_BOOM_BULLET_ACCELERATE_Y		1.09f/1000.0f

class CBoomRockManBullet : public CBullet
{
public:
	CBoomRockManBullet(CRockman* master);
	~CBoomRockManBullet();

	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox();

	void OnCollideWith(CGameObject *obj, CDirection normalX, CDirection normalY, float collideTime) override;
	
	void Destroy ()override;

private:
	CRockman*	_master;

	// Biếm đếm thời gian nổ, nếu <= 0 nghĩa là không nổ, nếu > 0 nghĩa bắt đầu đếm nổ
	int			_deltaTimeExplode;		
	float		_velocityYDefault;
	bool		_isChangeSprite;

	// Kiểm soát va chạm các đối tượng nền
	CollisionInfo	_collideLeft, _collideRight, _collideUp, _collideDown;
};
#endif //_BOOMMAN_BULLET_