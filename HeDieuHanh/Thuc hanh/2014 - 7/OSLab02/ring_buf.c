
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int N, in, out, num_e;
void **table;

void fifodestroy();
int fifoempty();
int fifoput(void *next);
void fifoget();
void fifoinit (int size);

/*init queue*/
void fifoinit (int size)
{
   num_e=0; in=0;out=0;
   N=size;
   printf("fifo init\n");

   table=(void**)malloc(N*sizeof(void*));
}

/*free memmory*/
void fifodestroy() 
{
   int i;
   if(!fifoempty()) 
	   free(table);
   else
   {
        for(i=out;i<in;i++)
		{
            free(table[i]);
        }
        free(table);
   }
}
/*empty queue = 1 else 0*/
int fifoempty() 
{
   return(num_e==0);
}
  
/*insert element*/
int fifoput(void *next) 
{
   if(num_e == N) 
	   return(0);
   else 
   {
       table[in] = next;
       num_e++;
       in=(in+1)%N;
       return(1);
   }   
}
/*get out element*/
void fifoget()
{
	if (num_e == 0)
		printf("Khong co chuoi nao de in ra.");
	else
	do{
		printf("%s", table[out]);
		num_e--;
		out++;
	} while (out<N);
}

int main(int argc,char* argv[]) 
{
   int y = 1;
   char *p, str[64];
   printf(" Give an integer for size: ");
   scanf_s("%d", &y);
   fifoinit(y); /*init fifo*/

   do
   {
	   putchar('\n');
	   printf(" 0: Exit\n");
	   printf(" 1: Insert string\n");
	   printf(" 2: Print next string\n");
	   printf(" Choose one of the above options:  ");
	   scanf_s("%d",&y);
	   switch (y) 
	   {
		   case 1 : 
			   {
				   printf(" Insert elements\n\n");
				   printf(" Give string ");
				   scanf_s("%s",str);
				   p=_strdup(str);
				   if (!(fifoput((void*) p))) 
				   {
					  free(p);
					  printf(" Table is full\n");
				   }
				   else 
				   {
					   printf(" Insert successful\n"); 
				   }   
				   break;
			   } 
			case 2:
				{
					printf("Get elements\n\n");
					fifoget();
					break;
				}
	   }   
	}while(y!=0);

   fifodestroy();
//   exit(0);
}