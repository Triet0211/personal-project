using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRAssignment_SE151127.Models
{
    public class AppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Full name is requried!")]
        public string FullName { get; set; }

        public string? Address { get; set; }

        [Required(ErrorMessage = "Email is requried!")]
        [EmailAddress(ErrorMessage = "Email is not valid!")]
        public string Email { get; set; }

        [RegularExpression(@"^.{6,}$", ErrorMessage = "Minimum 6 characters required")]
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 30 characters!")]
        public string Password { get; set; }
    }
}
