/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package MODEL;

/**
 *
 * @author TOBI_UIT
 */
public class User {
    private long userID;
    private String userEmail;
    private String userPass;
    private Boolean userRole;

    public User() {
    }

    public User(long userID, String userEmail, String userPass, Boolean userRole) {
        this.userID = userID;
        this.userEmail = userEmail;
        this.userPass = userPass;
        this.userRole = userRole;
    }

    public long getUserID() {
        return userID;
    }

    public void setUserID(long userID) {
        this.userID = userID;
    }

    public String getUserEmail() {
        return userEmail;
    }

    public void setUserEmail(String userEmail) {
        this.userEmail = userEmail;
    }

    public String getUserPass() {
        return userPass;
    }

    public void setUserPass(String userPass) {
        this.userPass = userPass;
    }

    public Boolean getUserRole() {
        return userRole;
    }

    public void setUserRole(Boolean userRole) {
        this.userRole = userRole;
    }
    
    
}
