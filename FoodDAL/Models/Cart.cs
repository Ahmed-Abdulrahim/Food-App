using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDAL.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required , MinLength(1)]
        public int Count { get; set; }
        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public Item Items { get; set; }
    }
}
