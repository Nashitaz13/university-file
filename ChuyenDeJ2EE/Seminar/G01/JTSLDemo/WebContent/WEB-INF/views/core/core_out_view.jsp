<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
    
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Out - JSTL Core Tags</title>
</head>
<body>
 
 <br/>
<b><c:out value="Employee name: ${Employee.getEmpName()}"/></b>
<br/>
<br/>
<c:out value="${nullitem}" default="zero" />
<br/>
<c:out value="${'This is true: 10 > 1 '}" />
 <br/>
<br/>
<h3>escapeXml="false"</h3>
Tag: <c:out value="${'<atag> , &'}" escapeXml="false"/>
<br/>
<br/>
<h3>escapeXml="true"</h3>
Tag: <c:out value="${'<atag> , &'}"/>
 
</body>
</html>