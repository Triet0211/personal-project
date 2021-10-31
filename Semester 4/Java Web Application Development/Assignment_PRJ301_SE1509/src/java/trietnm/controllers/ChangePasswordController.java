/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.controllers;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import trietnm.user.UserDAO;
import trietnm.user.UserDTO;

/**
 *
 * @author triet
 */
public class ChangePasswordController extends HttpServlet {

    private static String SUCCESS = "index.jsp";
    private static String ERROR = "error.jsp";

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");

        String url = ERROR;
        try {
            String userID = request.getParameter("userID");
            String oldPassword = request.getParameter("oldPassword");
            UserDAO dao = new UserDAO();
            UserDTO user = dao.checkLogin(userID, oldPassword);
            HttpSession session = request.getSession();
            if (user != null) {
                if (user.getStatusID().equals("DEAC")) {
                    session.setAttribute("ERROR_MESSAGE", "This account was deactivated!");
                } else {
                    String newPassword = request.getParameter("newPassword");
                    String confirmNewPassword = request.getParameter("confirmNewPassword");
                    if (!newPassword.equals(confirmNewPassword)) {
                        session.setAttribute("ERROR_MESSAGE", "2 password must be the same");
                    } else if (newPassword.length() > 20 || newPassword.length() < 5) {
                        session.setAttribute("ERROR_MESSAGE", "New password contain 5 to 20 characters!!!");
                    }else{
                        boolean check = dao.changePassword(user, newPassword);
                        if(check) url= SUCCESS;
                    }

                }

            } else {
                session.setAttribute("ERROR_MESSAGE", "Incorrect UserID or Password!");
            }
        } catch (Exception e) {
            log("Error at ChangePasswordController: " + e.toString());
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
