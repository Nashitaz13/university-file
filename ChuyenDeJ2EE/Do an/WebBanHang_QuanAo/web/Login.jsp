<%-- 
    Document   : Login
    Created on : Jun 8, 2016, 5:45:37 PM
    Author     : TOBI_UIT
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Login</title>
    </head>
    <body>
        <jsp:include page="Header.jsp"></jsp:include>
            <div class="container">
                <div class="account">
                    <h2 class="account-in">Login</h2>
                   
                    <form action="LoginController" method="POST">
                        <div>
                            <span class="word">Username *</span>
                            <input type="text" name="email" id="email">
                            <span id="user-result"></span>
                        </div> 	
                        <div> 
                            <span class="word">Password *</span>
                            <input type="password" name="pass">
                            <span></span>
                        </div>			
                        <input type="submit" value="login" name="btnAction"> 
                    </form>
                </div>
            </div>
        
        <jsp:include page="Footer.jsp"></jsp:include>
    </body>
</html>
