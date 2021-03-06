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
            <h2>Ch??o m???ng qu?? v??? ???? truy c???p trang th?? vi???n Th??? ?????c</h2>
            <p>T??? l??u th?? vi???n ???? ???????c coi l?? ???kho v??ng??? c???a n???n v??n h??a d??n t???c, l?? m???t b??? ph???n kh??ng th??? thi???u trong v??n h??a h???c ???????ng. Th?? vi???n b??? sung v?? c???p nh???t nh???ng ki???n th???c m???i, nh???ng ph????ng ph??p gi???ng d???y ti??n ti???n l??m cho vi???c h???c t???p v?? gi???ng d???y th??m sinh ?????ng v?? h???p d???n. Th?? vi???n l?? trung t??m th??ng tin ??? nhi???u d???ng kh??c nhau, t???o ??i???u ki???n cho ng?????i s??? d???ng ti???p c???n nhanh ch??ng ?????n tri th???c. ????ng v???y, ?????c s??ch l?? c??ch h???c t???t nh???t v?? kh??ng c?? c??ch gi???i tr?? n??o r??? h??n ?????c s??ch, c??ng kh??ng c?? s??? th?? v??? n??o b???n l??u h??n vi???c ?????c s??ch. ?????c s??ch ngo??i t??c d???ng gi???i tr?? l??nh m???nh c??n gi??p m???i ch??ng ta ho??n thi???n nh??n c??ch c???a ch??nh m??nh. S??ch gi??o d???c cho m???i ch??ng ta bi???t y??u th????ng, qu?? tr???ng, ??o??n k???t v???i m???i ng?????i, bi???t n??i l???i hay, l??m vi???c t???t. V?? s??ch ch??nh l?? c?? h???i ????? ch??ng ta m??? r???ng t???m nh??n v???i th??? gi???i.</p>

            <h3>V??? ch??ng t??i</h3>
            <p>Hi???u ???????c t??m l??, nhu c???u c???a m???i ng?????i mu???n c?? nhi???u c?? h???i ti???n ?????n c??nh c???ng tri th???c, ch??ng t??i ???? x??y d???ng Th?? vi???n Th??? ?????c. V???i trang thi???t b??? hi???n ?????i, c?? s??? v???t ch???t t??n ti???n c??ng v???i v??? tr?? thu???n l???i, ch??ng t??i cam k???t ??em ?????n s??? h??i l??ng tuy???t ?????i cho qu?? kh??ch h??ng!</br>N??i c??c b???n ??ang truy c???p l?? trang web ch??nh th???c c???a th?? vi???n, v?? c??ng l?? n??i qu?? v??? c?? th??? ????ng k?? m?????n s??ch ho??n to??n mi???n ph??.</p>
            <p>H??n th??? n???a, ch??ng t??i c??ng h??? tr??? mua s??ch tr???c ti???p t???i th?? vi???n v?? th??ng qua trang web, v???i hy v???ng t???o ??i???u ki???n thu???n l???i mang nh???ng cu???n s??ch th?? v??? ?????n tay ng?????i d??ng!</p>
            <h4>Th???i gian ho???t ?????ng:</h4>
            <p>T??? th??? 2 ?????n th??? 6: 8h00 - 16h00</br>
                Th??? 7: 9h00 - 12h00 </p>
            <h4>?????a ch???:</h4>
            <p>L?? E2a-7, ???????ng D1, Khu C??ng Ngh??? Cao, Long Th???nh M???, Qu???n 9, Th??nh ph??? H??? Ch?? Minh</p>
            <div class="map">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.605265612516!2d106.80785771487736!3d10.84148986095369!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752731176b07b1%3A0xb752b24b379bae5e!2zVHLGsOG7nW5nIMSQ4bqhaSBo4buNYyBGUFQgVFAuIEhDTQ!5e0!3m2!1svi!2s!4v1624181107313!5m2!1svi!2s" width=90% height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
            </div>
        </div>

        <%@include file="footer.jsp" %>
    </body>
</html>
