#include "CScreen.h"
#include "DSUtil.h"
#include "CGraphics.h"
#include "CInput.h"

CScreen::CScreen(){
	_isFinished = false;
	_camera = new CCamera();
	_cameraPath = new CCameraPath();
	_nextScreen = NULL;
}

CScreen::~CScreen(){
	_isFinished = true;
	SAFE_DELETE(_camera);
	SAFE_DELETE(_cameraPath);
	SAFE_DELETE(_nextScreen);
}

bool CScreen::IsFinished(){
	return _isFinished;
}

CScreen* CScreen::GetNextScreen(){
	return _nextScreen;
}

int CScreen::GetTypeID()
{
	return _typeID;
}