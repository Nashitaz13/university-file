#ifndef LIST_H_INCLUDED
#define LIST_H_INCLUDED

typedef struct lstnode {
    void* value;
    struct lstnode* next, *prev;
} lNODE;

typedef struct taglst {
    lNODE* head, *tail;
} LIST;

void create_list(LIST &l);
void push_head(LIST &l, void* val);
void* pop_head(LIST &l);
void* pop_tail(LIST &l);
bool is_empty(LIST l);
void print_list(LIST l, void (*print)(void*) );

#endif // LIST_H_INCLUDED
