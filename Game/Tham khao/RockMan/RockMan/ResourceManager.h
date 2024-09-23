#ifndef _RESOURCE_MANAGER_H_
#define _RESOURCE_MANAGER_H_

#include <map>
#include <sstream>
#include <fstream>

#include "DSUtil.h"
#include "Trace.h"
#include "resource.h"
#include "CSprite.h"

class ResourceManager
{
public:
	static int Init(HWND hWnd);

	//-----------------------------------------------------------------------------
	// Phát âm thanh
	// + soundID: ID của sound muốn phát
	//-----------------------------------------------------------------------------
	static void PlayASound(int soundID);

	//-----------------------------------------------------------------------------
	// Stop âm thanh
	// + soundID: ID của sound muốn dừng
	//-----------------------------------------------------------------------------
	static void StopSound(int soundID);

	//-----------------------------------------------------------------------------
	// Lấy đối tượng Sprite được load sẵn với spriteID cụ thể
	// + spriteID:  ID của Sprite muốn lấy
	//-----------------------------------------------------------------------------
	static CSprite GetSprite(int spriteID);

	//-----------------------------------------------------------------------------
	// Thêm đối tượng Sprite được load sẵn với spriteID cụ thể
	// + spriteID:  ID của Sprite muốn lấy
	// + sprite: Sprite muốn load vào hệ thống
	//-----------------------------------------------------------------------------
	static void AddSprite(int spriteID, CSprite* sprite);

	static void MuteSound();
	static void ReplaySound();
	static bool IsPlaySound;

private:
	ResourceManager();
	~ResourceManager();

	//-----------------------------------------------------------------------------
	// Khởi tạo Direct Sound
	//-----------------------------------------------------------------------------
	int InitDirectSound(HWND hWnd);

	//-----------------------------------------------------------------------------
	// Thêm một file audio vào danh sách âm thanh
	// + type: Loại audio
	// + loop: Có lặp lại audio đó không
	// + fileName: Đường dẫn file audio
	//-----------------------------------------------------------------------------
	void AddSound(int soundID, bool isLooping, wchar_t* fileName);

	//-----------------------------------------------------------------------------
	// Load file audio
	// + loop: Có lặp lại audio đó không
	// + fileName: Đường dẫn file audio
	//-----------------------------------------------------------------------------
	CSound* LoadSound(bool isLooping, wchar_t* fileName);

	static ResourceManager* _instance;
	CSoundManager* _soundManage;
	map<int, CSound*> _lstSound;
	map<int, CSprite*> _lstSprite;
	int _idSoundBGDefault;
};

#endif // !_RESOURCE_MANAGER_
