using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBLL.DTO
{
    public class SignUpData
    {
        [Required(ErrorMessage ="User Name is Required") ]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Name is Required") ,MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage ="Password is Required") , DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password is Required"), DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }

    }
}
