using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class User : BaseEntity
    {
        public User()
        {
            AuthTokens = new HashSet<AuthToken>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string HiddenData { get; set; }
        public virtual ICollection<AuthToken> AuthTokens { get; set; }
    }
}
