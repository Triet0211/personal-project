using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public String EmailAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public String Password { get; set; }

        [Required]
        [MaxLength(255)]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public String MiddleName { get; set; }


        [Required]
        [MaxLength(255)]
        public String LastName { get; set; }

        [Required]
        // Foreign key   
        [Display(Name = "Role")]
        public virtual int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [Required]
        // Foreign key   
        [Display(Name = "Publisher")]
        public virtual int PubId { get; set; }

        [ForeignKey("PubId")]
        public virtual Publisher Publisher { get; set; }

        [Required]
        public DateTime HiredDate { get; set; }

        public User() { }
    }
}
