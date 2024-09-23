//-----------------------------------------------------------------------------
// File: CItem.h
//
// Desc: Định nghĩa lớp CItem có tác dụng dựng tường giúp các đối tượng có thể đứng được
//
//-----------------------------------------------------------------------------
#ifndef _CITEM_H_
#define _CITEM_H_

#include "CGameObject.h"
#include "ResourceManager.h"
#include "CollisionInfo.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

class CItem :public CMoveableObject
{
public:
	CItem();
	CItem(int _typeID, Vector2 position, bool itemOfBoss = false, bool isDefault = false);
	~CItem();

	int Initlize() override;

	//-----------------------------------------------------------------------------
	// 	Vẽ tất cả các thành phần của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//	+ graphics	: cọ vẽ đối tượng
	//-----------------------------------------------------------------------------
	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	//-----------------------------------------------------------------------------
	// 	Cập nhật tất cả các logic của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime) override;

	void UpdateCollision(CGameObject* obj, CDirection normalX, CDirection normalY, float collideTime, float remainCollideTime);

	void UpdateBox() override;

	void GotIt();

	bool IsGot();

	CItem* ToValue() override;
private:
	bool _isGot;
	bool _isDefault;
	bool _itemOfBoss;
	int _timeAppear;
	CollisionInfo	_collisionUp, _collisionDown;
};

#endif // !_CITEM_H_