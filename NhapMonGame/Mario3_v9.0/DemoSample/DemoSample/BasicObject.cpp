#include "BasicObject.h"

BasicObject::~BasicObject()
{
}

BasicObject::BasicObject()
{
	this->x = this->y = 0;
	this->currBox = new CBox();
	this->preBox = new CBox();
	type = Type::ot_ground;
}
BasicObject::BasicObject(float x, float y, float width, float height)
{
	this->x = x;
	this->y = y;
	this->currBox = new CBox(this->x, this->y, width, height);
	this->preBox = new CBox(this->x, this->y, width, height);
	this->type = Type::ot_ground;
}
float BasicObject::CheckCollision(BasicObject* sObject, CollisionDirection &direction)
{
	if (CheckBroadPhase(sObject))
	{
		direction = CollisionDirection::cd_none;
		return 1.0f;
	}
	float tempVx = 0;
	float tempVy = 0;
	float entryTime, exitTime;
	float tEntryX, tEntryY, dEntryX, dEntryY;
	float tExitX, tExitY, disExitX, disExitY;
	int daux = 1;
	int dauy = 1;

	if ((vx >= 0 && sObject->vx < 0 && sObject->type!= ot_firebullet)
		&& (y - currBox->height <= sObject->y - sObject->currBox->height)
		&& (y - currBox->height >sObject->y - sObject->currBox->height -3))
	{
		if (vx == 0)
		{
			vx = 0.085;					
		}
		tempVx = vx*DeltaTime;
		daux = -1;
	}
	else
	{
		tempVx = (currBox->x + currBox->width) - (preBox->x + preBox->width) - (sObject->currBox->x - sObject->preBox->x);
		if (vx > 0 && sObject->vx > 0)
			daux = -1;
	}
		
		if (sObject->type == ot_gach || sObject->type== ot_odauhoi)
		{
			if ((y-currBox->height > sObject->y - sObject->currBox->height + 10) || (sObject->y - 10> y))
			{
				tempVy = (currBox->y - currBox->height) - (preBox->y - preBox->height) - (sObject->currBox->y - sObject->preBox->y);
				tempVx = abs((currBox->x + currBox->width) - (preBox->x + preBox->width));
			}
			else
			{
				if ((pretype == ot_gach)&&
					(!((y - currBox->height > sObject->y - sObject->currBox->height + 10) || (sObject->y - 10 > y)))
					&& (!(y<sObject->y) || currBox->height<= sObject->currBox->height))
				{
					direction = CollisionDirection::cd_none;
					return 0.5f;
				}
			}

		}
		else
		{
			tempVy = (currBox->y - currBox->height) - (preBox->y - preBox->height) - (sObject->currBox->y - sObject->preBox->y);
		}

		pretype = sObject->type;
	// find the distance between the objects on the near and far sides for both x and y
	if (tempVx > 0.0f)
	{
		dEntryX = sObject->preBox->x - (preBox->x + preBox->width);
		disExitX = (sObject->preBox->x + sObject->preBox->width) - preBox->x;
		if (dEntryX < 0 && daux == -1)
			dEntryX = daux*dEntryX;
	}
	else
	{
		dEntryX = sObject->preBox->x + sObject->preBox->width - preBox->x;
		disExitX = sObject->preBox->x - (preBox->x + preBox->width);
	}

	if (tempVy > 0.0f)
	{
		dEntryY = (sObject->preBox->y - sObject->preBox->height) - preBox->y;
		disExitY = sObject->preBox->y - (preBox->y - preBox->height);
	
	}
	else
	{
		dEntryY = sObject->preBox->y - (preBox->y - preBox->height);
		disExitY = (sObject->preBox->y - sObject->preBox->height) - preBox->y;

	}

	// find time of collision and time of leaving for each axis (if statement is to prevent divide by zero)
	if (tempVx == 0.0f)
	{
		tEntryX = -std::numeric_limits<float>::infinity();
		tExitX = std::numeric_limits<float>::infinity();
	}
	else
	{
		tEntryX = dEntryX / tempVx;
		tExitX = disExitX / tempVx;
	}

	if (tempVy == 0.0f)
	{
		tEntryY = -std::numeric_limits<float>::infinity();
		tExitY = std::numeric_limits<float>::infinity();
	}
	else
	{
		tEntryY = dEntryY / tempVy;
		tExitY = disExitY / tempVy;
	}

	// find the earliest/latest times of collision
	entryTime = max(tEntryX, tEntryY);
	exitTime = min(tExitX, tExitY);

	// if there was no collision
	if ((entryTime > exitTime) || !((tEntryX > 0.0f && tEntryX <= 1.0f) || (tEntryY > 0.0f && tEntryY <= 1.0f)))
	{
		if(sObject->type == ot_odauhoi)
			int i = 0;
		direction = CollisionDirection::cd_none;
		return 1.0f;
	}
	else // if there was a collision
	{
		// calculate normal of collided surface
		if (tEntryX > tEntryY)
		{
			if (dEntryX < 0.0f)
			{
				direction = CollisionDirection::cd_phai;	// va cham canh phai cua static object	
			}
			else
			{
				direction = CollisionDirection::cd_trai; // va cham canh trai cua static object
			}
		}
		else
		{
			
			if (dEntryY < 0.0f)
			{
				direction = CollisionDirection::cd_tren; // va cham canh tren cua static object
			}
			else
			{
				direction = CollisionDirection::cd_duoi; // va cham canh duoi cua static object
			}
			
		}
		return entryTime;	// return thoi gian bat dau xay ra va cham
	}
}
bool BasicObject::CheckBroadPhase(BasicObject *sObject)
{
	RECT rect;
	rect.top = max(currBox->y, preBox->y);
	rect.left = min(currBox->x, preBox->x);
	rect.right = max(currBox->x + currBox->width, preBox->x + preBox->width);
	rect.bottom = min(currBox->y - currBox->height, preBox->y - preBox->height);

	if (rect.right >= sObject->currBox->x &&  rect.left <= (sObject->currBox->x + sObject->currBox->width)
		&& rect.bottom <= sObject->currBox->y && rect.top >= (sObject->currBox->y - sObject->currBox->height))
	{
		return false;
	}

	return true;
}
RECT BasicObject::getRECT()
{
	RECT temp = { currBox->x, currBox->y, currBox->x + currBox->width, currBox->y - currBox->height };
	return temp;
}

