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
import trietnm.products.ProductDAO;
import trietnm.products.ProductDTO;
import trietnm.shopping.Cart;
import trietnm.shopping.Product;
import trietnm.user.UserDTO;

/**
 *
 * @author triet
 */
public class AddToCartController extends HttpServlet {

    private static final String SUCCESS = "viewBook.jsp";
    private static final String ERROR = "error.jsp";
    private static final String LOGIN = "login.html";

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        String url = ERROR;
        try {
            HttpSession session = request.getSession();
            UserDTO user = (UserDTO) session.getAttribute("LOGIN_USER");
            if (user == null  || !user.getRoleID().equals("US")) {
                url = LOGIN;
            } else {
                String productID = request.getParameter("productID");
                int quantity = Integer.parseInt(request.getParameter("quantity"));
                
                Product product = new Product(productID, quantity);
                
                ProductDAO dao= new ProductDAO();
                ProductDTO productInfo= dao.getProductById(productID);
                String productName = productInfo.getProductName();
                double price = productInfo.getPrice();

                Cart cart = (Cart) session.getAttribute("CART");
                if (cart == null) {
                    cart = new Cart();
                }
                cart.add(product);
                session.setAttribute("CART", cart);
                url = SUCCESS;
                String message = "Bạn vừa thêm " + quantity + " cuốn " + productName + " thành công!!";
                request.setAttribute("SHOPPING_MESSAGE", message);
                request.setAttribute("CURRENT_PRODUCT",productInfo);
            }
        } catch (Exception e) {
            log("Error at AddToCartController: " + e.toString());
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
