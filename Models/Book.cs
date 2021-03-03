using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Book // all of the inputs are required
    {
        [Key]
        public int BookId { get; set; } //this is the primary key
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        //[DataType(DataType.Custom)]
        [Display(Name = "Isbn Number")]
        [Required(ErrorMessage = "ISBN Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{10})$", // this is the format that will be required.
                   ErrorMessage = "Entered ISBN format is not valid.")]
        public string Isbn { get; set; } //make sure it's validated and required
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        public int PageNumbers { get; set; }// this is what we added to the database
    }
}