float BasicObject::Collision(BasicObject* sObject, CollisionDirection &direction)
{
	if (CheckBroadPhase(sObject))
	{
		direction = CollisionDirection::cd_none;
		return 1.0f;
	}
	float tempVx = 0;
	float tempVy = 0;
	float entryTime, exitTime;
	float tEntryX, tEntryY, dEntryX, dEntryY;
	float tExitX, tExitY, disExitX, disExitY;
	int daux = 1;
	// Tinh van toc tuong doi cua 2 doi tuong (xem sObject la static object)
	if (vx > 0 && sObject->vx < 0 && type == ot_turtle)
	{
		vx = 0.12; // toc do rua lan
		tempVx = vx*DeltaTime;
		daux = -1;
	}
	else
		tempVx = (currBox->x + currBox->width) - (preBox->x + preBox->width) - (sObject->currBox->x  - sObject->preBox->x);
	tempVy = (currBox->y - currBox->height) - (preBox->y - preBox->height) - (sObject->currBox->y - sObject->preBox->y);

	// find the distance between the objects on the near and far sides for both x and y
	if (tempVx > 0.0f)
	{
		dEntryX = sObject->preBox->x - (preBox->x + preBox->width);
		disExitX = (sObject->preBox->x + sObject->preBox->width) - preBox->x;
		if (dEntryX < 0 && daux == -1)
			dEntryX = daux*dEntryX;
	}
	else
	{
		dEntryX = sObject->preBox->x + sObject->preBox->width - preBox->x;
		disExitX = sObject->preBox->x - (preBox->x + preBox->width);
	}

	if (tempVy > 0.0f)
	{
		dEntryY = (sObject->preBox->y - sObject->preBox->height) - preBox->y;
		disExitY = sObject->preBox->y - (preBox->y - preBox->height);
	}
	else
	{
		dEntryY = sObject->preBox->y - (preBox->y - preBox->height);
		disExitY = (sObject->preBox->y - sObject->preBox->height) - preBox->y;
	}

	// find time of collision and time of leaving for each axis (if statement is to prevent divide by zero)
	if (tempVx == 0.0f)
	{
		tEntryX = -std::numeric_limits<float>::infinity();
		tExitX = std::numeric_limits<float>::infinity();
	}
	else
	{
		tEntryX = dEntryX / tempVx;
		tExitX = disExitX / tempVx;
	}

	if (tempVy == 0.0f)
	{
		tEntryY = -std::numeric_limits<float>::infinity();
		tExitY = std::numeric_limits<float>::infinity();
	}
	else
	{
		tEntryY = dEntryY / tempVy;
		tExitY = disExitY / tempVy;
	}

	// find the earliest/latest times of collision
	entryTime = max(tEntryX, tEntryY);
	exitTime = min(tExitX, tExitY);

	// if there was no collision
	if ((entryTime > exitTime) || !((tEntryX > 0.0f && tEntryX <= 1.0f) || (tEntryY > 0.0f && tEntryY <= 1.0f)))
	{
		direction = CollisionDirection::cd_none;
		return 1.0f;
	}
	else // if there was a collision
	{
		// calculate normal of collided surface
		if (tEntryX > tEntryY)
		{
			if (dEntryX < 0.0f)
			{
				direction = CollisionDirection::cd_phai;	// va cham canh phai cua static object	
			}
			else
			{
				direction = CollisionDirection::cd_trai; // va cham canh trai cua static object
			}
		}
		else
		{
			if (dEntryY < 0.0f)
			{
				direction = CollisionDirection::cd_tren; // va cham canh tren cua static object
			}
			else
			{
				direction = CollisionDirection::cd_duoi; // va cham canh duoi cua static object
			}
		}
		return entryTime;	// return thoi gian bat dau xay ra va cham
	}
}

D3DXVECTOR3* ReturnParabol(float _RootX, float _RootY, float _CrossX, float _CrossY)
{
	D3DXVECTOR3 *vReturn = new D3DXVECTOR3(0, 0, 0);
	vReturn->x = (_CrossY - _RootY) / (_CrossX*_CrossX - 2 * _RootX * _CrossX + _RootX * _RootX);
	vReturn->y = -2 * _RootX * vReturn->x;
	vReturn->z = _RootY + _RootX * _RootX * vReturn->x;
	return vReturn;
}