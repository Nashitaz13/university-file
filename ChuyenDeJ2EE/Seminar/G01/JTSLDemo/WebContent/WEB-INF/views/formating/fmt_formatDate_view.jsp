<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!-- Khai báo sử dụng JSTL Formatting and Localization Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>  

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
	<title>formatDate - JSTL Formatting and Localization Tags</title>
	<style>
     	div{
     		background-color:whiteSmoke;
		    color:black;
		    border-style: solid;
    		border-width: 2px;
    		border-color: #000099;
    		padding: 0px 20px 0px 2px;
     	}
     	
     	div p{
     		padding: 5px;
     		color:blue;
     		font-style: italic;
     	}
     	strong{
     		color:red;
     		font-style: normal;
     	}
     </style>
</head>
<body>
	<h2>Lấy giá trị thời gian hiện tại '<strong>java.util.Date()</strong>'</h2>
	<c:set var="now" value="<%=new java.util.Date()%>" />
	
	<div>
		<b>Chỉ có ngày</b>
		<p>
		Date (fmt:formatDate type="date"):
        <strong>
           <fmt:formatDate type="date" value="${now}"/>
        </strong>
		</p>
		
		<p>
		Date (fmt:formatDate type="date" dateStyle="short"):
        <strong>
           <fmt:formatDate type="date" value="${now}" dateStyle="short"/>
        </strong>
		</p>
		
		<p>
		Date (fmt:formatDate type="date" pattern="dd-MM-yyyy"):
        <strong>
           <fmt:formatDate type="date" value="${now}" pattern="dd-MM-yy"/>
        </strong>
		</p>
		
	</div> 
	
	<div>
		<b>Chỉ có giờ</b>
		<p>
		Date (fmt:formatDate type="time"):
        <strong>
           <fmt:formatDate type="time" value="${now}"/>
        </strong>
		</p>
		
		<p>
		Date (fmt:formatDate type="time" dateStyle="short"):
        <strong>
           <fmt:formatDate type="time" value="${now}" dateStyle="short"/>
        </strong>
		</p>
		
		<p>
		Date (fmt:formatDate type="time" pattern="HH:mm:ss:SSS"):
        <strong>
           <fmt:formatDate type="time" value="${now}" pattern="HH:mm:ss:SSS"/>
        </strong>
		</p>
		
	</div> 
	
	<div>
		<b>Ngày giờ</b>
		<p>
		Date (fmt:formatDate type="both"):
        <strong>
           <fmt:formatDate type="both" value="${now}"/>
        </strong>
		</p>
		
		<p>
		Date (fmt:formatDate type="both" dateStyle="short"):
        <strong>
           <fmt:formatDate type="both" value="${now}" dateStyle="short"/>
        </strong>
		</p>
		
		<p>
		Date (fmt:formatDate type="time" pattern="HH:mm:ss dd/MM/yyy"):
        <strong>
           <fmt:formatDate type="both" value="${now}" pattern="HH:mm:ss dd/MM/yyy"/>
        </strong>
		</p>
		
	</div> 
	
</body>
</html>