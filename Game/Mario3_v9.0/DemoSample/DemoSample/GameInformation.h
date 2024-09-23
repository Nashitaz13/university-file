#pragma once
#ifndef __GameInformation_H__
#define __GameInformation_H__

#include <string>
#include "Resource.h"
#include "MyRectangle.h"
#include "MovableObject.h"

#define FONT_FILE L"Font\\SuperMarioBros.ttf"


class CGameInformation : public MovableObject
{
private:
	int _Score, _Money, _Lives, _World;
	MyRectangle* _MyRect;
	int NewTime, OldTime;
	RECT rect;												// Rect v? khung ?en
	RECT rectItem1;
	RECT rectItem2;// Rect v? khung ?en
	LPDIRECT3DSURFACE9 back_buffer = NULL;
	LPDIRECT3DSURFACE9 surface = NULL;
	LPDIRECT3DSURFACE9 back_buffer1 = NULL;
	LPDIRECT3DSURFACE9 back_buffer2 = NULL;
	LPDIRECT3DSURFACE9 surface1 = NULL;
	LPDIRECT3DSURFACE9 surface2 = NULL;
	LPDIRECT3DSURFACE9 surface3 = NULL;
	

	int ytam = 0;
	int xtam = 0;
	std::string sodiem;
	std::string mang;

	void VeChuDong(std::string, D3DCOLOR);
	int iFontValue = 0;
	std::string ConvertIntToString(int i);

public:
	CGameInformation();
	~CGameInformation();

	int _gameTimer;

	void DrawTextString(int x, int y, std::string message, D3DCOLOR color);
	void DrawIntString(int x, int y, int value);

	void initBlackBox();
	void RenderBlackBox();
	void RenderNam1();
	void RenderSao1();
	void RenderHoa1();
	void RenderNam2();
	void RenderSao2();
	void RenderHoa2();
	int cardNumber1, cardNumber2;

	void SetScore(int score, int x1, int y1);
	int GetScore();
	void RenderScore();

	void SetMoney(int money, int x1, int y1);
	int GetMoney();
	void RenderMoney();

	void SetLive(int live, int x1, int y1);
	int GetLive();
	void RenderLive();

	void RenderTimer();

	virtual void Render();
	void Update();
};

extern CGameInformation* cGameInformation;
#endif