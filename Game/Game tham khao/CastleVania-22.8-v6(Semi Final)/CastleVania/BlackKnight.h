#ifndef _BLACKNIGHT_H_
#define _BLACKNIGHT_H_

#include "DynamicObject.h"

class BlackKnight: public DynamicObject
{
public:
	BlackKnight(void);
	BlackKnight(float x, float y);
	~BlackKnight(void);
};

#endif