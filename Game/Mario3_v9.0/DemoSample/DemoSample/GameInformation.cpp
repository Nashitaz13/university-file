#include "GameInformation.h"

CGameInformation::CGameInformation()
{
	_MyRect = new MyRectangle(0, 150, 270, 40, 1, 1, 1);
	_Score = _Money = 0;
	_Lives = 3;
	_World = 1;
	_gameTimer = 300;
	sodiem = "";
	mang = "";
	NewTime = timeGetTime();
	OldTime = NewTime;
}


CGameInformation::~CGameInformation()
{
	RemoveFontResourceEx(
		(LPCSTR)FONT_FILE,  // name of font file
		FR_PRIVATE,   		// font characteristics
		NULL         		// Reserved.
		);
}

void CGameInformation::Render()
{
	RenderBlackBox();
	if (cardNumber1 == 1)
		RenderNam1();
	if (cardNumber1 == 2)
		RenderHoa1();
	if (cardNumber1 == 3)
		RenderSao1();
	if (cardNumber2 == 1)
		RenderNam2();
	if (cardNumber2 == 2)
		RenderHoa2();
	if (cardNumber2 == 3)
		RenderSao2();
	RenderMoney();
	RenderLive();
	RenderScore();
	RenderTimer();

	VeChuDong(sodiem, D3DCOLOR_XRGB(255, 255, 255));	// V? ?i?m khi ?n ???c

	VeChuDong(mang, D3DCOLOR_XRGB(255, 0, 0));			// V? m?ng khi ?n ???c

}

void CGameInformation::RenderMoney()
{
	// Ve tien
	DrawTextString(130, 178, ConvertIntToString(_Money), D3DCOLOR_XRGB(0, 0, 0));
}

void CGameInformation::RenderBlackBox()
{
	D3ddv->StretchRect(surface,			// from 
		NULL,				// which portion?
		back_buffer,		// to 
		&rect,				// which portion?
		D3DTEXF_NONE);	
}
void CGameInformation::RenderNam1()
{
	D3ddv->StretchRect(surface1,			// from 
		NULL,				// which portion?
		back_buffer1,		// to 
		&rectItem1,				// which portion?
		D3DTEXF_NONE);
}
void CGameInformation::RenderHoa1()
{
	D3ddv->StretchRect(surface2,			// from 
		NULL,				// which portion?
		back_buffer1,		// to 
		&rectItem1,				// which portion?
		D3DTEXF_NONE);
}

void CGameInformation::RenderSao1()
{
	D3ddv->StretchRect(surface3,			// from 
		NULL,				// which portion?
		back_buffer1,		// to 
		&rectItem1,				// which portion?
		D3DTEXF_NONE);
}
void CGameInformation::RenderNam2()
{
	D3ddv->StretchRect(surface1,			// from 
		NULL,				// which portion?
		back_buffer2,		// to 
		&rectItem2,				// which portion?
		D3DTEXF_NONE);
}
void CGameInformation::RenderHoa2()
{
	D3ddv->StretchRect(surface2,			// from 
		NULL,				// which portion?
		back_buffer2,		// to 
		&rectItem2,				// which portion?
		D3DTEXF_NONE);
}
void CGameInformation::RenderSao2()
{
	D3ddv->StretchRect(surface3,			// from 
		NULL,				// which portion?
		back_buffer2,		// to 
		&rectItem2,				// which portion?
		D3DTEXF_NONE);
}

void CGameInformation::RenderLive()
{
	// Ve Mang
	DrawTextString(36, 189, ConvertIntToString(_Lives), D3DCOLOR_XRGB(0, 0, 0));
}

void CGameInformation::RenderTimer()
{
	DrawTextString(130, 190, ConvertIntToString(_gameTimer), D3DCOLOR_XRGB(0, 0, 0));
}

void CGameInformation::RenderScore()
{
	// Ve Diem
	DrawTextString(10, 178, ConvertIntToString(_Score), D3DCOLOR_XRGB(0, 0, 0));
}

void CGameInformation::VeChuDong(std::string chu, D3DCOLOR Color) {
	//ve diem khi an duoc
	if (xtam != 0 && ytam != 0)
	{
		DrawTextString(xtam, ytam, chu, Color);
	}
}
void CGameInformation::Update()
{
	// cap nhat toa do ve diem
	if (ytam > (_ScreenHeight - y) - 100)
	{
		ytam = ytam - 2;
	}
	else
	{
		xtam = 0;
		ytam = 0;
	}
	_Score = GetScore();
	_Money = GetMoney();
	NewTime = timeGetTime();
	float dt = (float)(NewTime - OldTime) / 1000; //delta time
	if (dt >= 1)
	{
		OldTime = NewTime;
		_gameTimer--;
	}

}

void CGameInformation::SetScore(int score, int x1, int y1)
{
	_Score += score; // Set diem
	mang = "";
	sodiem = "";
	if (score != 50)
	{
		sodiem = ConvertIntToString(score);
	}
	x = x1;
	y = y1;
	xtam = x - ViewPort->_X;
	ytam = (ViewPort->_Y - y);
}

int CGameInformation::GetScore()
{
	return _Score;
}

void CGameInformation::SetMoney(int money, int x1, int y1)
{
	_Money += money; // Set tien
	mang = "";
	sodiem = "";
	x = x1;
	y = y1;
	xtam = x - ViewPort->_X;
	ytam = (ViewPort->_Y - y);
}

