#include "ChuP.h"
#include "World.h"

ChuP::~ChuP()
{
}
ChuP::ChuP(float _x, float _y)
{
	SetXY(_x, _y);
	this->type = Type::ot_chuP;
	this->currRect = new MyRectangle(164, 134, 16, 16, 2, 2, 200);
	this->currBox->SetBox(currRect->Width, currRect->Height);
	*preBox = *currBox;
}
void ChuP::Render()
{
	currRect->Update();
	marioSprite->Render(x, y, currRect->Rect);
}
void ChuP::OnCollisionWithMario()
{
	quadtree->ThemObjectVaoQuadtree(new ChuP_Off(x, y - 9), false);
	this->IsRelease = true;
	for each ( Gach* gach in listGach)
	{
		gach->XuatHienDongTien();
	}
	
}
