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
import trietnm.user.UserError;

/**
 *
 * @author triet
 */
public class UpdateUserController extends HttpServlet {

    private static final String ERROR = "updateUser.jsp";
    private static final String SUCCESS = "SearchUserController";
    private static final String LOGOUT = "LogoutController";

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        String url = ERROR;
        try {
            HttpSession session = request.getSession();
            UserDTO loginUser = (UserDTO) session.getAttribute("LOGIN_USER");
            String userID = request.getParameter("userID");

            String fullName = request.getParameter("fullName");
            String email = request.getParameter("email");
            String address = request.getParameter("address");
            String gender = request.getParameter("gender");
            String phoneNum = request.getParameter("phoneNum");
            String roleID = request.getParameter("roleID");
            String statusID = request.getParameter("statusID");
            UserError userError = new UserError("", "", "", "", "", "", "");

            boolean check = true;
            if (fullName.length() > 50 || fullName.length() < 10 || !fullName.matches("^[a-zA-Z ]+(-[a-zA-Z ]+)*$")) {
                userError.setFullNameError("FullName must contain 10 to 50 characters and english alphabet!");
                check = false;
            }

            if (roleID.length() < 2 || (!roleID.equals("US") && !roleID.equals("AD"))) {
                userError.setRoleIDError("Role ID must be AD or US");
                check = false;
            }
            if (phoneNum.length() != 10 || !phoneNum.matches("[0-9]{10}")) {
                userError.setPhoneNumError("Phone Number must contain 10 digits!");
                check = false;
            }
            if (!email.matches("^(?=.{1,64}@)[A-Za-z0-9_-]+(\\.[A-Za-z0-9_-]+)*@[^-][A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z]{2,})$")) {
                userError.setEmailError("Please enter a real email!");
                check = false;
            }
            if (check) {
                UserDAO dao = new UserDAO();
                boolean checkGender = (gender.equals("TRUE")) ? true : false;
                UserDTO user = new UserDTO(userID, fullName, email, address, checkGender, phoneNum, userID, roleID, statusID);
                boolean checkUpdate = dao.updateUser(user);
                if (checkUpdate) {
                    if (userID.equals(loginUser.getUserID())) {
                        url = LOGOUT;
                    } else {
                        url = SUCCESS;
                    }
                }
            } else {
                request.setAttribute("USER_ERROR", userError);
            }

        } catch (Exception e) {
            log("Error at UpdateUserController: " + e.toString());
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
