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
import javax.mail.MessagingException;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.AddressException;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author triet
 */
public class ContactController extends HttpServlet {

    private static final String SUCCESS = "contact.jsp";
    private static final String ERROR = "contact.jsp";

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        HttpSession session = request.getSession();
        session.setAttribute("ERROR_MESSAGE", "");
        session.setAttribute("SENT_FEEDBACK", "");
        String url = ERROR;
        try {
            String fullName = request.getParameter("fullName");
            String phoneNum = request.getParameter("phoneNum");
            String to = request.getParameter("email");
            String from = "adtdlib@gmail.com";
            String messageText = request.getParameter("messageText");
            String subject = "Auto-reply mail from TD Library";

            if (!to.matches("^(?=.{1,64}@)[A-Za-z0-9_-]+(\\.[A-Za-z0-9_-]+)*@[^-][A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z]{2,})$")) {
                session.setAttribute("ERROR_MESSAGE", "Invalid Email!!!");
            } else if (fullName.length() > 50 || fullName.length() < 10 || !fullName.matches("^[a-zA-Z ]+(-[a-zA-Z ]+)*$")) {
                session.setAttribute("ERROR_MESSAGE", "FullName must contain 10 to 50 characters and english alphabet!");
            } else if (messageText.length() > 500 || messageText.length() < 10 || !messageText.matches("^[a-zA-Z ]+(-[a-zA-Z ]+)*$")) {
                session.setAttribute("ERROR_MESSAGE", "Message must contain 10 to 500 characters and english alphabet!");
            } else {

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
                msg.setText("Thank you for contacting us. Our team will try our best to give reply asap! See you soon!");

                // note for ourself
                Message msgSelf = new MimeMessage(sessionMail);
                msgSelf.setFrom(new InternetAddress(from));
                InternetAddress[] toSelf = {new InternetAddress(from)};
                msgSelf.setRecipients(Message.RecipientType.TO, toSelf);
                msgSelf.setSubject("From User " + fullName);
                msgSelf.setText(fullName + " - " + to + " - " + phoneNum + "\n" + messageText);

                Thread thread = new Thread() {
                    public void run() {
                        try {
                            Transport.send(msg);
                            Transport.send(msgSelf);
                        } catch (Exception ex) {
                            log("Error at ConfirmOrderController when sending email: " + ex.toString());
                        }
                    }
                };
                thread.start();

                url = SUCCESS;
                session.setAttribute("SENT_FEEDBACK", "Sent");
            }
        } catch (Exception e) {
            log("Error at ContactController: " + e.toString());
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
