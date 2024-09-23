#include "CCamera.h"

CCamera::CCamera()
{
	m_pos.x = 0;
	m_pos.y = 448;
	m_pos.z = 0;
	D3DXMatrixIdentity(&m_matrixTransform);
	m_matrixTransform._22 = -1;
}

CCamera::~CCamera()
{

}

void CCamera::Update(float x, float y)
{
	m_pos.x = (this->m_pos.x < x || x == 0) ? x : m_pos.x;
	m_pos.y = (y > this->m_pos.y) ? y : this->m_pos.y;
}

RECT*& CCamera::GetBound()
{
	RECT* rect = new RECT();
	rect->top = m_pos.y - __SCREEN_HEIGHT;
	rect->left = m_pos.x;
	rect->right = rect->left + __SCREEN_WIDTH;
	rect->bottom = m_pos.y;
	return rect;
}

D3DXVECTOR3 CCamera::GetPointTransform(float x, float y)
{
	m_matrixTransform._41 = -m_pos.x;
	m_matrixTransform._42 = m_pos.y;
	D3DXVECTOR3 posCurr(x,y,0);
	D3DXVECTOR4 posResult;
	D3DXVec3Transform(&posResult, &posCurr, &m_matrixTransform);
	return D3DXVECTOR3(posResult.x, posResult.y, posResult.z);
}
D3DXVECTOR3 CCamera::GetCameraPos()
{
	return this->m_pos;
}
void CCamera::SetPos(D3DXVECTOR3 pos)
{
	this->m_pos = pos;
}