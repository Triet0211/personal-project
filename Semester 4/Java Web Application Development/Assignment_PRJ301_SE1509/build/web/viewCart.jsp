<%-- 
    Document   : index
    Created on : Jun 20, 2021, 3:40:33 PM
    Author     : triet
--%>

<%@page import="trietnm.shopping.Product"%>
<%@page import="trietnm.shopping.Cart"%>
<%@page import="java.text.DecimalFormat"%>
<%@page import="trietnm.user.UserDTO"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cart</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/style.css" rel="stylesheet">
        <link href="css/cartStyle.css" rel="stylesheet">
    </head>
    <body>
        <%@include file="header.jsp" %>

        <%            UserDTO currentUser = (UserDTO) session.getAttribute("LOGIN_USER");
            if (currentUser == null || !"US".equals(currentUser.getRoleID())) {
                response.sendRedirect("login.html");
                return;
            }
        %>

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
                        <li class="active"><a href="viewCart.jsp">Cart</a></li>


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

        <%
            DecimalFormat decimalFormat = new DecimalFormat("###,###");

            Cart cart = (Cart) session.getAttribute("CART");
            if (cart == null) {

        %>
        <h2 class="center">Chưa có sản phẩm trong giỏ hàng...</h2>
        <%} else if (cart.isEmpty()) {
        %>
        <h2 class="center">Chưa có sản phẩm trong giỏ hàng...</h2>
        <%
        } else {

        %>
        <div class="cart">
            <table class="rtable" border="1">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Name</th>
                        <th>Quantity</th>
                        <th>Price</th>
                        <th>Total</th>
                        <th>Update</th>
                        <th>Remove</th>
                    </tr>
                </thead>
                <tbody>
                    <%                        int count = 1;
                        double total = 0;
                        for (Product book : cart.getCart().values()) {
                            total += book.getQuantity() * book.getPrice();
                    %>

                <form action="MainController">
                    <tr>
                        <td><%= count++%></td>
                        <td><%= book.getProductName()%></td>
                        <td>
                            <input class= "numText" type="number" name="quantity" value="<%= book.getQuantity()%>" min="0" max="<%= book.getMaxQuantity()%>"/>
                        </td>
                        <td><%= decimalFormat.format((int) book.getPrice())%></td>
                        <td><%= decimalFormat.format((int) book.getQuantity() * book.getPrice())%></td>
                        <td>
                            <input type="submit" name="action" value="Modify"/>
                            <input type="hidden" name="productID" value="<%= book.getProductID()%>"/>
                        </td>
                        <td>
                            <input type="submit" name="action" value="Remove"/>

                        </td>
                    </tr>
                </form>
                    <%
                    }
                    %>
                </tbody>
            </table>
        </div>
        <h4 class="center">Total: <%= decimalFormat.format((int) total)%> VND </h4>
        <form class="center" action="MainController">
            <input type="submit" name="action" value="Check Out"/>
        </form>
        <%

            }
        %>

        <h4><a href="MainController?action=Search&search=">Add More</a></h4>

        <%@include file="footer.jsp" %>
    </body>
</html>
