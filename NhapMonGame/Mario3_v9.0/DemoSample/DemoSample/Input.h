#pragma once
#ifndef _Input_H_
#define _Input_H_

#include <dinput.h>
#include "GlobalObject.h"

class CInput
{
public:
	CInput();
	~CInput();

	void Init();					// Initiate input object
	void Update();					// Updates keyboard states
	void SaveKeyStateHistory();		// Saves previous keyboard states.
	bool IsKeyDown(int keyCode);	// Checks a key be down, check one time
	bool IsKeyUp(int keyCode);		// Checks a key be up, check one time
	bool IsKeyPress(int keyCode);	// Checks a key be pressed
	bool IsKeyRelease(int keyCode);	// Checks a key be released
	void Active();					// Actives keyboard
	void Deactive();				// Deactives keyboard

private:
	void InitInputDirect();			// Initiate directX input
	void InitKeyboard();			// Initiate keyboard

	LPDIRECTINPUT8			_directInput;
	LPDIRECTINPUTDEVICE8	_keyBoard;
	BYTE	_keyStates[256];
	BYTE	_preKeyStates[256];
	bool	_isActive;
};


extern CInput* input;
void IniInput();

#endif