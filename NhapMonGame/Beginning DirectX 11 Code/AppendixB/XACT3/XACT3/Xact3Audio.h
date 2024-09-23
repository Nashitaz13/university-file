/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    XACT - Code used to load audio via XACT 3.
*/


#ifndef _XACT3_AUDIO_H_
#define _XACT3_AUDIO_H_


#include<windows.h>
#include<xact3.h>


struct stXACTAudio
{
   IXACT3WaveBank *waveBank;
   IXACT3SoundBank *soundBank;
   void *waveBankData;
   void *soundBankData;
};


bool SetupXACT( IXACT3Engine** audioEngine );

bool LoadXACTAudio( IXACT3Engine* audioEngine, stXACTAudio& audio,
    char* waveBank, char* soundBank );

#endif