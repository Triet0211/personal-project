/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.products;

import java.sql.SQLException;

/**
 *
 * @author triet
 */
public class ProductDTO {

    private String productID;
    private String productName;
    private String description;
    private int quantity;
    private String categoryID;
    private double price;
    private String statusID;
    private String image;

    public ProductDTO() {
    }

    public ProductDTO(String productID, String productName, String description, int quantity, String categoryID, double price, String statusID, String image) {
        this.productID = productID;
        this.productName = productName;
        this.description = description;
        this.quantity = quantity;
        this.categoryID = categoryID;
        this.price = price;
        this.statusID = statusID;
        this.image = image;
    }

    public String getProductID() {
        return productID;
    }

    public void setProductID(String productID) {
        this.productID = productID;
    }

    public String getProductName() {
        return productName;
    }

    public void setProductName(String productName) {
        this.productName = productName;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public String getCategoryID() {
        return categoryID;
    }

    public void setCategoryID(String categoryID) {
        this.categoryID = categoryID;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public String getStatusID() {
        return statusID;
    }

    public void setStatusID(String statusID) {
        this.statusID = statusID;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public String getCategoryName() throws SQLException {
        ProductDAO dao =new ProductDAO();
        return dao.getCategoryName(this.categoryID);
    }
}
