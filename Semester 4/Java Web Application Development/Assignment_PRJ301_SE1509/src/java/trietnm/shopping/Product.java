/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.shopping;

import java.sql.SQLException;
import trietnm.products.ProductDAO;
import trietnm.products.ProductDTO;

/**
 *
 * @author triet
 */
public class Product {
    private String productID;
    private int quantity;

    public Product() {
    }

    public Product(String productID, int quantity) {
        this.productID = productID;
        this.quantity = quantity;
    }

    public String getProductID() {
        return productID;
    }

    public void setProductID(String productID) {
        this.productID = productID;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public String getProductName() throws SQLException{
        ProductDAO dao = new ProductDAO();
        ProductDTO productInfo = dao.getProductById(this.productID);
        return productInfo.getProductName();
    }
    
    public double getPrice() throws SQLException{
        ProductDAO dao = new ProductDAO();
        ProductDTO productInfo = dao.getProductById(this.productID);
        return productInfo.getPrice();
    }
    
    public int getMaxQuantity() throws SQLException{
        ProductDAO dao = new ProductDAO();
        ProductDTO productInfo = dao.getProductById(this.productID);
        return productInfo.getQuantity();
    }
}
