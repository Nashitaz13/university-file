/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import DBConnect.DBConnect;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.util.Date;
import model.Bill;

/**
 *
 * @author TUNGDUONG
 */
public class BillDAO {

    public void insertBill(Bill bill) throws SQLException {
        Connection connection = DBConnect.getConnecttion();
        String sql = "INSERT INTO bill VALUES(?,?,?,?,?,?)";
        PreparedStatement ps = connection.prepareCall(sql);
        ps.setLong(1, bill.getBillID());
        ps.setLong(2, bill.getUserID());
        ps.setDouble(3, bill.getTotal());
        ps.setString(4, bill.getPayment());
        ps.setString(5, bill.getAddress());
        ps.setTimestamp(6, bill.getDate());
        ps.executeUpdate();
    }
    
    public static void main(String[] args) throws SQLException {
        
        new BillDAO().insertBill(new Bill(0, 0, 0, "s", "s", new Timestamp(new Date().getTime())));
    }

}
