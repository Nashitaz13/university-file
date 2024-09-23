<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
    
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>forTokens - JSTL Core Tags</title>
</head>
<body>
 
<h2>List name</h2>
 
 
<c:forTokens items="${tokens}" delims="," var="name">
  <c:out value="${name}"/><p>
</c:forTokens>
 
</body>
</html>