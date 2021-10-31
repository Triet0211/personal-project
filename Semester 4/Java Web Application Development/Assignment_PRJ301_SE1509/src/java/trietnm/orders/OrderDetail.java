/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.orders;

import java.sql.SQLException;
import trietnm.products.ProductDAO;
import trietnm.products.ProductDTO;

/**
 *
 * @author triet
 */
public class OrderDetail {
    private String orderID;
    private String productID;
    private int detailQuantity;
    private double price;

    public OrderDetail() {
    }

    public OrderDetail(String orderID, String productID, int detailQuantity, double price) {
        this.orderID = orderID;
        this.productID = productID;
        this.detailQuantity = detailQuantity;
        this.price = price;
    }

    public String getOrderID() {
        return orderID;
    }

    public void setOrderID(String orderID) {
        this.orderID = orderID;
    }

    public String getProductID() {
        return productID;
    }

    public void setProductID(String productID) {
        this.productID = productID;
    }

    public int getDetailQuantity() {
        return detailQuantity;
    }

    public void setDetailQuantity(int detailQuantity) {
        this.detailQuantity = detailQuantity;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }
    
    public String getProductName() throws SQLException{
        ProductDAO dao = new ProductDAO();
        ProductDTO productInfo = dao.getProductById(this.productID);
        return productInfo.getProductName();
    }
    
    public double getPriceEach() throws SQLException{
        ProductDAO dao = new ProductDAO();
        ProductDTO productInfo = dao.getProductById(this.productID);
        return productInfo.getPrice();
    }
}
