using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Breakfast.ViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20, ErrorMessage = "Maximum length: 20")]
        [MinLength(4, ErrorMessage = "Minimum length: 4")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "Maximum length: 20")]
        [MinLength(4, ErrorMessage = "Minimum length: 4")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [MaxLength(5, ErrorMessage = "Length must be 5")]
        [MinLength(5, ErrorMessage = "Length must be 5")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only use alphanumberic characters.")]
        public string Zipcode { get; set; }

        public string Address { get; set; }

        public string WorkAddress { get; set; }
    }
}