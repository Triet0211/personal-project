/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.products;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import sample.utils.DBUtils;
import trietnm.user.UserDTO;

/**
 *
 * @author triet
 */
public class ProductDAO {
    
    public List<ProductDTO> getListProduct(String search) throws SQLException {
        List<ProductDTO> list = new ArrayList<>();
        Connection conn = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = "SELECT productID, productName, description, quantity, categoryID, price, statusID, image "
                        + " FROM tblProducts"
                        + " WHERE productName like ?";
                stm = conn.prepareStatement(sql);
                stm.setString(1, "%" + search + "%");
                rs = stm.executeQuery();
                while (rs.next()) {
                    String productID = rs.getString("productID");
                    String productName = rs.getString("productName");
                    String description = rs.getString("description");
                    int quantity = rs.getInt("quantity");
                    String categoryID = rs.getString("categoryID");
                    int price = rs.getInt("price");
                    String statusID = rs.getString("statusID");
                    String image = rs.getString("image");
                    if (statusID.equals("AC")) {
                        list.add(new ProductDTO(productID, productName, description, quantity, categoryID, price, statusID, image));
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (stm != null) {
                stm.close();
            }
            if (conn != null) {
                conn.close();
            }
        }
        return list;
    }
    
    public boolean deactivateProduct(String productID) throws SQLException {
        boolean result = false;
        Connection conn = null;
        PreparedStatement stm = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = " UPDATE tblProducts "
                        + " SET statusID = 'DEAC'"
                        + " WHERE productID=?";
                stm = conn.prepareStatement(sql);
                stm.setString(1, productID);
                result = stm.executeUpdate() > 0 ? true : false;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (stm != null) {
                stm.close();
            }
            if (conn != null) {
                conn.close();
            }
        }
        return result;
    }
    
    public String getCategoryName(String categoryID) throws SQLException {
        String categoryName = null;
        Connection conn = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = "SELECT categoryID, categoryName "
                        + " FROM tblCategories"
                        + " WHERE categoryID=?";
                stm = conn.prepareStatement(sql);
                stm.setString(1, categoryID);
                rs = stm.executeQuery();
                if (rs.next()) {
                    categoryName = rs.getString("categoryName");
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (stm != null) {
                stm.close();
            }
            if (conn != null) {
                conn.close();
            }
        }
        return categoryName;
    }
    
    public ProductDTO getProductById(String productID) throws SQLException {
        ProductDTO product = null;
        Connection conn = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = "SELECT productName, description, quantity, categoryID, price, statusID, image "
                        + " FROM tblProducts"
                        + " WHERE productID=?";
                stm = conn.prepareStatement(sql);
                stm.setString(1, productID);
                rs = stm.executeQuery();
                if (rs.next()) {
                    String productName = rs.getString("productName");
                    String description = rs.getString("description");
                    int quantity = rs.getInt("quantity");
                    String categoryID = rs.getString("categoryID");
                    int price = rs.getInt("price");
                    String statusID = rs.getString("statusID");
                    String image = rs.getString("image");
                    product = new ProductDTO(productID, productName, description, quantity, categoryID, price, statusID, image);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (stm != null) {
                stm.close();
            }
            if (conn != null) {
                conn.close();
            }
        }
        return product;
    }
}
