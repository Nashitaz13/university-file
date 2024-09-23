#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#include "list.h"


typedef struct tNode {
    int key;
    struct tNode* left, *right;
} NODE;

int abs(int x){
    if (x < 0) return -x;
    return x;
}
int max(int x, int y){
    if (x > y) return x;
    return y;
}
void create_tree(NODE *root){
    root = NULL;
}

void tree_delete_value(NODE* &root, int x);
void tree_delete_node(NODE* &X);


void print(void* tnode){
    NODE* a = (NODE*)tnode;
    if (a != NULL)
        printf("%d, ", a->key);
    else
        printf("null,");
}

void add_node(NODE * &root, NODE* p){
    if (root != NULL){
        if (root->key == p->key)
            return;
        else if (p->key < root->key)
            add_node(root->left, p);
        else // if (p->key > root->key)
            add_node(root->right, p);
    }
    else {
        root = p;
    }
}

void tree_walk_pre(NODE* root){
    if (root != NULL)
    {
        printf("%d ", root->key);
        tree_walk_pre(root->left);
        tree_walk_pre(root->right);
    }
}
void tree_walk_in(NODE* root){
    if (root != NULL)
    {
        tree_walk_in(root->left);
        printf("%d ", root->key);
        tree_walk_in(root->right);
    }
}

void tree_walk_post(NODE* root){
    if (root != NULL)
    {
        tree_walk_post(root->left);
        tree_walk_post(root->right);
        printf("%d ", root->key);
    }
}


void tree_walk_preOrder_nr(NODE* root){
    LIST stack; create_list(stack);

    push_head(stack, root);
    NODE* cur = 0;
    while (!is_empty(stack)){
        cur = (NODE*)pop_head(stack);
        if (cur != 0){
            printf("%d ", cur->key);
            push_head(stack, cur->right);
            push_head(stack, cur->left);

        }
    }
}

void tree_walk_inOrder_nr(NODE* root){
    LIST stack; create_list(stack);

    NODE* cur = root;
    while (!is_empty(stack) || cur != 0){
        //We stop when current pointer is null and stack is empty
        if (cur != 0) //if there could be a left branch, we go all the way left
            while (cur != 0){
                //Go all the way left
                push_head(stack, cur);
                cur = cur->left;
            }
        else {
            cur = (NODE*)pop_head(stack);
            printf("%d ", cur->key);
            cur = cur->right;
        }
    }
}

void tree_walk_postOrder_nr(NODE* root){
    LIST stack; create_list(stack);
    enum location {left, right, no};

    NODE* cur = root;
    NODE* previous = NULL;

    push_head(stack, cur);
    while (!is_empty(stack) || cur != 0){
        if (cur == NULL){
            previous = cur;
            cur = (NODE*)pop_head(stack);
        }
        else if( (cur->left == NULL && cur->right == NULL)
                || previous == cur->right
                || (previous == cur->left && cur->right == NULL)
        ) {
            //time to finish it
            printf("%d ", cur->key);
            pop_head(stack);
            previous = cur;
            cur = (NODE*) pop_head(stack);push_head(stack,cur); //just take it out, don't pop it now
        }
        else if (cur->left != NULL && previous != cur->left) {
            //We are traveling down
            push_head(stack, cur->left);
            previous = cur;
            cur = cur->left;

        }
        else {
            //We are traveling down
            push_head(stack, cur->right);
            previous = cur;
            cur = cur->right;
        }
    }
}

void tree_walk_breadth_first(NODE* root){
    LIST queue; create_list(queue);

    push_head(queue, root);
    NODE* cur = 0;

    while (!is_empty(queue)){
        cur = (NODE*)pop_tail(queue);

        if (cur != 0){
            printf("%d ", cur->key);

            push_head(queue, cur->right);
            push_head(queue, cur->left);
        }

    }
}

void tree_copy(NODE* source_root, NODE* &destination_root){
    if (source_root){
        NODE *p = new NODE;
        p->left = p->right = NULL;
        p->key = source_root->key;
        add_node(destination_root, p);

        tree_copy(source_root->left, destination_root->left);
        tree_copy(source_root->right, destination_root->right);
    }
}
void tree_delete_node(NODE* &X){
    //assert(X != NULL);

    NODE* tmp = X;
    if (X->left == NULL){
        X = X->right;
        delete tmp;
    }
    else if (X->right == NULL){
        X = X->left;
        delete tmp;
    }
    else {
        NODE* tmp = X->left;
        while (tmp->right != NULL)
            tmp = tmp->right;
        tree_delete_value(X->left, tmp->key);
    }
}

