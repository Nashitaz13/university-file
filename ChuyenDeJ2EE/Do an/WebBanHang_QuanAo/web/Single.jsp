<%-- 
    Document   : Single
    Created on : Jun 8, 2016, 5:53:00 PM
    Author     : TOBI_UIT
--%>

<%@page import="MODEL.Product"%>
<%@page import="DAO.ProductDAO"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Single</title>
    </head>
    <body>
        <%
            ProductDAO productDAO = new ProductDAO();
            String product_id = "";
            if (request.getParameter("productID") != null) {
                product_id = request.getParameter("productID");
            }

            Product _product = productDAO.getProduct(Long.parseLong(product_id));
        %>

        <jsp:include page="Header.jsp"></jsp:include>

            <div class="container">
                <div class="single">
                    <div class="col-md-9 top-in-single">
                        <div class="col-md-5 single-top">	
                            <ul id="etalage">
                                <li>
                                    <a href="optionallink.html">
                                        <img class="etalage_thumb_image img-responsive" 
                                             src=<%=_product.getProductImage()%> alt="" ><br>
                                    </a>
                                </li>
                            </ul>

                        </div>	
                        <div class="col-md-7 single-top-in">
                            <div class="single-para">
                                <h4><%=_product.getProductName()%></h4>
                                <div class="para-grid">
                                    <span  class="add-to"><%=_product.getProductPrice()%></span>
                                    <a href="#" class="hvr-shutter-in-vertical cart-to">Add to Cart</a>					
                                    <div class="clearfix"></div>
                                </div>
                                <h5>100 items in stock</h5>
                                <p><%=_product.getProductDescription()%></p>

                                <a href="#" class="hvr-shutter-in-vertical ">More details</a>

                            </div>
                        </div>
                        <div class="clearfix"> </div>
                        <div class="content-top-in">
                            <div class="col-md-4 top-single">
                                <div class="col-md">
                                    <img  src="images/pic8.jpg" alt="" />	
                                    <div class="top-content">
                                        <h5>Mascot Kitty - White</h5>
                                        <div class="white">
                                            <a href="#" class="hvr-shutter-in-vertical hvr-shutter-in-vertical2">ADD TO CART</a>
                                            <p class="dollar"><span class="in-dollar">$</span><span>2</span><span>0</span></p>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>							
                                </div>
                            </div>
                            <div class="col-md-4 top-single">
                                <div class="col-md">
                                    <img  src="images/pic9.jpg" alt="" />	
                                    <div class="top-content">
                                        <h5>Mascot Kitty - White</h5>
                                        <div class="white">
                                            <a href="#" class="hvr-shutter-in-vertical hvr-shutter-in-vertical2">ADD TO CART</a>
                                            <p class="dollar"><span class="in-dollar">$</span><span>2</span><span>0</span></p>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>							
                                </div>
                            </div>
                            <div class="col-md-4 top-single-in">
                                <div class="col-md">
                                    <img  src="images/pic10.jpg" alt="" />	
                                    <div class="top-content">
                                        <h5>Mascot Kitty - White</h5>
                                        <div class="white">
                                            <a href="#" class="hvr-shutter-in-vertical hvr-shutter-in-vertical2">ADD TO CART</a>
                                            <p class="dollar"><span class="in-dollar">$</span><span>2</span><span>0</span></p>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>							
                                </div>
                            </div>

                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="single-bottom">
                            <h4>Categories</h4>
                            <ul>
                                <li><a href="#"><i> </i>Fusce feugiat</a></li>
                                <li><a href="#"><i> </i>Mascot Kitty</a></li>
                                <li><a href="#"><i> </i>Fusce feugiat</a></li>
                                <li><a href="#"><i> </i>Mascot Kitty</a></li>
                                <li><a href="#"><i> </i>Fusce feugiat</a></li>
                            </ul>
                        </div>
                        <div class="single-bottom">
                            <h4>Product Categories</h4>
                            <ul>
                                <li><a href="#"><i> </i>feugiat(5)</a></li>
                                <li><a href="#"><i> </i>Fusce (4)</a></li>
                                <li><a href="#"><i> </i> feugiat (4)</a></li>
                                <li><a href="#"><i> </i>Fusce (4)</a></li>
                                <li><a href="#"><i> </i> feugiat(2)</a></li>
                            </ul>
                        </div>
                        <div class="single-bottom">
                            <h4>Product Categories</h4>
                            <div class="product">
                                <img class="img-responsive fashion" src="images/st1.jpg" alt="">
                                <div class="grid-product">
                                    <a href="#" class="elit">Consectetuer adipiscing elit</a>
                                    <span class="price price-in"><small>$500.00</small> $400.00</span>
                                </div>
                                <div class="clearfix"> </div>
                            </div>
                            <div class="product">
                                <img class="img-responsive fashion" src="images/st2.jpg" alt="">
                                <div class="grid-product">
                                    <a href="#" class="elit">Consectetuer adipiscing elit</a>
                                    <span class="price price-in"><small>$500.00</small> $400.00</span>
                                </div>
                                <div class="clearfix"> </div>
                            </div>
                            <div class="product">
                                <img class="img-responsive fashion" src="images/st3.jpg" alt="">
                                <div class="grid-product">
                                    <a href="#" class="elit">Consectetuer adipiscing elit</a>
                                    <span class="price price-in"><small>$500.00</small> $400.00</span>
                                </div>
                                <div class="clearfix"> </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"> </div>
                </div>
            </div>

        <jsp:include page="Footer.jsp"></jsp:include>
    </body>
</html>
