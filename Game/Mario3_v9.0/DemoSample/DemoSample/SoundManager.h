
#ifndef _SOUNDGAME_H_
#define _SOUNDGAME_H_
#include "CAudio.h"
#include <vector>
#include "GlobalObject.h"
using namespace std;

enum BGSound
{
	BGM1, BGM2, BGM_under,
};

enum SoundEffect
{
	//mario sound
	SE_chay,
	SE_doihuong,
	SE_nhay,
	SE_tancong,
	SE_quayduoi,
	SE_chuiong,
	SE_chet,
	SE_nholon,
	SE_londuoi,
	SE_damenemy,
	SE_starman,
	
	//item sound
	SE_dunggach,
	SE_vogach,
	SE_namitem,
	SE_dongtien,
	SE_1up,
	SE_end,
	SE_gameover,
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
	CSound *bgm1;
	CSound *bgm2;
	CSound *bgmUnder;
	//Sound Effect
	CSound *seChay; //chay, baylen
	CSound *seDoiHuong;
	CSound *seNhay;
	CSound *seTanCong;
	CSound *seQuayDuoi; //quayduoi, bayxuong
	CSound *seChuiOng; //chuiong, lonnho
	CSound *seChet;
	CSound *seNhoLon;
	CSound *seLonDuoi;
	CSound *seDamEnemy;
	CSound *seStarMan;

	CSound *seDungGach;
	CSound *seVoGach;
	CSound *seNamItem;
	CSound *seDongTien;
	CSound *se1Up;
	CSound *seEnd;
	CSound *seGameOver;

	SoundManager();
	static SoundManager* _instance;
public:
	static SoundManager* GetInst();
	static bool isBGSound_On;
	static bool isSoundEffect_On;
	~SoundManager();

	void PlayBGSound(BGSound);
	void PlaySoundEffect(SoundEffect);
	void StopSoundEffect(SoundEffect);
	void StopAllBGSound();
	void RemoveAllBGM();
	void ResumeBGM();
};

#endif