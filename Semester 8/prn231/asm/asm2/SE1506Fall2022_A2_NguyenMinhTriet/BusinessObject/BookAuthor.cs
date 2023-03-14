using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("BookAuthor")]
    public class BookAuthor
    {
        [Required]

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]

        public int AuthorOrder { get; set; }

        [Required]

        public int RoyalityPercentage { get; set; }

    }
}
