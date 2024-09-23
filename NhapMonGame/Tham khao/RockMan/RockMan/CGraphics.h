#ifndef _CGRAPHICS_H_
#define _CGRAPHICS_H_

#include "CGlobal.h"
#include "Config.h"
#include "Trace.h"
#include "CCamera.h"


enum SpriteEffects{
	NONE				= 0, // Không chỉ định xoay
	FLIP_HORIZONTALLY	= 1, // Xoay 1 góc 180 quanh trục Y
	FLIP_VERTICALLY		= 2  // Xoay 1 góc 180 quanh trục X
};

class CGraphics
{
public:
	~CGraphics();
	//-----------------------------------------------------------------------------
	// Khởi tạo đối tượng Graphics
	//
	// Kết quả trả về = 1 là khởi tạo thành công, = 1 là khởi tạo lỗi.
	//-----------------------------------------------------------------------------
	int Init(HWND hwnd);
	static CGraphics* GetInstance();
	DirectX9 GetDirectX9();
	Device	GetDevice();
	Surface GetBackBuffer();
	Surface GetSurface();

	//-----------------------------------------------------------------------------
	// Khởi tạo môi trường vẽ
	// 
	//	Trả về 1: Thành công
	//	Trả về 0: Thất bại
	//-----------------------------------------------------------------------------
	int BeginDraw(CCamera* camera=NULL);

	//-----------------------------------------------------------------------------
	// Hoàn tất công đoạn vẽ
	//-----------------------------------------------------------------------------
	void EndDraw();

	//-----------------------------------------------------------------------------
	// Vẽ một sprite lên màn hình
	//
	// + texture: đối tượng texture cần vẽ
	// + destinationRectangle: khung frame cần vẽ
	// + position: tọa độ cần vẽ(lưu ý transform tọa độ trước)
	// + isDrawAtCenter: có vẽ tại tâm không 
	// + scale: scale đối tượng 
	// + effects: lật đối tượng
	// + colorNotDraw: màu chỉ định không vẽ lên màn hình
	//-----------------------------------------------------------------------------
	void Draw(Texture texture, Rect destinationRectangle, Vector2 position, bool isDrawAtCenter, Vector2 scale = Vector2(1, 1), SpriteEffects effects = SpriteEffects::NONE);
	void Draw(Texture texture, Rect destinationRectangle, Vector2 position, bool isDrawAtCenter, SpriteEffects effect);
	void Draw(Texture texture, Rect destinationRectangle, Vector2 position, Vector2 scale);

	//-----------------------------------------------------------------------------
	// Vẽ một Texture lên màn hình
	//
	// + texture: đối tượng texture cần vẽ
	// + boundingRectangle: khung bao trùm đối tượng chứa luôn position cần vẽ
	// + isDrawAtCenter: có vẽ tại tâm không
	// + scale: mức độ scale hình
	// + effect: hiệu ứng lật đối tượng
	// + colorNotDraw: màu chỉ định không vẽ lên màn hình
	//-----------------------------------------------------------------------------
	void Draw(Texture texture, Rect boundingRectangle, bool isDrawAtCenter = true, Vector2 scale = Vector2(1, 1), SpriteEffects effect = SpriteEffects::NONE);

	//-----------------------------------------------------------------------------
	// Vẽ một đoạn text ra bên ngoài màn hình với chiều cao khung hình chữ nhật bao
	// mặc định là bằng FONT_SIZE = 18
	//
	// + text : Nội dung đoạn text muốn vẽ
	// + position : Vị trí muốn vẽ
	// + color : Màu chữ
	// + isDrawAtCenter : Chỉ định có vẽ tại tâm đoạn text hay không
	//-----------------------------------------------------------------------------
	void DrawString(string text, Vector2 position, Color color = D3DCOLOR_XRGB(255, 255, 255), bool isDrawAtCenter = false);

	//-----------------------------------------------------------------------------
	// Vẽ một đoạn text ra bên ngoài màn hình với chiều cao khung hình chữ nhật tùy
	// chỉnh
	//
	// + text : Nội dung đoạn text muốn vẽ
	// + boundingRectangle : Khung hình chữ nhật bao đoạn text
	// + color : Màu chữ
	// + scale : Mức độ scale của chữ
	// + isDrawAtCenter : Chỉ định có vẽ tại tâm đoạn text hay không
	//-----------------------------------------------------------------------------
	void DrawString(string text, Rect boundingRectangle, Color color = D3DCOLOR_XRGB(255, 255, 255), Vector2 scale = Vector2(1, 1), bool isDrawAtCenter = false);

protected:
	static CGraphics*	_pInstance;
	DirectX9			_d3d;
	Device				_d3ddev;
	Surface				_backbuffer;
	Surface				_surface;
	Sprite				_spriteHandler;
	SpriteFont			_spriteFontHandler;
	CCamera*			_camera;

	CGraphics();
};

#endif //!_CGRAPHICS_H_
