/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trietnm.user;

/**
 *
 * @author triet
 */
public class UserError {
    
    private String userIDError;
    private String fullNameError;
    private String emailError;
    private String roleIDError;
    private String passwordError;
    private String confirmPasswordError;
    private String phoneNumError;

    public UserError() {
    }

    public UserError(String userIDError, String fullNameError, String emailError, String roleIDError, String passwordError, String confirmPasswordError, String phoneNumError) {
        this.userIDError = userIDError;
        this.fullNameError = fullNameError;
        this.emailError = emailError;
        this.roleIDError = roleIDError;
        this.passwordError = passwordError;
        this.confirmPasswordError = confirmPasswordError;
        this.phoneNumError = phoneNumError;
    }

    public String getUserIDError() {
        return userIDError;
    }

    public void setUserIDError(String userIDError) {
        this.userIDError = userIDError;
    }

    public String getFullNameError() {
        return fullNameError;
    }

    public void setFullNameError(String fullNameError) {
        this.fullNameError = fullNameError;
    }

    public String getEmailError() {
        return emailError;
    }

    public void setEmailError(String emailError) {
        this.emailError = emailError;
    }

    public String getRoleIDError() {
        return roleIDError;
    }

    public void setRoleIDError(String roleIDError) {
        this.roleIDError = roleIDError;
    }

    public String getPasswordError() {
        return passwordError;
    }

    public void setPasswordError(String passwordError) {
        this.passwordError = passwordError;
    }

    public String getConfirmPasswordError() {
        return confirmPasswordError;
    }

    public void setConfirmPasswordError(String confirmPasswordError) {
        this.confirmPasswordError = confirmPasswordError;
    }

    public String getPhoneNumError() {
        return phoneNumError;
    }

    public void setPhoneNumError(String phoneNumError) {
        this.phoneNumError = phoneNumError;
    }

    
}
