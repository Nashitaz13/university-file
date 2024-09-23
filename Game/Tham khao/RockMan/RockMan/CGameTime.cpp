#include "CGameTime.h"
#include <Windows.h>

CGameTime::CGameTime(int framePerSecond){
	this->_tickPerFrame = 1000.0f / framePerSecond;
	this->_deltaTime = 0.0f;
	this->_deltaTimePrevious = 0.0f;
	this->_startTime = GetTickCount();
}

CGameTime::~CGameTime(){
	this->_tickPerFrame = 0;
	this->_deltaTime = 0.0f;
	this->_startTime = 0.0f;
}

void CGameTime::Update(){
	DWORD now = GetTickCount();

	this->_deltaTime = now - this->_startTime;
	if (this->_deltaTime >= this->_tickPerFrame){
		if (this->_deltaTime <= this->_tickPerFrame*2)
		{
			this->_availableNextFrame = true;
			this->_startTime = now;
			this->_deltaTimePrevious = this->_deltaTime;
		}
		else
		{
			this->_availableNextFrame = true;
			this->_startTime = now;
			this->_deltaTime = this->_deltaTimePrevious;
		}
	}
	else
		this->_availableNextFrame = false;
}

int CGameTime::GetDeltaTime(){
	return (int)this->_deltaTime;
}

bool CGameTime::AvailableNextFrame(){
	return this->_availableNextFrame;
}

void CGameTime::Reset(){
	this->_availableNextFrame = false;
	this->_deltaTime = 0;
	this->_startTime = GetTickCount();
}