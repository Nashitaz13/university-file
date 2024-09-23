#include "CObject.h"

CObject::CObject(){
	_position = Vector2(0, 0);
	_origin = Vector2(0, 0);
	_size = Vector2(0, 0);
}

CObject::~CObject(){

}

void CObject::UpdateBox()
{
	 _box._x = _position.x;
	 _box._y = _position.y;
	 _box._width = _size.x;
	 _box._height = _size.y;
	 _box._vx = 0.0f;
	 _box._vy = 0.0f;
}

CBox CObject::GetBox()
{
	return _box;
}

Rect CObject::GetBoundingRectangle(){
	Rect boundingRect;
	boundingRect.left = _position.x;
	boundingRect.top = _position.y;
	boundingRect.right = boundingRect.left + _size.x;
	boundingRect.bottom = boundingRect.top + _size.y;

	return boundingRect;
}

Vector2 CObject::GetPositionCenter()
{
	return Vector2(_position.x/* + _origin.x*/, _position.y/* + _origin.y*/);
}