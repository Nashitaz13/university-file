//-----------------------------------------------------------------------------
// File: CGameObject.h
//
// Desc: Định nghĩa lớp CGameObject, đây là lớp các đối tượng chạy game
//
//-----------------------------------------------------------------------------
#ifndef _CGAME_OBJECT_H_
#define _CGAME_OBJECT_H_

#include "CObject.h"
#include "CTexture.h"
#include "CSprite.h"
#include "ResourceManager.h"

#include <string>

using namespace std;

class CGameObject : public CObject
{
private:
	CBox _collideRegion;	// vùng va chạm, dùng để kiêm tra đối tượng và lấy ra xét va chạm trên màn hình
public:
	CGameObject();
	virtual  ~CGameObject();

	virtual int Initlize() override;

	virtual void Update(CGameTime* gameTime) override;

	virtual void Render(CGameTime* gameTime, CGraphics* graphics) override;

	virtual CGameObject* ToValue();

	CBox GetCollideRegion();

	void SetCollideRegion(int x, int y, int width, int height);

	void UpdateCamera(CCamera camera);

	bool IsInViewPort();

	int _id;		// Mã xác định đối tượng
	int _typeID;	// Mã xác định loại đối tượng

	static bool IsDebugMode;
private:
	CTexture	_border;
	bool _isInViewPort;
};

class CStaticObject : public CGameObject
{
public:
	CStaticObject();
	virtual ~CStaticObject();

	virtual CStaticObject* ToValue() override;

	// Đối tượng nắm giữ ảnh của
	CTexture	_texture;
};

//-----------------------------------------------------------------------------
// Định nghĩa các đối tượng có thể di chuyển được trong game, VD: Rockman, emeny, bullet
//
//-----------------------------------------------------------------------------
class CMoveableObject : public CGameObject
{
public:
	CMoveableObject();
	virtual ~CMoveableObject();

	virtual void Render(CGameTime* gameTime, CGraphics* graphics) override;

	virtual CMoveableObject* ToValue() override;

	//Kiểm tra xem Enemy có chết hay chưa?
	virtual bool IsDied();

	//Get mức độ sát thương
	virtual int GetDame();

	virtual void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime);

	// Đối tượng nắm giữ ảnh vẽ ảnh động của GameObject
	CSprite _sprite;

	// Trạng thái của đối tượng, thường được dùng để chuyển sprite, hành vi đối tượng
	int _spriteStatus;

	// Vận tốc di chuyển của đối tượng trên
	Vector2 _v;

	// Gia tốc di chuyển của đối tượng
	Vector2 _a;

	// Số máu còn lại của một mạng sống của đối tượng
	int _blood;

	// Mức độ sát thương của bullet
	int _dame;
};

#endif //_CGAME_OBJECT_H_