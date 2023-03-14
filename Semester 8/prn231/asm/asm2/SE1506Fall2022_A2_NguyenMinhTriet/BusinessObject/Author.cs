using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Author")]
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(255)]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public String LastName { get; set; }

        [Required]
        [MaxLength(12)]
        public String Phone { get; set; }

        [Required]
        [MaxLength(255)]
        public String Address { get; set; }
        [Required]
        [MaxLength(255)]
        public String City { get; set; }

        [Required]
        [MaxLength(255)]
        public String State { get; set; }

        [Required]
        [MaxLength(50)]
        public String Zip { get; set; }
        [Required]
        [EmailAddress]
        public String EmailAddress { get; set; }

        public ICollection<Book> Books { get; set; }
        public List<BookAuthor> BooksOfThis { get; set; }

    }
}
