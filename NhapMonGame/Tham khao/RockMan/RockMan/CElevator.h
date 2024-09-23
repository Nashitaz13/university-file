//-----------------------------------------------------------------------------
// File: CElevator.h
//
// Desc: Định nghĩa lớp CElevator, là cầu thang chuyển động qua lại trên một đường ngang thẳng
//
//-----------------------------------------------------------------------------
#ifndef _CELEVATOR_H_
#define _CELEVATOR_H_

#include "CGameObject.h"

enum class ELEVATOR_STATE
{
	TROUBLE,//Sự cố
	NORMAL//Bình thường
};

class CElevator : public CMoveableObject
{
public :
	CElevator(int id, int typeID, CSprite sprite, float vX, Vector2 positionBegin);

	~CElevator();

	int Initlize() override;

	void Update(CGameTime* gameTime) override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;

private:
	// Cho biết trạng thái là đang tấn công hay không?
	ELEVATOR_STATE _state;
	// Tạo sự cố
	void RaiseATrouble();
	// Đã tạo sự cố hay chưa
	bool _isRaisedTrouble;

};

#endif // !_CELEVATOR_H_