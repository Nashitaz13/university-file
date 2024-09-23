
#include "Lake.h"


Lake::Lake(void): GameObject()
{
}

Lake::Lake(float _posX, float _posY, int _width, int _height):
	GameObject(_posX, _posY, EnumID::Lake_ID)
{
	width = _width;
	height = _height;	
}

Lake::~Lake(void)
{
}
