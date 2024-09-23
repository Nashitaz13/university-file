//-----------------------------------------------------------------------------
// File: CGameInfo.h
//
// Desc: Định nghĩa lớp quản lý các thông tin game
//
//-----------------------------------------------------------------------------
#ifndef _CGAME_INFO_H_
#define _CGAME_INFO_H_

#include "Config.h"
#include "resource.h"
#include "CGlobal.h"
#include "SkillInfo.h"
#include <vector>
#include <fstream>
#include <sstream>
#include <iostream>

using namespace std;

class CGameInfo
{
private:
	CGameInfo();

	~CGameInfo();

	static CGameInfo* _instance;

	//-----------------------------------------------------------------------------
	// 	Màn chơi hiện tại của Game. Mặc định là ID_LEVEL_1 - Màn kéo
	//-----------------------------------------------------------------------------
	int	_idLevelGame;

	//-----------------------------------------------------------------------------
	// 	Điểm số người chơi
	//-----------------------------------------------------------------------------
	int _score;

	//-----------------------------------------------------------------------------
	// 	Giá trị mỗi bonus
	//-----------------------------------------------------------------------------
	int _bonusValue;

	//-----------------------------------------------------------------------------
	// 	tổng số bonus rockman lấy được
	//-----------------------------------------------------------------------------
 unsigned	int _totalBonus;

	vector<Skill> _skills;

public:
	static CGameInfo* GetInstance();

	void SetScore(int score);
	int GetScore();

	void SetBonusValue(int bonusvalue);
	int GetBonusValue();

	void SetBonus(unsigned int totalBonus);
	int GetTotalBonus();

	void SetLevel(int level);
	int GetLevel();

	vector<Skill> GetSkills();
	void AddSkill(Skill skill);
	bool HasSkill(Skill skill);

	string to_string(unsigned int score, unsigned int lenght = 0);

	//-----------------------------------------------------------------------------
	// 	Tải thông tin game lên từ file
	//-----------------------------------------------------------------------------
	void Load();

	//-----------------------------------------------------------------------------
	// 	Lưu thông tin game xuống từ file
	//-----------------------------------------------------------------------------
	void Save();
};

#endif // !_CGAME_INFO_H_
