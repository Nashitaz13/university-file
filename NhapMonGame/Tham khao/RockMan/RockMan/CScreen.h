//-----------------------------------------------------------------------------
// File: CScreen.h
//
// Desc: Định nghĩa lớp Screen, đây là lớp căn bản cho tất cả các đối tượng 
//	     màn hình về sau.
//-----------------------------------------------------------------------------
#ifndef _CSCREEN_H_
#define _CSCREEN_H_

#include "CGameTime.h"
#include "CGraphics.h"
#include "CInput.h"
#include "CCamera.h"
#include "CCameraPath.h"

//-----------------------------------------------------------------------------
// Lớp CScreen là đối tượng căn bản cho mọi đối tượng màn hình
//
//-----------------------------------------------------------------------------
class CScreen{
public:
	CScreen();
	~CScreen();

	//-----------------------------------------------------------------------------
	// Phương thức cập nhật màn hình và các thành phần con bên trong
	//-----------------------------------------------------------------------------
	virtual void UpdateInput(CInput* input) = 0;

	//-----------------------------------------------------------------------------
	// Phương thức cập nhật màn hình theo thời gian thực
	//-----------------------------------------------------------------------------
	virtual void Update(CGameTime* gameTime) = 0;

	//-----------------------------------------------------------------------------
	// Phương thức vẽ màn hình và các thành phần con bên trong
	//-----------------------------------------------------------------------------
	virtual void Render(CGameTime* gameTime, CGraphics* graphics) = 0;

	// Kiểm tra xem màn hình đã chạy hoàn tất hay chưa
	bool IsFinished();

	int GetTypeID();

	// ấy ra màn hình kế tiếp sẽ xử lý
	CScreen* GetNextScreen();

	friend class CScreenManager;

protected:
	CCamera*		_camera;		// Đối tượng camera dùng để transform các tọa độ và di chuyển màn hình game
	CCameraPath*	_cameraPath;
	bool			_isFinished;	// Biến kiểm tra đã kết thúc màn hình chưa
	CScreen*		_nextScreen;	// Màn hình kế tiếp
	int				_typeID;		// ID của màn hình
};

#endif
