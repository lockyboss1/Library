using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13)]
        [RegularExpression(".*[0-9].*", ErrorMessage = "Invalid ISBN-13 digits")]
        public string ISBN { get; set; }

        public bool Read { get; set; }
    }
}
