#include "CDrawObject.h"
#include "CManagementTexture.h"
#include "CTexture.h"
#include "CCamera.h"
#include "CHidenObject.h"
#include "CContra.h"
#include "CDefenseCannon.h"
#include "CBridgeFire.h"
#include "CBigCapsule.h"
#include "CMechanicalAlien.h"

CDrawObject::CDrawObject()
{
	this->m_draw = new CSprite();
}

void CDrawObject::Draw(CGameObject* obj)
{
	//Kiem tra doi tuong khac null
	if (obj != nullptr)
	{
		//Neu doi tuong khong phai la hide object thi ve len ma hinh
		if (obj->ClassName() != __CLASS_NAME__(CGameObject))
		{
			int typeObject = obj->GetIDType();
			int idObject = obj->GetID();

			//Kiem tra xem Id cua doi tuong no co hop le hay khong
			if (typeObject > 0)
			{
				CTexture* texture;
				//Lay ra resource anh cua doi tuongLevel1quadTree
				if (typeObject == 13) //Day la weapon tinh
					texture = CManagementTexture::GetInstance()->GetTextureByID(1, 13);
				else
					if (typeObject == 14 && idObject != 8)
					{
						texture = CManagementTexture::GetInstance()->GetTextureByID(1, 14);
					}
					else
					{
						texture = CManagementTexture::GetInstance()->GetTextureByID(idObject, typeObject);
					}
				if (typeObject == 15)
				{
					texture = CManagementTexture::GetInstance()->GetTextureByID(1, 15);
				}
				//Neu ton tai texture 
				if (texture && this->m_draw)
				{
					D3DXVECTOR3 posObj(obj->GetPos().x, obj->GetPos().y, 0);
					D3DXVECTOR3 posObjAfterTransform = CCamera::GetInstance()->GetPointTransform(posObj.x, posObj.y);
					//Ve theo huong cua Object

					if (idObject == 2 && typeObject == 20){
						CBullet_L* object = (CBullet_L*)obj;

						if (!object->GetDirection())
						{
							if (object->getStateRotation() == L_ROTATION::L){
								this->m_draw->draw(texture, obj->GetRectRS(), posObjAfterTransform, D3DCOLOR_XRGB(255, 255, 255), true);
							}
							else{
								this->m_draw->drawRotation(texture, obj->GetRectRS(), posObjAfterTransform, object->getDrawRotation(), D3DCOLOR_XRGB(255, 255, 255), true);
							}
						}
						else
						{
							if (object->getStateRotation() == L_ROTATION::L){
								this->m_draw->drawFlipX(texture, obj->GetRectRS(), posObjAfterTransform, D3DCOLOR_XRGB(255, 255, 255), true);
							}
							else {
								this->m_draw->drawRotation(texture, obj->GetRectRS(), posObjAfterTransform, object->getDrawRotation(), D3DCOLOR_XRGB(255, 255, 255), true);
							}
						}
					}
					else if (typeObject == 15)
					{
						////D3DXVECTOR3 poshiden(0, 0, 0);
						//posObjAfterTransform = CCamera::GetInstance()->GetPointTransform(posObj.x, posObj.y);
						////this->m_draw->draw(texture, obj->GetRectRS(), posObjAfterTransform, D3DCOLOR_XRGB(255,255,255), true);
						//this->m_draw->drawScale(texture, obj->GetRectRS(), posObjAfterTransform,
						//	D3DXVECTOR2(obj->GetWidth() / texture->GetImageWidth(), obj->GetHeight() / texture->GetImageHeight())/* D3DXVECTOR2(0.5,0.5)*/, D3DCOLOR_XRGB(255, 255, 255), true);
					}
					else
					{
						//if (obj->GetIDType() != 50)
						//{

						//	RECT* rect = new RECT();
						//	rect->left = 0;
						//	rect->right = 64;
						//	rect->top = 0;
						//	rect->bottom = 64;
						//	D3DXVECTOR3 posofBox = CCamera::GetInstance()->GetPointTransform(obj->GetBox().x, obj->GetBox().y);
						//	CTexture* text = CManagementTexture::GetInstance()->GetTextureByID(1, 15);
						//	this->m_draw->drawScale(text,
						//		rect, posofBox,
						//		D3DXVECTOR2(obj->GetBox().w / text->GetImageWidth(), obj->GetBox().h / text->GetImageHeight())/* D3DXVECTOR2(0.5,0.5)*/,
						//		D3DCOLOR_XRGB(255, 255, 255), true);
						//}
						//sang test
						if (!obj->GetDirection())
						{
							this->m_draw->draw(texture, obj->GetRectRS(), posObjAfterTransform, D3DCOLOR_XRGB(255, 255, 255), true);
						}
						else
						{
							this->m_draw->drawFlipX(texture, obj->GetRectRS(), posObjAfterTransform, D3DCOLOR_XRGB(255, 255, 255), true);
							//this->m_draw->drawRotation(texture, obj->GetRectRS(), posObjAfterTransform,D3DXVECTOR2(50.0f, 1.0f), 0, D3DCOLOR_XRGB(255,255,255), true);
						}
					}

					//ve dan
					if (obj->m_allowShoot)
					{
						for (int i = 0; i < obj->m_listBullet.size(); i++)
						{
							CDrawObject::GetInstance()->Draw(obj->m_listBullet[i]);
						}
					}
				}
				//Tinh Test
				//Ve cay cau lua
				if (typeObject == 16)
				{
					switch (idObject)
					{
					case 2://cau lua
					{
							   CBridgeFire* objBridgeFire = ((CBridgeFire*)obj);
							   //Ve cuc lua trai
							   if (objBridgeFire->fireLeft->IsAlive())
								   CDrawObject::GetInstance()->Draw(objBridgeFire->fireLeft);
							   //Ve cuc lua phai
							   if (objBridgeFire->fireRight->IsAlive())
								   CDrawObject::GetInstance()->Draw(objBridgeFire->fireRight);
							   //
							   break;
					}
					default:
						break;
					}

				}
				//Tinh Test
				//Neu obj co phai la boss thi tao moi 3 doi tuong kia
				// k co box cho nong sung, sao no va cham :D=
				if (typeObject == 17)
				{
					if (CContra::GetInstance()->m_isDrawBoss)
					{
						switch (idObject)
						{
						case 1://Boss map 1
						{
								   CDefenseCannon* objDef = ((CDefenseCannon*)obj);
								   //ve boss
								   //Ve spiner
								   if (objDef->sniper->IsAlive())
									   CDrawObject::GetInstance()->Draw(objDef->sniper);
								   //
								   //ve u sung
								   if (objDef->turrect->IsAlive())
								   {
									   CDrawObject::GetInstance()->Draw(objDef->turrect);
								   }
								   //
								   if (objDef->gunLeft->IsAlive())
									   CDrawObject::GetInstance()->Draw(objDef->gunLeft);
								   if (objDef->gunRight->IsAlive())
									   CDrawObject::GetInstance()->Draw(objDef->gunRight);
								   break;
						}
						case 5://Boss map 2
						{
								   CMechanicalAlien* objMec = ((CMechanicalAlien*)obj);
								   //ve boss
								   //Ve dau boss
								   if (objMec->m_Head->IsAlive())
									   CDrawObject::GetInstance()->Draw(objMec->m_Head);
								   //
								   //ve tay ben trai
								   if (objMec->m_ArmLeft->IsAlive())
									   objMec->m_ArmLeft->Draw();
								   //Ve tay ben phai
								   if (objMec->m_ArmRight->IsAlive())
									   objMec->m_ArmRight->Draw();
								   break;
						}
						default:
							break;
						}
					}
				}
			}

		}
	}
}

