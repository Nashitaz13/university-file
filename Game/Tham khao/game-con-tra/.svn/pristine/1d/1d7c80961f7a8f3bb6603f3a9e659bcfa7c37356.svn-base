#ifndef __CBULLET_L_H__
#define __CBULLET_L_H__

#include "CBullet.h"
#include "CFileConfig.h"

enum L_ROTATION{
	L = 0,
	L_PI_4 = 1,
	L_PI_2 = 2,
	L_PI3_4 = 3,
	L_PI = 4,
	L_PI5_4 = 5,
	L_PI3_2 = 6,
	L_PI7_4 = 7
};

class CBullet_L : public CBullet
{
public:
	CBullet_L(void);
	CBullet_L(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset);
	CBullet_L(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction);
	~CBullet_L(void);

	virtual void MoveUpdate(float DeltaTime);// overide IMOVE
	virtual std::string ClassName(){return __CLASS_NAME__(CBullet_L);};
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* _listObjectCollision);
	virtual void OnCollision(float deltaTime, std::hash_map<int, CGameObject*>* listObjectCollision);
	virtual void ChangeFrame(float deltaTime);
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();
	virtual Box GetBox();
	int getStateRotation();
	float getDrawRotation();
	virtual void Init(); //Khoi tao vi tri ban dau cua vien dan
private:
	//D3DXVECTOR2 m_offset; //Vi tri cua vien dan so voi contra
	//float m_rotation; //Goc ban
	int m_stateRotation;
	float m_drawRotation; //Goc xoay
};

#endif // !__CBULLET_L_H__
