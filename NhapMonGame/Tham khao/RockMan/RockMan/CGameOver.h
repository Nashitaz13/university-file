//-----------------------------------------------------------------------------"
// File: CGameOver.h
//
// Desc: Định nghĩa lớp GameOver hiển thị khi người chơi kết thúc 3 mạng
//
//-----------------------------------------------------------------------------
#ifndef _CGAMEOVER_H_
#define _CGAMEOVER_H_

#include "CScreen.h"
#include "CScreen.h"
#include "CInput.h"
#include "CGameTime.h"
#include "CGraphics.h"
#include "DSUtil.h"
#include "CGlobal.h"
#include "CImage.h"
#include "CTextblock.h"
#include "CTexture.h"
#include "CPlayScreen.h"
#include "CGameMenu.h"
#include "CGameInfo.h"
#include <string>

class CGameOver : public CScreen
{
public:
	CGameOver(int score);
	~CGameOver();
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
	void SetScore(int score);

private: 
	CTextblock*	_textGameOver, *_textScore, *_textContinue, *_textStageSelect;
	CImage*		_background, *_arrow;
	Color		_replaceColor;
	int _score;// biến hiển thị điểm đang có
	int _statusKey;// trạng thái của mũi tên 0 ở trên 1 là ở dưới 
	string GetStringZero(int countScore);// lấy chuổi tổng số 0 cần điền
};
#endif //_CGAMEOVER_H_
