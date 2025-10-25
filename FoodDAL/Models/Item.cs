using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDAL.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [ForeignKey(nameof(Categories))]
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
        [ForeignKey(nameof(SubCategories))]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategories { get; set; }
    }
}