void CDrawObject::Draw(CGameObject* obj, D3DCOLOR color)
{
	if (obj != nullptr)
	{
		//Neu doi tuong khong phai la hide object thi ve len ma hinh
		if (obj->ClassName() != __CLASS_NAME__(CGameObject))
		{
			int typeObject = obj->GetIDType();
			int idObject = obj->GetID();
			//Kiem tra xem Id cua doi tuong no co hop le hay khong
			if (typeObject > 0)
			{
				CTexture* texture;
				//Lay ra resource anh cua doi tuongLevel1quadTree
				if (typeObject == 13) //Day la weapon tinh
					texture = CManagementTexture::GetInstance()->GetTextureByID(1, 13);
				else
				if (typeObject == 14 && idObject != 8)
				{
					texture = CManagementTexture::GetInstance()->GetTextureByID(1, 14);
				}
				else
				{
					texture = CManagementTexture::GetInstance()->GetTextureByID(idObject, typeObject);
				}
				if (typeObject == 15)
				{
					texture = CManagementTexture::GetInstance()->GetTextureByID(1, 15);
				}
				//Neu ton tai texture 
				if (texture && this->m_draw)
				{
					D3DXVECTOR3 posObj(obj->GetPos().x, obj->GetPos().y, 0);
					//D3DXVECTOR2 posCenter;
					//posCenter.x = posObj.x + obj->GetWidth() / 2;
					//posCenter.y = posObj.y + obj->GetHeight() / 2;
					D3DXVECTOR3 posObjAfterTransform = CCamera::GetInstance()->GetPointTransform(posObj.x, posObj.y);
					if (!obj->GetDirection())
					{
						this->m_draw->draw(texture, obj->GetRectRS(), posObjAfterTransform, color, true);
					}
					else
					{
						this->m_draw->drawFlipX(texture, obj->GetRectRS(), posObjAfterTransform, color, true);
					}
				}
			}
		}
	}
}

CDrawObject::~CDrawObject()
{
	if (this->m_draw)
		delete this->m_draw;
}