//-----------------------------------------------------------------------------"
// File: CIntroCharacter.h
//
// Desc: Định nghĩa lớp CIntroCharacter màn hình bắt đầu game
//
//-----------------------------------------------------------------------------
#ifndef _CGAME_INTRO_CHARACTER_H_
#define _CGAME_INTRO_CHARACTER_H_

#include "CScreen.h"
#include "CScreenManager.h"
#include "CImage.h"
#include "CTextblock.h"
#include "CMenuItem.h"
#include "resource.h"
#include "CSprite.h"
#include "CGameMenu.h"
#include "ResourceManager.h"

enum class INTRO_STAGE_STATE
{
	RUNNING_ANIMATION,
	RUNNING_TEXT,
	DELAY
};

enum class STAGE
{
	CUTMAN,
	GUTSMAN,
	BOMBMAN
};

class CIntroCharacter : public CScreen
{
public:
	CIntroCharacter(CSprite spriteBoss, STAGE stage, int maxScore);
	~CIntroCharacter();

	//-----------------------------------------------------------------------------
	// Phương thức cập nhật sự kiện bàn phím, chuột
	//-----------------------------------------------------------------------------
	void UpdateInput(CInput* input) override;

	//-----------------------------------------------------------------------------
	// Phương thức cập nhật màn hình theo thời gian thực
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime) override;

	//-----------------------------------------------------------------------------
	// Phương thức vẽ màn hình và các thành phần con bên trong
	//-----------------------------------------------------------------------------
	void Render(CGameTime* gameTime, CGraphics* graphics) override;

private:
	void RunAnimationBossCutMan(float deltaTime);
	void RunAnimationBossGutsMan(float deltaTime);
	void RunAnimationBossBombMan(float deltaTime);
	void GoToAnimationText();
	string _strLine1;
	string _strLine2;
	int _maxScore;
	int _currentIndexScoreAnimation;
	string _strAddScoreAnimation;
	int _numOfScoreAnimation;//Số lần chạy animation điểm
	CTextblock	_txtLine1;
	CTextblock	_txtLine2;
	CTextblock	_txtScore;

	CEnemy		_enemy;
	CImage		_imgBackground;
	CImage		_imgLine1;
	int _timeBossStand;//Thời gian đứng của Boss
	int _timeFrame;// Độ dài thời gian vẽ mỗi frame riêng lẻ

	float _tick;// Cộng dồn thời gian để chyển frame
	int _isRunAnimation;//Chạy Animation hay chưa
	INTRO_STAGE_STATE _state;
	CSprite _spriteBoss;
	Vector2 _posBoss;
	Vector2 _vBoss;
	bool _isBossStand;
	bool _isPlaySoundScore;
};

#endif //!_CGAME_INTRO_CHARACTER_H_

