#ifndef _GAMEOBJECT_H_
#define _GAMEOBJECT_H_

#include "CSprite.h"
#include "Singleton.h"
#include "CCamera.h"
#include "SweptAABB.h"
#include "SoundManager.h"
#include <list>
using namespace std;
class GameObject
{
public:
	CSprite* sprite;
	//posX, posY -> toa do center
	float posX, posY;
	int width;
	int height;
	float vX, vY;
	ObjectType type;
	bool canMove;
	bool active;
	bool death;
	//Cac thong so
	EnumID id;
	int hearts;
	int hp;
	int damage;
	int point;

	virtual void Update(int dt);
	virtual void Draw(CCamera*);
	virtual void ProcessInput(LPDIRECT3DDEVICE9 d3ddv, int t);
	virtual void OnKeyDown(int KeyCode);
	virtual void CreateSprite();
	virtual void Collision(list<GameObject*> obj, int dt);
	ECollisionDirect GetCollisionDirect(float normalx, float normaly);
	virtual Box GetBox();
	virtual void SetActive(float x, float y);
	virtual void SetActive();
	virtual void Remove();
	virtual void ReceiveDamage (int damagePoint);

	GameObject(void);
	GameObject(float posX, float posY, EnumID id);
	~GameObject(void);
};

#endif
