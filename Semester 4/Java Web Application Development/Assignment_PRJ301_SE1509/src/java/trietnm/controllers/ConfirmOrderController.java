/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.controllers;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Properties;
import javax.mail.Authenticator;
import javax.mail.Message;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import trietnm.orders.OrderDAO;
import trietnm.orders.OrderDTO;
import trietnm.orders.OrderDetail;
import trietnm.products.ProductDAO;
import trietnm.shopping.Cart;
import trietnm.shopping.Product;
import trietnm.user.UserDTO;

/**
 *
 * @author triet
 */
public class ConfirmOrderController extends HttpServlet {

    private static final String SUCCESS = "success.html";
    private static final String ERROR = "error.jsp";

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        String url = ERROR;
        try {
            HttpSession session = request.getSession();
            UserDTO user = (UserDTO) session.getAttribute("LOGIN_USER");
            Cart cart = (Cart) session.getAttribute("CART");
            String paymentMethod = request.getParameter("paymentMethod");
            String email = request.getParameter("email");
            String address = request.getParameter("address");
            String phoneNum = request.getParameter("phoneNum");
            double totalMoney = Double.parseDouble(request.getParameter("total"));
            if (user == null || !user.getRoleID().equals("US") || !user.getStatusID().equals("AC")) {
                session.setAttribute("ERROR_MESSAGE", "Invalid User!");
            } else if (cart == null || cart.isEmpty()) {
                session.setAttribute("ERROR_MESSAGE", "No product is found in cart!");
            } else if (!email.matches("^(?=.{1,64}@)[A-Za-z0-9_-]+(\\.[A-Za-z0-9_-]+)*@[^-][A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z]{2,})$")) {
                session.setAttribute("ERROR_MESSAGE", "Invalid Email!");
            } else if (phoneNum.length() != 10 || !phoneNum.matches("[0-9]{10}")) {
                session.setAttribute("ERROR_MESSAGE", "Invalid PhoneNumber!");
            } else if (paymentMethod == null || paymentMethod.isEmpty()) {
                session.setAttribute("ERROR_MESSAGE", "Please choose payment method!");
            } else {
                boolean checkQuantity = false;
                OrderDAO daoOrder = new OrderDAO();
                ProductDAO daoProduct = new ProductDAO();
                for (Product productInCart : cart.getCart().values()) {
                    checkQuantity = daoOrder.checkQuantity(productInCart, daoProduct.getProductById(productInCart.getProductID()));
                    if (!checkQuantity) {
                        session.setAttribute("ERROR_MESSAGE", "Quantity of " + productInCart.getProductName() + " exceeds the number in store!!! Please check your cart!!!");
                        break;
                    }
                }
                if (checkQuantity) {

                    if ("afterArrival".equals(paymentMethod)) {
                        String userID = user.getUserID();
                        boolean checkProgress = daoOrder.isHavingProgressingOrder(userID);
                        if (!checkProgress) {
                            String statusID = "PRO";
                            String paymentStatus = "Waiting for purchasing";
                            OrderDTO order = new OrderDTO("", userID, email, address, phoneNum, totalMoney, address, statusID, paymentStatus);
                            daoOrder.insertNewOrder(order);
                            String orderID = daoOrder.getOrderIDInProgress(userID);
                            for (Product productInCart : cart.getCart().values()) {
                                String productID = productInCart.getProductID();
                                int quantity = productInCart.getQuantity();
                                double price = quantity * daoProduct.getProductById(productID).getPrice();
                                daoOrder.decreaseQuantityInStore(productInCart, daoProduct.getProductById(productInCart.getProductID()));
                                OrderDetail detail = new OrderDetail(orderID, productID, quantity, price);
                                daoOrder.insertNewOrderDetail(detail);
                            }

                            daoOrder.updateOrderStatus(orderID, "SHIP");
                            session.setAttribute("CART", null);
                            Thread thread = new Thread() {
                                public void run() {
                                    try {
                                        String to = email;
                                        String from = "adtdlib@gmail.com";
                                        String messageText = "If you have any problems about our service or your product's status, feel free to call us on HOTLINE 0123456789 or reply this email!\nBest regard!";
                                        String subject = "Thank you for buying book from Thu Duc Library! ";
                                        Properties properties = new Properties();
                                        properties.put("mail.smtp.host", "smtp.gmail.com");
                                        properties.put("mail.smtp.port", "587");
                                        properties.put("mail.smtp.auth", "true");
                                        properties.put("mail.smtp.starttls.enable", "true");
                                        properties.put("mail.smtp.ssl.trust", "smtp.gmail.com");

                                        // creates a new session with an authenticator
                                        Authenticator auth = new Authenticator() {
                                            public PasswordAuthentication getPasswordAuthentication() {
                                                return new PasswordAuthentication(from, "thuvienthuduc");
                                            }
                                        };

                                        Session sessionMail = Session.getInstance(properties, auth);

                                        // creates a new e-mail message
                                        Message msg = new MimeMessage(sessionMail);

                                        msg.setFrom(new InternetAddress(from));
                                        InternetAddress[] toAddresses = {new InternetAddress(to)};
                                        msg.setRecipients(Message.RecipientType.TO, toAddresses);
                                        msg.setSubject(subject);
                                        msg.setText(messageText);
                                        Transport.send(msg);
                                    } catch (Exception ex) {
                                        log("Error at ConfirmOrderController when sending email: " + ex.toString());
                                    }
                                }
                            };
                            thread.start();
                            url = SUCCESS;
                        } else{
                            session.setAttribute("ERROR_MESSAGE", "You are having 1 order in progress! Please wait few minutes before you try again! Sorry for the inconvenience!");
                        }
                    } else if ("VNPAY".equals(paymentMethod)) {
                        session.setAttribute("ERROR_MESSAGE", "This payment method is in maintainance! Sorry for the inconvenience!");
                    }
                } else {

                }

            }

        } catch (Exception e) {
            log("Error at ConfirmOrderController: " + e.toString());
        } finally {
            response.sendRedirect(url);
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
