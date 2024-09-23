#ifndef __CBULLET_S_H__
#define __CBULLET_S_H__

#include "CBullet.h"

class CBullet_S : public CBullet
{
public:
	CBullet_S();
	~CBullet_S();
	CBullet_S(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset);
	CBullet_S(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction);
	virtual void MoveUpdate(float DeltaTime);// overide IMOVE
	virtual std::string ClassName(){return __CLASS_NAME__(CBullet_S);};
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*> _listObjectCollision);
	virtual void OnCollision(float deltaTime, std::hash_map<int, CGameObject*>* listObjectCollision);
	virtual void ChangeFrame(float deltaTime);
	virtual void SetLayer(LAYER layer);
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();

	CBullet* m_bullet_1;
	CBullet* m_bullet_2;
	CBullet* m_bullet_3;
	CBullet* m_bullet_4;
	CBullet* m_bullet_5;
	virtual void Init(); //Khoi tao vi tri ban dau cua vien dan
private:
};

#endif // !__CBULLET_S_H__
