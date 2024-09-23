<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Set, Remove, Catch - JSTL Core Tags</title>
</head>
<body>
	<h2>c:set example</h2>
	<c:set scope="session" var="greeting1" value="${Employee}" />
	Name of employee before update: <c:out value="${ greeting1.getEmpName()}"/>
	<c:set target="${greeting1}" value="Duy Luong" property="empName" />
	<br/>
	 
	Name of employee after update: <c:out value="${ greeting1.getEmpName()}"/>
	<br/>
	<c:if test="${not empty first}">
		<c:out value="Set greeting values!"></c:out>
		<c:set scope="session" var="greeting" value="${first}" />
	</c:if>
	<br/>
	 
	Greeting: <c:out value="${greeting}"/>
	
	<h2>c:remove example</h2>
	<c:remove var="greeting" scope="request"/>
	
	<h2>c:catch example</h2>
	<c:catch var ="ex">
	  <%
	   int a = 100/0;    
	  %>
	</c:catch>
	 
	 <br/>
	<c:if test = "${ex != null}">
	 Exception : ${ex}
	 <br />
	 Message: ${ex.message}
	</c:if>


</body>
</html>