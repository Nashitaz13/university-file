<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
    
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Url, Param, Redirect - JSTL Core Tags</title>
</head>
<body>

<c:url value="/core/when_choosen_otherwise" var="myURL1">
  <c:param name="color" value="red"/>
</c:url>

<c:url value="/core/when_choosen_otherwise" var="myURL2">
  <c:param name="color" value="blue"/>
</c:url>
 
<br/>

<c:if test="${not empty redirect}">
	<c:redirect url="${myURL1}"/>
</c:if>

<a href="${myURL1}">Red</a>
<br/>
<a href="${myURL2}">Blue</a>
 
</body>
</html>