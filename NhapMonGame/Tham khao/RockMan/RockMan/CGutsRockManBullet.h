#ifndef _GUTS_ROCKMAN_BULLET_
#define _GUTS_ROCKMAN_BULLET_

#include "CBullet.h"
#include "CSprite.h"
#include  "CRockman.h"
#include "ResourceManager.h"
#include "Config.h"
#include "CRock.h"

class CGutsRockmanBullet : public CBullet
{
public:
	CGutsRockmanBullet(CRockman* master, int rockTypeID=ID_ROCK);

	~CGutsRockmanBullet();

	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox();


	void Destroy() override;

private:
	CRockman*	_master;
	bool		_isAtFirst;
	int			_deltaTime;
};
#endif //_GUTS_MAN_BULLET_