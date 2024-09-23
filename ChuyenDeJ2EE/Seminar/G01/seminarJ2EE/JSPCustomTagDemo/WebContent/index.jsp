<%@ page language="java" contentType="text/html; charset=ISO-8859-1"  
   pageEncoding="ISO-8859-1"%>  
 <%@taglib prefix="dt" uri="https://codersontrang.wordpress.com/customtag"%> 
 <%@ taglib uri="MyExample.tld" prefix="sample" %>
 <!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" 
                          "http://www.w3.org/TR/html4/loose.dtd">  
 <html>  
 <head>  
 <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">  
 <title>JSP Custom Tag Demo</title>  
 </head>  
 <body>  
      <dt:ColorText color="#ff3c00" content="JSP Custom Tag Demo"/>
      <br/>  
      <hr />
                <sample:hello name="Khoa" iterations="5">
			<tr><td><b>Xin chao</b></td></tr>
			</sample:hello>
                <hr /> 
 </body>  
 </html>  