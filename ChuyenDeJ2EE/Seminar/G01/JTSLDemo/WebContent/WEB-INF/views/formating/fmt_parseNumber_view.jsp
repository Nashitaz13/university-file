<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!-- Khai báo sử dụng JSTL Formatting and Localization Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>  

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
  <head>
     <title>parseNumber - JSTL Formatting and Localization Tags</title>
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
     
	<div>
		<b>Chuyển đổi tiền tệ</b>
		<p>
		<!-- Một chuỗi có định dạng tiền tệ -->
   		<c:set var="accountBalance1" value="12,345.6789 VND" />
		Giá trị ban đầu = '<strong>${accountBalance1}</strong>'
		-> fmt:parseNumber (type='currency', pattern='#,##0.00 VND'):
		<strong>
			<fmt:parseNumber type="currency" pattern="#,##0.00 VND" value="${accountBalance1}" />
        </strong>
		</p>
		
		<p>
		<c:set var="accountBalance2" value="$12,345.6789" />
		Giá trị ban đầu = '<strong>${accountBalance2}</strong>' -> 
		fmt:parseNumber (type='currency', parseLocale='en_US'):
		<strong>
			<fmt:parseNumber type="currency" parseLocale="en_US" value="${accountBalance2}" />
        </strong>
		</p>
	</div> 
	
	<div>
		<b>Chuyển đổi số</b>
		<p>
		<!-- Một chuỗi có định dạng số -->
   		<c:set var="accountBalance3" value="12,345.6789" />
		Giá trị ban đầu = '<strong>${accountBalance3}</strong>'
		-> fmt:parseNumber (type='number', pattern='#,##0.00;-#,##0.00', integerOnly='true'):
		<strong>
			<fmt:parseNumber type="number" pattern="#,##0.00;-#,##0.00" value="${accountBalance3}" integerOnly="true"/>
        </strong>
		</p>
		
		<p>
		<!-- Một chuỗi có định dạng số -->
   		<c:set var="accountBalance3" value="12,345.6789" />
		Giá trị ban đầu = '<strong>${accountBalance3}</strong>'
		-> fmt:parseNumber (type='number', pattern='#,##0.00;-#,##0.00'):
		<strong>
			<fmt:parseNumber type="number" pattern="#,##0.00;-#,##0.00" value="${accountBalance3}" />
        </strong>
		</p>
		
	</div>  
	
	<div>
		<b>Chuyển đổi tỉ lệ</b>
		<p>
		<!-- Một chuỗi có định dạng tỉ lệ -->
   		<c:set var="accountBalance4" value="12345.6789%" />
		Giá trị ban đầu = '<strong>${accountBalance4}</strong>'
		-> fmt:parseNumber (type='percent'):
		<strong>
			<fmt:parseNumber type="percent" value="${accountBalance4}"/>
        </strong>
		</p>
		
		<p>
		<!-- Một chuỗi có định dạng tỉ lệ -->
   		<c:set var="accountBalance5" value="12,345.6789 %" />
		Giá trị ban đầu = '<strong>${accountBalance5}</strong>'
		-> fmt:parseNumber (type='percent',pattern='#,##0.00 %;-#,##0.00 %'):
		<strong>
			<fmt:parseNumber type="percent" value="${accountBalance5}" pattern="#,##0.00 %;-#,##0.00 %"/>
        </strong>
		</p>
		
	</div>  
  
  </body>
  
</html>