#include <iostream>
#include <conio.h>
using namespace std;
class hello
{
public:
	hello()
	{
		cout<<"Entering the Hello program saying..."<<endl;
	}
	~hello()
	{
		cout<<"Then exiting...";
		getch();
	}
};
hello a;
void main(){
	cout << "Hello, world.\n";
}

