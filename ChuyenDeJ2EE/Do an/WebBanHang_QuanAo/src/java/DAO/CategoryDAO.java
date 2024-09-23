/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAO;

import DBConnect.DBConnect;
import MODEL.Category;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author TOBI_UIT
 */
public class CategoryDAO {
    public static ArrayList<Category> getListCategory() {
        Connection cons = DBConnect.getConnecttion();
        String sql = "SELECT * FROM category";
        ArrayList<Category> list = new ArrayList<>();
        try {
            PreparedStatement ps = (PreparedStatement) cons.prepareStatement(sql);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                Category category = new Category();
                category.setCategoryID(rs.getInt("category_id"));
                category.setCategoryName(rs.getString("category_name"));
                list.add(category);
            }
            cons.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return list;
    }
    
    public static void main(String[] args) {
        ArrayList<Category> listCategory = getListCategory();
        
        System.out.println("test:"+listCategory.size());
    }
}
