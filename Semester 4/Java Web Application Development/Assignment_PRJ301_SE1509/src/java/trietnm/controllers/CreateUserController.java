/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.controllers;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import trietnm.user.UserDAO;
import trietnm.user.UserDTO;
import trietnm.user.UserError;

/**
 *
 * @author triet
 */
public class CreateUserController extends HttpServlet {

    private static final String ERROR = "createUser.jsp";
    private static final String SUCCESS = "login.html";

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        String url = ERROR;
        UserError userError = new UserError("", "", "", "", "", "", "");
        try {
            String userID = request.getParameter("userID");
            String fullName = request.getParameter("fullName");
            String email = request.getParameter("email");
            String address = request.getParameter("address");
            String gender = request.getParameter("gender");
            String phoneNum = request.getParameter("phoneNum");
            String roleID = request.getParameter("roleID");
            String password = request.getParameter("password");
            String confirm = request.getParameter("confirm");
            String statusID = request.getParameter("statusID");

            boolean check = true;
            if (userID.length() > 20 || userID.length() < 5) {
                userError.setUserIDError("User ID must contain 5 to 20 characters!");
                check = false;
            }
            if (fullName.length() > 50 || fullName.length() < 10 || !fullName.matches("^[a-zA-Z ]+(-[a-zA-Z ]+)*$")) {
                userError.setFullNameError("FullName must contain 10 to 50 characters and english alphabet!");
                check = false;
            }
            if (roleID.length() > 5 || userID.length() < 2) {
                userError.setRoleIDError("Role ID[2,5]!");
                check = false;
            }
            if (password.length() > 20 || password.length() < 5) {
                userError.setPasswordError("Password must contain 5 to 20 characters!");
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
            if (!password.equals(confirm)) {
                userError.setConfirmPasswordError("2 password must be the same!");
                check = false;
            }
            if (check) {
                UserDAO dao = new UserDAO();
                boolean checkGender = (gender.equals("TRUE")) ? true : false;

                UserDTO user = new UserDTO(userID, fullName, email, address, checkGender, phoneNum, password, roleID, statusID);

                boolean checkInsert = dao.insertUserNew(user);

                if (checkInsert) {
                    url = SUCCESS;
                }
            } else {
                request.setAttribute("USER_ERROR", userError);
            }
        } catch (Exception e) {
            log("Error at CreateController: " + e.toString());
            if (e.toString().contains("duplicate")) {
                userError.setUserIDError("This user name has been existed, try another user name!!!");
                request.setAttribute("USER_ERROR", userError);
            }
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
