#include "CGraphics.h"
#include "DSUtil.h"

 CGraphics* CGraphics::_pInstance = NULL;

CGraphics::CGraphics()
{
	this->_pInstance = NULL;
	this->_d3d = NULL;
	this->_d3ddev = NULL;
	this->_surface = NULL;
	this->_backbuffer = NULL;
}

CGraphics::~CGraphics()
{
	if(CGraphics::GetInstance() != nullptr)
	{
		SAFE_DELETE(this->_d3d);
		SAFE_DELETE(this->_d3ddev);
		SAFE_DELETE(this->_surface);
		SAFE_DELETE(this->_backbuffer);
		SAFE_DELETE(this->_pInstance);
	}
}

int CGraphics::Init(HWND hwnd)
{
	//initialize Direct3D
    this->_d3d = Direct3DCreate9(D3D_SDK_VERSION);
    if (this->_d3d == NULL)
    {
        MessageBox(hwnd, L"Error initializing Direct3D", L"Error", MB_OK);
        return 0;
    }

    //set Direct3D presentation parameters
    D3DPRESENT_PARAMETERS d3dpp; 
    ZeroMemory(&d3dpp, sizeof(d3dpp));

	d3dpp.Windowed = (!FULL_SCREEEN);
	d3dpp.SwapEffect = D3DSWAPEFFECT_DISCARD;
    d3dpp.BackBufferFormat = D3DFMT_X8R8G8B8;
    d3dpp.BackBufferCount = 1;
	d3dpp.BackBufferWidth = SCREEN_WIDTH;
	d3dpp.BackBufferHeight = SCREEN_HEIGHT;

    //create Direct3D device
    this->_d3d->CreateDevice(
        D3DADAPTER_DEFAULT, 
        D3DDEVTYPE_HAL, 
        hwnd,
        D3DCREATE_SOFTWARE_VERTEXPROCESSING,
        &d3dpp, 
        &this->_d3ddev);

    if (this->_d3ddev == NULL)
    {
        MessageBox(hwnd, L"Error creating Direct3D device", L"Error", MB_OK);
        return 0;
    }

	HRESULT result;
	// Khởi tạo SpriteHandler
	result= D3DXCreateSprite(_d3ddev, &_spriteHandler);
	if (result != D3D_OK){
		Trace(L"[ERROR] Failed to create Sprite Handler");
		return 0;
	}

	// Khởi tạo font handler
	result = D3DXCreateFont(_d3ddev, FONT_SIZE, 0, FW_NORMAL, 0, FALSE, DEFAULT_CHARSET, OUT_DEFAULT_PRECIS, CLEARTYPE_QUALITY, DEFAULT_PITCH | FF_DONTCARE, L"Megaman 2", &_spriteFontHandler);
	if (result != D3D_OK){
		Trace(L"[ERROR] Failed to create Sprite Font Handler");
		return 0;
	}

    //clear the backbuffer to black
    this->_d3ddev->Clear(0, NULL, D3DCLEAR_TARGET, D3DCOLOR_XRGB(0,0,0), 1.0f, 0);
    //create pointer to the back buffer
    this->_d3ddev->GetBackBuffer(0, 0, D3DBACKBUFFER_TYPE_MONO, &this->_backbuffer);
	result = this->_d3ddev->CreateOffscreenPlainSurface(
		515,					//width of the surface
        450,					//height of the surface
        D3DFMT_X8R8G8B8,    //surface format
        D3DPOOL_DEFAULT,    //memory pool to use
        &this->_surface,           //pointer to the surface
        NULL);       


	return 1;
}

CGraphics* CGraphics::GetInstance()
{
	if(_pInstance == nullptr)
		_pInstance = new CGraphics();

	return _pInstance;
}

DirectX9 CGraphics::GetDirectX9()
{
	return this->_d3d;
}

Device CGraphics::GetDevice()
{
	return this->_d3ddev;
}

Surface CGraphics::GetSurface()
{
	return this->_surface;
}

Surface CGraphics::GetBackBuffer()
{
	return this->_backbuffer;
}

int CGraphics::BeginDraw(CCamera* camera){
	if (this->_d3ddev->BeginScene())
		return 0;

	this->_d3ddev->Clear(0, NULL, D3DCLEAR_TARGET, D3DCOLOR_XRGB(0, 0, 0), 1.0f, 0);
	this->_spriteHandler->Begin(D3DXSPRITE_ALPHABLEND);
	this->_camera=camera;
	return 1;
}

