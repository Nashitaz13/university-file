#include "CCameraPath.h"

CCameraPath::CCameraPath()
{
	_pointOnPath = Vector2(0, 0);
	_startIndex = _endIndex = -1;
}

CCameraPath::~CCameraPath()
{

}

Vector2 CCameraPath::CalculatePointOnPathWith(Vector2 newPosition)
{
	// Nếu không có điểm line thì không tính toán
	if (_paths.size() == 0)
		return Vector2(0, 0);

	// Nếu có 1 điểm thì trả về điểm đó
	if (_startIndex == 0 && _endIndex == 0)
		return _paths[0];

	Vector2 distance = newPosition - _pointOnPath;

	// Nếu camera nằm ngang
	if (_paths[_endIndex].x != _paths[_startIndex].x)
	{
		_pointOnPath.x += distance.x;

		// Giới hạn điểm di chuyển chiều ngang theo hai đầu
		_pointOnPath.x = __max(_pointOnPath.x, _paths[_startIndex].x);
		_pointOnPath.x = __min(_pointOnPath.x, _paths[_endIndex].x);



		if ((_pointOnPath.x == _paths[_startIndex].x || _pointOnPath.x == _paths[_endIndex].x))
		{
			int startIndex = _pointOnPath.x == _paths[_startIndex].x ? __max(0, _startIndex - 1) : __min(_startIndex + 1, _paths.size() - 1);
			int endIndex = __min(startIndex + 1, _paths.size() - 1);

			if (distance.y != 0.0f)
			{
				if (newPosition.y<__max(_paths[startIndex].y, _paths[endIndex].y) && newPosition.y>__min(_paths[startIndex].y, _paths[endIndex].y))
				{
					_startIndex = startIndex;
					_endIndex = endIndex;

					_pointOnPath.y += distance.y;
					// Giới hạn điểm di chuyển chiều dọc
					if (_paths[_startIndex].y > _paths[_endIndex].y)
					{
						_pointOnPath.y = __max(_pointOnPath.y, _paths[_startIndex].y);
						_pointOnPath.y = __min(_pointOnPath.y, _paths[_endIndex].y);
					}
					else
					{
						_pointOnPath.y = __max(_pointOnPath.y, _paths[_startIndex].y);
						_pointOnPath.y = __min(_pointOnPath.y, _paths[_endIndex].y);
					}
				}
			}
			else  if (distance.x != 0)
			{
				if (_pointOnPath.x == _paths[_startIndex].x &&  _startIndex - 1 >= 0 && _paths[_startIndex - 1].y == _paths[_startIndex].y
					|| _pointOnPath.x == _paths[_endIndex].x  && _endIndex + 1 <= _paths.size() - 1 && _paths[_endIndex + 1].y == _paths[_endIndex].y)
				{
					_startIndex = startIndex;
					_endIndex = endIndex;

					_pointOnPath.x += newPosition.x - _pointOnPath.x;
				}
			}
		}
	}
	else if (_paths[_endIndex].y != _paths[_startIndex].y)
	{
		_pointOnPath.y += distance.y;
		float calculatedPoint = _pointOnPath.y;	// Lưu trữ lại điểm mới theo tính toán, tìm điểm cũ
		// Giới hạn di chuyển hai đầu mút
		int maxYValue = __max(_paths[_startIndex].y, _paths[_endIndex].y);
		int minYValue = __min(_paths[_startIndex].y, _paths[_endIndex].y);
		_pointOnPath.y = __min(_pointOnPath.y, maxYValue);
		_pointOnPath.y = __max(_pointOnPath.y, minYValue);

		// Tính ra khoảng cách còn thừa cần phải thực hiện dời điểm trên màn hình
		distance.y -= (calculatedPoint - _pointOnPath.y);

		if (_pointOnPath.y == maxYValue || _pointOnPath.y == minYValue)
		{
			int startIndex = _pointOnPath.y == _paths[_endIndex].y ? _endIndex  : __max(0, _startIndex - 1);
			int endIndex = __min(startIndex + 1, _paths.size()-1);

			if (newPosition.x > _paths[startIndex].x&& newPosition.x < _paths[endIndex].x&&distance.x != 0)
			{
				_startIndex = startIndex;
				_endIndex = endIndex;

				_pointOnPath.x += distance.x;
			}
			else if (newPosition.y>__min(_paths[startIndex].y, _paths[endIndex].y) && newPosition.y < __max(_paths[startIndex].y, _paths[endIndex].y))
			{
				_startIndex = startIndex;
				_endIndex = endIndex;

				_pointOnPath.y += newPosition.y-_pointOnPath.y;
			}
		}
	}
	return _pointOnPath;
}

Vector2 CCameraPath::GetCameraPointOnPath()
{
	return _pointOnPath;
}

void CCameraPath::SetCameraPointOnPath(Vector2 pointOnPath)
{
	_pointOnPath = pointOnPath;
}

Vector2 CCameraPath::GetStartPoint()
{
	return _paths[_startIndex];
}

