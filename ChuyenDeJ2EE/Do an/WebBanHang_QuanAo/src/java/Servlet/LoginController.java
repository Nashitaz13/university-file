/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servlet;

import DAO.Login;
import MODEL.User;
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author TOBI_UIT
 */
public class LoginController extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            String action = request.getParameter("btnAction");
            RequestDispatcher rd;
            Login login = new Login();
            String url ="";
            HttpSession session; // tao session de set ,get
            User users = new User();
            //
            switch(action)
            {
                case "login":
                    String userEmail = request.getParameter("email");
                    String userPass = request.getParameter("pass");
                    
                    Boolean rs = login.checkLogin(userEmail,userPass);
                    //User users = new User();
                    if(rs)
                    {
                        session = request.getSession(true);
                      
                        users.setUserID(new java.util.Date().getTime());
                        users.setUserEmail(request.getParameter("email"));
                        users.setUserPass(request.getParameter("pass"));
                        users.setUserRole(false);
                        session.setAttribute("user", users);  // set value cho session nao do.
                        url = "index.jsp";
                    }
                    else
                    {
                        url = "ErrorPage.jsp";
                    }
                    
                    break;
                case "register":
                    url = "Register.jsp";
                    break;
                case "tryAgain":
                    url = "Login.jsp";
                    
                    break;
                case "createAccount":
                    long _userID = new java.util.Date().getTime();
                    String _userEmail = request.getParameter("user_email");
                    String _userPass = request.getParameter("user_pass");
                    
                    users.setUserID(_userID);
                    users.setUserEmail(_userEmail);
                    users.setUserPass(_userPass);
                    users.setUserRole(false);
                    Boolean _resultRegister = login.insertUser(users);
                    if(_resultRegister)
                    {
                        session = request.getSession(true);
                        session.setAttribute("user", users);
                        url = "index.jsp";
                    }
                    break;
            }
            rd = request.getRequestDispatcher(url);
            rd.forward(request, response);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
