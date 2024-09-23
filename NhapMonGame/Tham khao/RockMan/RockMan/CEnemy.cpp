#include "CEnemy.h"

CEnemy::CEnemy() :CMoveableObject()
{
	_score = 0;
}
CEnemy::~CEnemy()
{
}

void CEnemy::Update(CGameTime* gameTime)
{

}

void CEnemy::Render(CGameTime* gameTime, CGraphics* graphic)
{

}

void CEnemy::Update(CGameTime* gameTime, CRockman* rockman)
{

}

vector<CBullet*> CEnemy::Fire()
{
	return vector<CBullet*>();
}

CEnemy* CEnemy::ToValue()
{
	return new CEnemy(*this);
}

unsigned int CEnemy::GetScore()
{
	return _score;
}