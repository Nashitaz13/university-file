//-----------------------------------------------------------------------------
#ifndef _CBABMANA_H_
#define _CBARMANA_H_

#include "CControl.h"
#include "CGlobal.h"
#include "CGraphics.h"
#include "CTextblock.h"
#include "CTexture.h"

class CBarMana : public CControl
{
public:
	//-----------------------------------------------------------------------------
	// 	Hàm khởi tạo 
	//-----------------------------------------------------------------------------
	CBarMana();
	CBarMana(Vector2 position, string name);
	~CBarMana();

	//-----------------------------------------------------------------------------
	// 	Khởi tạo tất cả các thành phần của 1 đối tượng với các giá trí đã có
	//	
	//	Trả về 0 nếu lối hoặc 1 nếu thành công
	//-----------------------------------------------------------------------------
	int Initlize() override;

	//-----------------------------------------------------------------------------
	// 	Cập nhật tất cả các logic của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime) override;

	//-----------------------------------------------------------------------------
	// 	Vẽ tất cả các thành phần của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//	+ graphics	: cọ vẽ đối tượng
	//-----------------------------------------------------------------------------
	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	//-----------------------------------------------------------------------------
	// Set giá trị mana
	//-----------------------------------------------------------------------------
	void SetMana(int mana);

	void IsDraw(boolean isdraw);
private:
	Rect _boundingBG;
	Rect _boundingMana;
	Vector2 _position;

	int _mana;// giá trị chính của mana chạy từ 0->20 
	int _maxMana;
	CTexture _textureMana;
	CTexture _textureBG;
	CTextblock _text;
	boolean _isDraw;

	

};
#endif //!_CPROGRESSBAR_H_

