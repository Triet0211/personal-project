<%-- 
    Document   : history
    Created on : Jul 2, 2021, 3:23:54 PM
    Author     : triet
--%>

<%@page import="trietnm.orders.OrderDetail"%>
<%@page import="trietnm.orders.OrderDTO"%>
<%@page import="java.util.List"%>
<%@page import="java.text.DecimalFormat"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Purchase History Page</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/style.css" rel="stylesheet">
        <link href="css/cartStyle.css" rel="stylesheet">
    </head>
    <body>
        <%@include file="header.jsp" %>
        <%            UserDTO loginUser = (UserDTO) session.getAttribute("LOGIN_USER");

            if (loginUser == null || !"US".equals(loginUser.getRoleID())) {
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

        <%
            DecimalFormat decimalFormat = new DecimalFormat("###,###");

            List<OrderDTO> listOrder = (List<OrderDTO>) session.getAttribute("ORDER_LIST");
            if (listOrder == null || listOrder.isEmpty()) {

        %>
        <h2 class="center">${requestScope.HISTORY_MESSAGE}</h2>
        <%        } else {
        %>
        <div class="center">
            <table class="rtable history" border="1">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>OrderID</th>
                        <th>Address</th>
                        <th>Phone</th>
                        <th>Total</th>
                        <th>Status</th>
                        <th>Payment Status</th>
                        <th>Cancel</th>
                        <th>Detail</th>
                    </tr>
                </thead>
                <%
                    int count = 1;
                    double total = 0;
                    for (OrderDTO order : listOrder) {
                        total += order.getTotalMoney();

                %>
                <tbody>
                    <tr>
                        <td><%= count++%></td>
                        <td>
                            <%= order.getOrderID()%>
                        </td>
                        <td><%= order.getAddress()%></td>
                        <td><%= order.getPhoneNum()%></td>
                        <td><%= decimalFormat.format((int) order.getTotalMoney())%></td>
                        <td>
                            <%= order.getStatusName()%>
                        </td>
                        <td><%= order.getPaymentStatus()%></td>
                        <td>
                            <%
                                if (order.getStatusID().equals("SHIP")) {
                            %>
                            
                            <form action="MainController" onSubmit="return confirm('Confirm Cancellation Order: <%= order.getOrderID()%>');">
                                <input type="submit" name="action" value="Cancel"/>
                                <input type="hidden" name="orderID" value="<%= order.getOrderID()%>"/>
                            </form>


                            <%
                            } else {
                            %>
                            Can not Cancel
                            <%
                                }
                            %>
                        </td>
                        <td>
                            <form action="MainController">
                                <input type="submit" name="action" value="Detail"/>
                                <input type="hidden" name="orderID" value="<%= order.getOrderID()%>"/>
                            </form>
                        </td>
                    </tr>
                </tbody>
                <%
                    }
                %>
            </table>
        </div>
        <h4 class="center">Total: <%= decimalFormat.format((int) total)%> VND </h4>

        <%
            List<OrderDetail> listDetail = (List<OrderDetail>) session.getAttribute("DETAIL_LIST");
            if (listDetail != null) {
        %>
        <div class="history">
            <h3>Detail of order: ${sessionScope.ORDER_ID} </h3>
            <table class="rtable" border="1">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Product Name</th>
                        <th>Quantity</th>
                        <th>Price</th>
                        <th>Total Price</th>
                    </tr>
                </thead>
                <tbody>

                    <%
                        int countDetail = 1;
                        for (OrderDetail detail : listDetail) {
                    %>


                    <tr>
                        <td><%= countDetail++%></td>
                        <td>
                            <%= detail.getProductName()%>
                        </td>
                        <td>
                            <%= detail.getDetailQuantity()%>
                        </td>
                        <td><%= decimalFormat.format((int) detail.getPriceEach())%></td>
                        <td><%= decimalFormat.format((int) detail.getPrice())%></td>
                    </tr>

                    <%
                        }
                    %>
                </tbody>
            </table>
            <%
                    }
                }
            %>


            <%@include file="footer.jsp" %>
    </body>
</html>
