#ifndef _CCUTMAN_BULLET_
#define _CCUTMAN_BULLET_

#include "CBullet.h"
#include "CSprite.h"

class CCutManBullet : public CBullet
{
public:
	CCutManBullet(int id, int typeID, CSprite sprite, int dame, Vector2 v, Vector2 beginPosition);
	~CCutManBullet();

	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox();

	void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime) override;
	//-----------------------------------------------------------------------------
	// Phương thức tạo ẩn viên đạn và restar lại các thuộc tính
	//
	//-----------------------------------------------------------------------------
	void Hide();

	//-----------------------------------------------------------------------------
	// Phương thức hủy viên đạn
	//
	//-----------------------------------------------------------------------------
	void setState();

	Vector2 _posRockMan; // Vị trí của rock man khi nó đứng
	Vector2 _posCutMan; // Vị trí của cut man khi nó đứng
	double _spBulletAndCutMan; // Khoảng cách giữa đạn và cut man
	bool _isReverse;
	bool _isHide;// ẩn viên đạn khi viên đạn trở về. 

private:
	float _speed; // tốc độ của đạn.
	void Fire(double d);
	void CheckDirectionBullet();
	CMoveableObject* _master;
};
#endif //_CCUTMAN_BULLET_