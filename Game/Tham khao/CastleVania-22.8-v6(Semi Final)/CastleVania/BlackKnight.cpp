
#include "BlackKnight.h"


BlackKnight::BlackKnight(void): DynamicObject()
{
}

BlackKnight::BlackKnight(float x, float y): DynamicObject(x, y, 0.08f, 0, EnumID::BlackKnight_ID)
{
	type = ObjectType::Enemy_Type;
	point = 400;
	hp = 2;
	damage = 2;
}

BlackKnight::~BlackKnight(void)
{
}
