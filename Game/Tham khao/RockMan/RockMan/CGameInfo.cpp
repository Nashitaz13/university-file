#include "CGameInfo.h"

CGameInfo* CGameInfo::_instance = NULL;

CGameInfo::CGameInfo()
{
	_idLevelGame = ID_LEVEL_CUT;
	_score = 0;
	_bonusValue = 1000;
}

CGameInfo::~CGameInfo()
{

}

CGameInfo* CGameInfo::GetInstance()
{
	if (_instance == NULL)
		_instance = new CGameInfo();

	return _instance;
}

void CGameInfo::SetScore(int score)
{
	_score = score;
}

int CGameInfo::GetScore()
{
	return _score;
}
void CGameInfo::SetBonusValue(int bonusvalue)
{
	_bonusValue = bonusvalue;
}

int CGameInfo::GetBonusValue()
{
	return _bonusValue;
}

void CGameInfo::SetBonus(unsigned int totalBonus)
{
	_totalBonus= totalBonus;
}

int CGameInfo::GetTotalBonus()
{
	return _totalBonus;
}

void CGameInfo::SetLevel(int level)
{
	_idLevelGame = level;
}

int CGameInfo::GetLevel()
{
	return _idLevelGame;
}

vector<Skill> CGameInfo::GetSkills()
{
	return _skills;
}

void CGameInfo::AddSkill(Skill skill)
{
	bool hasSkill = false;

	for (int i = 0; i < _skills.size(); i++)
	if (_skills[i] == skill)
	{
		hasSkill = true;
		break;
	}

	if (!hasSkill)
		_skills.push_back(skill);
}

string CGameInfo::to_string(unsigned int score, unsigned int lenght)
{
	string strValue = "";
	for (int i = 0; i < lenght; i++)
		strValue += "0";

	strValue+= std::to_string(score);

	strValue = strValue.substr(strValue.size() - lenght, lenght);

	return strValue;
}

bool CGameInfo::HasSkill(Skill skill)
{
	for (int i = 0; i < _skills.size(); i++)
		if (_skills[i] == skill)
			return true;
	return false;
}

void CGameInfo::Load()
{
	// Khởi động game, skill mặc định là Normal 
	_skills.push_back(Skill::NORMAL);

	// Chuẩn bị đọc file
	wchar_t* gameInfoFile = GAME_INFO_FILE;
	ifstream fs;
	string line;

	fs.open(gameInfoFile, ios::in);
	if (!fs.is_open())
	{
		OutputDebugString(L"Can not open map file game info");
		return;
	}

	istringstream iss;

	// Tiến hành đọc file
	getline(fs, line);
	if (line.compare("#Special_Skill_Info") == 0)
	{
		int countSpeicalSkill = 0;
		string skill;
		getline(fs, line);
		iss.clear();
		iss.str(line);
		iss >> countSpeicalSkill;
		if (countSpeicalSkill != 0)
		{
			for (int i = 0; i < countSpeicalSkill; i++)
			{
				getline(fs, line);
				iss.clear();
				iss.str(line);
				iss >> skill;

				if (skill == "cut")
				{
					_skills.push_back(Skill::CUT);
				}
				else if (skill == "boom")
				{
					_skills.push_back(Skill::BOOM);
				}
				else if (skill == "guts")
				{
					_skills.push_back(Skill::GUTS);
				}
			}
		}
		getline(fs, line);					// Bỏ qua dòng "#Special_Skill_Info_End"
	}

	// Kết thúc đọc file
	fs.close();
}

void CGameInfo::Save()
{
	// Chuẩn bị ghi file
	wchar_t* gameInfoFile = GAME_INFO_FILE;
	ofstream fs;
	string line;

	fs.open(gameInfoFile);
	if (!fs.is_open())
	{
		OutputDebugString(L"Can not open map file game info to save data");
		return;
	}

	fs.flush();
	// Tiến hành ghi file
	fs << "#Special_Skill_Info";
	fs << "\n" + std::to_string(_skills.size()-1);
	for (int i = 0; i < _skills.size(); i++)
		switch (_skills[i])
	{
		case CUT:
			fs << "\ncut";
			break;
		case BOOM:
			fs << "\nboom";
			break;
		case GUTS:
			fs << "\nguts";
			break;
	}
	fs << "\n#Special_Skill_Info_end";

	// Kết thúc ghi file
	fs.close();
}

