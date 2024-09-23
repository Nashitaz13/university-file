#include "CPoolingObject.h"
#include "CDrawObject.h"
#include "CGameObject.h"
#include "CCamera.h"
#include "CLoadGameObject.h"
#include "CContra.h"

bool CPoolingObject::m_isContraHaveBulletItemR = false;

CPoolingObject::CPoolingObject()
{

}

void CPoolingObject::CreateEnemyEffect(int size)
{
	if (this->m_enemyEffect.empty())
	{
		for (int i = 0; i < size; i++)
		{
			CEnemyEffect* effectTemp;
			effectTemp = new CEnemyEffect();
			this->m_enemyEffect.push_back(effectTemp);
		}
	}

}

void CPoolingObject::CreateBulletItem(int size)
{
	if (this->m_listBulletItem.empty())
	{
		for (int i = 0; i < size; i++)
		{
			CBulletItem* bulletItem;
			bulletItem = new CBulletItem();
			this->m_listBulletItem.push_back(bulletItem);
		}
	}
}

void CPoolingObject::CreateExplosionEffect(int size)
{
	if (this->m_explosionEffect.empty())
	{
		for (int i = 0; i < size; i++)
		{
			CExplosionEffect* effectTemp;
			effectTemp = new CExplosionEffect();
			this->m_explosionEffect.push_back(effectTemp);
		}
	}
}

void CPoolingObject::CreateBulletEffect(int size)
{
	if (this->m_bulletEffect.empty())
	{
		for (int i = 0; i < size; i++)
		{
			CBulletEffect* effectTemp;
			effectTemp = new CBulletEffect();
			this->m_bulletEffect.push_back(effectTemp);
		}
	}
}

void CPoolingObject::CreateSoliderObject(int size)
{
	if (this->m_listSolider.empty())
	{
		for (int i = 0; i < size; i++)
		{
			CSoldier* soldier;
			soldier = new CSoldier();
			this->m_listSolider.push_back(soldier);
		}
	}
}

void CPoolingObject::CreateSoliderShootObject(int size)
{
	if (this->m_listSoliderShoot.empty())
	{
		for (int i = 0; i < size; i++)
		{
			CSoldierShoot* soldierShoot;
			soldierShoot = new CSoldierShoot();
			this->m_listSoliderShoot.push_back(soldierShoot);
		}
	}
}

void CPoolingObject::CreateBigStone(int size)
{
	if (this->m_listBigStone.empty())
	{
		for (int i = 0; i < size; i++)
		{
			CBigStone* bigStone;
			bigStone = new CBigStone();
			this->m_listBigStone.push_back(bigStone);
		}
	}
}

void CPoolingObject::CreateWeapon(int size)
{
	if (this->m_listWeapon.empty())
	{
		for (int i = 0; i < size; i++)
		{
			CWeapon* weapon;
			weapon = new CWeapon();
			this->m_listWeapon.push_back(weapon);
		}
	}
}

void CPoolingObject::CreateCapsuleBoss(int size)
{
	if (this->m_listCapsuleBoss.empty())
	{
		for (int i = 0; i < size; i++)
		{
			CCapsuleBoss* capsule;
			capsule = new CCapsuleBoss();
			this->m_listCapsuleBoss.push_back(capsule);
		}
	}
}

void CPoolingObject::CreateBulletLaze(int size)
{
	if (this->m_listBulletLaze.empty())
	{
		for (int i = 0; i < size; i++)
		{
			CBulletLaze* laze;
			laze = new CBulletLaze();
			this->m_listBulletLaze.push_back(laze);
		}
	}
}

CSoldier* CPoolingObject::GetSoliderObject()
{
	CSoldier* obj = nullptr;
	CSoldier* objCheck = nullptr;
	int count = 0;
	for (std::vector<CSoldier*>::iterator it = this->m_listSolider.begin();
		it != this->m_listSolider.end();
		++it)
	{
		objCheck = *it;
		if (obj == nullptr)
		{
			obj = *it;
			if (!obj->IsAlive())
			{
				obj->Init();
			}
			else
			{
				obj = nullptr;
			}
		}
		if (objCheck->IsAlive())
		{
			count++;
		}
	}

	// kiem tra so luong soldier toi da tren man hinh
	if (count < 4)
	{
		count = 0;
		return obj;
	}
	else
		return nullptr;
}

