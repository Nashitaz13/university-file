
#include "CAudio.h"


int CAudio::Init_DirectSound(HWND hwnd)
{
    HRESULT result;

    //create DirectSound manager object
    dsound = new CSoundManager();

    //initialize DirectSound
    result = dsound->Initialize(hwnd, DSSCL_PRIORITY);
    if (result != DS_OK)
    {
		GLTrace("[FAILED] Can not init directx sound");
		return 0;
	}

    //set the primary buffer format
    result = dsound->SetPrimaryBufferFormat(2, 22050, 16);
    if (result != DS_OK)
    {
		GLTrace("[FAILED] Can not set the primary buffer");
		 return 0;
	}
    //return success
	GLTrace("Directx Sound has been success init");
    return 1;
}

CSound* CAudio::LoadSound(char *filename)
{
    HRESULT result;

    //create local reference to wave data
    CSound *wave;

    //attempt to load the wave file
    result = dsound->Create(&wave, filename);
    if (result != DS_OK)
    {
		GLTrace("[Failed] Can not load sound file");
		 return NULL;
	}
	GLTrace("Sound file has been loaded");
    //return the wave
    return wave;
}

void CAudio::PlaySound(CSound *sound)
{
    sound->Play();
	GLTrace("Sound file has been played");
}

void CAudio::LoopSound(CSound *sound)
{
    sound->Play(0, DSBPLAY_LOOPING);
}

void CAudio::StopSound(CSound *sound)
{
    sound->Stop();
}
