#ifndef __CBULLET_M_H__
#define __CBULLET_M_H__

#include "CBullet.h"

class CBullet_M : public CBullet
{
public:
	CBullet_M(void);
	CBullet_M(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset);
	CBullet_M(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction);
	~CBullet_M(void);

	virtual void MoveUpdate(float DeltaTime);// overide IMOVE
	virtual std::string ClassName(){return __CLASS_NAME__(CBullet_M);};
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*> _listObjectCollision);
	virtual void OnCollision(float deltaTime, std::hash_map<int, CGameObject*>* listObjectCollision);
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();
	virtual Box GetBox();
protected:
	virtual void Init(); //Khoi tao vi tri ban dau cua vien dan
	D3DXVECTOR2 m_offset; //Vi tri cua vien dan so voi contra
	double m_rotation; //Goc ban
};

#endif // !__CBULLET_M_H__
