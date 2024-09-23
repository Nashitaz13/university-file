
#ifndef _SOUNDGAME_H_
#define _SOUNDGAME_H_
#include "CAudio.h"
#include <vector>
#include "Global.h"
using namespace std;

enum EBGSound
{
	EMenuSound,
	EStage1Sound,
	EStage2Sound,
	EBoss,
	EIntroSound,
	EEndGameSound
};

enum ESoundEffect
{
	ES_LifeLost,
	ES_CollectItem,
	ES_CollectWeapon,
	ES_UsingMorningStar,
	ES_SplashWater,
	ES_HitByWeapon,
	ES_HolyCross,
	ES_Select,
	ES_OpenDoor,
	ES_HolyWater,
	ES_StageClear,
	ES_FallingCastle,
	ES_GetScoreTimer,
	ES_GetScoreWeaponCount,
	ES_StopTimer,
	ES_FallInLake
};
class SoundManager
{
private:
	CAudio* _audio;
	//List of effect sound
	vector<CSound*> _listSoundEffect;
	//List of background sound (looped play sound)
	vector<CSound*> _listBgm;

	//BackGround Music
	CSound *bgmMenu;
	CSound *bgmStage1;
	CSound *bgmStage2;
	CSound *bgmBoss;
	CSound *bgmIntro;
	CSound *bgmEndGame;
	//Sound Effect
	CSound *lifeLost;
	CSound *stageClear;
	CSound* collectItem;
	CSound* collectWeapon;
	CSound* usingMorningStar;
	CSound* splashWater;
	CSound* hitByWeapon;
	CSound* holyCross;
	CSound* select;
	CSound* openDoor;
	CSound* holyWater;
	CSound* fallCastle;
	CSound* getScoreTimer;
	CSound* getScoreWeaponCount;
	CSound* stopTimer;
	CSound* fallInLake;
	SoundManager();
	static SoundManager* _instance;
public:
	static SoundManager* GetInst();
	static bool isBGM_On;
	static bool isSoundEffect_On;
	~SoundManager();

	void PlayBGSound(EBGSound);
	void PlaySoundEffect(ESoundEffect);
	void StopAllBGSound();
	void RemoveAllBGM();
	void ResumeBGM();
};

#endif