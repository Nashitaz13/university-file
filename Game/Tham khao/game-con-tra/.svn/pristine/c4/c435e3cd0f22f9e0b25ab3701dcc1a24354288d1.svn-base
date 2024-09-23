#include "CFactoryDynamicObject.h"
#include "CSoldier.h"
#include "CBigStone.h"
#include "CSoldierShoot.h"
#include "CTank.h"
#include "CBulletLaze.h"

CFactoryDynamicObject::~CFactoryDynamicObject()
{

}

CGameObject* CFactoryDynamicObject::CreateObject(int idObject)
{
	switch(idObject)
	{
	case 1001:
		{
			return nullptr;
		}
	}
}

CGameObject* CFactoryDynamicObject::CreateObject(const std::vector<int>& info)
{
	int idObject;
	float posX;
	float posY;
	if(!info.empty())
	{
		idObject = info.at(0);
		posX = info.at(1);
		posY = info.at(2);
		switch (idObject)
		{
			//case 12001:
			//{
			//			  return new CBigStone(info);
			//}
			case 12002:
			{
						  return new CSoldier(info);
			}
			case 12003:
			{
						  return new CSoldierShoot(info);
			}
			case 12004:
			{
						  return new CTank(info);
			}
			//case 12005:
			//{
			//			  return new CBulletLaze(info);
			//}
			case 14002: //Dan B
			{
							//return new CWeapon(info);
			}
		}
	}
	return nullptr;
}