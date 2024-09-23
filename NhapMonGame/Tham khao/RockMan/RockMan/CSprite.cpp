#include "CSprite.h"

CSprite::CSprite()
{

}
CSprite::CSprite(wchar_t* pNamePath, int countRow, int countColumn, int countFrame, int timeFrame, Color color) :CTexture(pNamePath, color)
{
	this->_countColumn = countColumn;
	this->_countFrame = countFrame;
	this->_countRow = countRow;
	this->_index = 0;
	this->_frameHeight = _height / _countRow;
	this->_frameWidth = _width / _countColumn;
	this->_timeFrame = timeFrame;
	_timeFrameDefault = timeFrame;
	_tick = 0;
	_isNextFrame = false;
	_frameStart = 0;
	_frameEnd = _countFrame-1;
}
CSprite::~CSprite()
{

}
int CSprite::SetFrame(int frameStart, int frameEnd)
{
	if (frameStart >= 0
		&& frameStart < _countFrame
		&& frameEnd >= 0
		&& frameEnd < _countFrame)
	{
		_frameStart = frameStart;
		_frameEnd = frameEnd;
		_index = _frameStart;
		_timeFrame = _timeFrameDefault;
		return 0;
	}
	return -1;
}
void CSprite::SetIndex(int index)
{
	this->_index = index;
	_timeFrame = 0;
}
int CSprite::GetIndex()
{
	return this->_index;
}
Rect CSprite::GetDestinationRectangle()
{
	Rect rect;
	rect.left = (_index%_countColumn)*_frameWidth;
	rect.top = (_index/_countColumn)*_frameHeight;// chia cho tổng số cột để xuống dòng
	rect.right = rect.left + _frameWidth;
	rect.bottom = rect.top + _frameHeight;
	return rect;
}
void CSprite::NextSprite()
{
	if (_frameStart <= _frameEnd)//trường hợp chạy thuận
	{
		if (_index < _frameEnd)
			_index++;
		else
			_index = _frameStart;
	}
	else//trường hợp chạy theo chiều ngược
	{
		if (_index > _frameEnd)
			_index--;
		else
			_index = _frameStart;
	}
}
int CSprite::GetColum()
{
	return _countColumn;
}

int CSprite::GetRow()
{
	return _countRow;
}

void CSprite::Update(CGameTime* gameTime)
{
	if (_timeFrame != 0)
	{
		_tick += gameTime->GetDeltaTime();
		if (_tick >= _timeFrame){
			NextSprite();
			_tick = 0;
			_isNextFrame = true;
		}
		else
			_isNextFrame = false;
	}
}

int CSprite::GetFrameHeight()
{
	return _frameHeight;
}
int CSprite::GetFrameWidth()
{
	return _frameWidth;
}

bool CSprite::IsNextFrame()
{
	return _isNextFrame;
}
void CSprite::Reset()
{
	SetIndex(0);
	_tick = 0;
}
int CSprite::GetCountFrame()
{
	return _countFrame;
}

void CSprite::SetAllowAnimate(int timeFrame)
{
	_timeFrame = timeFrame;
	_timeFrameDefault = timeFrame;
}

