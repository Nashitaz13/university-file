//-----------------------------------------------------------------------------"
// File: CGameMenu.h
//
// Desc: Định nghĩa lớp CGameMenu cho phép người chơi chọn màn chơi
//
//-----------------------------------------------------------------------------
#ifndef _CGAME_MENU_H_
#define _CGAME_MENU_H_

#include <vector>
#include <iostream>

#include "CScreen.h"
#include "CScreenManager.h"
#include "CPlayScreen.h"
#include "CInput.h"
#include "ResourceManager.h"
#include "CGameTime.h"
#include "CGraphics.h"
#include "DSUtil.h"
#include "CGlobal.h"
#include "CImage.h"
#include "CTextblock.h"
#include "CTexture.h"
#include "CMenuItem.h"
#include "CGameInfo.h"
#include "CIntroCharacter.h"

using namespace std;

class CGameMenu :public CScreen
{
public:
	CGameMenu();
	~CGameMenu();

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
	int			_stageIndex;
	bool		_isJustPlaySound;
	CTextblock	_title;
	CImage		_background;
	CMenuItem   _stage[6];
};

#endif //!_CGAME_MENU_H_