<%-- 
    Document   : updateUser
    Created on : Jun 21, 2021, 5:51:10 PM
    Author     : triet
--%>

<%@page import="trietnm.user.UserError"%>
<%@page import="trietnm.user.UserDTO"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <link href="css/style.css" rel="stylesheet">
        <link href="css/styleContact.css" rel="stylesheet">
        <title>Update User Page</title>
    </head>
    <body>
        <%@include file="header.jsp" %>
        <%            UserDTO loginUser = (UserDTO) session.getAttribute("LOGIN_USER");

            if (loginUser == null || (!"AD".equals(loginUser.getRoleID()) && !"US".equals(loginUser.getRoleID()))) {
                response.sendRedirect("login.html");
                return;
            }
            
            if ("US".equals(loginUser.getRoleID()) && !loginUser.getUserID().equals(request.getParameter("userID"))) {
                response.sendRedirect("index.jsp");
                return;
            }
        %>      

        <%
            UserError userError = (UserError) request.getAttribute("USER_ERROR");
            if (userError == null) {
                userError = new UserError("", "", "", "", "", "", "");
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

        <form action="MainController" class="contact">
            UserID<input type="text" name="userID" value="<%= request.getParameter("userID")%>" readonly=""/>
            Full Name*<input type="text" name="fullName" value="<%= request.getParameter("fullName")%>" required=""/>
            <p class="error"><%= userError.getFullNameError()%></p>
            Email*<input type="text" name="email" value="<%= request.getParameter("email")%>"/>
            <p class="error"><%= userError.getEmailError()%></p>
            Address<input type="text" name="address" value="<%= request.getParameter("address")%>"/>
            Gender*
            <%
                if (request.getParameter("gender").equals("true")) {
            %>
            <select name="gender">
                <option value="TRUE">Nam</option>
                <option value="FALSE">Nữ</option>
            </select></br>
            <%
            } else {
            %>
            <select name="gender">
                <option value="FALSE">Nữ</option>
                <option value="TRUE">Nam</option>
            </select></br>
            <%
                }
            %>
            </br>
            Phone Number*<input type="text" name="phoneNum" value="<%= request.getParameter("phoneNum")%>" required=""/>
            <p class="error"><%= userError.getPhoneNumError()%></p>
            <%
                if ("AD".equals(loginUser.getRoleID())) {
            %>
            RoleID*<input type="text" name="roleID" value="<%= request.getParameter("roleID")%>" required=""/>
            <input type="hidden" name="search" value="<%= request.getParameter("search")%>"/>
            <p class="error"><%= userError.getRoleIDError()%></p>
            <%
            } else if ("US".equals(loginUser.getRoleID())) {
            %>
            <input type="hidden" name="roleID" value="<%=request.getParameter("roleID")%>"/>
            <p class="error" >Note: Auto logout after updating!!!</p>

            <%
                }
            %>
            <input type ="submit" name="action" value="Confirm Update User"/>
            <input type="reset" value="Reset"/>
        </form>
        <%@include file="footer.jsp" %>
    </body>
</html>
