using BusinessObject.Models;

namespace Utils.Authentication
{
    public class LoginUser : User
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public LoginUser(User user, string accessToken, string refreshToken)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DisplayName = user.DisplayName;
            Email = user.Email;
            Role = user.Role;
            Description = user.Description;
            Avatar = user.Avatar;
            Address = user.Address;
            PhoneNumber = user.PhoneNumber;
            HiddenData = user.HiddenData;
            AccessToken = accessToken;
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
            DeletedAt = user.DeletedAt;
            RefreshToken = refreshToken;
        }

        public LoginUser()
        {

        }
    }
}
