<%-- 
    Document   : ErrorPage
    Created on : Jun 9, 2016, 2:06:19 PM
    Author     : TOBI_UIT
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Error</title>
    </head>
    <body>
        <jsp:include page="Header.jsp"></jsp:include>
            <div class="container">
                <div class="account">
                    <h2 class="account-in">Login Fail</h2>
                     <font color = "red" size = "4">mail or Password không đúng<font><br/><br/>
                    <form action="LoginController" method="POST">
                        <input type="submit" value="register" name="btnAction"> 
                        <input type="submit" value="tryAgain" name ="btnAction"> 
                    </form>
                </div>
            </div>
        
        <jsp:include page="Footer.jsp"></jsp:include>
    </body>
</html>
