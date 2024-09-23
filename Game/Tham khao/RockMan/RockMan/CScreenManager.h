//-----------------------------------------------------------------------------
// File: CScreenManager.h
//
// Desc: Định nghĩa lớp CScreenManager hỗ trợ quản lý các màn hình
//
//-----------------------------------------------------------------------------
#ifndef _CSCREEN_MANAGER_H_
#define _CSCREEN_MANAGER_H_

#include <vector>
#include <iostream>

#include "CScreen.h"
#include "CInput.h"
#include "CGameTime.h"
#include "CGraphics.h"
#include "DSUtil.h"
#include "CSprite.h"
#include "CGlobal.h"
#include "CPopup.h"

using namespace std;

class CScreenManager{
	CScreenManager();
	~CScreenManager();
	static CScreenManager*	_instance;

public:
	static CScreenManager* GetInstance();

	void SetStartScreen(CScreen* screen);
	//-----------------------------------------------------------------------------
	// Summary: Phương thức vẽ màn hình và các thành phần con bên trong
	//-----------------------------------------------------------------------------
	void Render(CGameTime* gameTime, CGraphics* graphics);

	//-----------------------------------------------------------------------------
	// Summary: Phương thức cập nhật màn hình và các thành phần con bên trong
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime);

	//-----------------------------------------------------------------------------
	// Summary: Phương thức cập nhật màn hình và các thành phần con bên trong
	//-----------------------------------------------------------------------------
	void UpdateInput(CInput* input);
	
	//-----------------------------------------------------------------------------
	// Summary: Phương thức lấy màn hình hiện tại đang được xử lý
	//-----------------------------------------------------------------------------
	CScreen* GetCurrentScreen();

	//-----------------------------------------------------------------------------
	// Summary: Hiện thị màn hình popup
	//-----------------------------------------------------------------------------
	void ShowPopupScreen(CScreen* popupScreen);

private:
	CScreen*	_currentScreen;
	CScreen*	_popupScreen;
	vector<CScreen*>	_screenItems;
};

#endif //!_CSCREEN_MANAGER_H_