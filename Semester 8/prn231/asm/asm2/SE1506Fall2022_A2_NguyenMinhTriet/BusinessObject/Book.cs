using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [MaxLength(255)]
        public String Title { get; set; }

        [Required]
        [MaxLength(50)]
        public String Type { get; set; }

        [Required]
        // Foreign key   
        [Display(Name = "Publisher")]
        public virtual int PubId { get; set; }

        [ForeignKey("PubId")]
        public virtual Publisher Publisher { get; set; }

        [Required]
        public decimal Price { get; set; }


        [Required]
        public decimal Advanced { get; set; }

        [Required]
        public int Royalty { get; set; }

        [Required]
        public decimal YtdSales { get; set; }

        [Required]
        [MaxLength(500)]
        public String Notes { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        public ICollection<Author> Authors { get; set; }
        public List<BookAuthor> AuthorsOfThis { get; set; }
        public Book() { }
    }
}
