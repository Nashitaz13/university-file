#pragma once

#include "CGlobal.h"
#include "CGameObject.h"
#include "CSprite.h"

enum class EXPLODING_EFFECT_STATE
{
	EXPLODING,//Đang nổ
	DONE//Chết
};

class CExplodingEffect :public CGameObject
{
public:
	CExplodingEffect(Vector2 position, CSprite sprite, int idSoundExplodingEffect = ID_EFFECT_ENEMY_EXPLODING);

	~CExplodingEffect();

	//-----------------------------------------------------------------------------
	// 	Khởi tạo tất cả các thành phần của 1 đối tượng với các giá trí đã có
	//	
	//	Trả về 0 nếu lối hoặc 1 nếu thành công
	//-----------------------------------------------------------------------------
	virtual	int Initlize() override;

	//-----------------------------------------------------------------------------
	// 	Vẽ tất cả các thành phần của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//	+ graphics	: cọ vẽ đối tượng
	//-----------------------------------------------------------------------------
	virtual void Render(CGameTime* gameTime, CGraphics* graphics) override;

	//-----------------------------------------------------------------------------
	// 	Cập nhật tất cả các logic của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	virtual void Update(CGameTime* gameTime) override;

	bool IsDone();
	//Set sound để phát hiệu ứng nổ
	void SetSoundEffect(int idSoundExplodingEffect);

	CExplodingEffect* GetThis();

	void UpdateBox() override;
protected:
	// Đối tượng nắm giữ ảnh vẽ ảnh động
	CSprite _sprite;
	EXPLODING_EFFECT_STATE _state;
	//Đã play Sound Effect Exploding chưa?
	bool _isPlaySoundEffect;
	//Id sound exploding effect
	int _idSoundEffect;
};

