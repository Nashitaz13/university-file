#ifndef _SCENE1_H_
#define _SCENE1_H_

#include "HeaderObj.h"
#include "QBackground.h"
#include "QGameObject.h"
#include "Scene.h"
#include "GameScore.h"
using namespace std;

class SceneGame: public Scene
{
public:
	int _score;
	int _lifes;
	int _levelNow;
	int _stageNow;
	int _timeToReset;	//thoi gian countdown de reset lai simon sau khi chet
	int _stageReset;	//Stage hoi sinh simon sau khi chet
	bool _playedDie;

	bool _loadLevel;

	bool _moveCameraHaft;	//Di chuyen camera lan 1
	bool _moveCameraDone;	//Di chuyen camera lan 2

	bool _beginMoveCamera;
	int _rangeMoveCamera;
	int _rangeMoveSimon;
	int _rangeMoveCamera2;
	int _doorDirect;		//Huong mo cua
	EStateCamera _stateCamera;
	D3DXVECTOR2 posDoor;	//vi tri canh cua chuyen man
	D3DXVECTOR2 posCamera;	//vi tri camera hoi sinh
	D3DXVECTOR2 posStageToReset; //Vi tri hoi sinh
	EState stateGame;
	
	SceneGame();
	~SceneGame();
protected: 
	
	LPDIRECT3DSURFACE9 BackgroundWhite;

	QBackground *bg;
	QBackground *bg_2;
	Simon* simon;
	Simon* simonTemp;	//Luu thong tin cua simon cu
	QGameObject* qGameObject;
	OpenDoor* openDoor;
	IntroGame* introScene;
	GameObject* intro;
	CCamera *camera;

	PhantomBat* _phantomBat;
	QueenMedusa* _queenMedusa;
	
	GameScore* _gameScore;

	void ChangeCamera(EDirectDoor _directDoor);
	void MoveCamera(int &_range);
	void LoadLevel(int level);
	void LoadStage(int stage);
	void ResetLevel();
	void NextLevel();
	void RenderFrame(LPDIRECT3DDEVICE9 d3ddv, int t);
	void ProcessInput(int keyCode);
	void LoadResources(LPDIRECT3DDEVICE9 d3ddv);

	void OnKeyDown(int KeyCode);
};
#endif
