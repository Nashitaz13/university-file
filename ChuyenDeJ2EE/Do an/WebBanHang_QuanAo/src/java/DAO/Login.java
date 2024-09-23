/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAO;

import DBConnect.DBConnect;
import MODEL.User;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author TOBI_UIT
 */
public class Login {
    public static Boolean checkLogin(String userEmail, String userPass) throws SQLException
    {
        try {
            Connection conn = DBConnect.getConnecttion();

            String sqlQuery = "select * from users where user_email = ? and user_pass = ? ";

            PreparedStatement ps = conn.prepareStatement(sqlQuery);
            ps.setString(1, userEmail);
            ps.setString(2, userPass);

            ResultSet rs = ps.executeQuery();

            Boolean result = rs.next();
            rs.close();
            ps.close();
            conn.close();

            if (result) {
                return true;
            }
        }
        catch(Exception e){
            e.printStackTrace();
        }
        return false;
    }
    
    public static boolean insertUser(User u) {
        Connection connection = DBConnect.getConnecttion();
        String sql = "INSERT INTO users VALUES(?,?,?,?)";
        try {
            PreparedStatement ps = connection.prepareCall(sql);
            ps.setLong(1, u.getUserID());
            ps.setString(2, u.getUserEmail());
            ps.setString(3, u.getUserPass());
            ps.setBoolean(4, u.getUserRole());
            ps.executeUpdate();
            return true;
        } catch (SQLException ex) {
            Logger.getLogger(Login.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }
    
    public static void main(String[] args) throws SQLException {
        if(insertUser(new User(3,"mail","4444",false)))
        {
            System.out.println("okie");
        }
    }
    
    
}
