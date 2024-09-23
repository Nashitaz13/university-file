#pragma once
#ifndef __BasicObject_H__
#define __BasicObject_H__

#include "Box.h"
#include <vector>
#include "d3dx9.h"
#include "SoundManager.h"
#include "GlobalObject.h"


enum CollisionDirection
{
	cd_tren,
	cd_duoi,
	cd_phai,
	cd_trai,
	cd_none,
};

enum Type
{
	ot_mario,
	ot_ground,
	ot_redfireplant,
	ot_firebullet,
	ot_odauhoi,
	ot_dongtien,
	ot_turtle,
	ot_namenemy,
	ot_namitem,
	ot_chiecla,
	ot_viengachvo,
	ot_gach,
	ot_chuP,
	ot_chuP_off,
	ot_imageeffect,
	ot_ongnuoc,
	ot_endbox,
	ot_boxstair,
};

class BasicObject
{
public:
	CBox *currBox, *preBox;
	float x, y,vx,vy;
	float root_x, root_y;
	Type type;
	bool IsRelease = false;
	Type pretype;
public:
	BasicObject();
	BasicObject(float, float, float, float);
	virtual void UpdatePosition() {};
	virtual void UpdateCollision() {};
	virtual void Render() {};				// Render object
	virtual void UpdateRootPosition() {};
	float CheckCollision(BasicObject*, CollisionDirection &);
	bool CheckBroadPhase(BasicObject*);
	~BasicObject();

	virtual RECT getRECT();

	float Collision(BasicObject*, CollisionDirection &);
};

D3DXVECTOR3* ReturnParabol(float _RootX, float _RootY, float _CrossX, float _CrossY);

#endif