Vector2 CCameraPath::GetEndPoint()
{
	return _paths[_endIndex];
}

Vector2 CCameraPath::GetNextPoint()
{
	return _paths[__min(_endIndex + 1, _paths.size() - 1)];
}

Vector2 CCameraPath::GetNextOfNextPoint()
{
	return _paths[__min(_endIndex + 2, _paths.size() - 1)];
}

Vector2 CCameraPath::GetPreviousPoint()
{
	return _paths[__max(_startIndex - 1, 0)];
}

Vector2 CCameraPath::GetPrevOfPreviousPoint()
{
	return _paths[__max(_startIndex - 2, 0)];
}

void CCameraPath::SetPaths(vector<Vector2> paths)
{
	_paths = paths;
	if (paths.size() == 0)
	{
		_startIndex = _endIndex = -1;
		return;
	}
	_startIndex = 0;
	_endIndex =  paths.size() == 1 ? 0 : 1;
	_pointOnPath = paths[0];
}
vector<Vector2> CCameraPath::GetPaths()
{
	return _paths;
}
int  CCameraPath::GetStartIndex()
{
	return _startIndex;
}

void CCameraPath::SetStartIndex(int startIndex)
{
	_startIndex = startIndex;
}

int  CCameraPath::GetEndIndex()
{
	return _endIndex;
}

void CCameraPath::SetEndIndex(int endIndex)
{
	_endIndex = endIndex;
}

bool CCameraPath::IsHorizontalLine()
{
	return _paths[_endIndex].x != _paths[_startIndex].x;
}

bool CCameraPath::IsVerticalLine()
{
	return  _paths[_endIndex].y != _paths[_startIndex].y;
}

bool CCameraPath::CanMoveLeft()
{
	if (IsVerticalLine())
	{
		if (_pointOnPath.y == _paths[_startIndex].y)
		{
			int startIndex = __max(0, _startIndex - 1);
			int endIndex = __min(startIndex + 1, _paths.size() - 1);

			if (_paths[startIndex].x < _paths[endIndex].x)
				return true;
			else return false;
		}
		else if (_pointOnPath.y == _paths[_endIndex].y)
		{
			int startIndex = _endIndex;
			int endIndex = __min(startIndex + 1, _paths.size() - 1);

			if (_paths[startIndex].x < _paths[endIndex].x)
				return true;
			else return false;
		}
	}
	else
	{
		if (_pointOnPath.x> _paths[_startIndex].x)
			return true;
		else return false;
	}
}

bool CCameraPath::CanMoveRight()
{
	if (IsVerticalLine())
	{
		if (_pointOnPath.y == _paths[_startIndex].y)
		{
			int startIndex = __max(0, _startIndex - 1);
			int endIndex = __min(startIndex + 1, _paths.size() - 1);

			if (_paths[startIndex].x > _paths[endIndex].x)
				return true;
			else return false;
		}
		else if (_pointOnPath.y == _paths[_endIndex].y)
		{
			int startIndex = _endIndex;
			int endIndex = __min(startIndex + 1, _paths.size() - 1);

			if (_paths[startIndex].x > _paths[endIndex].x)
				return true;
			else return false;
		}
	}
	else
	{
		if (_pointOnPath.x< _paths[_startIndex].x)
			return true;
		else return false;
	}
}

bool CCameraPath::CanMoveUp()
{
	if (IsHorizontalLine())
	{
		if (_pointOnPath.x == _paths[_startIndex].x)
		{
			int startIndex =__max(0, _startIndex - 1);
			int endIndex = __min(startIndex + 1, _paths.size() - 1);

			if (_paths[startIndex].y > _paths[endIndex].y)
				return true;
			else return false;
		}
		else if (_pointOnPath.x == _paths[_endIndex].x)
		{
			int startIndex = _endIndex;
			int endIndex = __min(startIndex + 1, _paths.size() - 1);

			if (_paths[endIndex].y > _paths[startIndex].y)
				return true;
			else return false;
		}
		return false;
	}
	else
	{
		if (_pointOnPath.y < __max(_paths[_startIndex].y, _paths[_endIndex].y))
			return true;
		else return false;
	}
}

bool CCameraPath::CanMoveDown()
{
	if (IsHorizontalLine())
	{
		if (_pointOnPath.x == _paths[_startIndex].x)
		{
			int startIndex = __max(0, _startIndex - 1);
			int endIndex = __min(startIndex + 1, _paths.size() - 1);

			if (_paths[startIndex].y < _paths[endIndex].y)
				return true;
			else return false;
		}
		else if (_pointOnPath.x == _paths[_endIndex].x)
		{
			int startIndex = _endIndex;
			int endIndex = __min(startIndex + 1, _paths.size() - 1);

			if (_paths[startIndex].y > _paths[endIndex].y)
				return true;
			else return false;
		}
		return false;
	}
	else
	{
		if (_pointOnPath.y > __min(_paths[_startIndex].y, _paths[_endIndex].y))
			return true;
		else return false;
	}
}