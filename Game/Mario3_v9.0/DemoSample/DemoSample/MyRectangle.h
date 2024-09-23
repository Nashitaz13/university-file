#pragma once
#ifndef __MyRectangle_H__
#define __MyRectangle_H__

#include <windows.h>
#include "GlobalObject.h"

#define DefaultFrameTime 200;			// Xac dinh khoang thoi gian mac dinh giua hai frame

class MyRectangle
{
public:
	~MyRectangle(void);
	MyRectangle(float x, float y, float width, float height, int total, int spritePerRow, int frameTime);
	MyRectangle();

	void Next();				// Chuy?n ??n frame ti?p theo trong sprite
	void UpdateRect();			// Thay ??i frame ???c v? ti?p theo ??ng ngh?a v?i thay ??i Rect // Rect: là hình ch? nh?t t??ng ?ng v?i t?ng frame ?ó
	void Update();				// Update frame cua sprite
	void SetIndex(int index);	// Set Index
public:
	// T?a ?? c?a t?ng Sprite trong hình l?n
	float X, Y;

	// Hình ch? nh?t dùng ?? xác ??nh t?ng frame trong Sprite
	RECT Rect;

	// Chi?u cao c?a m?i frame
	int Height;

	// Chi?u r?ng c?a m?i frame
	int Width;

	// Index t??ng ?ng v?i m?i frame trong sprite
	// ??ng th?i c?ng là index c?a frame hi?n ?ang ???c v?
	int Index;

	// T?ng s? frame trong sprite
	int Total;

	// So luong sprite trên mot hàng
	int SpritePerRow;

	// Khoang thoi gian chuyen doi giua hai frame
	int FrameTime;

	// Tinh tong thoi gian ke tu luc bat dau ve frame thu nhat
	// Khi tong thoi gian nay bang voi FrameTime, se nhay qua frame moi
	int Tick;

	// Xem thu co the nhay qua frame moi duoc k, hay k thuc hien animation nua
	bool NextFrame;
};

#endif