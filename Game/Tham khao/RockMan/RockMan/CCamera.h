#ifndef _CCAMERA_H_
#define _CCAMERA_H_
#include <d3dx9.h>
#include "CGlobal.h"
#include "Config.h"

class CCamera
{
public:
	/*------------------------------------------
	Summary:	Khởi tạo đối tượng camera, di chuyển camera về toa độ góc trái dưới cùng(lưu ý chiều y vẫn đang âm)
	Return:
	-------------------------------------------*/
	CCamera();
	~CCamera();
	/*------------------------------------------
	Summary: chuyển tọa độ thế giới thực về tọa độ của camera
	Return:ma trận đã được tranform
	-------------------------------------------*/
	void Transform(Vector2* position);
	/*------------------------------------------
	Summary: chuyển tọa độ thế giới ảo(như tọa đô chuột) về tọa độ thế giới thực
	Return: ma trận đã được tranform
	-------------------------------------------*/
	void InTransform(Vector2* inPosition);
	/*------------------------------------------
	Summary: set tọa độ camera hiểu đơn giản là di chuyển camera đến 1 vị trí
	Return: 
	-------------------------------------------*/
	void SetPositionCamera(Vector2 position);
	/*------------------------------------------
	Summary: lấy vị trí camera
	Return: vị trí camera
	-------------------------------------------*/
	Vector2 GetPositionCamera();
	
	Rect GetViewport();
	
private:

	Matrix _transformMatrix;
	Matrix _inTransformMatrix;
	Vector2 _position;				// biến thể hiện tọa độ
};
#endif

