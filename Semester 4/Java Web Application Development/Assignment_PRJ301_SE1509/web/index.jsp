<%-- 
    Document   : index
    Created on : Jun 20, 2021, 9:50:07 AM
    Author     : triet
--%>

<%@page import="trietnm.user.UserDTO"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Thu Duc Library</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="css/style.css" rel="stylesheet">
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

                        <li class="active"> <a href="index.jsp"> <span class="glyphicon glyphicon-home"></span> Home</a> </li>

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

        <div class="content">
            <h2>Chào mừng quý vị đã truy cập trang thư viện Thủ Đức</h2>
            <p>Từ lâu thư viện đã được coi là “kho vàng” của nền văn hóa dân tộc, là một bộ phận không thể thiếu trong văn hóa học đường. Thư viện bổ sung và cập nhật những kiến thức mới, những phương pháp giảng dạy tiên tiến làm cho việc học tập và giảng dạy thêm sinh động và hấp dẫn. Thư viện là trung tâm thông tin ở nhiều dạng khác nhau, tạo điều kiện cho người sử dụng tiếp cận nhanh chóng đến tri thức. Đúng vậy, đọc sách là cách học tốt nhất và không có cách giải trí nào rẻ hơn đọc sách, cũng không có sự thú vị nào bền lâu hơn việc đọc sách. Đọc sách ngoài tác dụng giải trí lành mạnh còn giúp mỗi chúng ta hoàn thiện nhân cách của chính mình. Sách giáo dục cho mỗi chúng ta biết yêu thương, quý trọng, đoàn kết với mọi người, biết nói lời hay, làm việc tốt. Và sách chính là cơ hội để chúng ta mở rộng tầm nhìn với thế giới.</p>

            <h3>Về chúng tôi</h3>
            <p>Hiểu được tâm lý, nhu cầu của mọi người muốn có nhiều cơ hội tiến đến cánh cổng tri thức, chúng tôi đã xây dựng Thư viện Thủ Đức. Với trang thiết bị hiện đại, cơ sở vật chất tân tiến cùng với vị trí thuận lợi, chúng tôi cam kết đem đến sự hài lòng tuyệt đối cho quý khách hàng!</br>Nơi các bạn đang truy cập là trang web chính thức của thư viện, và cũng là nơi quý vị có thể đăng kí mượn sách hoàn toàn miễn phí.</p>
            <p>Hơn thế nữa, chúng tôi cũng hỗ trợ mua sách trực tiếp tại thư viện và thông qua trang web, với hy vọng tạo điều kiện thuận lợi mang những cuốn sách thú vị đến tay người dùng!</p>
            <h4>Thời gian hoạt động:</h4>
            <p>Từ thứ 2 đến thứ 6: 8h00 - 16h00</br>
                Thứ 7: 9h00 - 12h00 </p>
            <h4>Địa chỉ:</h4>
            <p>Lô E2a-7, Đường D1, Khu Công Nghệ Cao, Long Thạnh Mỹ, Quận 9, Thành phố Hồ Chí Minh</p>
            <div class="map">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.605265612516!2d106.80785771487736!3d10.84148986095369!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752731176b07b1%3A0xb752b24b379bae5e!2zVHLGsOG7nW5nIMSQ4bqhaSBo4buNYyBGUFQgVFAuIEhDTQ!5e0!3m2!1svi!2s!4v1624181107313!5m2!1svi!2s" width=90% height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
            </div>
        </div>

        <%@include file="footer.jsp" %>
    </body>
</html>
