#include "background.h"


CBackground::CBackground()
{
	mRect = new MyRectangle();
}

void CBackground::LoadMatrix(LPWSTR FileText)
{
	ifstream fileText(FileText);

	fileText >> row;
	fileText >> col;
	_Width = col * BACKGROUND_CELL_SIZE;
	_Height = row * BACKGROUND_CELL_SIZE;

	matrix = new int*[row];
	for (int i = 0; i < row; i++)
	{
		matrix[i] = new int[col];
	}

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			fileText >> matrix[i][j];
		}
	}
}


CBackground::~CBackground()
{
	delete mRect;
	delete[]matrix;
}