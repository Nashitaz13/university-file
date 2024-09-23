#include <stdio.h>
#include <windows.h>

char path[] = "C:\\WINDOWS\\system32\\notepad.exe" ;

int main()
{
	PROCESS_INFORMATION pif;
	STARTUPINFO si;

	printf("Current Process ID = %d\n", GetCurrentProcessId());
	
	ZeroMemory(&si,sizeof(si));
	si.cb = sizeof(si);

	// creat a process to run notepad
	printf("Creat a process to run notepad\n");
	CreateProcess( path, NULL, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pif);
	printf("process notepad id: %d\n", GetProcessId(pif.hProcess));
	printf("Press any key to terminate notepad ...\n");
	getch();
	TerminateProcess(pif.hProcess,0);
	CloseHandle(pif.hProcess);
	CloseHandle(pif.hThread);

	ZeroMemory(&si,sizeof(si));
	si.cb = sizeof(si);
	printf("Creat a process to run notepad\n");
	CreateProcess( path, NULL, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pif);
	printf("Waiting for notepad terminated\n");
	WaitForSingleObject(pif.hProcess, INFINITE);
	CloseHandle(pif.hProcess);
	CloseHandle(pif.hThread);
	return 0;
}