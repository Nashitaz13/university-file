#pragma once
#include <vector>
using namespace std;
class text
{
private:
	string t;
public:
	text(void);
	~text(void);
	void Doc();
	vector<string> LuuCau();
	vector<string> LuuTu();
	int SLCau();
	void SLTu(int [], int &, ofstream &);
	int Max(vector<string> &,int []);
	void SapXep(vector<string> &p);
};
