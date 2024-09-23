#ifndef _BOOMMAN_BULLET_
#define _BOOMMAN_BULLET_

#include "CBullet.h"
#include "CSprite.h"
#include "ResourceManager.h"
#include "CExplodingEffectManager.h"
#include "CExplodingEffectX.h"

#define TIME_EXPLOSIVE 500.0f

class CBoomManBullet : public CBullet
{
public:
	CBoomManBullet(int id, int typeID, CSprite sprite, int dame, Vector2 v, Vector2 beginPosition);
	~CBoomManBullet();

	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox();

	void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime) override;
	//-----------------------------------------------------------------------------
	// Phương thức tạo ẩn viên đạn và restar lại các thuộc tính
	//
	//-----------------------------------------------------------------------------
	void Reset();

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
	// Phương thức set lại state trạng thái của đạn
	//
	//-----------------------------------------------------------------------------
	void SetStatus(bool i);

	Vector2 _posRockManStand; // Vị trí của rock man khi nó đứng ban đầu
	Vector2 _posRockMan; // Vị trí của rock man khi nó đứng
	Vector2 _posBoomMan; // Vị trí của BoomMan khi nó đứng
	STTBOOM _sttBoom; // trạng thái của trái boom;
	double _spBulletAndBoomMan; // Khoảng cách giữa đạn và cut man
	bool _isfire;
	bool _isBoomManDie; // cho biết được boom man chớt.	
	bool _isOneHitBullet; //chỉ thêm 1 viên đạn vào list.
private:
	float _timerPush;// thời gian ném 1 lần bóng lúc bắt đầu chơi đấu với rock man
	float _timeExplosive; // Thời gian ném nổ của một trái boom
	bool _isDirec; // hướng lên(true) và xuống (âm)
	int _idSprite;
	int _preIdSprite; // Trạng thái hinh của trái boom luc truoc;
	float _timeaddspeed; // tốc độ của viên đạn
	float _dieDistance; // khoảng cách giữa các viên đạn.
	float _gravity;
	void CheckDirectionBullet();
};
#endif //_BOOMMAN_BULLET_