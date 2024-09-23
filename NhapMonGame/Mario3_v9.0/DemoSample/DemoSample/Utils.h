#pragma once
#ifndef __Utils_H__
#define __Utils_H__
#include "MyRectangle.h"
#include "Sprite.h"
#include <fstream>
#include <string>

#define BACKGROUND_CELL_SIZE 16
#define TEXTFILE_LV1 L"Map\\Lv1\\Matrix.txt"

struct MATRAN {
	int** matrix;		// Ma trận của map
	int row, col;		// Số cột, số dòng của ma trận
	int width, height;	// Chiều dài và chiều cao của map

	// Cắt đoạn matrix theo viewport
	void ClipMatrix(int &startRow, int &endRow, int &startCol, int &endCol)
	{
		startRow = (ViewPort->getRECT()).bottom / BACKGROUND_CELL_SIZE;
		endRow = (ViewPort->getRECT()).top / BACKGROUND_CELL_SIZE;
		startCol = (ViewPort->getRECT()).left / BACKGROUND_CELL_SIZE;
		endCol = (ViewPort->getRECT()).right / BACKGROUND_CELL_SIZE;
	}
};

MATRAN mMatrix;
CSprite *background;
MyRectangle* rect;

inline void LoadMatran(LPWSTR filePath, CSprite* bg)
{	
	if (mMatrix.matrix != NULL)
	{
		for (int i = 0; i < mMatrix.row; ++i)
			delete[]  mMatrix.matrix[i];
		delete[]  mMatrix.matrix;
	}
	// Load file lên ma tran
	std::ifstream fileText(filePath);
	fileText >> mMatrix.row;
	mMatrix.height = mMatrix.row * BACKGROUND_CELL_SIZE;
	fileText >> mMatrix.col;
	mMatrix.width = mMatrix.col * BACKGROUND_CELL_SIZE;
	int total;
	fileText >> total;
	rect = new MyRectangle(0, 0, BACKGROUND_CELL_SIZE, BACKGROUND_CELL_SIZE, total, total, 200);
	mMatrix.matrix = new int*[mMatrix.row];
	for (int i = 0; i < mMatrix.row; i++)
	{
		mMatrix.matrix[i] = new int[mMatrix.col];
	}

	for (int i = mMatrix.row - 1; i >=0; i--)
	{
		for (int j = 0; j < mMatrix.col; j++)
		{
			fileText >> mMatrix.matrix[i][j];
		}
	}
	background = bg;
}

inline void LoadBackground()
{
	// For ma tran: Update Rect, Background Render
	int startRow, endRow, startCol, endCol;
	mMatrix.ClipMatrix(startRow, endRow, startCol, endCol);
	for (int i = startRow; i <= endRow; i++)
	{
		for (int j = startCol; j <= endCol; j++)
		{
			rect->Index = mMatrix.matrix[i][j];
			rect->UpdateRect();
			background->Render(j * BACKGROUND_CELL_SIZE, i * BACKGROUND_CELL_SIZE + BACKGROUND_CELL_SIZE, rect->Rect);
		}
	}
}

#endif