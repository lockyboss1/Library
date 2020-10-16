using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public int Year { get; set; }
        public bool Read { get; set; }
    }
}
