<%-- 
    Document   : header
    Created on : Jun 22, 2021, 2:05:42 PM
    Author     : triet
--%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page import="trietnm.user.UserDTO"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Header Page</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/style.css" rel="stylesheet">
    </head>
    <body>
        <header class="top d-flex justify-content-between">

           
            <h1 class = "p-2"> <a href="index.jsp"><img src="images/book-png.png" alt="TD logo" class = "img-responsive"/></a>Thư viện Thủ Đức</h1>
            <%
                UserDTO user = (UserDTO) session.getAttribute("LOGIN_USER");
                if (user == null) {
            %>
            <a class="p-2" href="login.html" ><input type="button" value="Login" class="btn btn-default" /></a>
            <a class="p-2" href="createUser.jsp" ><input type="button" value="Sign Up" class="btn btn-default" /></a>
                <%
                } else if(("US".equals(user.getRoleID()))) {
                %>
            <h2 class="p-2"> Xin chào, <%= user.getFullName()%> </br>
                <form action="MainController">
                    <input type="submit" name="action" value="Logout"/>

                    <input type="submit" name="action" value="View Information"/>


                </form>
            </h2>
            <%
                }
            %>
            <c:if test = "${ LOGIN_USER.roleID == 'AD' }" >
                <h2 class="p-2"> Xin chào admin: <%= user.getFullName()%> </br>
                    <form action="MainController">
                        <input type="submit" name="action" value="Logout"/>
                    </form>
                </h2>
            </c:if>


        </header>

    </body>
</html>
