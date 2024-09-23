<%-- 
    Document   : Register
    Created on : Jun 8, 2016, 10:18:19 PM
    Author     : TOBI_UIT
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>register</title>
    </head>
    <body>

        <jsp:include page="Header.jsp"></jsp:include>
            <div class="container">
                <div class="account">
                    <h2 class="account-in">Register</h2>
                    <form action="LoginController" method="POST">
<!--                        <div>
                            <span class="word">User ID *</span>
                            <input type="text" name="user_id" id="email">
                            <span id="user-result"></span>
                        </div>-->
                        <div>
                            <span class="word">User Email *</span>
                            <input type="text" name="user_email" id="email">
                            <span id="user-result"></span>
                        </div> 	
                        <div> 
                            <span class="word">Password *</span>
                            <input type="password" name="user_pass">
                            <span></span>
                        </div>			
                        <input type="hidden" value="createAccount" name="btnAction">
                        <input type="submit" value="Register"> 
                    </form>
                </div>
            </div>

        <jsp:include page="Footer.jsp"></jsp:include>


    </body>
</html>