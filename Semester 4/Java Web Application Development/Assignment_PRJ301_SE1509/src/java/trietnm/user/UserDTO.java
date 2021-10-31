/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.user;

import java.sql.SQLException;

/**
 *
 * @author triet
 */
public class UserDTO {

    private String userID;
    private String fullName;
    private String email;
    private String address;
    private boolean gender;
    private String phoneNum;
    private String password;
    private String roleID;
    private String statusID;

    public UserDTO() {
    }

    public UserDTO(String userID, String fullName, String email, String address, boolean gender, String phoneNum, String password, String roleID, String statusID) {
        this.userID = userID;
        this.fullName = fullName;
        this.email = email;
        this.address = address;
        this.gender = gender;
        this.phoneNum = phoneNum;
        this.password = password;
        this.roleID = roleID;
        this.statusID = statusID;
    }

    public String getUserID() {
        return userID;
    }

    public void setUserID(String userID) {
        this.userID = userID;
    }

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
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

    public boolean isGender() {
        return gender;
    }

    public void setGender(boolean gender) {
        this.gender = gender;
    }

    public String getPhoneNum() {
        return phoneNum;
    }

    public void setPhoneNum(String phoneNum) {
        this.phoneNum = phoneNum;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getRoleID() {
        return roleID;
    }

    public void setRoleID(String roleID) {
        this.roleID = roleID;
    }

    public String getStatusID() {
        return statusID;
    }

    public void setStatusID(String statusID) {
        this.statusID = statusID;
    }

    public String getStatusName() throws SQLException {
        UserDAO dao =new UserDAO();
        return dao.getStatusName(this.statusID);
    }


}
