using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDAL.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Type { get; set; }
        public double DisCount { get; set; }
        public double MinAmount { get; set; }
        public byte[] CouponImage { get; set; }
        public bool IsActive { get; set; }

    }
    public enum CouponType 
    {
        percent = 0,
        Currency=1,
    }
}
