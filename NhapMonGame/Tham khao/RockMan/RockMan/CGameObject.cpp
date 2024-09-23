#include "CGameObject.h"

bool CGameObject::IsDebugMode = false;

CGameObject::CGameObject() :CObject()
{
	_id = -1;
	_typeID = -1;
	_border = ResourceManager::GetSprite(ID_DEBUG_BOX);
	_collideRegion._vx=_collideRegion._vy=_collideRegion._x = _collideRegion._y = _collideRegion._width = _collideRegion._height = 0;
	_isInViewPort = false;
}

CGameObject::~CGameObject()
{

}

int CGameObject::Initlize()
{
	return 1;
}

void CGameObject::Update(CGameTime* gameTime)
{

}

bool CGameObject::IsInViewPort()
{
	return _isInViewPort;
}

void CGameObject::Render(CGameTime* gameTime, CGraphics* graphics)
{

	Rect rectBorder;
	rectBorder.left = _box._x;
	rectBorder.top = _box._y;
	rectBorder.right = _box._x + _border.GetWidth();
	rectBorder.bottom = _box._y + _border.GetHeight();

	if (CGameObject::IsDebugMode)
	graphics->Draw(_border.GetTexture(), rectBorder, false, Vector2(_box._width / _border.GetWidth(), _box._height / _border.GetHeight()));

}

void CGameObject::UpdateCamera(CCamera camera)
{
	if (_box.IntersecWith(CBox(camera.GetViewport())) && !_isInViewPort)
		_isInViewPort = true;
}

CBox CGameObject::GetCollideRegion()
{
	return _collideRegion;
}

void CGameObject::SetCollideRegion(int x, int y, int width, int height)
{
	if (x == 0 && y == 0 && width == 0 && height == 0)
	{
		_collideRegion = GetBox();
	}
	else
	{
		_collideRegion._vx = 0.0f;
		_collideRegion._vy = 0.0f;
		_collideRegion._x = x;
		_collideRegion._y = y;
		_collideRegion._width = width;
		_collideRegion._height = height;
	}
}

CGameObject* CGameObject::ToValue()
{
	return new CGameObject(*this);
}

// Định nghĩa lớp đối tượng CStaticObject
CStaticObject::CStaticObject() :CGameObject()
{
	
}

CStaticObject::~CStaticObject()
{

}

CStaticObject* CStaticObject::ToValue()
{
	return new CStaticObject(*this);
}

// Định nghĩa lớp đối tượng CMoveableObject
CMoveableObject::CMoveableObject() :CGameObject()
{
	_v = Vector2(0.0f, 0.0f);
	_a = Vector2(0.0f, 0.0f);
	_blood = 0;
	_dame = 0;
}

CMoveableObject::~CMoveableObject()
{

}

void CMoveableObject::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (IsDebugMode)
		CGameObject::Render(gameTime, graphics);
}

CMoveableObject* CMoveableObject::ToValue()
{
	return new CMoveableObject(*this);
}

bool CMoveableObject::IsDied()
{
	if (_blood <= 0)
		return true;
	else
		return false;
}

int CMoveableObject::GetDame()
{
	return _dame;
}

void CMoveableObject::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{

}