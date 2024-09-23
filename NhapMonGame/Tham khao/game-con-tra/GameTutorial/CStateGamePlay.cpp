#include "CStateManagement.h"
#include "CStateGamePlay.h"	
#include "CStateMenu.h"
#include "CDevice.h"
#include "CCamera.h"
#include "CLoadBackGround.h"
#include "CLoadGameObject.h"
#include "CDrawObject.h"
#include "CCollision.h"
#include "CPoolingObject.h"
#include "CManageAudio.h"
#include "CLifeItem.h"

CStateGamePlay::CStateGamePlay()
{
}

CStateGamePlay::CStateGamePlay(int mapId)
{
	this->m_mapId = mapId;
	this->m_scenseManager = new CScenseManagement();
}

CStateGamePlay::~CStateGamePlay()
{

}

void CStateGamePlay::Init()	
{
	CLoadBackGround::GetInstance()->LoadAllResourceFromFile();
	CLoadGameObject::GetInstance()->LoadReSourceFromFile();
	//Tinh
	CLoadBackGround::GetInstance()->ChangeBackGround(this->m_mapId);
	CLoadGameObject::GetInstance()->ChangeMap(this->m_mapId);
	
	// Khoi tao enemy effect
	CPoolingObject::GetInstance()->CreateEnemyEffect(30);
	CPoolingObject::GetInstance()->CreateExplosionEffect(30);
	CPoolingObject::GetInstance()->CreateBulletEffect(40);
	CPoolingObject::GetInstance()->CreateBulletItem(20);
	
	CPoolingObject::GetInstance()->CreateSoliderObject(10);
	CPoolingObject::GetInstance()->CreateSoliderShootObject(10);
	CPoolingObject::GetInstance()->CreateBigStone(12);
	CPoolingObject::GetInstance()->CreateSoliderShootObject(10);
	CPoolingObject::GetInstance()->CreateCapsuleBoss(25);
	CPoolingObject::GetInstance()->CreateBulletLaze(10);

	//TT
	CPoolingObject::GetInstance()->CreateWeapon(15);
	//Load Audio
	switch (CMenuGameScense::m_mapId)
	{
	case 10:
		//Dung sound background map 1
		ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_1);
		break;
	case 11:
		//Dung sound background map 3
		ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_3);
		break;
	case 12:
		//Dung sound background map 5
		ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_5);
		break;
	default:
		break;
	}
	//Tinh--> Manage Scense
	this->m_scenseManager->Init();
}

void CStateGamePlay::Update(float deltaTime)
{
	//Neu game chưa over thi update cac doi tuong
	if (!CContra::GetInstance()->m_isGameOver)
	{
		CLoadGameObject::GetInstance()->Update(deltaTime);
		CContra::GetInstance()->Update(deltaTime);
		CContra::GetInstance()->OnCollision(deltaTime, CLoadGameObject::GetInstance()->GetListGameObjectOnScreen());
		CLoadBackGround::GetInstance()->Update(deltaTime);
	}
	//Van update binh thuong cac doi tuong pooling
	if (!CContra::GetInstance()->m_isGameOver)//Tinh test 14/1
		CPoolingObject::GetInstance()->Update(deltaTime, CLoadGameObject::GetInstance()->GetListGameObjectOnScreen());

	//Update cho Cac man hinh
	this->m_scenseManager->Update(deltaTime);
}

void CStateGamePlay::Render()
{
	//Ve Background
	CLoadBackGround::GetInstance()->Draw();
	//Neu game chưa over thi render cac doi tuong
	if (!CContra::GetInstance()->m_isGameOver)//Tinh test 14/1
	{
		CLoadGameObject::GetInstance()->Draw();
		//Draw Object
		if (CContra::GetInstance()->m_isHided)
		{
			CDrawObject::GetInstance()->Draw(CContra::GetInstance(), D3DCOLOR_ARGB(127, 255, 255, 255));
		}
		else
		{
			CDrawObject::GetInstance()->Draw(CContra::GetInstance(), D3DCOLOR_ARGB(255, 255, 255, 255));
		}
		// Draw Pooling Object
		CPoolingObject::GetInstance()->Draw();
		//VE LIFE ITEM
		if (!CScenseManagement::m_isWinScenseShowed || !CScenseManagement::m_isGameWinner)
			CLifeItem::GetInstance()->Draw();
	}

	//Render cho cac man hinh 
	this->m_scenseManager->Render();
}

void CStateGamePlay::Destroy()
{

}