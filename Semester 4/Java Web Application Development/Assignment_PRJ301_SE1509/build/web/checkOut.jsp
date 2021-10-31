<%-- 
    Document   : checkOut
    Created on : Jun 29, 2021, 8:42:50 PM
    Author     : triet
--%>

<%@page import="trietnm.shopping.Cart"%>
<%@page import="java.text.DecimalFormat"%>
<%@page import="trietnm.shopping.Product"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Check Out</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/style.css" rel="stylesheet">
        <link href="css/styleCheckOut.css" rel="stylesheet">
    </head>
    <body>
    <c:if test = "${sessionScope.LOGIN_USER == null ||  'US' ne sessionScope.LOGIN_USER.roleID }">
        <c:redirect url="login.html"></c:redirect>
    </c:if>    
    <div class="form-check">
        <form action="MainController">
            <h2 class="center">Xác nhận thông tin</h2>
            <label for="fname">Tên</label>
            <input type="text" id="fname" name="fullName" placeholder="Your name..." required="" value="${sessionScope.LOGIN_USER.fullName}">

            <label for="email">Email</label>
            <input type="text" id="email" name="email" placeholder="Your email..." required="" value="${sessionScope.LOGIN_USER.email}">

            <label for="phoneNum">Số điện thoại liên hệ</label>
            <input type="text" id="phoneNum" name="phoneNum" placeholder="Your phone number..." required="" value="${sessionScope.LOGIN_USER.phoneNum}">

            <label for="address">Địa chỉ</label>
            <input type="text" id="address" name="address" placeholder="Your address..." required="" value="${sessionScope.LOGIN_USER.address}">

              <input type="radio" id="afterArrival" name="paymentMethod" value="afterArrival">
              <label for="afterArrival"><i class="bi bi-cash"></i>Thanh toán khi nhận hàng</label><br>
              <input type="radio" id="VNPAY" name="paymentMethod" value="VNPAY">
              <label for="VNPAY">Thanh toán qua VNPAY</label><br>

            <%
                DecimalFormat decimalFormat = new DecimalFormat("###,###");
                double total = 0;
                Cart cart = (Cart) session.getAttribute("CART");
                if (cart == null) {

            %>
            Chưa có sản phẩm trong giỏ hàng...
            <%} else if (cart.isEmpty()) {
            %>
            Chưa có sản phẩm trong giỏ hàng...
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
                        </tr>
                    </thead>
                    <tbody>
                        <%                        
                            int count = 1;
                            for (Product book : cart.getCart().values()) {
                                total += book.getQuantity() * book.getPrice();
                        %>
                        <tr>
                            <td><%= count++%></td>
                            <td><%= book.getProductName()%></td>
                            <td>
                                <%= book.getQuantity()%>
                            </td>
                            <td><%= decimalFormat.format((int) book.getPrice())%></td>
                            <td><%= decimalFormat.format((int) book.getQuantity() * book.getPrice())%></td>
                        </tr>
                        <%}
                        %>

                    </tbody>
                </table>
            </div>
            <h4>Total: <%= decimalFormat.format((int) total)%> VND </h4>
            <%
                }
            %>
            <input type="submit" name="action" value="Confirm Order">
            <input type="submit" name="action" value="View Cart">
            <input type="hidden" name="total" value="<%= total  %>"/>
        </form>
    </div>
</body>
</html>