CSoldierShoot* CPoolingObject::GetSoliderShootObject()
{
	CSoldierShoot* obj = nullptr;
	CSoldierShoot* objCheck = nullptr;
	int count = 0;
	for (std::vector<CSoldierShoot*>::iterator it = this->m_listSoliderShoot.begin();
		it != this->m_listSoliderShoot.end();
		++it)
	{
		objCheck = *it;
		if (obj == nullptr)
		{
			obj = *it;
			if (!obj->IsAlive())
			{
				obj->Init();
			}
			else
			{
				obj = nullptr;
			}
		}
		if (objCheck->IsAlive())
		{
			count++;
		}
	}

	// kiem tra so luong soldier toi da tren man hinh
	if (count < 3)
	{
		count = 0;
		return obj;
	}
	else
		return nullptr;
}

CBigStone* CPoolingObject::GetBigStone()
{
	CBigStone* obj = nullptr;
	CBigStone* objCheck = nullptr;
	int count = 0;
	for (std::vector<CBigStone*>::iterator it = this->m_listBigStone.begin();
		it != this->m_listBigStone.end();
		++it)
	{
		objCheck = *it;
		if (obj == nullptr)
		{
			obj = *it;
			if (!obj->IsAlive())
			{
				obj->Init();
			}
			else
			{
				obj = nullptr;
			}
		}
		if (objCheck->IsAlive())
		{
			count++;
		}
	}
	// kiem tra so luong bigStone toi da tren man hinh
	/*if (count < 4)
	{
	count = 0;
	return obj;
	}
	else
	return nullptr;*/
	return obj;
}

CBulletItem* CPoolingObject::GetBulletItem()
{
	for (std::vector<CBulletItem*>::iterator it = this->m_listBulletItem.begin();
		it != this->m_listBulletItem.end();
		++it)
	{
		CBulletItem* obj = *it;
		if (!obj->IsAlive())
		{
			obj->Init();
			return obj;
			break;
		}
	}
}

CEnemyEffect* CPoolingObject::GetEnemyEffect()
{
	for (std::vector<CEnemyEffect*>::iterator it = this->m_enemyEffect.begin();
		it != this->m_enemyEffect.end();
		++it)
	{
		CEnemyEffect* obj = *it;
		if (!obj->IsAlive())
		{
			return obj;
			break;
		}
	}
}

CExplosionEffect* CPoolingObject::GetExplosionEffect()
{
	for (std::vector<CExplosionEffect*>::iterator it = this->m_explosionEffect.begin();
		it != this->m_explosionEffect.end();
		++it)
	{
		CExplosionEffect* obj = *it;
		if (!obj->IsAlive())
		{
			return obj;
			break;
		}
	}
}

CBulletEffect* CPoolingObject::GetBulletEffect()
{
	for (std::vector<CBulletEffect*>::iterator it = this->m_bulletEffect.begin();
		it != this->m_bulletEffect.end();
		++it)
	{
		CBulletEffect* obj = *it;
		if (!obj->IsAlive())
		{
			return obj;
			break;
		}
	}
}

CWeapon* CPoolingObject::GetWeapon()
{
	for (std::vector<CWeapon*>::iterator it = this->m_listWeapon.begin();
		it != this->m_listWeapon.end();
		++it)
	{
		CWeapon* obj = *it;
		if (!obj->IsAlive())
		{
			return obj;
			break;
		}
	}
}

CCapsuleBoss* CPoolingObject::GetCapsuleBoss()
{
	for (std::vector<CCapsuleBoss*>::iterator it = this->m_listCapsuleBoss.begin();
		it != this->m_listCapsuleBoss.end();
		++it)
	{
		CCapsuleBoss* obj = *it;
		if (!obj->IsAlive())
		{
			return obj;
			break;
		}
	}
}

CBulletLaze* CPoolingObject::GetBulletLaze()
{
	CBulletLaze* obj = nullptr;
	CBulletLaze* objCheck = nullptr;
	int count = 0;
	for (std::vector<CBulletLaze*>::iterator it = this->m_listBulletLaze.begin();
		it != this->m_listBulletLaze.end();
		++it)
	{
		objCheck = *it;
		if (obj == nullptr)
		{
			obj = *it;
			if (!obj->IsAlive())
			{
				obj->Init();
			}
			else
			{
				obj = nullptr;
			}
		}
		if (objCheck->IsAlive())
		{
			count++;
		}
	}
	//Random so luong laze
	int ranCountLaze = 1 + rand() % 4;
	// kiem tra so luong laze toi da tren man hinh
	if (count < ranCountLaze)
	{
		count = 0;
		return obj;
	}
	else
		return nullptr;

}

