#include "GameMario.h"
#include "Utils.h"


GameMario::GameMario(HINSTANCE hInstance) : CGame(hInstance)
{
}
GameMario::~GameMario()
{
}

void  GameMario::Init()
{
//	Level = 2;
	CGame::Init();
	LoadMatran(L"Map\\Lv1\\Matrix.txt", background1);
	RECT* temp = new RECT{ 0,177 * 16,177 * 16,0 };
	quadtree = new QuadTree(temp);
	quadtree->assign(listObject);	
	SoundManager::GetInst()->PlayBGSound(BGSound::BGM1);
	cGameInformation->initBlackBox();
}
void GameMario::RenderFrame()
{
	CGame::RenderFrame();
	LoadBackground();
	if (Level==1 || Level==3)
		quadtree->getListObject(ViewPort->getRECT());

	mario1->Render();
	world->Render();
	cGameInformation->Render();
	
}
void ChuyenMan()
{
	switch (Level)
	{
	case 1:
		SoundManager::GetInst()->RemoveAllBGM();
		SoundManager::GetInst()->PlayBGSound(BGSound::BGM1);
		LoadMatran(L"Map\\Lv1\\Matrix.txt", background1);
		if (!mario1->chuiOng)
			mario1->SetXY(START_X, START_Y);
		break;
	case 2:
		SoundManager::GetInst()->RemoveAllBGM();
		SoundManager::GetInst()->PlayBGSound(BGSound::BGM_under);
		LoadMatran(L"Map\\Lv1.1\\Matrix.txt", background1_1);
		world->LoadListObject();
		/*quadtree1 = new QuadTree(new RECT{ 0, max(mMatrix.col, mMatrix.row) * 16, max(mMatrix.col, mMatrix.row) * 16, 0 });
		quadtree1->assign(listObject);*/
		break;
	case 3:
		SoundManager::GetInst()->RemoveAllBGM();
		SoundManager::GetInst()->PlayBGSound(BGSound::BGM2);
		LoadMatran(L"Map\\Lv2\\Matrix.txt", background2);
		if (!mario1->chuiOng)
			mario1->SetXY(START_X1, START_Y1);
		break;
	case 4:
		SoundManager::GetInst()->RemoveAllBGM();
		SoundManager::GetInst()->PlayBGSound(BGSound::BGM_under);
		LoadMatran(L"Map\\Lv2.1\\Matrix.txt", background2_1);
		world->LoadListObject();
	/*	quadtree1 = new QuadTree(new RECT{ 0, max(mMatrix.col, mMatrix.row) * 16, max(mMatrix.col, mMatrix.row) * 16, 0 });
		quadtree1->assign(listObject);*/
		break;
	}
	ViewPort = new _VIEWPORT(0, _ScreenHeight - 40, _ScreenWidth, _ScreenHeight - 40);
	
}
void GameMario::Update()
{
	if (preLevel != Level)
	{
		ChuyenMan();
		if ((Level == 1 && preLevel != 2) || (Level == 3 && preLevel != 4))
		{
			world->LoadListObject();
			quadtree = new QuadTree(new RECT{ 0, max(mMatrix.col, mMatrix.row) * 16, max(mMatrix.col, mMatrix.row) * 16, 0 });
			quadtree->assign(listObject);
		}
		preLevel = Level;
	}
	if (mario1->die == 0)
	{
		mario1->Update();
		if (!mario1->bienNhoLon && !mario1->bienLonDuoi && mario1->marioAction != MarioAction::chet)
		{
			UpdateViewPort();
			world->Update();
		}
		cGameInformation->Update();
	}
	else
	{
		switch (Level)
		{
		case 1:
			SoundManager::GetInst()->PlayBGSound(BGSound::BGM1);
			break;
		case 2: case 4:
			SoundManager::GetInst()->PlayBGSound(BGSound::BGM_under);
			break;
		case 3:
			SoundManager::GetInst()->PlayBGSound(BGSound::BGM2);
			break;
		}
		world->DeleteAllObject();
		world->LoadListObject();
//		quadtree->~QuadTree();
		quadtree = new QuadTree(new RECT{ 0, max(mMatrix.col, mMatrix.row) * 16, max(mMatrix.col, mMatrix.row) * 16, 0 });
		quadtree->assign(listObject);
		mario1->KhoiTao();
		ViewPort = new _VIEWPORT(0, _ScreenHeight - 40, _ScreenWidth, _ScreenHeight - 40);
		//cGameInformation->Update();
		mario1->die = 0;
	}
}
void GameMario::UpdateViewPort()
{
	if (mario1->x >= ViewPort->_Width / 2 &&
		mario1->x <= (mMatrix.width - ViewPort->_Width / 2))
	{
		ViewPort->_X = mario1->x - ViewPort->_Width / 2;
	}
	if (mario1->y >= ViewPort->_Height * 3 / 4)
	{
		ViewPort->_Y = mario1->y + ViewPort->_Height / 4;
		if (mario1->y + ViewPort->_Height / 4 >= mMatrix.height)
			ViewPort->_Y = mMatrix.height - 1;
	}
	else
		ViewPort->_Y = ViewPort->_Height;
}