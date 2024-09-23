#include "CFactoryStaticObject.h"
#include "CHidenObject.h"
#include "CSWeapon.h"
#include "CWallTurret.h"
#include "CGroundCannon.h"
#include "CSniper.h"
#include "CBridge.h"
#include "CDefenseCannon.h"
#include "CSoldier.h"
#include "CGunner.h"
#include "CScubaSolider.h"
#include "CBridgeFire.h"
#include "CBridgeStone.h"
#include "CBigCapsule.h"
#include "CMechanicalAlien.h"

CFactoryStaticObject::~CFactoryStaticObject()
{

}

CGameObject* CFactoryStaticObject::CreateObject(int idObject)
{
	switch(idObject)
	{
	case 1001:
		{
			return nullptr;
		}
	}
}

CGameObject* CFactoryStaticObject::CreateObject(const std::vector<int>& info)
{
	int idType;
	if(!info.empty())
	{
		idType = info.at(0);
		switch(idType)
		{
		case 15001://Ground
		case 15002://Water
		case 15003:	// sjnh weapon
		case 15004:	// sinh enemy
		case 15005:	// Hieu ung no cau
		case 15006://Soldier_right :
		case 15007://Soldier_left: 
		case 15008://Ground no falling
		case 15009://Soldier_Shoot_left: 
		case 15010://Soldier_Shoot_right: 
		case 15011://Hidden ve BigStone
		case 15012://Create BigStone
		case 15013://Create Bullet Laze
		case 15014://Hidden ve Bullet laze
		case 15015://Hidden ko cho contra di qua da
		case 14002: //Dan F
		case 14003: //Dan L
		case 14004: //Dan M
		case 14005: //Dan R
		case 14006: //Dan S
		case 14001: //Dan S
			{
				return new CHidenObject(info);
			}
			// TT
		case 11000:
			{
				return new CSoldier(info);
			}
		case 11001: case 11002:
			{
				return new CSniper(info);
			}
		case 11003: //Wallturret
			{
				return new CWallTurret(info);
			}
		case 11004: //Cannon
			{
				return new CGroundCanon(info);
			}
		case 11005: //Scuba Soldier
			{
				return new CScubaSolider(info);
			}
		case 11006: //Gunner
			{
				return new CGunner(info);
			}
		case 13002: //Dan F
		case 13003: //Dan L
		case 13004: //Dan M
		case 13005: //Dan R
		case 13006: //Dan S
		case 13001: //Dan S
			{
				return new CSWeapon(info);
			}
		case 16001:
			{
				return new CBridge(info);
			}
		case 16002:
			{
				return new CBridgeFire(info);
			}
		case 16003:
			{
				return new CBridgeStone(info);
			}
		case 17001://Boss map 1
			{
				return new CDefenseCannon(info);
			}
		case 17005://Boss map 3
			{
				return new CMechanicalAlien(info);
			}
		case 17010://Boss map 5
			{
				return new CBigCapsule(info);
			}
		default:
			return nullptr;
		}
	}
	return nullptr;
}