#pragma once
#ifndef __Box_H__
#define __Box_H__

#include <windows.h>

class CBox
{
public:
	float x, y, width, height;
public:
	CBox();
	//CBox &operator=(const CBox&); // We dont need to to this function because of no pointer included members
	CBox(float x, float y, float width, float height);
	void SetBox(float, float, float, float);
	void SetBox(float x, float y);

	~CBox();
};

#endif