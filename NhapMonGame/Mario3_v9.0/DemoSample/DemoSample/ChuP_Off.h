#pragma once
#ifndef __ChuP_Off_H__
#define __ChuP_Off_H_

#include "MovableObject.h"
#include "Resource.h"

class ChuP_Off : public	 MovableObject
{
public:
	ChuP_Off(float, float );
	~ChuP_Off();

	virtual void Render();
};

#endif
