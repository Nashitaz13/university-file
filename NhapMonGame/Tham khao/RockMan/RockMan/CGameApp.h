//-----------------------------------------------------------------------------
// File: CGameApp.h
//
// Desc: Định nghĩa lớp CGameApp, là đối tượng chạy chính của game
//-----------------------------------------------------------------------------
#ifndef _CGAMEAPP_H_
#define _CGAMEAPP_H_

#include <d3d9.h>
#include <d3dx9.h>
#include <dxerr.h>
#include <windows.h>
#include <time.h>
#include <stdio.h>
#include <stdlib.h>

#include "CWindow.h"
#include "CGraphics.h"
#include "Config.h"
#include "CInput.h"
#include "CGameObject.h"
#include "ResourceManager.h"
#include "CGameTime.h"
#include "CScreenManager.h"
#include "CGameMenu.h"
#include "CGameStart.h"
#include "CGameInfo.h"

class CGameApp
{
public:

	/*------------------------------------------
	Sumary:	Khởi tạo tất cả các thành phần của game
	Parameters:
	+ hInstance :  Thực thể game trong window
	+ isFullScreen : isFullScreen = 1 là full, isFullScreen = 0 là không full
	Return:	1 là khởi tạo game thành công, 0 là lỗi
	-------------------------------------------*/
	CGameApp(HINSTANCE hInstance, int isFullScreen=0);
	~CGameApp();

	/*------------------------------------------
	Sumary:	Vòng lặp chính của game
	Parameters:
	+ 
	Return:	
	-------------------------------------------*/
	void Run();
	
private:
	/*------------------------------------------
	Sumary:	Khởi tạo các đối tượng của game
	Parameters:
	+ time :  khoảng thời gian mỗi lần lặp game.
	Return:	
	-------------------------------------------*/
	int InitGame();

	CGameTime*		_gameTime;
};

#endif //!_CGAMEAPP_H_
