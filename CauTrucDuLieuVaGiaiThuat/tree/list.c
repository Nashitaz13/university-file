#include "list.h"
void create_list(LIST &l){
    l.head = l.tail = 0;
}
void push_head(LIST &l, void* val){
    lNODE *p = new lNODE;
    p->value = val;
    p->next = p->prev = 0;

    if (l.head == 0)
        l.head = l.tail = p;
    else {
        p->next = l.head;
        l.head->prev = p;
        l.head = p;
        l.head->prev = 0;
    }
}
void* pop_head(LIST &l){
    if (!is_empty(l)){
        lNODE *p = l.head;
        l.head = l.head->next;
        if (l.head)
            l.head->prev = 0;
        else
            l.tail = l.head = 0;
        return p->value;
    }
    else {
        return 0;
    }
}

void* pop_tail(LIST &l){
    if (!is_empty(l)){
        lNODE *p = l.tail;
        l.tail = l.tail->prev;
        if (l.tail)
            l.tail->next = 0;
        else
            l.tail = l.head = 0;
        return p->value;
    }
    else {
        return 0;
    }

}

void print_list(LIST l, void (*print)(void*) ){
    while (l.head != 0){
        print(l.head->value);
        l.head = l.head->next;
    }
}

bool is_empty(LIST l){
    return l.head == 0 ;
}
