#include "CScense.h"
#include "CLoadGameObject.h"

CScense::CScense()
{

}

int CScense::InitWord(char _c)
{
	int temp = -1;
	switch (_c)
	{
	case 'A'://a
		temp = 10;
		break;
	case 'B'://b
		temp = 11;
		break;
	case 'C'://c
		temp = 12;
		break;
	case 'D'://d
		temp = 13;
		break;
	case 'E'://e
		temp = 14;
		break;
	case 'F'://f
		temp = 15;
		break;
	case 'G'://g
		temp = 16;
		break;
	case 'H'://h
		temp = 17;
		break;
	case 'I'://i
		temp = 18;
		break;
	case 'J'://j
		temp = 19;
		break;
	case 'K'://k
		temp = 20;
		break;
	case 'L'://l
		temp = 21;
		break;
	case 'M'://m
		temp = 22;
		break;
	case 'N'://n
		temp = 23;
		break;
	case 'O'://o
		temp = 24;
		break;
	case 'P'://p
		temp = 25;
		break;
	case 'Q'://q
		temp = 26;
		break;
	case 'R'://r
		temp = 27;
		break;
	case 'S'://s
		temp = 28;
		break;
	case 'T'://t
		temp = 29;
		break;
	case 'U'://u
		temp = 30;
		break;
	case 'V'://v
		temp = 31;
		break;
	case 'W'://w
		temp = 32;
		break;
	case 'X'://x
		temp = 33;
		break;
	case 'Y'://y
		temp = 34;
		break;
	case 'Z'://z
		temp = 35;
		break;
	case ' '://Sapce
		temp = 36;
		break;
	}
	return temp;
}
