#ifndef __CSCORE_SCENSE_H__
#define __CSCORE_SCENSE_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CScense.h"
#include "CChooseItem.h"

#define __HightScore_Path__ "..\\Resource\\File\\BackGround\\HightScore.txt"

class CScoreScense : public CScense
{
public:
	CScoreScense();
	CScoreScense(bool);
	CScoreScense(const std::vector<int>& info);
	virtual ~CScoreScense(){};
	std::string ClassName(){ return __CLASS_NAME__(CScoreScense); };
	void Update(float deltaTime);
	void Move(float deltaTime);
	void Draw();
	void Init();
	void InitScore(int score);
	void InitNameStage(int mapId);
	void InitHightScore(int hightScore);
	void InitCountAlive(int countAlive);
	void InitStageNumber(int stageNumberCurrent);
	RECT* GetRectRS();
protected:
	float m_timeDelay;
	int m_ScoreMap;
	int m_hightScore;
	bool m_isScenseGameOver;//Cho biet la man diem qua man hay man hinh diem game over
	bool m_isHided;
	bool m_isPlaySoundGameOver;
public:
	//Choose item
	CChooseItem* m_itemChoose;
	//tao 1 dong word de luu va ve diem so
	CWordItem** m_listNumberScore;
	//List luu ten man
	CWordItem** m_listWordStageName;
	//Man thu n
	CWordItem** m_listStageNumber;
	//So man cua contra
	CWordItem** m_listCountAliveNumber;
	//Hight Score cua game
	CWordItem** m_listHightScoreNumber;
	//List luu label 'lP'//Score
	CWordItem** m_listLPWord;
	//List luu label 'REST'//So mang
	CWordItem** m_listRestWord;
	//List luu label 'HI'//Hight Score
	CWordItem** m_listHIWord;
	//List luu label 'STAGE'//Man
	CWordItem** m_listStageWord;
	//List luu Label "CONTINUE"
	CWordItem** m_listContinueWord;
	//List luu Label "END"
	CWordItem** m_listEndWord;
	///
	int lenghtNumberScore;//do dai cua diem
	int lenghtWordStateName;//Do dai cua ten man
	int lenghtNumberHightScore;//do dai cua diem cao nhat
	int lenghtCountAliveNumber;//Do dai cua so mang contra
	int lenghtStageNumber;//Do dai cua man thu
	int lenghtlPWord;//do dai cua diem
	int lenghtRestWord;//Do dai cua ten man
	int lenghtHIWord;//Do dai cua ten man
	int lenghtStageWord;//Do dai cua ten man
	int lenghtContinueWord;//Do dai cua Label CONTINUE
	int lenghtEndWord;//Do dai cua Lable END
	//Ham lay ra no la man hinh game over hay man hinh diem
	bool IsScenseGameOver()
	{
		return this->m_isScenseGameOver;
	}
	bool m_isReadFileHightScore;
};
#endif // !__CSCORE_SCENSE_H__
