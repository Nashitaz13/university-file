#include "SoundManager.h"

SoundManager* SoundManager::_instance = NULL;
bool SoundManager::isBGSound_On = true;
bool SoundManager::isSoundEffect_On = true;
SoundManager* SoundManager::GetInst()
{
	if(SoundManager::_instance == NULL)
	{
		_instance = new SoundManager();
	}
	return _instance;
}

SoundManager::SoundManager()
{
	_audio = new CAudio();
	_audio->Init_DirectSound(HWnd);

	bgm1 = _audio->LoadSound("Sounds\\bg\\bgm1.wav");
	bgm2 = _audio->LoadSound("Sounds\\bg\\bgm2.wav");
	bgmUnder = _audio->LoadSound("Sounds\\bg\\bgmunder.wav");

	seChay = _audio->LoadSound("Sounds\\mario\\chay.wav");
	seDoiHuong = _audio->LoadSound("Sounds\\mario\\doihuong.wav");
	seNhay = _audio->LoadSound("Sounds\\mario\\nhay.wav");
	seTanCong = _audio->LoadSound("Sounds\\mario\\tancong.wav");
	seQuayDuoi = _audio->LoadSound("Sounds\\mario\\quayduoi.wav");
	seChuiOng = _audio->LoadSound("Sounds\\mario\\chuiong.wav");
	seChet = _audio->LoadSound("Sounds\\mario\\chet.wav");
	seNhoLon = _audio->LoadSound("Sounds\\mario\\nholon.wav");
	seLonDuoi = _audio->LoadSound("Sounds\\mario\\londuoi.wav");
	seDamEnemy = _audio->LoadSound("Sounds\\mario\\damenemy.wav");
	seStarMan = _audio->LoadSound("Sounds\\mario\\starman.wav");

	seDungGach = _audio->LoadSound("Sounds\\item\\dunggach.wav");
	seVoGach = _audio->LoadSound("Sounds\\item\\vogach.wav");
	seNamItem = _audio->LoadSound("Sounds\\item\\namitem.wav");
	seDongTien = _audio->LoadSound("Sounds\\item\\dongtien.wav");
	se1Up = _audio->LoadSound("Sounds\\item\\1up.wav");
	seEnd = _audio->LoadSound("Sounds\\item\\end.wav");
	seGameOver = _audio->LoadSound("Sounds\\item\\gameover.wav");
}

SoundManager::~SoundManager()
{

}

void SoundManager::PlayBGSound(BGSound id)
{
	if (!isBGSound_On)
		return;
	switch(id)
	{
	case BGSound::BGM1:
		_listBgm.push_back(bgm1);
		bgm1->Reset();
		_audio->LoopSound(bgm1);
	break;
	case BGSound::BGM2:
		_listBgm.push_back(bgm2);
		bgm2->Reset();
		_audio->LoopSound(bgm2);
		break;
	case BGSound::BGM_under:
		_listBgm.push_back(bgmUnder);
		bgmUnder->Reset();
		_audio->LoopSound(bgmUnder);
		break;
	}
}
void SoundManager::PlaySoundEffect(SoundEffect id)
{
	if(!isSoundEffect_On)
		return;
	switch(id)
	{
	//mario
	case SoundEffect::SE_chay:
		seChay->Play();
		break;
	case SoundEffect::SE_doihuong:
		seDoiHuong->Play();
		break;
	case SoundEffect::SE_nhay:
		seNhay->Play();
		break;
	case SoundEffect::SE_tancong:
		seTanCong->Play();
		break;
	case SoundEffect::SE_quayduoi:
		seQuayDuoi->Play();
		break;
	case SoundEffect::SE_chuiong:
		seChuiOng->Play();
		break;
	case SoundEffect::SE_chet:
		seChet->Play();
		break;
	case SoundEffect::SE_nholon:
		seNhoLon->Play();
		break;
	case SoundEffect::SE_londuoi:
		seLonDuoi->Play();
		break;
	case SoundEffect::SE_damenemy:
		seDamEnemy->Play();
		break;
	case SoundEffect::SE_starman:
		seStarMan->Play();
		break;
	//item
	case SoundEffect::SE_vogach:
		seVoGach->Play();
		break;
	case SoundEffect::SE_dunggach:
		seDungGach->Play();
		break;
	case SoundEffect::SE_namitem:
		seNamItem->Play();
		break;
	case SoundEffect::SE_dongtien:
		seDongTien->Play();
		break;
	case SoundEffect::SE_1up:
		se1Up->Play();
		break;
	case SoundEffect::SE_end:
		seEnd->Play();
		break;
	case SoundEffect::SE_gameover:
		seGameOver->Play();
		break;
	}
}
void SoundManager::StopSoundEffect(SoundEffect id)
{	
	switch (id)
	{
	case SoundEffect::SE_chay:
		seChay->Stop();
		break;
	case SoundEffect::SE_starman:
		seStarMan->Stop();
		break;
	}
}

void SoundManager::StopAllBGSound()
{
	for (int i = 0; i<_listBgm.size(); i++)
	{
		_listBgm[i]->Stop();
	}
}

void SoundManager::RemoveAllBGM()
{
	StopAllBGSound();
	_listBgm.clear();
}
void SoundManager::ResumeBGM()
{
	for (int i = 0; i<_listBgm.size(); i++)
	{
		_audio->PlaySoundA(_listBgm[i]);
	}
}