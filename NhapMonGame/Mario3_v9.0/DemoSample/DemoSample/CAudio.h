
#ifndef _DXAUDIO_H
#define _DXAUDIO_H

#include "dsutil.h"
#include "GlobalObject.h"
class CAudio
{
public:
	CSoundManager *dsound;

	int Init_DirectSound(HWND);
	CSound *LoadSound(char *);
	void PlaySound(CSound *);
	void LoopSound(CSound *);
	void StopSound(CSound *);

};
#endif

