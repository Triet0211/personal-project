<%-- 
    Document   : index
    Created on : Jun 22, 2021, 12:40:33 AM
    Author     : triet
--%>

<%@page import="trietnm.user.UserDTO"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>View Information</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/style.css" rel="stylesheet">
    </head>
    <body>
        <%
            UserDTO currentUser = (UserDTO) session.getAttribute("LOGIN_USER");
            if (currentUser == null || !"US".equals(currentUser.getRoleID())) {
                response.sendRedirect("login.html");
                return;
            }
        %>
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

        <div class="row">
            <div class="information">
                <h2 class="center">Thông tin của bạn</h2>
                <h3>UserName: ${sessionScope.LOGIN_USER.userID}</h3> 
                <h3>FullName: ${sessionScope.LOGIN_USER.fullName}</h3>
                <h3>Email: ${sessionScope.LOGIN_USER.email}</h3>
                <h3>Address: ${sessionScope.LOGIN_USER.address}</h3>
                <h3>Gender: ${sessionScope.LOGIN_USER.isGender()? "Nam":"Nữ"}</h3>
                <h3>PhoneNumber: ${sessionScope.LOGIN_USER.phoneNum}</h3>


                <form action="MainController">
                    <input type="submit" name="action" value="Update User">
                    <input type="hidden" name="userID" value="<%= currentUser.getUserID()%>"/>
                    <input type="hidden" name="fullName" value="<%= currentUser.getFullName()%>"/>
                    <input type="hidden" name="email" value="<%= currentUser.getEmail()%>"/>
                    <input type="hidden" name="address" value="<%= currentUser.getAddress()%>"/>
                    <input type="hidden" name="gender" value="<%= currentUser.isGender()%>"/>
                    <input type="hidden" name="phoneNum" value="<%= currentUser.getPhoneNum()%>"/>
                    <input type="hidden" name="roleID" value="<%= currentUser.getRoleID()%>"/>
                    <input type="hidden" name="statusID" value="<%= currentUser.getStatusID()%>"/>
                    <input type="submit" name="action" value="Change Password">
                    <input type="submit" name="action" value="View History Purchase">
                </form>
            </div>
        </div>
        <%@include file="footer.jsp" %>
    </body>
</html>
