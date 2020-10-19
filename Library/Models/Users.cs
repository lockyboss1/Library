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
        //[RegularExpression("^[ISBN]{4}[ ]{0,1}[0-9]{1}[-]{1}[0-9]{3}[-]{1}[0-9]{5}[-]{1}[0-9]{0,1}$", ErrorMessage = "Invalid ISBN Number")]
        public string ISBN { get; set; }

        public bool Read { get; set; }
    }
}
