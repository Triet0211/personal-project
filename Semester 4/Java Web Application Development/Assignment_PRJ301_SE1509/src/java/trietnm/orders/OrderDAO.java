/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.orders;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import sample.utils.DBUtils;
import trietnm.products.ProductDTO;
import trietnm.shopping.Product;

/**
 *
 * @author triet
 */
public class OrderDAO {

    public boolean insertNewOrder(OrderDTO order) throws SQLException {
        boolean check = false;
        Connection conn = null;
        PreparedStatement stm = null;
         ResultSet rs = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = "INSERT INTO tblOrders(orderID, userID, email, address, phone, totalMoney, orderDate, statusID, paymentStatus) "
                        + " VALUES(default,?,?,?,?,?,CURRENT_TIMESTAMP,?,?)";
                stm = conn.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
                
                stm.setString(1, order.getUserID());
                stm.setString(2, order.getEmail());
                stm.setString(3, order.getAddress());
                stm.setString(4, order.getPhoneNum());
                stm.setDouble(5, order.getTotalMoney());
                stm.setString(6, order.getStatusID());
                stm.setString(7, order.getPaymentStatus());
                check = stm.executeUpdate() > 0;
                rs = stm.getGeneratedKeys();
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
        return check;

    }

    public boolean insertNewOrderDetail(OrderDetail detail) throws SQLException {
        boolean check = false;
        Connection conn = null;
        PreparedStatement stm = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = "INSERT INTO tblOrderDetail(orderID, productID, detailQuantity, price) "
                        + " VALUES(convert(uniqueidentifier, ?),?,?,?)";
                stm = conn.prepareStatement(sql);
                stm.setString(1, detail.getOrderID());
                stm.setString(2, detail.getProductID());
                stm.setInt(3, detail.getDetailQuantity());
                stm.setDouble(4, detail.getPrice());
                check = stm.executeUpdate() > 0;
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
        return check;

    }

    public List<OrderDetail> getListDetail(String orderID) throws SQLException {
        List<OrderDetail> list = new ArrayList<>();
        Connection conn = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = "SELECT productID, detailQuantity, price"
                        + " FROM tblOrderDetail"
                        + " WHERE orderID=?";
                stm = conn.prepareStatement(sql);
                stm.setString(1, orderID);
                rs = stm.executeQuery();
                while (rs.next()) {
                    String productID = rs.getString("productID");
                    int detailQuantity = rs.getInt("detailQuantity");
                    double price = rs.getDouble("price");
                    list.add(new OrderDetail(orderID, productID, detailQuantity, price));
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

    public List<OrderDTO> getListOrderByUserID(String userID) throws SQLException {
        List<OrderDTO> list = new ArrayList<>();
        Connection conn = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = "SELECT orderID, userID, email, address, phone, totalMoney, orderDate, statusID, paymentStatus "
                        + " FROM tblOrders"
                        + " WHERE userID=?";
                stm = conn.prepareStatement(sql);
                stm.setString(1, userID);
                rs = stm.executeQuery();
                while (rs.next()) {
                    String orderID = rs.getString("orderID");
                    String email = rs.getString("email");
                    String address = rs.getString("address");
                    String phone = rs.getString("phone");
                    double totalMoney = rs.getDouble("totalMoney");
                    String orderDate = rs.getTimestamp("orderDate").toString();
                    String statusID = rs.getString("statusID");
                    String paymentStatus = rs.getString("paymentStatus");
                    list.add( new OrderDTO(orderID, userID, email, address, phone, totalMoney, orderDate, statusID, paymentStatus));
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

    public String getStatusName(String statusID) throws SQLException {
        String statusName = null;
        Connection conn = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = "SELECT statusID, statusName "
                        + " FROM tblStatus"
                        + " WHERE statusID=?";
                stm = conn.prepareStatement(sql);
                stm.setString(1, statusID);
                rs = stm.executeQuery();
                if (rs.next()) {
                    statusName = rs.getString("statusName");
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
        return statusName;
    }
    
    public boolean decreaseQuantityInStore(Product productInCart, ProductDTO productInStore) throws SQLException {
        boolean check = false;
        Connection conn = null;
        PreparedStatement stm = null;
        try {
            conn = DBUtils.getConnection();
            if(conn!=null){
                int newQuantity = productInStore.getQuantity() -  productInCart.getQuantity() ;
                String sql = "UPDATE tblProducts "
                        + " SET quantity=? "
                        + " WHERE productID=?";
                stm = conn.prepareStatement(sql);
                stm.setInt(1, newQuantity);
                stm.setString(2, productInStore.getProductID());
                check = stm.executeUpdate() > 0;
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
        return check;
    }
    
    public boolean checkQuantity(Product productInCart, ProductDTO productInStore) {
         boolean check = false;
         if(productInCart.getQuantity() <= productInStore.getQuantity()){
                check=true;
            }
         return check;
    }
    
    public String getOrderIDInProgress(String userID) throws SQLException {
        String orderID = null;
        Connection conn = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = "SELECT orderID "
                        + " FROM tblOrders"
                        + " WHERE statusID='PRO' AND userID=?";
                stm = conn.prepareStatement(sql);
                stm.setString(1, userID);
                rs = stm.executeQuery();
                if (rs.next()) {
                    orderID=rs.getString("orderID");
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
        return orderID;
    }
    
    public boolean updateOrderStatus(String productID, String statusID) throws SQLException {
        boolean check = false;
        Connection conn = null;
        PreparedStatement stm = null;
        try {
            conn = DBUtils.getConnection();
            if(conn!=null){
                String sql = "UPDATE tblOrders "
                        + " SET statusID=? "
                        + " WHERE orderID=?";
                stm = conn.prepareStatement(sql);
                stm.setString(1,statusID);
                stm.setString(2, productID);
                check = stm.executeUpdate() > 0;
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
        return check;
    }
    
    public boolean updateOrderPaymentStatus(String productID, String paymentStatus) throws SQLException {
        boolean check = false;
        Connection conn = null;
        PreparedStatement stm = null;
        try {
            conn = DBUtils.getConnection();
            if(conn!=null){
                String sql = "UPDATE tblOrders "
                        + " SET paymentStatus=? "
                        + " WHERE orderID=?";
                stm = conn.prepareStatement(sql);
                stm.setString(1,paymentStatus);
                stm.setString(2, productID);
                check = stm.executeUpdate() > 0;
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
        return check;
    }
    
    public boolean increaseQuantityInStore(OrderDetail detail, ProductDTO productInStore) throws SQLException {
        boolean check = false;
        Connection conn = null;
        PreparedStatement stm = null;
        try {
            conn = DBUtils.getConnection();
            if(conn!=null){
                int newQuantity = productInStore.getQuantity() +  detail.getDetailQuantity() ;
                String sql = "UPDATE tblProducts "
                        + " SET quantity=? "
                        + " WHERE productID=?";
                stm = conn.prepareStatement(sql);
                stm.setInt(1, newQuantity);
                stm.setString(2, productInStore.getProductID());
                check = stm.executeUpdate() > 0;
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
        return check;
    }
    
    public boolean isHavingProgressingOrder(String userID) throws SQLException{
        boolean check = false;
        Connection conn = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            conn = DBUtils.getConnection();
            if (conn != null) {
                String sql = "SELECT orderID "
                        + " FROM tblOrders"
                        + " WHERE statusID='PRO' AND userID=?";
                stm = conn.prepareStatement(sql);
                stm.setString(1, userID);
                rs = stm.executeQuery();
                if (rs.next()) {
                    check = true;
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
        return check;
        
    }
    
}
