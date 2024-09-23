#pragma once
class Queue
{
   int kichthuoc;
   int front,rear;
   int *data;
public:
   Queue(void);
   ~Queue();
   int isempty();
   int isfull();
   void Add(int);
   int Remove();
   void Nhap(int);
   void Xuat(int);
};

