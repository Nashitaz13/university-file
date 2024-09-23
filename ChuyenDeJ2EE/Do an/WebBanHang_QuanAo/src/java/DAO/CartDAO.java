/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAO;

import MODEL.Item;
import MODEL.Product;
import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author TOBI_UIT
 */
public class CartDAO {
    private HashMap<Long, Item> listItemInCart;

    public CartDAO() {
        listItemInCart = new HashMap<>();
    }

    public CartDAO(HashMap<Long, Item> listItemInCart) {
        this.listItemInCart = listItemInCart;
    }

    public HashMap<Long, Item> getListItemInCart() {
        return listItemInCart;
    }

    public void setListItemInCart(HashMap<Long, Item> listItemInCart) {
        this.listItemInCart = listItemInCart;
    }
    
    
    // insert to cart
    public void plusToCart(Long key, Item item) {
        boolean check = listItemInCart.containsKey(key);
        if (check) {
            int quantity_old = item.getCount();
            item.setCount(quantity_old + 1);
            listItemInCart.put(key, item);
        } else {
            listItemInCart.put(key, item);
        }
    }

    // sub to cart
    public void subToCart(Long key, Item item) {
        boolean check = listItemInCart.containsKey(key);
        if (check) {
            int quantity_old = item.getCount();
            if (quantity_old <= 1) {
                listItemInCart.remove(key);
            } else {
                item.setCount(quantity_old - 1);
                listItemInCart.put(key, item);
            }
        }
    }

    // remove to cart
    public void removeToCart(Long key) {
        boolean check = listItemInCart.containsKey(key);
        if (check) {
            listItemInCart.remove(key);
        }
    }

    // count item
    public int countItem() {
        return listItemInCart.size();
    }

    // sum total 
    public double totalCart() {
        double count = 0;
        // count = price * quantity
        for (Map.Entry<Long, Item> list : listItemInCart.entrySet()) {
            count += list.getValue().getProduct().getProductPrice() * list.getValue().getCount();
        }
        return count;
    }
    
    
}
