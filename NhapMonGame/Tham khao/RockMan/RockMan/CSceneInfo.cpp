#include "CSceneInfo.h"

CSceneInfo::CSceneInfo()
{

}

CSceneInfo::~CSceneInfo()
{

}

void CSceneInfo::BuildScene(vector<Vector2 > fallingPoints, vector<Vector2> paths)
{
	_fallingPoints.clear();

	for (int i = 0; i < fallingPoints.size(); i++)
	{
		for (int j = 0; j < paths.size() - 1; j++)
		{
			int distanceY = paths[j].y - paths[j + 1].y;

			if (distanceY == 0)
			{
				if (fallingPoints[i].x >= paths[j].x - SCREEN_WIDTH / 2 && fallingPoints[i].x <= paths[j + 1].x + SCREEN_WIDTH / 2
					&& fallingPoints[i].y >= paths[j].y - SCREEN_HEIGHT / 2 && fallingPoints[i].y <= paths[j].y + SCREEN_WIDTH / 2 && !hasInListPoint(fallingPoints[i]))
					_fallingPoints.insert(pair<int, Vector2>(j, fallingPoints[i]));
			}
			else if (distanceY>0)
			{
				if (fallingPoints[i].x >= paths[j].x - SCREEN_WIDTH / 2 && fallingPoints[i].x <= paths[j + 1].x + SCREEN_WIDTH / 2
					&& fallingPoints[i].y <= paths[j].y && fallingPoints[i].y >= paths[j + 1].y&& !hasInListPoint(fallingPoints[i]))
					_fallingPoints.insert(pair<int, Vector2>(j, fallingPoints[i]));
			}
			else
			{
				if (fallingPoints[i].x >= paths[j].x - SCREEN_WIDTH / 2 && fallingPoints[i].x <= paths[j + 1].x + SCREEN_WIDTH / 2
					&& fallingPoints[i].y >= paths[j].y && fallingPoints[i].y <= paths[j + 1].y&& !hasInListPoint(fallingPoints[i]))
					_fallingPoints.insert(pair<int, Vector2>(j, fallingPoints[i]));
			}
		}
	}
}

map<int,Vector2> CSceneInfo::GetScene(int startIndex)
{
	map<int, Vector2> rs;
	if (_fallingPoints.size() != 0)
	{
		rs.insert(pair<int, Vector2>(0,_fallingPoints.find(0)->second));

		for (map<int, Vector2>::iterator it = _fallingPoints.begin(); it != _fallingPoints.end(); it++)
		{
			if (it->first <= startIndex)
			{
				rs.clear();
				rs.insert(pair<int, Vector2>(it->first, it->second));
			}
			else
				return rs;
		}
	}
	return rs;
}

bool CSceneInfo::hasInListPoint(Vector2 point)
{
	for (map<int, Vector2>::iterator it = _fallingPoints.begin(); it != _fallingPoints.end(); it++)
		if (it->second == point)
			return true;

	return false;
}