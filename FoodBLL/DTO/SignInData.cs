using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBLL.DTO
{
    public class SignInData
    {
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
