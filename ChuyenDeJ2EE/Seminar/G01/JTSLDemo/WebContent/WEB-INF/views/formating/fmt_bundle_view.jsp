<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!-- Khai báo sử dụng JSTL Formatting and Localization Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>  
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<c:if test="${not empty param.language}">
  <c:set var="language" value="${param.language}" scope="session"/>
</c:if>
<fmt:requestEncoding value="UTF-8" />
<fmt:setLocale value="${language}" />
<fmt:setBundle basename="jstl.bundles.LangBundles" />
<html>
  <head>
     <meta charset="UTF-8">
     <title>bundle, setBundle, message, requestEncoding - JSTL Formatting and Localization Tags</title>
  </head>
  <body>
     <form action="">
        <table border="0">
           <tr>
              <td>
                 <fmt:message key="login.label.userName"/>
              </td>
              <td>
                 <input type="text" name="userName" />
              </td>
           </tr>
           <tr>
              <td>
                 <fmt:message key="login.label.password"/>
              </td>
              <td><input type="text" name="userName" /></td>
           </tr>
        </table>
        <input type="submit"  value="Submit"/>
     </form>
  </body>
</html>