<%-- 
    Document   : createUser
    Created on : Jun 20, 2021, 9:53:53 AM
    Author     : triet
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Sign Up Page</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/loginStyle.css" rel="stylesheet">
    </head>
    <body>
        <div class="login-form align-middle">
            <form action="MainController" method="POST">
                <h2 class="text-center">Sign Up</h2>       
                <div class="form-group"><input class="form-control" type="text" name="userID" required="" placeholder="User Name"/>
                    ${requestScope.USER_ERROR.getUserIDError()} </div> 

                <div class="form-group"><input class="form-control" type="text" name="fullName"required="" placeholder="Full Name"accept-charset="utf-8"/>
                    ${requestScope.USER_ERROR.getFullNameError()}</div> 
                <div class="form-group"><input class="form-control" type="text" name="email"required=""placeholder="Email"/>
                    ${requestScope.USER_ERROR.getEmailError()}</div>
                <input type="hidden" name="address" value=""/>
                <div class="form-group"><select class="form-control" name="gender">
                        <option value="TRUE">Nam</option>
                        <option value="FALSE">Nữ</option>
                    </select></div>
                <div class="form-group"><input class="form-control" type="text" name="phoneNum"required="" placeholder="Phone Number"/></div>
                    ${requestScope.USER_ERROR.getPhoneNumError()}
                <div class="form-group"><input class="form-control" type="password" name="password"required="" placeholder="Password"/>
                    ${requestScope.USER_ERROR.getPasswordError()}</div>
                <div class="form-group"><input class="form-control" type="password" name="confirm" required="" placeholder="Confirm Password"/>
                    ${requestScope.USER_ERROR.getConfirmPasswordError()}</div>

                <input type="hidden" name="roleID" value="US"/>
                <input type="hidden" name="statusID" value="AC"/>
                <input class="btn btn-primary btn-block" type="submit" name="action" value="Create User"/>
                <input class="btn btn-primary btn-block" type="reset" vale="Reset"/>
            </form>
        </div>
    </body>
</html>
