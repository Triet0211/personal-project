<%-- 
    Document   : changePwd
    Created on : Jun 25, 2021, 2:42:17 PM
    Author     : triet
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <title>Change Password</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/loginStyle.css" rel="stylesheet">
    </head>
    <body>
        <div class="login-form align-middle">
            <form action="ChangePasswordController" method="post">
                <h2 class="text-center">Change Password</h2>       
                <div class="form-group">
                    <input type="text" class="form-control" placeholder="Username" name="userID" required="" value="${sessionScope.LOGIN_USER.userID}">
                </div>
                <div class="form-group">
                    <input type="password" class="form-control" placeholder="Old Password" name="oldPassword" required="">
                </div>
                <div class="form-group">
                    <input type="password" class="form-control" placeholder="New Password" name="newPassword" required="">
                </div>
                <div class="form-group">
                    <input type="password" class="form-control" placeholder="Confirm New Password" name="confirmNewPassword" required="">
                </div>
                <div class="form-group">
                    <button type="submit" class="btn btn-primary btn-block">Confirm</button>
                </div>      
            </form>
        </div>
    </body>
</html>

