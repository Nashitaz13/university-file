#include <stdio.h>
#include <windows.h>

DWORD WINAPI PrintThreads (LPVOID);

int main ()
{
	HANDLE hThread;
	DWORD dwThreadID;
	int i;
	for (i=0; i<5; i++)
	{
		hThread=CreateThread(
						NULL, //default security attributes
						0, //default stack size
						PrintThreads, //function name
						(LPVOID)i, // parameter
						0, // start the thread immediately after creation
						&dwThreadID
						);
		printf("ThreadID = %d\n", dwThreadID);
		if (hThread)
		{
			printf ("Thread launched successfully, hThread = %d\n", hThread);
			//CloseHandle (hThread);
		}
	}
	Sleep (1000);
	getch();
	return (0);
}
//function PrintThreads
DWORD WINAPI PrintThreads (LPVOID num)
{
	while (1)
	{
		printf ("Thread Number is %d%d%d\n", num,num,num);
		printf("Thread Id = %d is running\n", GetCurrentThreadId());
		Sleep(1000);
	}
	return 0;
}