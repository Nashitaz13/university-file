#ifndef _LAKE_H_
#define _LAKE_H_

#include "GameObject.h"
#include "CEnum.h"

class Lake: public GameObject
{
public:
	Lake(void);
	Lake(float _posX, float _posY, int _width, int _height);
	~Lake(void);
};

#endif