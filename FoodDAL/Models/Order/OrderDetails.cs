using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDAL.Models.Order
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeaders { get; set; }
        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public Item Items { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }


    }
}
