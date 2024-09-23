#ifndef _GUTS_MAN_BULLET_
#define _GUTS_MAN_BULLET_

#include "CBullet.h"
#include "CSprite.h"
#include "ResourceManager.h"

#define TIME_EXPLOSIVE_GUST 800.0f
class CGutsManBullet : public CBullet
{
public:
	CGutsManBullet(int id, int typeID, CSprite sprite, int dame, Vector2 v, Vector2 beginPosition);
	~CGutsManBullet();

	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox();

	void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime) override;
	//-----------------------------------------------------------------------------
	// Phương thức tạo ẩn viên đạn và restar lại các thuộc tính
	//
	//-----------------------------------------------------------------------------
	void reset();

	//-----------------------------------------------------------------------------
	// Phương thức Tính toán đường đi của đạn
	//
	//-----------------------------------------------------------------------------
	void Fire();

	//-----------------------------------------------------------------------------
	// Phương thức kiểm tra trạng thái của đạn
	//
	//-----------------------------------------------------------------------------
	void CheckStatus(float t);
	//-----------------------------------------------------------------------------
	// Phương thức thay đổi trạng thái của đạn
	//
	//-----------------------------------------------------------------------------
	void SetStatus();

	Vector2 _posRockMan; // Vị trí của rock man khi nó đứng
	Vector2 _posGutsMan; // Vị trí của BoomMan khi nó đứng
	Vector2 _posBurst; //Vị trí bắt đầu mặc định của quả boom.
	STTBOOM _sttRock; // trạng thái của trái boom;
	bool _isfire;
	bool _isOneHitBullet; // cho phép đẩy dạn vào list trong screen khi đạn được bắn.
	
private:	
	int _idSprite;
	int _preIdSprite; // Trạng thái hinh của trái boom luc truoc;
	float _timeaddspeed; // tốc độ của viên đạn
	float _dieDistance; // khoảng cách giữa các viên đạn.
	bool _flat; // biến bật tính toán đường bắn.
	bool _recFire; // hướng bắn;
	float _timeExplosive;
	

	void CheckDirectionBullet();
};
#endif //_GUTS_MAN_BULLET_