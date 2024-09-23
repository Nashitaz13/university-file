#ifndef _ASSET_H_
#define _ASSET_H_    

class Asset
{
public:	
	static Asset* GetInstance();
	 bool __is_require_shake_screen = false;
private:
	Asset();
	~Asset();
	static  Asset* _pInstance;
};

#endif