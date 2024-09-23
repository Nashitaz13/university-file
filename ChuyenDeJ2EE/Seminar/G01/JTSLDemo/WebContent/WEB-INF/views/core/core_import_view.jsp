<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Import - JSTL Core Tags</title>
</head>
<body>

	<c:url value="http://localhost:8080/JTSLDemo/core/when_choosen_otherwise" var="myURL1">
	  <c:param name="color" value="red"/>
	</c:url>
	<c:import var="data" url="${myURL1}" charEncoding="UTF-8"/>
	<p>Respone text from <b>${myURL1}</b>:</p><br/>
	<c:out value="${data}"/>
</body>
</html>