void CPoolingObject::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	// Update enemyEffect
	for (std::vector<CEnemyEffect*>::iterator it = this->m_enemyEffect.begin();
		it != this->m_enemyEffect.end();
		++it)
	{
		CEnemyEffect* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime);
		}

	}

	// Update explosionEffect

	for (std::vector<CExplosionEffect*>::iterator it = this->m_explosionEffect.begin();
		it != this->m_explosionEffect.end();
		++it)
	{
		CExplosionEffect* obj = *it;
		if (obj->GetBox().h < 0)
			int temp = 0;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime);
		}

	}
	// Update bulletEffect

	for (std::vector<CBulletEffect*>::iterator it = this->m_bulletEffect.begin();
		it != this->m_bulletEffect.end();
		++it)
	{
		CBulletEffect* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime);
		}

	}

	////Update bullet
	//for (int i = 0; i < this->m_listBulletOfObject.size(); ++i)
	//{
	//	CBullet* obj = this->m_listBulletOfObject.at(i);
	//	if (obj->GetBox().h < 0)
	//		int temp = 0;

	//	if (obj != NULL && obj->IsAlive())
	//	{
	//		obj->Update(deltaTime);
	//		obj->Update(deltaTime, listObjectCollision);
	//		D3DXVECTOR3 pos;
	//		pos.x = obj->GetPos().x;
	//		pos.y = obj->GetPos().y;
	//		pos = CCamera::GetInstance()->GetPointTransform(pos.x, pos.y);
	//		if (pos.x > __SCREEN_WIDTH || pos.x < 0 || pos.y > __SCREEN_HEIGHT || pos.y < 0
	//			|| !obj->IsAlive())
	//		{
	//			delete obj;
	//			this->m_listBulletOfObject.erase(m_listBulletOfObject.begin() + i);
	//		}
	//	}
	//}

	//Update bullet
	for (std::vector<CBullet*>::iterator it = this->m_listBulletOfObject.begin();
		it != this->m_listBulletOfObject.end();)
	{
		CBullet* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime, listObjectCollision);
			D3DXVECTOR3 pos;
			pos.x = obj->GetPos().x;
			pos.y = obj->GetPos().y;
			pos = CCamera::GetInstance()->GetPointTransform(pos.x, pos.y);
			if (pos.x > __SCREEN_WIDTH || pos.x < 0 || pos.y > __SCREEN_HEIGHT || pos.y < 0
				|| !obj->IsAlive())
			{
				//delete obj;
				it = this->m_listBulletOfObject.erase(it);
			}
			else
			{
				++it;
			}
		}
	}

	//Update BulletItem
	for (std::vector<CBulletItem*>::iterator it = this->m_listBulletItem.begin();
		it != this->m_listBulletItem.end();
		++it)
	{
		CBulletItem* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime, CLoadGameObject::GetInstance()->GetListGameObjectOnScreen());
		}

	}

	//Update Soldier
	for (std::vector<CSoldier*>::iterator it = this->m_listSolider.begin();
		it != this->m_listSolider.end();
		++it)
	{
		CSoldier* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime, CLoadGameObject::GetInstance()->GetListGameObjectOnScreen());
		}

	}

	//Update Soldier Shoot
	for (std::vector<CSoldierShoot*>::iterator it = this->m_listSoliderShoot.begin();
		it != this->m_listSoliderShoot.end();
		++it)
	{
		CSoldierShoot* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime, CLoadGameObject::GetInstance()->GetListGameObjectOnScreen());
		}

	}

	//Update Big Stone
	for (std::vector<CBigStone*>::iterator it = this->m_listBigStone.begin();
		it != this->m_listBigStone.end();
		++it)
	{
		CBigStone* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime, CLoadGameObject::GetInstance()->GetListGameObjectOnScreen());
		}

	}

	//Update Weapon
	for (std::vector<CWeapon*>::iterator it = this->m_listWeapon.begin();
		it != this->m_listWeapon.end();
		++it)
	{
		CWeapon* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime, CLoadGameObject::GetInstance()->GetListGameObjectOnScreen());
		}

	}

	//Update Capsule
	for (std::vector<CCapsuleBoss*>::iterator it = this->m_listCapsuleBoss.begin();
		it != this->m_listCapsuleBoss.end();
		++it)
	{
		CCapsuleBoss* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime, CLoadGameObject::GetInstance()->GetListGameObjectOnScreen());
		}

	}

	//Update Bullet Laze
	for (std::vector<CBulletLaze*>::iterator it = this->m_listBulletLaze.begin();
		it != this->m_listBulletLaze.end();
		++it)
	{
		CBulletLaze* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime, CLoadGameObject::GetInstance()->GetListGameObjectOnScreen());
		}

	}

	//Update Bullet of scuba solider 
	for (std::vector<CBullet_ScubaSolider*>::iterator it = this->m_listBulletScubaSolider.begin();
		it != this->m_listBulletScubaSolider.end();
		++it)
	{
		CBullet_ScubaSolider* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			obj->Update(deltaTime, CLoadGameObject::GetInstance()->GetListGameObjectOnScreen());
		}

	}
}

