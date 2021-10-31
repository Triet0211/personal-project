<%-- 
    Document   : index
    Created on : Jun 20, 2021, 3:42:29 PM
    Author     : triet
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Contact</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/style.css" rel="stylesheet">
        <link href="css/styleContact.css" rel="stylesheet">

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


                        <li class="active">  <a href="contact.jsp"><span class="glyphicon glyphicon-envelope"></span> Contact</a>  </li>
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

        <div class="contact">
            <form action="MainController">

                <label for="fname">Tên</label>
                <input type="text" id="fname" name="fullName" placeholder="Your name..." required="" value="${sessionScope.LOGIN_USER.fullName}">

                <label for="email">Email</label>
                <input type="text" id="email" name="email" placeholder="Your email..." required="" value="${sessionScope.LOGIN_USER.email}">

                <label for="phoneNum">Số điện thoại liên hệ</label>
                <input type="text" id="phoneNum" name="phoneNum" placeholder="Your phone number..." value="${sessionScope.LOGIN_USER.phoneNum}">

                <label for="messageText">Subject</label>
                <textarea id="messageText" name="messageText" placeholder="Write something.." required="" style="height:200px"></textarea>
                <p class="error">${sessionScope.ERROR_MESSAGE}</p>
                <input type="submit" name="action" value="Send Feedback"/>


                <c:if test="${sessionScope.SENT_FEEDBACK eq 'Sent'}">

                    <!-- Modal -->

                    <div id="popUpModal" class="modal fade" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Send feedback</h4>
                                </div>
                                <div class="modal-body">
                                    <p class="center">:> DONE <:</p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>

                        </div>
                    </div>
                    <script>$(document).ready(function () {
                            $('#popUpModal').modal('show');
                        });
                    </script>
                    <%                            session.setAttribute("SENT_FEEDBACK", "");
                    %>
                </c:if>
            </form>
        </div>


        <%@include file="footer.jsp" %>
    </body>
</html>
