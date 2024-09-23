#pragma once
#ifndef __World_H__
#define __World_H__

#include "QuadTree.h"
#include <fstream>
#include <string>
#include <sstream>
#include <vector>

#include "MovableObject.h"
#include "RedFirePlant.h"
#include "DongTien.h"
#include "ODauHoi.h"
#include "Turtle.h"
#include "NamEnemy.h"
#include "NamItem.h"
#include "Gach.h"
#include "OngNuoc.h"
#include "EndBox.h"
#include "BoxStair.h"

using namespace std;

extern vector<BasicObject*> listObject;
extern vector<BasicObject*> prelistObject;
extern vector<BasicObject*> listGround;
extern vector<FireBullet*> listBullet;
extern vector<RedFirePlant*> listRedFirePlant;
extern vector<DongTien*> listDongTien;
extern vector<ODauHoi*> listODauHoi;
extern vector<Turtle*> listTurtle;
extern vector<NamEnemy*> listNamEnemy;
extern vector<NamItem*> listNamItem;
extern vector<Gach*> listGach;
extern vector<OngNuoc*> listOngNuoc;
extern vector<EndBox*> listEndBox;
extern vector<CBoxStair*> listBoxStair;

class World
{
private:
	Type StringToType(string);
	void FilterLists();
	void UpdatePosition();
	void UpdateCollision();
	
	void DeleteObject(BasicObject* ob);
	void CheckRelease();
	void UpdatePositionPreList();
public:
	World();
	~World();
	void LoadListObject();
	void DeleteAllObject();
	void Render();
	void Update();
	vector<BasicObject*>::iterator FindIterator(BasicObject* ob);
};

extern World* world;
void InsertElementToListObject(BasicObject* position, BasicObject* value);
#endif