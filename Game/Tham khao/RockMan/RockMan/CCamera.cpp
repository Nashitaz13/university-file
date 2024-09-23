#include "CCamera.h"

CCamera::CCamera()
{

	D3DXMatrixIdentity(&_transformMatrix);
	_transformMatrix._22 = -1;

	D3DXMatrixIdentity(&_inTransformMatrix);
	_inTransformMatrix._22 = -1;

	SetPositionCamera(Vector2(0.0f, SCREEN_HEIGHT));
}

CCamera::~CCamera()
{

}

void CCamera::SetPositionCamera(Vector2 position)
{
	_position = position;

	_transformMatrix._41 = -_position.x;
	_transformMatrix._42 = _position.y;

	_inTransformMatrix._41 = _position.x;
	_inTransformMatrix._42 = _position.y;
}

void CCamera::Transform(Vector2* position)
{
	Vector4 outTransform;

	// Transform theo ma trận tranform
	D3DXVec3Transform(&outTransform, &Vector3(position->x, position->y, 0), &_transformMatrix);

	position->x = floor( outTransform.x);
	position->y =floor( outTransform.y);

}

void CCamera::InTransform(Vector2* inPosition)
{
	Vector4 outInTransform;

	// Transform theo ma trận intranform
	D3DXVec3Transform(&outInTransform, &Vector3(inPosition->x, inPosition->y, 0), &_inTransformMatrix);

	inPosition->x =floor( outInTransform.x);
	inPosition->y =floor( outInTransform.y);

}
Vector2 CCamera::GetPositionCamera()
{
	return _position;
}

Rect CCamera::GetViewport()
{
	Rect rect;
	rect.left = _position.x;
	rect.top = _position.y;
	rect.right = rect.left + SCREEN_WIDTH;
	rect.bottom = rect.top - SCREEN_HEIGHT;

	return rect;

}