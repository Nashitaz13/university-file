<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!-- Khai báo sử dụng JSTL Formatting and Localization Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>  

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
	<title>parseDate - JSTL Formatting and Localization Tags</title>
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
	
	<div>
		<b>Chỉ lấy ngày</b>
		<c:set var="dateTimeString" value="19/08/1993" />
		Giá trị ban đầu = '<strong>${dateTimeString}</strong>'
		<p>
		-> Date (fmt:formatDate type="date", pattern="dd/MM/yyyy"):
        <strong>
           <fmt:parseDate var="resultDate" type="date" value="${dateTimeString}" pattern="dd/MM/yyyy"/>
           <fmt:formatDate type="date" value="${resultDate }" pattern="dd----MM----yyyy"/>
        </strong>
		</p>
		
	</div> 
	
	<div>
		<b>Chỉ có giờ</b>
		<c:set var="dateTimeString" value="22:02:32" />
		Giá trị ban đầu = '<strong>${dateTimeString}</strong>'
		<p>
		-> Date (fmt:formatDate type="time", pattern="HH:mm:ss"):
        <strong>
           <fmt:parseDate var="resultDate" type="time" value="${dateTimeString}" pattern="HH:mm:ss"/>
           <fmt:formatDate type="time" value="${resultDate }" pattern="HH----mm----ss"/>
        </strong>
		</p>
	</div> 
	
	<div>
		<b>Ngày giờ</b>
		<c:set var="dateTimeString" value="03:00:00 19/08/1993" />
		Giá trị ban đầu = '<strong>${dateTimeString}</strong>'
		<p>
		-> Date (fmt:formatDate type="both", pattern="HH:mm:ss dd/MM/yyyy"):
        <strong>
           <fmt:parseDate var="resultDate" type="both" value="${dateTimeString}" pattern="HH:mm:ss dd/MM/yyyy"/>
           <fmt:formatDate type="both" value="${resultDate }" pattern="HH~~mm~~ss dd----MM----yyyy"/>
        </strong>
		</p>
	</div> 
	
</body>
</html>