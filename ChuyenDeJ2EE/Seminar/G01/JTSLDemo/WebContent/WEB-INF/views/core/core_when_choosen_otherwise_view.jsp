<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
    
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Choose,When,Otherwise - JSTL Core Tags</title>
</head>
<body>
 
<h2>Show Input Color</h2>
 
 
<c:choose>
   <%-- Khi tham số color == 'red' --%>
   <c:when test="${param.color=='red' || param.color=='Red'}">
       <p style="color:red;">Is Main Color: RED COLOR</p>
   </c:when>  
    
   <%-- Khi tham số color == 'blue' --%>
   <c:when test="${param.color=='blue' || param.color=='Blue'}">
       <p style="color:blue;">Is Main Color: BLUE COLOR</p>
   </c:when>  
   
   <%-- Khi tham số color == 'green' --%>
   <c:when test="${param.color=='green' || param.color=='Green'}">
       <p style="color:green;">Is Main Color: GREEN COLOR</p>
   </c:when>  
    
   <%-- Các trường hợp khác --%>
   <c:otherwise>
   
   		<c:choose>
   			<%-- Khi tham số color == 'yellow' --%>
		   <c:when test="${param.color=='yellow' || param.color=='yellow'}">
		       <p style="color:yellow;">Is Blending Color: YELLOW COLOR</p>
		   </c:when> 
		   
		   <%-- Các trường hợp khác --%>
		   <c:otherwise>
		   		<b>Other color</b>
		   </c:otherwise> 
   		</c:choose>
   
   </c:otherwise>
</c:choose>
 <h4>${kqua}</h4>
</body>
</html>