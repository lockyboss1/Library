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
        [Range(1, 2020)]
        public int PageCount { get; set; }

        [Required]
        [Range(1, 2020)]
        public int Year { get; set; }

        public bool Read { get; set; }
    }
}
