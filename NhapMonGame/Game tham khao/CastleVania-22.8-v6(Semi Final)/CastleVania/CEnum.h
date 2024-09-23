#ifndef _CENUM_H_
#define _CENUM_H_

enum Action
{
	Idle,
	Run_Right,
	Run_Left,
	Jump,
	Fight,
	Sit,
	Fall,
	IntoCastle
};

static enum ESceneState
{
	Menu_Scene,
	Intro_Scene,
	Game_Scene,
	EndGame_Scene
} EnumSceneState;


enum ObjectType
{
	None_Type,
	Item_Type,
	Enemy_Type,
	Other_Type
};

enum EKindStair
{
	UpRight,
	UpLeft,
	DownRight,
	DownLeft,
	None
};

enum EnumID
{
	None_ID,		
	Watch_ID,
	Dagger_ID,
	FireBomb_ID,
	Boomerang_ID,
	Axe_ID,

	LargeHeartItem_ID,
	SmallHeartItem_ID,
	MoneyBagRedItem_ID,
	MoneyBagBlueItem_ID,
	MoneyBagWhiteItem_ID,
	MoneyBagItem_ID,
	CrossItem_ID,
	WatchItem_ID,
	DaggerItem_ID,
	FireBombItem_ID,
	BoomerangItem_ID,
	AxeItem_ID,
	MorningStarItem_ID,

	MagicalCrystal_ID,

	MorningStar_ID,
	Simon_ID,
	SimonDeath_ID,

	Brick_ID,
	Candle_ID,
	LargeCandle_ID,
	StairUpLeft_ID,
	StairUpRight_ID,
	StairDownLeft_ID,
	StairDownRight_ID,

	CastleGate_ID,
	DoorLeft_ID,
	DoorRight_ID,
	DoorUp_ID,
	DoorDown_ID,
	OpenDoor_ID,
	Lake_ID,

	Zombie_ID,
	BlackKnight_ID,
	BlackLeopard_ID,
	FishMan_ID,
	DragonSkullCannon_ID,
	VampireBat_ID,
	Medusa_ID,

	PhantomBat_ID,
	QueenMedusa_ID,
	LittleSnake_ID,

	MovingPlatform_ID,
	StupidDoor_ID,

	Fire_ID,
	Water_ID,
	FireBall_ID,

	BGMenu_ID,	

	Helicopter_ID,
	Bat_ID,
	IntroScene_ID,
	HP_ID,
	GameScore_ID,

	FallingCastle_ID,
	SimonInCastle_ID


};

enum EDirectDoor
{
	DoorUp,
	DoorDown,
	DoorRight,
	DoorLeft,
	NoneDoor
};

enum EStateCamera
{
	Update_Camera,
	NoUpdate_Camera
};

enum EState
{
	None_State,
	NoUpdate_State
};

enum ECollisionDirect
{
	Colls_None,
	Colls_Left,
	Colls_Right,
	Colls_Bot,
	Colls_Top
};

enum EKind
{
	EDynamic,
	EStatic,
	ESolid,
	EScene
};
#endif