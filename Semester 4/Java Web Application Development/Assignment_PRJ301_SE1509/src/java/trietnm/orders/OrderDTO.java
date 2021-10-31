/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.orders;

import java.sql.SQLException;
import java.util.Date;

/**
 *
 * @author triet
 */
public class OrderDTO {
    private String orderID;
    private String userID;
    private String email;
    private String address;
    private String phoneNum;
    private double totalMoney;
    private String orderDate;
    private String statusID;
    private String paymentStatus;

    public OrderDTO() {
    }

    public OrderDTO(String orderID, String userID, String email, String address, String phoneNum, double totalMoney, String orderDate, String statusID, String paymentStatus) {
        this.orderID = orderID;
        this.userID = userID;
        this.email = email;
        this.address = address;
        this.phoneNum = phoneNum;
        this.totalMoney = totalMoney;
        this.orderDate = orderDate;
        this.statusID = statusID;
        this.paymentStatus = paymentStatus;
    }

    public String getOrderID() {
        return orderID;
    }

    public void setOrderID(String orderID) {
        this.orderID = orderID;
    }

    public String getUserID() {
        return userID;
    }

    public void setUserID(String userID) {
        this.userID = userID;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhoneNum() {
        return phoneNum;
    }

    public void setPhoneNum(String phoneNum) {
        this.phoneNum = phoneNum;
    }

    public double getTotalMoney() {
        return totalMoney;
    }

    public void setTotalMoney(double totalMoney) {
        this.totalMoney = totalMoney;
    }

    public String getOrderDate() {
        return orderDate;
    }

    public void setOrderDate(String orderDate) {
        this.orderDate = orderDate;
    }

    public String getStatusID() {
        return statusID;
    }

    public void setStatusID(String statusID) {
        this.statusID = statusID;
    }

    public String getPaymentStatus() {
        return paymentStatus;
    }

    public void setPaymentStatus(String paymentStatus) {
        this.paymentStatus = paymentStatus;
    }

    public String getStatusName() throws SQLException {
        OrderDAO dao =new OrderDAO();
        return dao.getStatusName(this.statusID);
    }
}
