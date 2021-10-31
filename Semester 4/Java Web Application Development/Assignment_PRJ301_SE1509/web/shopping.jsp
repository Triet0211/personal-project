<%-- 
    Document   : index
    Created on : Jun 20, 2021, 3:50:07 PM
    Author     : triet
--%>

<%@page import="java.text.DecimalFormat"%>
<%@page import="trietnm.products.ProductDTO"%>
<%@page import="java.util.List"%>
<%@page import="trietnm.user.UserDTO"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Bookshelf</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">

        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/style.css" rel="stylesheet">
        <link href="css/styleView.css" rel="stylesheet">
    </head>
    <body>
        <%@include file="header.jsp" %>

        <%            
            String search = (String) request.getParameter("search");
            if (search == null) {
                search = "";
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

                        <li class="active"><a href="MainController?action=Search&search=">Bookshelf</a></li>
                        <li ><a href="viewCart.jsp">Cart</a></li>


                        <li>  <a href="contact.jsp"><span class="glyphicon glyphicon-envelope"></span> Contact</a>  </li>
                    </ul>


                    <form class="navbar-form navbar-right" role="search" action="MainController">
                        <div class="form-group">
                            <input type="text" class="form-control" placeholder="Search" name="search" value="<%= search%>">

                        </div>
                        <button type="submit" class="btn btn-default" name="action" value="Search">Search</button>
                    </form>

                </div><!-- /.navbar-collapse -->
            </div><!-- /.container-fluid -->
        </nav>
   
        <div class="row">
            <% 
                DecimalFormat decimalFormat = new DecimalFormat("###,###");
                List<ProductDTO> list = (List<ProductDTO>) request.getAttribute("LIST_PRODUCT");
                if (list != null) {
                    if (!list.isEmpty()) {
                        int count = 1;
                        for (ProductDTO product : list) {
            %>

            <div class="col-md-6 item" >
                <a href="MainController?action=View+Book&productID=<%= product.getProductID()%>">
                    <img class ="img-responsive img-thumbnail" src="<%= product.getImage()%>" alt="<%= product.getProductName()%>">
                </a>
                <div class="slide-caption">
                    <h3>
                        <a href="MainController?action=View+Book&productID=<%= product.getProductID()%>" title="<%= product.getProductName()%>"><%= product.getProductName()%></a>
                    </h3>
                    <span class="">
                        Còn lại: <%= product.getQuantity()%></span></br>
                    <span class="">
                        Giá: <%= decimalFormat.format((int) product.getPrice())%> VNĐ</span>
                </div>
            </div>
            <%
                        }
                    }
                }
            %>
        </div>
        </br>
        <%@include file="footer.jsp" %>
    </body>
</html>
