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

/**
 *
 * @author triet
 */
public class MainController extends HttpServlet {

    private final String ERROR = "error.jsp";
    private final String LOGIN = "LoginController";
    private final String LOGOUT = "LogoutController";
    private final String SEARCH_USER = "SearchUserController";
    private final String DEACTIVATE_USER = "DeactivateUserController";
    private final String UPDATE_USER_PAGE = "updateUser.jsp";
    private final String CONFIRM_UPDATE_USER = "UpdateUserController";
    private final String VIEW_INFO = "viewInfo.jsp";
    private final String CREATE_USER = "CreateUserController";
    private final String CHANGE_PASSWORD = "changePwd.jsp";
    private final String SEARCH_BOOK = "SearchBookController";
    private final String VIEW_BOOK = "ViewBookController";
    private final String ADD_TO_CART = "AddToCartController";
    private final String VIEW_CART = "viewCart.jsp";
    private final String UPDATE_CART = "UpdateCartController";
    private final String REMOVE_CART = "RemoveCartController";
    private final String CHECK_OUT = "checkOut.jsp";
    private final String CONFIRM_ORDER = "ConfirmOrderController";
    private final String CONTACT = "ContactController";
    private final String HISTORY = "ViewHistoryController";
    private final String DETAIL = "ViewDetailController";
    private final String CANCEL = "CancelController";

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        String url = ERROR;
        try {
            String action = request.getParameter("action");
            if ("Login".equals(action)) {
                url = LOGIN;
            } else if ("Logout".equals(action)) {
                url = LOGOUT;
            } else if ("Search User".equals(action)) {
                url = SEARCH_USER;
            } else if ("Deactivate User".equals(action)) {
                url = DEACTIVATE_USER;
            } else if ("Update User".equals(action)) {
                url = UPDATE_USER_PAGE;
            } else if ("Confirm Update User".equals(action)) {
                url = CONFIRM_UPDATE_USER;
            } else if ("View Information".equals(action)) {
                url = VIEW_INFO;
            } else if ("Create User".equals(action)) {
                url = CREATE_USER;
            } else if ("Change Password".equals(action)) {
                url = CHANGE_PASSWORD;
            } else if ("Search".equals(action)) {
                url = SEARCH_BOOK;
            } else if ("View Book".equals(action)) {
                url = VIEW_BOOK;
            } else if ("Add to Cart".equals(action)) {
                url = ADD_TO_CART;
            } else if ("View Cart".equals(action)) {
                url = VIEW_CART;
            } else if ("Modify".equals(action)) {
                url = UPDATE_CART;
            } else if ("Remove".equals(action)) {
                url = REMOVE_CART;
            } else if ("Check Out".equals(action)) {
                url = CHECK_OUT;
            } else if ("Confirm Order".equals(action)) {
                url = CONFIRM_ORDER;
            } else if ("Send Feedback".equals(action)) {
                url = CONTACT;
            } else if ("View History Purchase".equals(action)) {
                url = HISTORY;
            } else if ("Detail".equals(action)) {
                url = DETAIL;
            } else if ("Cancel".equals(action)) {
                url = CANCEL;
            } else {
                HttpSession session = request.getSession();
                session.setAttribute("ERROR_MESSAGE", "Function is not available!");
            }
        } catch (Exception e) {
            log("Error at MainController: " + e.toString());
        } finally {
            request.getRequestDispatcher(url).forward(request, response);
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