void tree_delete_value(NODE* &root, int x){
    if (root){
        if (x < root->key) tree_delete_value(root->left, x);
        else if (x > root->key) tree_delete_value(root->right, x);
        else tree_delete_node(root);
    }
}

void tree_destroy(NODE* &root){
    if (root){

        tree_destroy(root->left);
        tree_destroy(root->right);
        delete root;
        root = NULL;
    }
}

int h(NODE* X){
    if (X!=NULL)
        return max( h(X->left), h(X->right) )+ 1;
    if (X == NULL)
        return 0;
}

int tree_walk_tim_gan_nhat(NODE* root
                        , int gia_tri_can_tim
                        , int &min
                        ){
    if (root != NULL)
    {
        if (chieu_cao_hien_tai > chieu_cao_max)
            chieu_cao_max = chieu_cao_hien_tai;

        tree_walk_tinh_chieu_cao(root->left
                     , chieu_cao_hien_tai + 1
                     , chieu_cao_max
                     );
        tree_walk_tinh_chieu_cao(root->right
                     , chieu_cao_hien_tai + 1
                     , chieu_cao_max
                     );
    }
}


/*
Kiem tra xem tat ca key cua nhung node la con chau
cua X co bi chia het boi gia tri value hay khong
*/
int check(NODE* X, int value){

    if (X){

        if (value % X->key != 0) return 0;
        if (check(X->left, value) && check(X->right, value)){
            return 1;
        }
        else return 0;
    }
    return 1;
}
int dem_so_node_co_key_chia_het_cho_con_chau(NODE *X){
    if (X != NULL){
        return dem_so_node_co_key_chia_het_cho_con_chau(X->left)
            + dem_so_node_co_key_chia_het_cho_con_chau(X->right)
            + check(X, X->key) ;
    }
    if (X== NULL) return 0;
}

void in_node_cao_h(NODE*x, int h){
    if (x){
        if( h < 2){
            printf("%d ", x->key);
        } else {
            in_node_cao_h(x->left, h - 1);
            in_node_cao_h(x->right, h - 1);
        }
    }
}

int search_closest(NODE *T, int x){
    printf("Search in %d\n", T->key);
//    printf("left: %d, right: %d\n", T->left->key, T->right->key);
    if (T){
        NODE * p = T->left;
        if (p){
            printf("\tp1=%d\n", p->key);
            while (p->right) p = p->right;
            printf("\tp=%d\n", p->key);
            if (x < p->key)
                return search_closest(T->left, x);
        }


        NODE *q = T->right;
        if (q){
            printf("\tq1=%d\n", q->key);
            while (q->left) q = q->left;
            printf("\tq=%d\n", q->key);
            if (x > q->key)
                return search_closest(T->right, x);
        }


        if (p == NULL || abs(T->key - x) < abs(p->key - x)){
            if (q != NULL && abs(q->key - x) < abs(T->key - x)){
                return q->key;
            }
            return T->key;
        }
        else {
            if (q!= NULL && abs(q->key - x) < abs(p->key - x)){
                return q->key;
            }
            return p->key;
        }
    }


}

int main()
{
    NODE * TREE = NULL;
    NODE * TREE2 = NULL;

    srand(1335871688);

    for (int i = 0; i < 10; i++){
        NODE *p = new NODE;
        p->left = p->right = NULL;

        p->key = rand()%15;

        //printf("%d ", p->key);

        add_node(TREE, p );
    }

    tree_walk_pre(TREE);
    tree_walk_breadth_first(TREE);
    int cao;
    if (TREE == NULL) cao = 0;
    else cao = 1;
    tree_walk_tinh_chieu_cao(TREE, 1, cao);
    printf("The height of TREE is %d\n", cao);


    printf("So gan 10 nhat la %d", search_closest(TREE, 10));

//    for (int i = 0; i < 1995; i++){
//        tree_delete_value(TREE, i);
//    }
//    printf("\n Pre order:\n");
//    tree_walk_pre(TREE);
    printf ("\n");
    //tree_copy(TREE, TREE2);
    TREE->key = 100000;
    return 0;
}
