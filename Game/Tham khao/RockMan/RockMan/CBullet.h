//-----------------------------------------------------------------------------
// File: CBullet.h
//
// Desc: Định nghĩa lớp CBullet là lớp ảo dùng chung cho các đối tượng Bullet
//
//-----------------------------------------------------------------------------
#ifndef _CBULLET_H_
#define _CBULLET_H_

#include "CObject.h"
#include "CGameObject.h"


enum BULLET_BASE_STATE
{
	EXPLODING,//Đang nổ
	FLYING,//Đang bay
	DIE//Chết
};

class CBullet :public CMoveableObject
{
public:
	CBullet(int id, int typeID, CSprite sprite, int dame, Vector2 v, Vector2 beginPosition);
	
	~CBullet();

	virtual void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime);

	void UpdateBox() override;

	virtual void Destroy();

	//Hàm lấy trạng thái của đạn dùng để check xem đạn đang ở đã chết hay đang nổ. Đang nổ thì không cần check va chạm, chết rồi thì không phải vẽ.
	BULLET_BASE_STATE GetState();
	// Set trạng thái đạn
	void Die();

protected:
	//Trạng thái của đạn
	BULLET_BASE_STATE _state;
};

#endif // !_CBULLET_H_