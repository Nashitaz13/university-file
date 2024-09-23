#pragma once
#ifndef __BGLevel1_H__
#define __BGLevel1_H__

#include "Background.h"

#define TEXTFILE_LV1 L"Map\\Lv1\\Matrix.txt"

class BGLevel1 : public CBackground
{
public:
	BGLevel1();
	~BGLevel1();

	virtual void Render();
};


extern BGLevel1* Background1;

#endif