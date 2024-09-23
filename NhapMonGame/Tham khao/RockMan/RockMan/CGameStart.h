//-----------------------------------------------------------------------------"
// File: CGameStart.h
//
// Desc: Định nghĩa lớp CGameStart màn hình bắt đầu game
//
//-----------------------------------------------------------------------------
#ifndef _CGAME_START_H_
#define _CGAME_START_H_

#include "CScreen.h"
#include "CScreenManager.h"
#include "CImage.h"
#include "CTextblock.h"
#include "CMenuItem.h"
#include "resource.h"
#include "CGameMenu.h"
#include "ResourceManager.h"

class CGameStart : public CScreen
{
public:
	CGameStart();
	~CGameStart();

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
	CTextblock	_txtPressStart;
	CTextblock	_txtCopyright;
	CTextblock	_txtTM;

	CImage		_imgTitleGame;
	CImage		_imgBackground;

	CImage		_imgRockman;
	CImage		_imgRockmanGray;
	CImage		_imgLine1;
	CImage		_imgLine2;
	CImage		_imgLine3;
	CImage		_imgLine4;
	CImage		_imgLine1_1;
	CImage		_imgLine2_1;
	CImage		_imgLine3_1;
	CImage		_imgLine4_1;

	int _timeFrame;// Độ dài thời gian vẽ mỗi frame riêng lẻ
	float _tick;// Cộng dồn thời gian để chyển frame
	int _isNextFrame;//Trạng thái phím đã được nhấn hay chưa? Chưa nhấn thì = 0; đã nhấn thì khác 0. Biến này cũng được dùng để thay đổi trạng thái của của frame

};

#endif //!_CGAME_START_H_

