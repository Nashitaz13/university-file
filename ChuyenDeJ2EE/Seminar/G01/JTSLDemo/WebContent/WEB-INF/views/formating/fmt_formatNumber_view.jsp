<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
 
<!-- Khai báo sử dụng JSTL Core Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!-- Khai báo sử dụng JSTL Formatting and Localization Tags -->
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>  
<!DOCTYPE html>
<html>
  <head>
     <title>formatNumber - JSTL Formatting and Localization Tags</title>
     
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
     <c:set var="accountBalance" value="12345.6789" />
     <h2>Giá trị ban đầu= <strong><c:out value="${accountBalance}"/></strong></h2>
      
     <div>
     	<b>Định dạng tiền tệ (currency)</b>
     	<p>
     	formatNumber (type='currency' currencySymbol="VND" pattern="#,##0.00 ¤;-$#,##0.00 ¤" maxFractionDigits="3"):
     	<strong>
           <fmt:formatNumber value="${accountBalance}" type="currency" currencySymbol="VND" pattern="#,##0.00 ¤;-#,##0.00 ¤" maxFractionDigits="3"/>
        </strong>
     	</p>
     	
     	<p>    
        (fmt:setLocale value='en_US') + 
        formatNumber (type='currency'):          
        <fmt:setLocale value="en_US"/>
        <strong>
           <fmt:formatNumber value="${accountBalance}" type="currency"/>
        </strong>
     </div>
     
     <div>
     	<b>Định dạng số (number)</b>
     	<p>
	        formatNumber (type='number', maxIntegerDigits= '3'):
	        <strong>
	           <fmt:formatNumber type="number" maxIntegerDigits="3" value="${accountBalance}" />
	        </strong>
	     </p>
	     <p>
	        formatNumber (type='number', maxFractionDigits= '3'):
	        <strong>
	           <fmt:formatNumber type="number" maxFractionDigits="3" value="${accountBalance}" />
	        </strong>
	     </p>
	     <p>
	        formatNumber (type='number', groupingUsed= 'false'):
	        <strong>
	           <fmt:formatNumber type="number" groupingUsed="true" value="${accountBalance}" />
	        </strong>
	     </p>
	      <p>
	        formatNumber (type='number', groupingUsed= 'false'):
	        <strong>
	           <fmt:formatNumber type="number" groupingUsed="false" value="${accountBalance}" />
	        </strong>
	     </p>
	     <p>
	        formatNumber (type='number', pattern= '###.###E0'):
	        <strong>
	           <fmt:formatNumber type="number" pattern="###.###E0" value="${accountBalance}" />
	        </strong>
	     </p>
     	
     </div>
     
     <div>
     	<b>Định dạng tỉ lệ % (percent)</b>
     	<p>
	       formatNumber (type='percent', maxIntegerDigits= '4'):
	        <strong>
	           <fmt:formatNumber type="percent" maxIntegerDigits="4" value="${accountBalance}" />
	        </strong>
	     </p>
	     <p>
	        formatNumber (type='percent', maxIntegerDigits= '10'):
	        <strong>
	           <fmt:formatNumber type="percent" minFractionDigits="10" value="${accountBalance}" />
	        </strong>
	     </p>
     </div>
     
     
  </body>
  
</html>