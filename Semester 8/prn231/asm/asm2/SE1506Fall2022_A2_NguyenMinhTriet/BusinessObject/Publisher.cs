using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PubId { get; set; }

        [Required]
        [MaxLength(255)]
        public String PublisherName { get; set; }

        [Required]
        [MaxLength(255)]
        public String City { get; set; }

        [Required]
        [MaxLength(255)]
        public String State { get; set; }

        [Required]
        [MaxLength(255)]
        public String Country { get; set; }

        public Publisher()
        {

        }
    }
}
