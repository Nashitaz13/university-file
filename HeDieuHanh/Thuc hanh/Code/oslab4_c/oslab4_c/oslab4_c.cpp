#include <stdio.h>
#include <conio.h>
#include <windows.h>
#include <process.h>

//#define MEM_SIZE 1024*1024*1024 //Kích thước vùng nhớ cần cấp phát

int main()
{
	//printf("Vung nho khi chua cap phat");
	//system("pause");
	//LPVOID lpCommit = VirtualAlloc(
		//NULL, // Hệ thống định địa chỉ
		//MEM_SIZE, //Số byte cập nhật
		//MEM_RESERVE, //Chế độ cấp phát dự trữ
		//PAGE_READWRITE); //Cho phép đọc ghi

	//if (lpCommit == NULL)
	//{
	//	printf("\nVung nho khong the cap nhat");
	//	exit(1);
	//}
	//else
	//{
	//	printf("\nVung nho da duoc cap nhat");
	//	system("pause");
	//}

	//LPTSTR lpPtr = (LPTSTR)lpCommit; //Ghi dữ liệu vào vùng nhớ
	//for (int i = 0; i < MEM_SIZE / 2; i++)
	//	lpPtr[i] = 1;
	//printf("\nDa gan tri vao vung nho");
	//system("pause");

	//Giải phóng vùng nhớ đã cập nhật

	//Lấy thông tin hệ thống dùng hàm GetSytemInfo
	LPVOID Result;
	SYSTEM_INFO siSysInfo;
	GetSystemInfo(&siSysInfo);
	// Display the contents of the SYSTEM_INFO structure. 
	printf("Hardware information: \n");
	printf(" OEM ID: %u\n", siSysInfo.dwOemId);
	printf(" Number of processors: %u\n",
		siSysInfo.dwNumberOfProcessors);
	printf(" Page size: %u\n", siSysInfo.dwPageSize);
	printf(" Processor type: %u\n", siSysInfo.dwProcessorType);
	printf(" Minimum application address: %lx\n",
		siSysInfo.lpMinimumApplicationAddress);
	printf(" Maximum application address: %lx\n",
		siSysInfo.lpMaximumApplicationAddress);
	printf(" Active processor mask: %u\n",
		siSysInfo.dwActiveProcessorMask);

	Result = VirtualAlloc(NULL, 2147483648, MEM_COMMIT, PAGE_READWRITE);
	if (Result == NULL)
		printf("VirtualAlloc Failed!");
	else
		printf("VirtualAlloc Complete!");
	system("pause");
	return 0;
}