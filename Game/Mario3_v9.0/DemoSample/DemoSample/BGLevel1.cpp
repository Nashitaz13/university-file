#include "BGLevel1.h"




BGLevel1::BGLevel1() : CBackground()
{
	mRect = new MyRectangle(0, 0, 16, 16, 176, 176, 0);
	CBackground::LoadMatrix(TEXTFILE_LV1);
}


void BGLevel1::Render()
{
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			mRect->Index = matrix[i][j];
			mRect->UpdateRect();
			background1->Render(j * BACKGROUND_CELL_SIZE, _Height - i * BACKGROUND_CELL_SIZE, mRect->Rect);
		}
	}
}


BGLevel1::~BGLevel1() 
{
}


BGLevel1* Background1 = new BGLevel1();