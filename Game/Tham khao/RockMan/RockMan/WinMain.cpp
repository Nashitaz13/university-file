#include <windows.h>
#include "CGameApp.h"

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	CGameApp* game = new CGameApp(hInstance);
	game->Run();
	return 0;
}