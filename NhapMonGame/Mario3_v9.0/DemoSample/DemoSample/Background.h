#pragma once
#ifndef __Background_H__
#define __Background_H__

#include <d3d9.h>
#include <d3dx9.h>
#include <fstream>
#include "Resource.h"
#include "GlobalObject.h"
#include "MyRectangle.h"

using namespace std;

#define BACKGROUND_CELL_SIZE 16
#define TEXTFILE_LV2 L"Map\\Lv2\\Matrix.txt"

class CBackground
{
public:
	CBackground();

	float _Width;
	float _Height;
	MyRectangle* mRect;

	int** matrix;
	int row, col;

	void LoadMatrix(LPWSTR FileText);

	virtual void Render() = 0;

	~CBackground();
};

#endif