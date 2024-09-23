//-----------------------------------------------------------------------------
// File: CSceneInfo.h
//
// Desc: Định nghĩa lớp quản lý các thông tin Scene
//
//-----------------------------------------------------------------------------
#ifndef _CSCENE_INFO_H_
#define _CSCENE_INFO_H_

#include "CGlobal.h"
#include "Config.h"
#include <map>

class CSceneInfo
{
private:
	//-----------------------------------------------------------------------------
	// 	ma trận fallingPoint, map<Vector2(startPoint, endPoint),Vector2(FallingPoint_X,FallingPoint_Y)>
	//-----------------------------------------------------------------------------
	map<int, Vector2>	_fallingPoints;

	bool hasInListPoint(Vector2 point);
public:
	CSceneInfo();

	~CSceneInfo();

	//-----------------------------------------------------------------------------
	// 	Dựng Scene theo path, fallingPoints và paths phải chạy theo thứ tự
	//-----------------------------------------------------------------------------
	void BuildScene(vector<Vector2> fallingPoints, vector<Vector2> paths);

	//-----------------------------------------------------------------------------
	// 	Dựa theo startIndex của camera path, lấy ra fallingPoint thích hợp
	//-----------------------------------------------------------------------------
	map<int, Vector2> CSceneInfo::GetScene(int startIndex);
};

#endif // !_CSCENE_INFO_H_
