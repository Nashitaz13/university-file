//-----------------------------------------------------------------------------
#ifndef _CPOPUP_H_
#define _CPOPUP_H_

#include "CControl.h"
#include "CGlobal.h"
#include "CGraphics.h"
#include "CScreen.h"
#include "CBarMana.h"
#include "CTexture.h"
#include "ResourceManager.h"
#include "CScreenManager.h"
#include "CRockman.h"


class CPopup : public CScreen
{
public:
	CPopup(CRockman* rockman);
	~CPopup();
	//-----------------------------------------------------------------------------
	// Phương thức cập nhật màn hình và các thành phần con bên trong
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
	
	void Initilize();
	

private:
	CRockman* _rockman;

	CBarMana _barManaBoom;// thanh bar boom 
	CBarMana _barManaCut;// thanh bar cut 
	CBarMana _barManaGut;// thanh bar gutman 

	CTexture _textureBG;// texture nen đen 
	CTexture _textureLifeRockMan;// texture item life

	CTextblock _textP;
	CTextblock _textLife;

	Vector2 _position;
	Vector2 _positionLife;

	Rect _boundingBG;
	Rect _boundingLR;

	int _RockManChoose;// chỉ số rockman đang dc chọn trong skill
	int _life;

	int _timeDraw;
	int _timeDrawDefault;

	int _valueManaBoomman;
	int _valueManaCutman;
	int _valueManaGutman;

	map<Skill, int> skillsInfo;// thông tin skill gồm tên skill mana
	vector<Skill> skills;// thông tin skill hiện có

};
#endif //!_CPROGRESSBAR_H_