int CGameInformation::GetMoney()
{
	return _Money;
}

void CGameInformation::SetLive(int live, int x1, int y1)
{
	_Lives += live; // Set diem
	sodiem = "";
	mang = "";
	if (live > 0)
	{
		mang = "1 UP";
	}
	x = x1;
	y = y1;
	xtam = x - ViewPort->_X;
	ytam = (ViewPort->_Y - y);
}

int CGameInformation::GetLive()
{
	return _Lives;
}



void CGameInformation::DrawTextString(int x, int y, std::string message, D3DCOLOR color)
{
	ID3DXFont *font;
	RECT fontRect;

	font = NULL;

	HRESULT hr = D3DXCreateFont(D3ddv, 14, 0, 100, 1, false, DEFAULT_CHARSET,
		OUT_DEFAULT_PRECIS, ANTIALIASED_QUALITY, FF_DONTCARE,
		"Arial", &font);
	if (!SUCCEEDED(hr))
	{
		return;
	}

	SetRect(&fontRect, x, y, 500, 500);

	if (font)
	{
		font->DrawTextA(NULL, message.c_str(), -1, &fontRect, DT_LEFT, color);
	}
	if (font) {
		font->Release(); font = 0;

	}
}

void CGameInformation::DrawIntString(int x, int y, int value)
{
	DrawTextString(x, y, ConvertIntToString(value), D3DCOLOR_XRGB(0, 0, 0));

}

void CGameInformation::initBlackBox()
{
	D3ddv->GetBackBuffer(0, 0, D3DBACKBUFFER_TYPE_MONO, &back_buffer);
	D3ddv->GetBackBuffer(0, 0, D3DBACKBUFFER_TYPE_MONO, &back_buffer1);
	D3ddv->GetBackBuffer(0, 0, D3DBACKBUFFER_TYPE_MONO, &back_buffer2);

	D3ddv->CreateOffscreenPlainSurface(
		276,			// width 				
		120,			// height
		D3DFMT_X8R8G8B8,		// format
		D3DPOOL_DEFAULT,
		&surface,
		NULL);
	D3ddv->CreateOffscreenPlainSurface(
		276,			// width 				
		120,			// height
		D3DFMT_X8R8G8B8,		// format
		D3DPOOL_DEFAULT,
		&surface1,
		NULL);
	D3ddv->CreateOffscreenPlainSurface(
		276,			// width 				
		120,			// height
		D3DFMT_X8R8G8B8,		// format
		D3DPOOL_DEFAULT,
		&surface2,
		NULL);
	D3ddv->CreateOffscreenPlainSurface(
		276,			// width 				
		120,			// height
		D3DFMT_X8R8G8B8,		// format
		D3DPOOL_DEFAULT,
		&surface3,
		NULL);

	// Load Surface
	int result = D3DXLoadSurfaceFromFile(
		surface, 			// surface
		NULL,				// destination palette	
		NULL,				// destination rectangle 
		(LPCSTR)"Image\\khung_den.png",	// Image
		NULL,				// source rectangle
		D3DX_DEFAULT, 		// filter image
		D3DCOLOR_XRGB(0, 0, 0),			// transparency (0 = none)
		NULL);

	D3DXLoadSurfaceFromFile(
		surface1, 			// surface
		NULL,				// destination palette	
		NULL,				// destination rectangle 
		(LPCSTR)"Image\\cardItem\\namItem.png",	// Image
		NULL,				// source rectangle
		D3DX_DEFAULT, 		// filter image
		D3DCOLOR_XRGB(0, 0, 0),			// transparency (0 = none)
		NULL);
	D3DXLoadSurfaceFromFile(
		surface2, 			// surface
		NULL,				// destination palette	
		NULL,				// destination rectangle 
		(LPCSTR)"Image\\cardItem\\hoaItem.png",	// Image
		NULL,				// source rectangle
		D3DX_DEFAULT, 		// filter image
		D3DCOLOR_XRGB(0, 0, 0),			// transparency (0 = none)
		NULL);
	D3DXLoadSurfaceFromFile(
		surface3, 			// surface
		NULL,				// destination palette	
		NULL,				// destination rectangle 
		(LPCSTR)"Image\\cardItem\\saoItem.png",	// Image
		NULL,				// source rectangle
		D3DX_DEFAULT, 		// filter image
		D3DCOLOR_XRGB(0, 0, 0),			// transparency (0 = none)
		NULL);

	rect.left = 0;
	rect.top = ViewPort->_Height;
	rect.right = _ScreenWidth;
	rect.bottom = _ScreenHeight;


	rectItem1.left = 179;
	rectItem1.top = ViewPort->_Height + 12;
	rectItem1.right = rectItem1.left + 16;
	rectItem1.bottom = rectItem1.top + 16;

	rectItem2.left = 211;
	rectItem2.top = ViewPort->_Height + 12;
	rectItem2.right = rectItem2.left + 16;
	rectItem2.bottom = rectItem2.top + 16;
}

std::string CGameInformation::ConvertIntToString(int i) {

	std::string s = std::to_string(i);
	return s.c_str();  //use char const* as target type

}

CGameInformation* cGameInformation = new CGameInformation();