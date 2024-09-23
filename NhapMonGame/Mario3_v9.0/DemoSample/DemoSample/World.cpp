#include "World.h"
#include "mario.h"

vector<BasicObject*> listObject;
vector<BasicObject*> prelistObject;
vector<BasicObject*> listGround;
vector<FireBullet*> listBullet;
vector<RedFirePlant*> listRedFirePlant;
vector<DongTien*> listDongTien;
vector<ODauHoi*> listODauHoi;
vector<Turtle*> listTurtle;
vector<NamEnemy*> listNamEnemy;
vector<NamItem*> listNamItem;
vector<Gach*> listGach;
vector<OngNuoc*> listOngNuoc;
vector<EndBox*> listEndBox;
vector<CBoxStair*> listBoxStair;

World::~World()
{
}
World::World()
{
	LoadListObject();
}
void World::LoadListObject()
{
	DeleteAllObject();
	string path = "";
	switch (Level)
	{
	case 1:
		path = "MapEditor\\MapEditor1.txt";
		break;
	case 2:
		path = "MapEditor\\MapEditor1.1.txt";
		break;
	case 3:
		path = "MapEditor\\MapEditor2.txt";
		break;
	case 4:
		path = "MapEditor\\MapEditor2.1.txt";
		break;
	}
	ifstream fileText(path);
	string line, type;
	int x, y, rong, cao;
	while (!fileText.eof())
	{
		getline(fileText, line);
		istringstream iss(line);
		iss >> type >> x >> y;
		switch (StringToType(type))
		{
		case Type::ot_ground:
			iss >> rong >> cao;
			listObject.push_back(new BasicObject(x, y, rong, cao));
			break;
		case Type::ot_redfireplant:
			bool Do, Ban;
			iss >> Do >> Ban;
			listObject.push_back(new RedFirePlant(x, y, Do, Ban)); //8.5.5
			break;
		case Type::ot_dongtien:
			listObject.push_back(new DongTien(x, y, false));
			break;
		case Type::ot_odauhoi:
			int item;
			int Loai;
			iss >> item >> Loai;
			listObject.push_back(new ODauHoi(x, y, item, Loai));
			break;
		case Type::ot_turtle:
			bool RuaXanh, RuaBay;
			float bien;
			iss >> RuaXanh >> RuaBay >> bien;
			listObject.push_back(new Turtle(x, y, RuaXanh, RuaBay, bien));
			break;
		case Type::ot_namenemy:
			bool Bay;
			iss >> Bay;
			listObject.push_back(new NamEnemy(x, y, Bay));
			break;
		case Type::ot_gach:
			listObject.push_back(new Gach(x, y));
			break;
		case Type::ot_ongnuoc:
			float x1, y1;
			int width, height, width1, height1;
			bool down;
			iss >> width >> height >> x1 >> y1 >> width1 >> height1 >> down;
			listObject.push_back(new OngNuoc(x, y, width, height, x1, y1, width1, height1, down));
			break;
		case Type::ot_endbox:
			listObject.push_back(new EndBox(x, y));
			break;
		case Type::ot_boxstair:
			bool UpLeft;
			iss >> rong >> cao >> UpLeft;
			listObject.push_back(new CBoxStair(x, y, rong, cao,UpLeft));
			break;
		}
	}
	fileText.close();
}
Type World::StringToType(string type)
{
	if (type == "ground")
		return Type::ot_ground;
	if (type == "redfireplant")
		return Type::ot_redfireplant;
	if (type == "DongTien")
		return Type::ot_dongtien;
	if (type == "ODauHoi")
		return Type::ot_odauhoi;
	if (type == "turtle")
		return Type::ot_turtle;
	if (type == "namenemy")
		return Type::ot_namenemy;
	if (type == "gach")
		return Type::ot_gach;
	if (type == "ongnuoc")
		return Type::ot_ongnuoc;
	if (type == "endbox")
		return Type::ot_endbox;
	if (type == "boxstair")
		return Type::ot_boxstair;
}
void World::Render()
{
	for (vector<BasicObject*>::iterator it = listObject.begin();
	it != listObject.end(); it++)
	{
		BasicObject* ob = *it;
		switch (ob->type)
		{
		case Type::ot_ground:
			break;
		default:
			if (ob->type == Type::ot_redfireplant)
				int i = 0;
			((MovableObject*)ob)->Render();
			break;
		}
	}

}
void World::Update()
{
	FilterLists();
	UpdatePosition();
	CollisionDirection cd;
	UpdatePositionPreList();
	// Check rua va ground
	for (int i = 0; i < listTurtle.size(); i++)
	{
		for (int j = 0; j < listGround.size(); j++)
		{
			if (listTurtle[i]->Collision(listGround[j], cd) != 1)
			{
				listTurtle[i]->OnCollisionWithGround(listGround[j], cd);
			}
		}
	}

	// Check nam enemy voi ground
	for (int i = 0; i < listNamEnemy.size(); i++)
	{
		for (int j = 0; j < listGround.size(); j++)
		{
			if (listNamEnemy[i]->Collision(listGround[j], cd) != 1)
			{
				listNamEnemy[i]->OnCollisionWithGround(listGround[j], cd);
			}
		}
	}

	// Check Nam voi ground
	for (int i = 0; i < listNamItem.size(); i++)
	{
		for (int j = 0; j < listGround.size(); j++)
		{
			if (listNamItem[i]->Collision(listGround[j], cd) != 1)
			{
				listNamItem[i]->OnCollisionWithGround(listGround[j], cd);
			}
		}
	}
	// Check Nam voi odauhoi
	for (int i = 0; i < listNamItem.size(); i++)
	{
		for (int j = 0; j < listODauHoi.size(); j++)
		{
			if (listNamItem[i]->Collision(listODauHoi[j], cd) != 1)
			{
				listNamItem[i]->OnCollisionWithODauHoi(listODauHoi[j], cd);
			}
		}
	}
	// Check Nam voi gach
	for (int i = 0; i < listNamItem.size(); i++)
	{
		for (int j = 0; j < listGach.size(); j++)
		{
			if (listNamItem[i]->Collision(listGach[j], cd) != 1)
			{
				listNamItem[i]->OnCollisionWithGach(listGach[j], cd);
			}
		}
	}
	//Check Nam enemy vs O dau hoi
	for (int i = 0; i < listNamEnemy.size(); i++)
	{
		for (int j = 0; j < listODauHoi.size(); j++)
		{
			if (listNamEnemy[i]->Collision(listODauHoi[j], cd) != 1)
			{
				listNamEnemy[i]->OnCollisionWithODauHoi(listODauHoi[j], cd);
			}
		}
	}
	//Check Nam enemy vs O gach
	for (int i = 0; i < listNamEnemy.size(); i++)
	{
		for (int j = 0; j < listGach.size(); j++)
		{
			if (listNamEnemy[i]->Collision(listGach[j], cd) != 1)
			{
				listNamEnemy[i]->OnCollisionWithGach(listGach[j], cd);
			}
		}
	}
	//Check Nam enemy vs Rua
	for (int i = 0; i < listTurtle.size(); i++)
	{
		for (int j = 0; j < listNamEnemy.size(); j++)
		{
			if (listTurtle[i]->Collision(listNamEnemy[j], cd) != 1)
			{
				listNamEnemy[j]->OnCollisionWithTurtle(listTurtle[i], cd);
				listTurtle[i]->OnCollisionWithNamEnemy(listNamEnemy[j], cd);
			}
		}
	}

	//Check Rua vs O dau hoi
	for (int i = 0; i < listTurtle.size(); i++)
	{
		for (int j = 0; j < listODauHoi.size(); j++)
		{
			if (listTurtle[i]->Collision(listODauHoi[j], cd) != 1)
			{
				listTurtle[i]->OnCollisionWithODauHoi(listODauHoi[j], cd);
				listODauHoi[j]->OnCollisionWithTurtle(listTurtle[i], cd);
			}
		}
	}
	//Check Rua vs O gach
	for (int i = 0; i < listTurtle.size(); i++)
	{
		for (int j = 0; j < listGach.size(); j++)
		{
			if (listTurtle[i]->Collision(listGach[j], cd) != 1)
			{
				listTurtle[i]->OnCollisionWithGach(listGach[j], cd);
				listGach[j]->OnCollisionWithTurtle(listTurtle[i], cd);
			}
		}
	}
	//Check Rua vs Rua 
	for (int i = 0; i < listTurtle.size(); i++)
	{
		for (int j = 0; j < listTurtle.size(); j++)
		{
			if (i != j)
			{
				if (listTurtle[i]->Collision(listTurtle[j], cd) != 1)
				{
					listTurtle[i]->OnCollisionWithTurtle(listTurtle[j], cd);
				}
			}
		}
	}
	//Check NamEnemy vs NamEnemy
	for (int i = 0; i < listNamEnemy.size(); i++)
	{
		for (int j = 0; j < listNamEnemy.size(); j++)
		{
			if (i != j)
			{
				if (listNamEnemy[i]->Collision(listNamEnemy[j], cd) != 1)
				{
					listNamEnemy[i]->OnCollisionWithNamEnemy(listNamEnemy[j], cd);
				}
			}
		}
	}
	//Check Rua vs FirePlant 
	for (int i = 0; i < listTurtle.size(); i++)
	{
		for (int j = 0; j < listRedFirePlant.size(); j++)
		{
			if (listTurtle[i]->Collision(listRedFirePlant[j], cd) != 1)
			{
				listRedFirePlant[j]->OnCollisionWithTurtle();
			}
		}
	}

	for (int i = 0; i < listNamEnemy.size(); i++)
	{
		for (int j = 0; j < listBoxStair.size(); j++)
		{
			if (listNamEnemy[i]->Collision(listBoxStair[j], cd) != 1)
			{
				listNamEnemy[i]->OnCollisionWithBoxStair(listBoxStair[j]);
			}
		}
	}
	// CheckRelease
	CheckRelease();
	// Update lan cuoi cung cua tat ca doi tuong
	UpdateCollision();
}
void World::FilterLists()
{
	listGround.clear();
	listTurtle.clear();
	listBullet.clear();
	listRedFirePlant.clear();
	listDongTien.clear();
	listODauHoi.clear();
	listNamEnemy.clear();
	listNamItem.clear();
	listGach.clear();
	listOngNuoc.clear();
	listEndBox.clear();
	listBoxStair.clear();
	for (int i = 0; i < listObject.size(); i++)
	{
		BasicObject* ob = listObject[i];
		switch (ob->type)
		{
		case Type::ot_ground:
			listGround.push_back(ob);
			break;
		case Type::ot_redfireplant:
			listRedFirePlant.push_back((RedFirePlant*)ob);
			break;
		case Type::ot_firebullet:
			listBullet.push_back((FireBullet*)ob);
			break;
		case Type::ot_dongtien:
			listDongTien.push_back((DongTien*)ob);
			break;
		case Type::ot_odauhoi:
			listODauHoi.push_back((ODauHoi*)ob);
			break;
		case Type::ot_turtle:
			listTurtle.push_back((Turtle*)ob);
			break;
		case Type::ot_namenemy:
			listNamEnemy.push_back((NamEnemy*)ob);
			break;
		case Type::ot_namitem:
			listNamItem.push_back((NamItem*)ob);
			break;
		case Type::ot_gach:
			listGach.push_back((Gach*)ob);
			break;
		case Type::ot_ongnuoc:
			listOngNuoc.push_back((OngNuoc*)ob);
			break;
		case Type::ot_endbox:
			listEndBox.push_back((EndBox*)ob);
			break;
		case Type::ot_boxstair:
			listBoxStair.push_back((CBoxStair*)ob);
			break;
		}
	}
}
void World::UpdatePosition()
{
	for (int i = 0; i < listObject.size(); i++)
	{
		listObject[i]->UpdatePosition();
	}
}
void World::UpdateCollision()
{
	for (int i = 0; i < listObject.size(); i++)
	{
		listObject[i]->UpdateCollision();
	}
}
void World::DeleteObject(BasicObject* ob)
{
	for (vector<BasicObject*>::iterator it = listObject.begin();
	it != listObject.end(); it++)
	{
		if (*it == ob)
		{
			delete *it;
			listObject.erase(it);
			return;
		}
	}
}
void World::DeleteAllObject()
{
	listObject.clear();
}
void World::CheckRelease()
{
	for (vector<BasicObject*>::iterator it = listObject.begin();
	it != listObject.end(); it++)
	{
		BasicObject* ob = *it;
		if (ob->IsRelease)
		{
			//delete ob;
			if(Level==1 || Level==3)
				quadtree->root_->XoaObjectKhoiNode(ob);
			it = listObject.erase(it);
			if (it != listObject.begin())
				it--;
			if (it == listObject.end())
				break;
		}
	}
}
void InsertElementToListObject(BasicObject* position, BasicObject* value)
{
	vector<BasicObject*>::iterator it = listObject.begin();
	for (int i = 0; i < listObject.size(); i++)
	{
		if (*it == position)
		{
			it--;
			listObject.insert(it, value);
			return;
		}
		it++;
	}
}
vector<BasicObject*>::iterator World::FindIterator(BasicObject* ob)
{
	for (vector<BasicObject*>::iterator it = listObject.begin();
	it != listObject.end(); it++)
	{
		if (*it == ob)
			return it;
	}
}
void World::UpdatePositionPreList()
{
	for (int i = 0; i < prelistObject.size(); i++)
	{
		prelistObject[i]->UpdateRootPosition();
	}
}
World* world = new World();