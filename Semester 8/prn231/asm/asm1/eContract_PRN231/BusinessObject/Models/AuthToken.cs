using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class AuthToken : BaseEntity
    {
        public string RefreshToken { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
