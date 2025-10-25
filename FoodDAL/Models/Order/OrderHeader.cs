using FoodDAL.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDAL.Models.Order
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime TmeOfPick { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfPick { get; set; }
        public double SubTotal { get; set; }
        public double OrderTotal { get; set; }
        public string CouponCode { get; set; }
        public double CouponDisCount { get; set; }
        public string TransId { get; set; }
        public string OrderStatus { get; set; }
        public string Payment { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Phone { get; set; }
        [ForeignKey(nameof(AppUsers))]
        public string AppUserId { get; set; }
        public AppUser AppUsers { get; set; }
    }
}
