<%-- 
    Document   : viewBook
    Created on : Jun 28, 2021, 12:53:16 PM
    Author     : triet
--%>

<%@page import="java.text.DecimalFormat"%>
<%@page import="trietnm.products.ProductDAO"%>
<%@page import="trietnm.products.ProductDTO"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Book Information Page</title>

        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/style.css" rel="stylesheet">
        <link href="css/styleView.css" rel="stylesheet">
    </head>
    <body>
        <%@include file="header.jsp" %>

        <nav class="navbar navbar-inverse bg-primary"  role="navigation">
            <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>

                </div>

                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav">

                        <li > <a href="index.jsp"> <span class="glyphicon glyphicon-home"></span> Home</a> </li>

                        <li ><a href="MainController?action=Search&search=">Bookshelf</a></li>
                        <li ><a href="viewCart.jsp">Cart</a></li>


                        <li>  <a href="contact.jsp"><span class="glyphicon glyphicon-envelope"></span> Contact</a>  </li>
                    </ul>


                    <form class="navbar-form navbar-right" role="search" action="MainController">
                        <div class="form-group">
                            <input type="text" class="form-control" placeholder="Search" name="search">
                        </div>
                        <button type="submit" class="btn btn-default" name="action" value="Search">Search</button>
                    </form>

                </div><!-- /.navbar-collapse -->
            </div><!-- /.container-fluid -->
        </nav>

        <%            DecimalFormat decimalFormat = new DecimalFormat("###,###");
            ProductDTO currentProduct = (ProductDTO) request.getAttribute("CURRENT_PRODUCT");
            String formatPrice = decimalFormat.format((int) currentProduct.getPrice());
        %>

        <div class="row book">
            <img class ="img-responsive img-thumbnail col-md-4" src="${requestScope.CURRENT_PRODUCT.getImage()}" alt="${requestScope.CURRENT_PRODUCT.productName}">
            <div class="info col-md-8" >
                <tittle >${requestScope.CURRENT_PRODUCT.productName}</tittle>
                <p ><span>Thể loại</span>: ${requestScope.CURRENT_PRODUCT.getCategoryName()}</p>
                <p ><span>Số lượng hàng còn lại</span>: 
                    <c:if test="${requestScope.CURRENT_PRODUCT.quantity == 0}">
                        Hết hàng
                    </c:if>
                    <c:if test="${requestScope.CURRENT_PRODUCT.quantity != 0}">
                        ${requestScope.CURRENT_PRODUCT.quantity}
                    </c:if>
                </p>
                <p ><span>Mô tả</span>: ${requestScope.CURRENT_PRODUCT.description}</p>
                <p ><span>Giá</span>: <%=  formatPrice%> VNĐ</p>
                <c:if test="${requestScope.CURRENT_PRODUCT.quantity != 0}">
                    <c:if test = "${sessionScope.LOGIN_USER.roleID eq 'US'}">
                        <form action="MainController">
                            <p><span>Số lượng</span>: 
                                <input type="number" name="quantity" value="1" min="1" max="${requestScope.CURRENT_PRODUCT.quantity}"/>
                                <input type="hidden" name="productID" value="${requestScope.CURRENT_PRODUCT.productID}"/>
                                <input type ="submit" name="action" value="Add to Cart"/>
                                <input type ="submit" name="action" value="View Cart"/></p>  
                        </form>  
                    </c:if>

                    <c:if test = "${sessionScope.LOGIN_USER.roleID ne 'US'}">
                        <p>Bạn phải <a href="login.html">đăng nhập</a> trước khi thêm sách vào giỏ hàng!</p>
                    </c:if>
                    ${requestScope.SHOPPING_MESSAGE}
                </c:if>

            </div>
        </div>


        <%@include file="footer.jsp" %>
    </body>
</html>
