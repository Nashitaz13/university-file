#include "OngNuoc.h"
#include "mario.h"


OngNuoc::OngNuoc(float _x, float _y, int _width, int _height, float _x1, float _y1, int _width1, int _height1, bool _down)
{
	x = _x;
	y = _y;
	x1 = _x1;
	y1 = _y1;
	width1 = _width1;
	height1 = _height1;
	down = _down;
	type = Type::ot_ongnuoc;
	currBox->SetBox(_width , _height);
	currBox->x = x + 1;
	currBox->y = y;
	*preBox = *currBox;
	if (Level == 1)
	{
		ongvao = ongra = new MyRectangle(368, 74, 32, 32, 1, 1, 0);
		ongvaoX = 2272;
		ongvaoY = 320;
		ongraX = 2336;
		ongraY = 48;
	}
	if (Level == 2)
	{
		ongvao = ongra = new MyRectangle(416, 74, 32, 32, 1, 1, 0);
		ongvaoX = 352;
		ongvaoY = 192;
		ongraX = 128;
		ongraY = 192;
	}
	if (Level == 3)
	{
		ongvao = ongra = new MyRectangle(368, 74, 32, 32, 1, 1, 0);
		ongvaoX = 1184;
		ongvaoY = 160;
		ongraX = 960;
		ongraY = 112;
	}
	if (Level == 4)
	{
		ongra = new MyRectangle(416, 74, 32, 32, 1, 1, 0);
		ongvao = new MyRectangle(448, 74, 32, 32, 1, 1, 0);
		ongvaoX = 0;
		ongvaoY = 48;
		ongraX = 112;
		ongraY = 368;
	}
}

void OngNuoc::Render()
{
	marioSprite->Render(ongvaoX, ongvaoY, ongvao->Rect);
	marioSprite->Render(ongraX, ongraY, ongra->Rect);
}

OngNuoc::~OngNuoc()
{
}