void CPoolingObject::Draw()
{
	// Draw enemyEffect 
	for (std::vector<CEnemyEffect*>::iterator it = this->m_enemyEffect.begin();
		it != this->m_enemyEffect.end();
		++it)
	{
		CEnemyEffect* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}
	}

	// Draw explosionEffect
	for (std::vector<CExplosionEffect*>::iterator it = this->m_explosionEffect.begin();
		it != this->m_explosionEffect.end();
		++it)
	{
		CExplosionEffect* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}
	}

	// Draw bulletEffect
	for (std::vector<CBulletEffect*>::iterator it = this->m_bulletEffect.begin();
		it != this->m_bulletEffect.end();
		++it)
	{
		CBulletEffect* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}
	}

	//Draw bullet
	for (int i = 0; i < this->m_listBulletOfObject.size(); ++i)
	{
		CBullet* obj = this->m_listBulletOfObject.at(i);//*it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}
	}

	////Draw bullet
	//for (std::vector<CBullet*>::iterator it = this->m_listBulletOfObject.begin();
	//	it != this->m_listBulletOfObject.end();
	//	++it)
	//{
	//	CBullet* obj = *it;
	//	if (obj != NULL && obj->IsAlive())
	//	{
	//		CDrawObject::GetInstance()->Draw(obj);
	//	}
	//}

	//Draw bullet Item
	for (std::vector<CBulletItem*>::iterator it = this->m_listBulletItem.begin();
		it != this->m_listBulletItem.end();
		++it)
	{
		CBulletItem* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}
	}

	////Draw Weapon
	for (std::vector<CWeapon*>::iterator it = this->m_listWeapon.begin();
		it != this->m_listWeapon.end();
		++it)
	{
		CWeapon* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}

	}

	//Solider
	for (std::vector<CSoldier*>::iterator it = this->m_listSolider.begin();
		it != this->m_listSolider.end();
		++it)
	{
		CSoldier* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}

	}

	//Solider Shoot
	for (std::vector<CSoldierShoot*>::iterator it = this->m_listSoliderShoot.begin();
		it != this->m_listSoliderShoot.end();
		++it)
	{
		CSoldierShoot* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}

	}

	//Big Stone
	for (std::vector<CBigStone*>::iterator it = this->m_listBigStone.begin();
		it != this->m_listBigStone.end();
		++it)
	{
		CBigStone* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}

	}

	//Capsule
	for (std::vector<CCapsuleBoss*>::iterator it = this->m_listCapsuleBoss.begin();
		it != this->m_listCapsuleBoss.end();
		++it)
	{
		CCapsuleBoss* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}

	}

	//Bullet Laze
	for (std::vector<CBulletLaze*>::iterator it = this->m_listBulletLaze.begin();
		it != this->m_listBulletLaze.end();
		++it)
	{
		CBulletLaze* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}

	}

	//Bullet of Scuba Solider
	for (std::vector<CBullet_ScubaSolider*>::iterator it = this->m_listBulletScubaSolider.begin();
		it != this->m_listBulletScubaSolider.end();
		++it)
	{
		CBullet_ScubaSolider* obj = *it;
		if (obj != NULL && obj->IsAlive())
		{
			CDrawObject::GetInstance()->Draw(obj);
		}

	}
}

void CPoolingObject::Reset()
{
	if (m_listBulletOfObject.size() > 0)
		m_listBulletOfObject.clear();
	if (m_listWeapon.size() > 0)
		m_listWeapon.clear();
	if (m_listBulletLaze.size() > 0)
		m_listBulletLaze.clear();
	if (m_listBulletScubaSolider.size() > 0)
		m_listBulletScubaSolider.clear();
	if (m_listBigStone.size() > 0)
		m_listBigStone.clear();
	if (m_listCapsuleBoss.size() > 0)
		m_listCapsuleBoss.clear();
	if (m_listSolider.size() > 0)
		m_listSolider.clear();
	if (m_listSoliderShoot.size() > 0)
		m_listSoliderShoot.clear();
	if (m_listBulletItem.size() > 0)
		m_listBulletItem.clear();
	if (m_enemyEffect.size() > 0)
		m_enemyEffect.clear();
	if (m_explosionEffect.size() > 0)
		m_explosionEffect.clear();
	if (m_bulletEffect.size() > 0)
		m_bulletEffect.clear();
	//
	this->CreateBulletItem(20);
	this->CreateEnemyEffect(30);
	this->CreateExplosionEffect(30);
	this->CreateBulletEffect(40);
	this->CreateSoliderObject(10);
	this->CreateSoliderShootObject(10);
	this->CreateBigStone(12);
	this->CreateSoliderShootObject(10);
	this->CreateCapsuleBoss(25);
	this->CreateBulletLaze(10);
	this->CreateWeapon(15);
}