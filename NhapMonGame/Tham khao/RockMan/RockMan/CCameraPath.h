#ifndef _CCAMERA_PATH_H_
#define _CCAMERA_PATH_H_

#include "CGlobal.h"

class CCameraPath
{
public:
	/*------------------------------------------
	Summary:	Khởi tạo đối tượng camera path, tính toán vị trí trên camera
	-------------------------------------------*/
	CCameraPath();
	~CCameraPath();

	Vector2 CalculatePointOnPathWith(Vector2 newPosition);
	Vector2 GetCameraPointOnPath();
	void SetCameraPointOnPath(Vector2 pointOnPath);
	Vector2 GetStartPoint();
	Vector2 GetEndPoint();
	Vector2 GetNextPoint();
	Vector2 GetNextOfNextPoint();
	Vector2 GetPreviousPoint();
	Vector2 GetPrevOfPreviousPoint();
	int  GetStartIndex();
	void SetStartIndex(int startIndex);
	int  GetEndIndex();
	void SetEndIndex(int endIndex);
	void SetPaths(vector<Vector2> paths);
	vector<Vector2> GetPaths();
	bool IsHorizontalLine();
	bool IsVerticalLine();
	bool CanMoveLeft();
	bool CanMoveRight();
	bool CanMoveUp();
	bool CanMoveDown();
private:

	Vector2 _pointOnPath;			// biến thể hiện tọa độ
	vector<Vector2>	_paths;			// Ma trận điểm tâm camera
	int _startIndex, _endIndex;		// Các chỉ số truy cập path, _pointOnPath sẽ nằm giữa cặp giá trị theo 2 chỉ số này
};
#endif //!_CCAMERA_PATH_H_