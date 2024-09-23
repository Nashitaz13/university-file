#ifndef FireBullet_Header
#define FireBullet_Header

#include "GlobalObject.h"
#include "Input.h"
#include <map>
#include <fstream>
#include <string>
#include <sstream>
#include "MovableObject.h"

enum FireBullet_Alpha {
	ALPHA_1, 
	ALPHA_2,
	ALPHA_3,
	ALPHA_4,
};

class FireBullet : public MovableObject
{
private:
	float _tanAlpha;
public:
	~FireBullet();
	FireBullet(float X, float Y, float tanAlpha);
	virtual void UpdatePosition();
	virtual void UpdateCollision();
	virtual void Render();	// Render object
	void SetX(float);
	void SetY(float);
	void SetXY(float, float);
};
#endif

