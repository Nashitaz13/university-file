#ifndef __CCAMERA_H__
#define __CCAMERA_H__

#include "CGlobal.h"
#include "CSingleton.h"

class CCamera : public CSingleton<CCamera>
{
	friend class CSingleton<CCamera>;
public:
	~CCamera();
	void Update(float x, float y); //Update vi tri cua camera
	RECT*& GetBound();
	D3DXVECTOR3 GetPointTransform(float x, float y); // Tra ve vi tri da transform
protected:
	CCamera();
	D3DXVECTOR3 m_pos;
	D3DXMATRIX m_matrixTransform;
public:
	D3DXVECTOR3 GetCameraPos();
	void SetPos(D3DXVECTOR3);
};

#endif // !__CCAMERA_H__
