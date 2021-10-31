<%-- 
    Document   : admin.jsp
    Created on : Jun 20, 2021, 10:38:59 AM
    Author     : triet
--%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page import="java.util.List"%>
<%@page import="trietnm.user.UserDTO"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Admin Page</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/adminStyle.css" rel="stylesheet">
        <link href="css/style.css" rel="stylesheet">
    </head>
    <body>
        <%
            UserDTO currentUser = (UserDTO) session.getAttribute("LOGIN_USER");
            if (currentUser == null || !"AD".equals(currentUser.getRoleID())) {
                response.sendRedirect("login.html");
                return;
            }

            String search = (String) request.getParameter("search");
            if (search == null) {
                search = "";
            }
        %>      


        <header class="top d-flex justify-content-between">

            <img src="images/book-png.png" alt="TD logo" class = "img-responsive p-2 "/>
            <h1 class = "p-2">Thư viện Thủ Đức</h1>
            <h2 class="p-2"> Xin chào admin: <%= currentUser.getFullName()%> </br>
                <form action="MainController">
                    <input type="submit" name="action" value="Logout"/>
                </form>
            </h2>

            <form action="MainController">
                Search<input type="text" name="search" value="<%= search%>"/>
                <input type="submit" name="action" value="Search User"/>
            </form>
            <%
                String error_message = (String) request.getAttribute("ERROR_MESSAGE");
                if (error_message != null) {
            %>    
            <h1> <%= error_message%> </h1>


            <%
                }
                List<UserDTO> list = (List<UserDTO>) request.getAttribute("LIST_USER");
                if (list != null) {
                    if (!list.isEmpty()) {
            %>
            <table class="rtable userSearch" border="1">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>User ID</th>
                        <th>Full name</th>
                        <th>Email</th>
                        <th>Address</th>
                        <th>Gender</th>
                        <th>Phone Number</th>
                        <th>Role</th>
                        <th>Password</th>
                        <th>Status</th>
                        <th>Deactivate</th>
                        <th>Update</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        int count = 1;
                        for (UserDTO user : list) {
                    %>
                <form action="MainController">
                    <tr>
                        <td><%= count++%></td>
                        <td><%= user.getUserID()%></td>
                        <td><%= user.getFullName()%></td>
                        <td><%= user.getEmail()%></td>
                        <td><%= user.getAddress()%></td>
                        <td><%
                                if (user.isGender()) { %>Nam
                            <%
                                ;
                            } else { %>Nữ
                            <%;
                                }
                            %>
                        </td>
                        <td><%= user.getPhoneNum()%></td>
                        <td><%= user.getRoleID()%></td>
                        <td><%= user.getPassword()%></td>
                        <td><%= user.getStatusName()%></td>

                        <td>
                            <%
                                if (user.getStatusID().equals("AC") && "US".equals(user.getRoleID())) {
                            %>
                            <a href="MainController?userID=<%= user.getUserID()%>&action=Deactivate+User&search=<%= search%>">Deactivate</a>
                            <%
                            } 
                            %>
                        </td>
                        <td>
                            <%
                                if((currentUser.getUserID().equals(user.getUserID()) || "US".equals(user.getRoleID()))){
                             %>
                             <input type="submit" name="action" value="Update User"/>
                            <%
                                }
                                
                            %>
                           
                            <input type="hidden" name="userID" value="<%= user.getUserID()%>"/>
                            <input type="hidden" name="fullName" value="<%= user.getFullName()%>"/>
                            <input type="hidden" name="email" value="<%= user.getEmail()%>"/>
                            <input type="hidden" name="address" value="<%= user.getAddress()%>"/>
                            <input type="hidden" name="gender" value="<%= user.isGender()%>"/>
                            <input type="hidden" name="phoneNum" value="<%= user.getPhoneNum()%>"/>
                            <input type="hidden" name="roleID" value="<%= user.getRoleID()%>"/>
                            <input type="hidden" name="statusID" value="<%= user.getStatusID()%>"/>
                            <input type="hidden" name="search" value="<%= search%>"/>
                        </td>
                    </tr>
                </form>
                <%
                    }
                %>
                </tbody>
            </table>

            <%
                    }
                }

            %>    
    </body>
</html>