void CGraphics::EndDraw(){
	this->_spriteHandler->End();
	this->_d3ddev->EndScene();
	this->_d3ddev->Present(NULL, NULL, NULL, NULL);
	_camera = NULL;
}

                                                              
void CGraphics::Draw(Texture texture, Rect destinationRectangle, Vector2 position, bool isDrawAtCenter, Vector2 scale, SpriteEffects effects)
{
	//xét định tọa độ tâm của khung hình chữ nhật
	Vector3 center;

	if (isDrawAtCenter){
		center.x = (destinationRectangle.right - destinationRectangle.left) / 2;
		center.y = (destinationRectangle.bottom - destinationRectangle.top) / 2;
		center.z = 0;
	}
	else
	{
		center.x = destinationRectangle.left;
		center.y = destinationRectangle.top;
		center.z = 0;
	}

	// Nếu có set camera thì transform theo camera
	if (_camera != NULL){
		_camera->Transform(&position);
	}

	// đặt lại vị trí tương ứng giá trị scale
	Vector3 positionDraw;
	positionDraw.x = position.x / scale.x;
	positionDraw.y = position.y / scale.y;
	positionDraw.z = 0;

	// tạo hai ma trận lưu trữ hệ thống tọa độ cũ, mới 
	Matrix oldMatrix, newMatrix;

	_spriteHandler->GetTransform(&oldMatrix);
	
	//đặt ma trận scale 
	D3DXMatrixIdentity(&newMatrix);
	newMatrix._11 = scale.x;
	newMatrix._22 = scale.y;

	switch (effects)
	{
	case SpriteEffects::FLIP_HORIZONTALLY:
		newMatrix._11 *= -1;
		positionDraw.x *= -1;
		break;
	case SpriteEffects::FLIP_VERTICALLY:
		newMatrix._22 *= -1;
		positionDraw.y *= -1;
		break;
	default:
		break;
	}

	_spriteHandler->SetTransform(&newMatrix);

	_spriteHandler->Draw(texture, &destinationRectangle, &center, &positionDraw, D3DCOLOR_XRGB(255,255,255));
	
	// đặt lại ma trận ban đầu
	_spriteHandler->SetTransform(&oldMatrix);
}
void CGraphics::Draw(Texture texture, Rect boundingRectangle, bool isDrawAtCenter, Vector2 scale, SpriteEffects effect){
	Rect destinationRectangle;
	destinationRectangle.left = 0;
	destinationRectangle.top = 0;
	destinationRectangle.right = boundingRectangle.right - boundingRectangle.left;
	destinationRectangle.bottom = boundingRectangle.bottom - boundingRectangle.top;

	Vector2 pos(boundingRectangle.left, boundingRectangle.top);

	Draw(texture, destinationRectangle, pos, isDrawAtCenter, scale, effect);
}


void CGraphics::Draw(Texture texture, Rect destinationRectangle, Vector2 position, bool isDrawAtCenter, SpriteEffects effect)
{
	Draw(texture, destinationRectangle, position, isDrawAtCenter, Vector2(1.0f, 1.0f), effect);
}

void CGraphics::Draw(Texture texture, Rect destinationRectangle, Vector2 position, Vector2 scale)
{
	Draw(texture, destinationRectangle, position, true, scale, SpriteEffects::NONE);
}
void CGraphics::DrawString(string text, Vector2 position, Color color, bool isDrawAtCenter){

	Rect destRect;
	destRect.top = position.y;
	destRect.left = position.x;
	destRect.bottom = destRect.top + SCREEN_HEIGHT;
	destRect.right = destRect.left + SCREEN_WIDTH;

	DrawString(text, destRect, color, Vector2(1, 1), isDrawAtCenter);
}
void CGraphics::DrawString(string text, Rect boundingRectangle, Color color, Vector2 scale, bool isDrawAtCenter){

	// Nếu có camera thì chuyển vị theo camera
	if (_camera != NULL)
	{
		Vector2 drawPos(boundingRectangle.left, boundingRectangle.top);
		long width = boundingRectangle.right - boundingRectangle.left;
		long height = boundingRectangle.bottom - boundingRectangle.top;

		_camera->Transform(&drawPos);
		boundingRectangle.left = drawPos.x;
		boundingRectangle.top = drawPos.y;
		boundingRectangle.right = boundingRectangle.left + width;
		boundingRectangle.bottom = boundingRectangle.top + height;
	}

	// Chỉnh giá trị scale cho phù hợp
	Matrix oldMatrix, newMatrix;
	_spriteHandler->GetTransform(&oldMatrix);

	// Tìm ra vị trí mới trong hệ tọa độ hệ thống mới
	boundingRectangle.top /= scale.y;
	boundingRectangle.left /= scale.x;

	// Cài đặt tọa độ hệ thống mới
	D3DXMatrixIdentity(&newMatrix);
	newMatrix._11 = scale.x;
	newMatrix._22 = scale.y;

	// Cài đặt hệ thống tọa độ mới
	_spriteHandler->SetTransform(&newMatrix);

	// Kiểm tra nếu chỉ định là vẽ tại tâm đoạn Text thì cần tính lại vị trí của khung hình chữ nhật
	if (isDrawAtCenter){
		boundingRectangle.top += FONT_SIZE / 2;
		boundingRectangle.left -= (FONT_SIZE*text.length()) / 2;
		boundingRectangle.bottom = boundingRectangle.top + SCREEN_HEIGHT;
		boundingRectangle.right = boundingRectangle.left + SCREEN_WIDTH;
	}

	// Vẽ bóng chữ
	Rect boundingRectangleShadow;
	boundingRectangleShadow.top = boundingRectangle.top + 1;
	boundingRectangleShadow.left = boundingRectangle.left + 1;
	boundingRectangleShadow.bottom = boundingRectangleShadow.top + SCREEN_HEIGHT;
	boundingRectangleShadow.right = boundingRectangleShadow.left + SCREEN_WIDTH;
	_spriteFontHandler->DrawTextA(_spriteHandler, text.c_str(), text.length(), &boundingRectangleShadow, DT_LEFT, D3DCOLOR_XRGB(0, 0, 0));

	// Tiến hành vẽ chữ tại vị trí mới trong hệ thống tọa độ mới
	_spriteFontHandler->DrawTextA(_spriteHandler, text.c_str(), text.length(), &boundingRectangle, DT_LEFT, color);
	
	// Reset lại ma trận hệ thống
	_spriteHandler->SetTransform(&oldMatrix);
}