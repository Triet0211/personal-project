/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.controllers;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import trietnm.orders.OrderDAO;
import trietnm.orders.OrderDetail;
import trietnm.products.ProductDAO;
import trietnm.products.ProductDTO;

/**
 *
 * @author triet
 */
public class CancelController extends HttpServlet {

    private final static String SUCCESS="ViewHistoryController";
    private final static String ERROR="error.jsp";
    
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        String url=ERROR;
        try{
            String orderID=request.getParameter("orderID");
            OrderDAO daoOrder = new OrderDAO();
            ProductDAO daoProduct = new ProductDAO();
            List<OrderDetail> listDetail = daoOrder.getListDetail(orderID);
            for(OrderDetail detail : listDetail){
                String productID= detail.getProductID();
                ProductDTO productInStore = daoProduct.getProductById(productID);
                daoOrder.increaseQuantityInStore(detail,productInStore);
            }
            daoOrder.updateOrderStatus(orderID, "CAN");
            daoOrder.updateOrderPaymentStatus(orderID, "Order canceled");
            url=SUCCESS;
        }catch(Exception e){
            log("Error at CancelController: " + e.toString());
        }finally {
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
