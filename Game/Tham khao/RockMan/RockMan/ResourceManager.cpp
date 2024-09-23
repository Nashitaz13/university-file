#include "ResourceManager.h"

ResourceManager* ResourceManager::_instance = NULL;
bool ResourceManager::IsPlaySound = true;

ResourceManager::ResourceManager()
{

}

ResourceManager::~ResourceManager()
{

}

int ResourceManager::Init(HWND hWnd)
{
	if (ResourceManager::_instance == NULL)
		ResourceManager::_instance = new ResourceManager();

	if (ResourceManager::_instance->InitDirectSound(hWnd) == 0) return 0;

	//	ResourceManager::_instance->AddSound(ID_SOUND_ONE_UP, 0, L"Resources//SoundEffects//1up.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_BEAM_IN, 0, L"Resources//SoundEffects//beam_in.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_DEAD, 0, L"Resources//SoundEffects//dead.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_DISAPPEARING_BLOCK, 0, L"Resources//SoundEffects//disappearing_block.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_ENEMY_HIT, 0, L"Resources//SoundEffects//enemy_hit.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_HEALTH, 0, L"Resources//SoundEffects//health.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_HURT, 0, L"Resources//SoundEffects//hurt.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_LAND, 0, L"Resources//SoundEffects//land.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_PAUSE, 0, L"Resources//SoundEffects//pause.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_POWER_UP, 0, L"Resources//SoundEffects//power_up.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_SHOOT, 0, L"Resources//SoundEffects//shoot.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_SHOT_BLOCKED, 0, L"Resources//SoundEffects//shot_blocked.wav");

	ResourceManager::_instance->AddSound(ID_SOUND_STAGE_SELECT, 1, L"Resources//SoundTracks//stage_select.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_GAME_START, 0, L"Resources//SoundTracks//game_start.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_CUTMAN_STAGE, 1, L"Resources//SoundTracks//cutman_stage.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_GUTSMAN_STAGE, 1, L"Resources//SoundTracks//gutsman_stage.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_BOMBMAN_STAGE, 1, L"Resources//SoundTracks//bombman_stage.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_BOSS, 1, L"Resources//SoundTracks//boss.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_STAGE_CLEAR, 0, L"Resources//SoundTracks//stage_clear.wav");
	ResourceManager::_instance->AddSound(ID_SOUND_GAME_OVER, 0, L"Resources//SoundTracks//game_over.wav");

	ResourceManager::_instance->AddSound(ID_EFFECT_ANIMATION_SCORE, 1, L"Resources//SoundEffects//animation_score.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_BIG_ROBOT_ON_LAND, 0, L"Resources//SoundEffects//big_robot_on_land.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_BOSS_DIE, 0, L"Resources//SoundEffects//boss_die.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_BULLET_BOOM_EXPLODING, 0, L"Resources//SoundEffects//bullet_boom_exploding.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_BULLET_BOSS_CUTMAN, 0, L"Resources//SoundEffects//bullet_boss_cutman.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_BULLET_HIT_ENEMY_WITH_SHIELD, 0, L"Resources//SoundEffects//bullet_hit_enemy_with_shield.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_CAMERA_VIBRATE, 0, L"Resources//SoundEffects//camera_vibrate.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ELEVATOR_RUNNING, 1, L"Resources//SoundEffects//elevator_running.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ENEMY_EXPLODING, 0, L"Resources//SoundEffects//enemy_exploding.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ENEMY_FIRE, 0, L"Resources//SoundEffects//enemy_fire.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ENEMY_HIT, 0, L"Resources//SoundEffects//enemy_hit.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_FOCUS_STAGE, 0, L"Resources//SoundEffects//focus_stage.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_GET_BLOOD, 0, L"Resources//SoundEffects//get_blood.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_GET_ITEM, 0, L"Resources//SoundEffects//get_item.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_HEALTH, 0, L"Resources//SoundEffects//health.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_INCREASE_POWER_ENEMY, 0, L"Resources//SoundEffects//increase_power_energy.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_INTRO_STAGE, 0, L"Resources//SoundEffects//intro_stage.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_LAND, 0, L"Resources//SoundEffects//land.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_OPEN_THE_DOOR, 0, L"Resources//SoundEffects//open_the_door.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_PAUSE, 0, L"Resources//SoundEffects//pause.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_POPUP_APPEAR, 0, L"Resources//SoundEffects//popup_appear.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_POWER_UP, 0, L"Resources//SoundEffects//power_up.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ROCKMAN_APPEAR, 0, L"Resources//SoundEffects//rockman_appear.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ROCKMAN_COLLIDE_WITH_ENEMY, 0, L"Resources//SoundEffects//rockman_collide_with_enemy.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ROCKMAN_DIE, 0, L"Resources//SoundEffects//rockman_die.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ROCKMAN_FIRE_BULLET_NORMAL, 0, L"Resources//SoundEffects//rockman_fire_bulet_normal.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ROCKMAN_FIRE_BULLET_CUT, 0, L"Resources//SoundEffects//rockman_fire_bullet_cut.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ROCKMAN_FIRE_BULLET_GUTS, 0, L"Resources//SoundEffects//rockman_fire_bullet_guts.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_SELECT_STAGE, 0, L"Resources//SoundEffects//select_stage.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_VICTORY, 0, L"Resources//SoundTracks//stage_victory.wav");
	ResourceManager::_instance->AddSound(ID_EFFECT_ANIMATION_TEXT, 0, L"Resources//SoundEffects//animation_text.wav");

#pragma region Load resource cho Rockman
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAND, new CSprite(L"Resources//Sprites//Rockman//rockman_stand.png", 1, 2, 2, 600, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAND_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_stand.png", 1, 2, 2, 600, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAND_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_stand.png", 1, 2, 2, 600, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAND_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_stand.png", 1, 2, 2, 600, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAND_GUTS_ROCK, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_stand_rock.png", 1, 2, 2, 600, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAND_FIRE, new CSprite(L"Resources//Sprites//Rockman//rockman_stand_fire.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAND_FIRE_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_fire_stand.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAND_FIRE_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_stand_fire.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAND_FIRE_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_stand_fire.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_PREPARE_RUN, new CSprite(L"Resources//Sprites//Rockman//rockman_prepare_run.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_PREPARE_RUN_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_prepare_run.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_PREPARE_RUN_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_prepare_run.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_PREPARE_RUN_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_prepare_run.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_PREPARE_RUN_GUTS_ROCK, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_prepare_run_rock.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_RUN, new CSprite(L"Resources//Sprites//Rockman//rockman_run.png", 1, 3, 3, 50, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_RUN_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_run.png", 1, 3, 3, 50, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_RUN_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_run.png", 1, 3, 3, 50, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_RUN_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_run.png", 1, 3, 3, 50, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_RUN_GUTS_ROCK, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_run_rock.png", 1, 3, 3, 50, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_FALL, new CSprite(L"Resources//Sprites//Rockman//rockman_jump.png", 1, 1, 1, 600, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_FALL_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_jump.png", 1, 1, 1, 600, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_FALL_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_jump.png", 1, 1, 1, 600, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_FALL_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_jump.png", 1, 1, 1, 600, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_JUMP_FIRE, new CSprite(L"Resources//Sprites//Rockman//rockman_jump_fire.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_JUMP_FIRE_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_jump_fire.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_JUMP_FIRE_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_jump_fire.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_JUMP_FIRE_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_jump_fire.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR, new CSprite(L"Resources//Sprites//Rockman//rockman_stair.png", 1, 2, 2, 120, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_stair.png", 1, 2, 2, 120, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_stair.png", 1, 2, 2, 120, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_stair.png", 1, 2, 2, 120, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_END, new CSprite(L"Resources//Sprites//Rockman//rockman_stair_end.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_END_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_stair_end.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_END_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_stair_end.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_END_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_stair_end.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_FIRE, new CSprite(L"Resources//Sprites//Rockman//rockman_stair_fire.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_FIRE_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_stair_fire.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_FIRE_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_stair_fire.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_STAIR_FIRE_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_stair_fire.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_HURT, new CSprite(L"Resources//Sprites//Rockman//rockman_collide.png", 1, 2, 2, 50, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_HURT_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_collide.png", 1, 2, 2, 50, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_HURT_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_collide.png", 1, 2, 2, 50, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_HURT_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_collide.png", 1, 2, 2, 50, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_CONFUSE, new CSprite(L"Resources//Sprites//Rockman//rockman_collide_confuse.png", 1, 4, 4, 150, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_EXPLODING_EFFECT_ROCKMAN, new CSprite(L"Resources//Sprites//Rockman//rockman_die.png", 1, 5, 5, 50, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_EXPLODING_EFFECT_CUTMAN, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_die.png", 1, 5, 5, 50, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_EXPLODING_EFFECT_BOOMMAN, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_die.png", 1, 5, 5, 50, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_EXPLODING_EFFECT_GUTSMAN, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_die.png", 1, 5, 5, 50, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_RUN_FIRE, new CSprite(L"Resources//Sprites//Rockman//rockman_run_fire.png", 1, 3, 3, 120, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_RUN_FIRE_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_run_fire.png", 1, 3, 3, 120, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_RUN_FIRE_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_run_fire.png", 1, 3, 3, 120, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_RUN_FIRE_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_run_fire.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_START, new CSprite(L"Resources//Sprites//Rockman//rockman_start.png", 1, 3, 3, 0, D3DCOLOR_XRGB(101, 141, 209))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_START_CUT, new CSprite(L"Resources//Sprites//Rockman//rockman_cut_start.png", 1, 3, 3, 0, D3DCOLOR_XRGB(101, 141, 209))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_START_BOOM, new CSprite(L"Resources//Sprites//Rockman//rockman_boom_start.png", 1, 3, 3, 0, D3DCOLOR_XRGB(101, 141, 209))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROCKMAN_START_GUTS, new CSprite(L"Resources//Sprites//Rockman//rockman_guts_start.png", 1, 3, 3, 0, D3DCOLOR_XRGB(101, 141, 209))));


#pragma endregion

#pragma region Load resource cho map cut man

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_CUTMAN_STAND0, new CSprite(L"Resources//Sprites//BossCutMan//cutman_stand0.png", 1, 2, 2, 800, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_CUTMAN_STAND1, new CSprite(L"Resources//Sprites//BossCutMan//cutman_stand1.png", 1, 2, 2, 800, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_CUTMAN_RUN0, new CSprite(L"Resources//Sprites//BossCutMan//cutman_run0.png", 1, 4, 4, 100, D3DCOLOR_XRGB(35, 177, 77))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_CUTMAN_RUN1, new CSprite(L"Resources//Sprites//BossCutMan//cutman_run1.png", 1, 4, 4, 100, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_CUTMAN_JUMP0, new CSprite(L"Resources//Sprites//BossCutMan//cutman_jump0.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_CUTMAN_JUMP1, new CSprite(L"Resources//Sprites//BossCutMan//cutman_jump1.png", 1, 1, 1, 1000, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_CUTMAN_FIRE0, new CSprite(L"Resources//Sprites//BossCutMan//cutman_fire0.png", 1, 2, 2, 1000, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_CUTMAN_COLLIDE, new CSprite(L"Resources//Sprites//BossCutMan//cutman_collide.png", 1, 2, 2, 1000, D3DCOLOR_XRGB(34, 177, 76))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BOOMMAN_JUMP_HEIGHT, new CSprite(L"Resources//Sprites//BossBoomMan//bom_jump_height.png", 1, 1, 1, 800, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BOOMMAN_JUMP_LOW, new CSprite(L"Resources//Sprites//BossBoomMan//bom_jump_low.png", 1, 1, 1, 800, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BOOMMAN_JUMP_STAND, new CSprite(L"Resources//Sprites//BossBoomMan//bom_stand.png", 1, 1, 1, 800, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BOOMMAN_FIRE, new CSprite(L"Resources//Sprites//BossBoomMan//boss_boom_fire.png", 1, 2, 2, 800, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BOOMMAN_BOOM_BURST, new CSprite(L"Resources//Sprites//BossBoomMan//boom_burst.png", 1, 4, 4, 50, D3DCOLOR_XRGB(0, 255, 0))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BOOMMAN_BOOM_PUSH, new CSprite(L"Resources//Sprites//BossBoomMan//boss_boom_push.png", 1, 2, 2, 200, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_BOSS_BOOM, new CSprite(L"Resources//Sprites//BossBoomMan//boom_boss.png", 1, 1, 1, 800, D3DCOLOR_XRGB(0, 255, 0))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_GUSTMAN_STOMING, new CSprite(L"Resources//Sprites//BossGutsMan//gutsnam_stoming.png", 1, 4, 4, 400, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_GUSTMAN_THROW, new CSprite(L"Resources//Sprites//BossGutsMan//gutsnam_throw.png", 1, 3, 3, 300, D3DCOLOR_XRGB(34, 177, 76))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_GUSTMAN_ROCKFIRE, new CSprite(L"Resources//Sprites//BossGutsMan//rockFire_gutsman.png", 1, 1, 1, 800, D3DCOLOR_XRGB(0, 255, 0))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_WEAPON_GUTS_PART, new CSprite(L"Resources//Sprites//BossGutsMan//weapon_guts_part.png", 1, 2, 2, 1300, D3DCOLOR_XRGB(0, 255, 0))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_GUSTMAN_STAND, new CSprite(L"Resources//Sprites//BossGutsMan//boss_gutsman_stand.png", 1, 2, 2, 300, D3DCOLOR_XRGB(34, 177, 76))));


	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_CUT, new CSprite(L"Resources//Sprites//BossCutMan//weapon_cut.png", 1, 4, 4, 200, D3DCOLOR_XRGB(0, 255, 0)))); // bullet Cut Man

	//Vùng Uy thêm vào
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_BUBBLE_BLUE, new CSprite(L"Resources//Sprites//BossCutMan//enemy_bubble_blue.png", 1, 2, 2, 150, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_BUBBLE_GREEN, new CSprite(L"Resources//Sprites//BossGutsMan//enemy_bubble_green.png", 1, 2, 2, 150, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_ROBOT_RED, new CSprite(L"Resources//Sprites//BossCutMan//enemy_robot_red.png", 1, 2, 2, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_ROBOT_BLUE, new CSprite(L"Resources//Sprites//BossGutsMan//enemy_robot_blue.png", 1, 2, 2, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_MACHINE_AUTO_ORGANGE, new CSprite(L"Resources//Sprites//BossCutMan//enemy_machine_auto_orange.png", 1, 4, 4, 150, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_MACHINE_AUTO_BLUE, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_machine_auto_blue.png", 1, 4, 4, 150, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_EXPLODING_EFFECT_BASE, new CSprite(L"Resources//Sprites//ExplodingEffect.png", 1, 7, 7, 5, D3DCOLOR_XRGB(0, 255, 0))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_BOOM_BLUE, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_boom_blue.png", 1, 1, 1, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_BOOM, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_boom_part_blue.png", 1, 1, 1, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_WALL_SHOOTER, new CSprite(L"Resources//Sprites//BossCutMan//enemy_wall_shooter.png", 1, 4, 4, 100, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_WALL_SHOOTER, new CSprite(L"Resources//Sprites//BossCutMan//enemy_wall_shooter.png", 1, 4, 4, 100, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_WORKER, new CSprite(L"Resources//Sprites//BossGutsMan//enemy_worker_bullet.png", 2, 2, 4, 30, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_WORKER, new CSprite(L"Resources//Sprites//BossGutsMan//enemy_worker.png", 1, 3, 3, 1200, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_BALL, new CSprite(L"Resources//Sprites//BossCutMan//enemy_ball.png", 1, 2, 2, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_BLUE_COLOR, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_bullet_blue.png", 1, 1, 1, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_RED_COLOR, new CSprite(L"Resources//Sprites//BossCutMan//enemy_bullet_red.png", 1, 1, 1, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_ORANGE_COLOR, new CSprite(L"Resources//Sprites//BossCutMan//enemy_bullet_orange.png", 1, 1, 1, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ELEVATOR, new CSprite(L"Resources//Sprites//BossGutsMan//enemy_elevator.png", 1, 3, 3, 145, D3DCOLOR_XRGB(109, 167, 131))));

	//Kết thúc vùng Uy thêm

	// quái của huy
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_EYE, new CSprite(L"Resources//Sprites//BossCutMan//enemy_eye_red.png", 1, 3, 3, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_INK_BLUE, new CSprite(L"Resources//Sprites//BossCutMan//enemy_ink_blue.png", 1, 2, 2, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_INK_RED, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_ink_red.png", 1, 2, 2, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_HAT, new CSprite(L"Resources//Sprites//BossGutsMan//enemy_hat.png", 1, 2, 2, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_ENEMY_HAT, new CSprite(L"Resources//Sprites//BossCutMan//enemy_bullet_orange.png", 1, 1, 1, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_FISH, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_fish_orange.png", 1, 1, 1, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_ENEMY_FISH, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_fish_bullet.png", 1, 8, 8, 100, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_MACHINE, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_machine_orange.png", 1, 2, 2, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_ENEMY_SNAPPER, new CSprite(L"Resources//Sprites//BossCutMan//enemy_cut.png", 1, 2, 2, 100, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_NINJA_FIRE, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_ninja_green_fire.png", 1, 2, 2, 100, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_NINJA_JUMP, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_ninja_green_jump.png", 1, 1, 1, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ENEMY_NINJA_STAND, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_ninja_green_stand.png", 1, 1, 1, 0, D3DCOLOR_XRGB(109, 167, 131))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_ENEMY_NINJA, new CSprite(L"Resources//Sprites//BossBoomMan//enemy_bullet_green.png", 1, 1, 1, 0, D3DCOLOR_XRGB(109, 167, 131))));
	// kết thúc quái huy 

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_DOOR_CUTMAN, new CSprite(L"Resources//Sprites//Others//door_cutman.png", 1, 5, 5, 120, D3DCOLOR_XRGB(255, 255, 255))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_DOOR_GUTSMAN, new CSprite(L"Resources//Sprites//Others//door_gutsman.png", 1, 5, 5, 120, D3DCOLOR_XRGB(255, 255, 255))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_DOOR1_BOOMMAN, new CSprite(L"Resources//Sprites//Others//door1_boomman.png", 1, 5, 5, 120, D3DCOLOR_XRGB(255, 255, 255))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_DOOR2_BOOMMAN, new CSprite(L"Resources//Sprites//Others//door2_boomman.png", 5, 1, 5, 120, D3DCOLOR_XRGB(255, 255, 255))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_ROCKMAN_NORMAL, new CSprite(L"Resources//Sprites//Rockman//bullet_rockman.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 120, 255))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_ROCKMAN_GUTS_BIG, new CSprite(L"Resources//Sprites//Rockman//bullet_guts_big_rockman.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 120, 255))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_ROCKMAN_GUTS_STAGE_BIG, new CSprite(L"Resources//Sprites//BossGutsMan//rockFire_gutsman.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 255, 0))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BULLET_ROCKMAN_GUTS_SMALL, new CSprite(L"Resources//Sprites//Rockman//bullet_guts_small_rockman.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 120, 255))));
#pragma endregion

#pragma region Load Resource cho Item

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_BLOOD_BIG, new CSprite(L"Resources//Sprites//Others//item_blood_big.png", 1, 2, 2, 120, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_BLOOD_SMALL, new CSprite(L"Resources//Sprites//Others//item_blood_small.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_MANA_BIG, new CSprite(L"Resources//Sprites//Others//item_mana_big.png", 1, 2, 2, 120, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_MANA_SMALL, new CSprite(L"Resources//Sprites//Others//item_mana_small.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_BONUS_ORANGE, new CSprite(L"Resources//Sprites//Others//item_bonus_red.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_BONUS_RED, new CSprite(L"Resources//Sprites//Others//item_bonus_red.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_BONUS_BLUE, new CSprite(L"Resources//Sprites//Others//item_bonus_red.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_BONUS_GREEN, new CSprite(L"Resources//Sprites//Others//item_bonus_red.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_LIFE, new CSprite(L"Resources//Sprites//Others//item_life.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_BOSS_CUT, new CSprite(L"Resources//Sprites//Others//item_boss_cut.png", 1, 2, 2, 100, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_BOSS_GUTS, new CSprite(L"Resources//Sprites//Others//item_boss_guts.png", 1, 2, 2, 100, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ITEM_BOSS_BOOM, new CSprite(L"Resources//Sprites//Others//item_boss_boom.png", 1, 2, 2, 100, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_DEBUG_BOX, new CSprite(L"Resources//Sprites//border.png", 1, 1, 1, 0, D3DCOLOR_XRGB(255, 255, 255))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BAR_BACKGROUND_VERTICAL, new CSprite(L"Resources//Sprites//Others//bar_background_vertical.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BAR_ROCKMAN_VERTICAL, new CSprite(L"Resources//Sprites//Others//bar_rockman_vertical.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BAR_BOOM_VERTICAL, new CSprite(L"Resources//Sprites//Others//bar_cutman_vertical.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BAR_CUT_VERTICAL, new CSprite(L"Resources//Sprites//Others//bar_gutsman_vertical.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_BAR_GUTS_VERTICAL, new CSprite(L"Resources//Sprites//Others//bar_boomman_vertical.png", 1, 1, 1, 0, D3DCOLOR_XRGB(0, 102, 102))));

	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROOM_BOOM_STAGE, new CSprite(L"Resources//Sprites//Others//map_boom_intro_boss_room.png", 1, 2, 2, 100, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROOM_CUT_STAGE, new CSprite(L"Resources//Sprites//Others//map_cut_intro_boss_room.png", 1, 2, 2, 100, D3DCOLOR_XRGB(0, 102, 102))));
	ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(ID_SPRITE_ROOM_GUTS_STAGE, new CSprite(L"Resources//Sprites//Others//map_guts_intro_boss_room.png", 1, 2, 2, 100, D3DCOLOR_XRGB(0, 102, 102))));
#pragma endregion

	return 1;
}

int ResourceManager::InitDirectSound(HWND hWnd)
{
	HRESULT result;

	//create Direct Manage Sound Object
	_soundManage = new CSoundManager();

	//initializa DirectSound
	result = _soundManage->Initialize(hWnd, DSSCL_PRIORITY);
	if (result != DS_OK) return 0;// lỗi
	Trace(L"SoundManager has been initialize success.");

	//set the primaty buffer format
	result = _soundManage->SetPrimaryBufferFormat(2, 22050, 16);
	if (result != DS_OK) return 0;// lỗi
	Trace(L"SetPrimaryBufferFormat SoundManager has been success.");

	//return success
	return 1;
}

void ResourceManager::AddSound(int soundID, bool isLooping, wchar_t* fileName)
{
	CSound* sound = this->LoadSound(isLooping, fileName);
	if (sound != NULL)
		_lstSound.insert(pair<int, CSound*>(soundID, sound));
}

CSound* ResourceManager::LoadSound(bool isLooping, wchar_t* fileName)
{
	HRESULT result;

	CSound *wave;

	result = _soundManage->Create(&wave, fileName);
	if (result != DS_OK) return NULL;// lỗi
	Trace(L"The ", fileName, L" has been created successfully");

	wave->loop = isLooping;
	return wave;
}

void ResourceManager::PlayASound(int soundID)
{
	if (ResourceManager::IsPlaySound)
	{
		map<int, CSound*>::iterator it = ResourceManager::_instance->_lstSound.find(soundID);
		if (it != ResourceManager::_instance->_lstSound.end())
		{
			CSound* sound = it->second;

			if (sound->loop)
			{
				sound->Play(0, 1);
				ResourceManager::_instance->_idSoundBGDefault = it->first;
			}
			else if (!sound->IsSoundPlaying())
				sound->Play();
		}
	}
}

void ResourceManager::StopSound(int soundID)
{
	if (ResourceManager::IsPlaySound)
	{
		map<int, CSound*>::iterator it = ResourceManager::_instance->_lstSound.find(soundID);
		if (it != ResourceManager::_instance->_lstSound.end())
		{
			CSound* sound = it->second;

			sound->Stop();
		}
	}
}
void ResourceManager::ReplaySound()
{
	for (map<int, CSound*>::iterator it = ResourceManager::_instance->_lstSound.begin(); it != ResourceManager::_instance->_lstSound.end(); it++)
	{
		CSound* sound = it->second;
		if (it->first == ResourceManager::_instance->_idSoundBGDefault)
		{
			sound->Play(0, 1);
			IsPlaySound = true;
			break;
		}
	}

}
void ResourceManager::MuteSound()
{
	for (map<int, CSound*>::iterator it = ResourceManager::_instance->_lstSound.begin(); it != ResourceManager::_instance->_lstSound.end(); it++)
		if (it != ResourceManager::_instance->_lstSound.end())
		{
			CSound* sound = it->second;
			sound->Stop();
		}
	IsPlaySound = false;
}

CSprite ResourceManager::GetSprite(int spriteID)
{
	return *ResourceManager::_instance->_lstSprite.find(spriteID)->second;
}

void ResourceManager::AddSprite(int spriteID, CSprite* sprite)
{
	CSprite* spriteTmp = ResourceManager::_instance->_lstSprite.find(spriteID)->second;

	if (spriteTmp == NULL)
		ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(spriteID, sprite));
	else
	{
		ResourceManager::_instance->_lstSprite.erase(spriteID);
		ResourceManager::_instance->_lstSprite.insert(pair<int, CSprite*>(spriteID, sprite));
	}
}