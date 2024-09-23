#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define test_number 20000000

typedef struct lNODE {
    int data;
    struct lNODE* pNext;
} NODE;

typedef struct lLIST{
    NODE *head, *tail;
} LIST;

void list_create(LIST &l);
void list_add_head(LIST &l, int data);
void list_add_tail(LIST &l, int data);
void list_add_at(LIST &l, int data, int index);
void list_print(const LIST l);

/**
    @return NODE da`u tien chua gia' tri can ti`m
    @return Ne^'u gia' tri can tim khong con trong danh sach
            return NULL
*/
NODE* list_search(const LIST l, int search_data);

void list_remove_value(LIST &l, int data);
void list_remove_at(LIST &l, int index);
void list_remove_head(LIST &l);
void list_remove_tail(LIST &l);

static NODE* node_create(int data);
static void list_add_node_head(LIST &l, NODE* newnode);
static void list_add_node_tail(LIST &l, NODE* newnode);
static void list_add_node_after(LIST &l, NODE* old_node, NODE* newnode);


void list_create(LIST &l){
    l.head = l.tail = NULL;
}
static NODE* node_create(int data){
    NODE* p = (NODE*)malloc(sizeof(NODE));
    if (p != NULL){
        p->data = data;
        p->pNext = NULL;
    }

    return p;
}

static void list_add_node_tail(LIST &l, NODE* newnode){
    if (l.head == NULL){
        l.head  = l.tail = newnode;
    } else {
        l.tail->pNext = newnode;
        l.tail = newnode;
    }
}
static void list_add_node_head(LIST &l, NODE* newnode){
    if (l.head == NULL){
        l.head  = l.tail = newnode;
    } else {
        newnode->pNext = l.head;
        l.head = newnode;
    }
}
static void list_add_node_after(LIST &l, NODE* old_node, NODE* newnode){
    if (old_node == l.tail) return list_add_node_tail(l, newnode);
    if (old_node == NULL) return list_add_node_head(l, newnode);
    newnode->pNext = old_node->pNext;
    old_node->pNext = newnode;
}

void list_add_tail(LIST &l, int data){
    list_add_node_tail(l, node_create(data));
}
void list_add_head(LIST &l, int data){
    list_add_node_head(l, node_create(data));
}
void list_add_at(LIST &l, int data, int index){
    NODE*p = l.head;
    NODE*q = NULL;
    for(int i = 0; i < index && p != NULL; i++){
        q = p;
        p = p->pNext;
    }

    if (p == NULL) return; //data khong ton tai trong list
    list_add_node_after(l, q, node_create(data));
}


void list_print(const LIST l){
    NODE* p = l.head;
    while (p != NULL){
        printf("%d ", p->data);
        p = p->pNext;
    }
    printf("\n");
}


void list_remove_value(LIST &l, int data){
    NODE*p = l.head;
    NODE*q = NULL;
    while(p != NULL && p->data != data){
        q = p;
        p = p->pNext;
    }

    if (p == NULL) return; //data khong ton tai trong list
    else if (q == NULL) list_remove_head(l);
    else {
        q->pNext = p->pNext;
        free(p);
        if (p== l.tail) l.tail = q;
    }
}
void list_remove_at(LIST &l, int index){
    NODE*p = l.head;
    NODE*q = NULL;
    for(int i = 0; i < index && p != NULL; i++){
        q = p;
        p = p->pNext;
    }

    if (p == NULL) return; //index khong ton tai
    else if (q == NULL) list_remove_head(l);
    else {
        q->pNext = p->pNext;
        free(p);
        if (p== l.tail) l.tail = q;
    }
}
void list_remove_head(LIST &l){
    if (l.head){
        NODE* p = l.head;
        l.head = l.head->pNext;
        if (l.head == NULL) l.tail = NULL;
        free(p);
    }
}
void list_remove_tail(LIST &l){
    NODE* pre_tail = l.head;
    while(pre_tail){
        if (pre_tail->pNext == l.tail) break;
        pre_tail = pre_tail->pNext;
    }

    if (pre_tail == NULL && l.head != NULL){
        pre_tail = l.head;
        l.head = l.tail = NULL;
        free(pre_tail);
    } else {
        l.tail = pre_tail;
        free(pre_tail->pNext);
        pre_tail->pNext == NULL;
    }
}




void nhap_list_l1(LIST& l){
    int x;
    do {
        printf("Nhp phan tu tiep theo "); scanf("%d", &x);
        if (x > 0){
            list_add_tail(l, x);
        }
    } while (x > 0);
}

void copy_list(LIST source, LIST &destination){
    NODE* x = source.head;
    while (x != NULL){
        list_add_tail(destination, x->data);
        x = x->pNext;
    }
}

void invert_list(LIST source, LIST &destination){
    NODE* x = source.head;
    while (x != NULL){
        list_add_head(destination, x->data);
        x = x->pNext;
    }
}

void list_bubble_sort(LIST& l){
    if (l.head == l.tail) return;

    int hoan_vi = 0;

    do{
        hoan_vi = 0;
        for(NODE*j = l.head; j->pNext != NULL; j=j->pNext){
            if (j->data > j->pNext->data){
                hoan_vi = 1;
                int x = j->data;
                j->data = j->pNext->data;
                j->pNext->data = x;
            }
        }
    } while (hoan_vi);
}

float list_average(LIST l){
    int dem =0;
    NODE*p = l.head;
    int sum = 0;
    while (p != NULL){
        sum += p->data;
        dem++;

        p = p->pNext;
    }
    return sum * 1.0 / dem;
}

int list_median(LIST l){
    LIST temp; list_create(temp);
    copy_list(l, temp);
    list_bubble_sort(temp);

    int dem = 0;
    NODE*p = l.head;

    while (p != NULL){
        dem++;
        p = p->pNext;
    }

    p = temp.head;
    for (int i= 0; i < dem/2 ; i++){
        p = p->pNext;
    }
    return p->data;
}

int main()
{


    srand(time(0));
    LIST l1, l2, l3;
    list_create(l1);
    list_create(l2);
    list_create(l3);

    for(int i = 0; i < 8; i++){
        list_add_tail(l1, i);
    }

    for(int i =0 ; i < 10; i++){
        int j = rand()%15;
        list_add_at(l1, i, j);
        printf("add %i at %i ", i, j); list_print(l1);
    }


    clock_t start = clock();
}
