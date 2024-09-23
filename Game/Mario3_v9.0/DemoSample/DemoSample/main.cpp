#include "GameMario.h"

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	GameMario *gameMario = new GameMario(hInstance);
	gameMario->Init();
	gameMario->Run();
}