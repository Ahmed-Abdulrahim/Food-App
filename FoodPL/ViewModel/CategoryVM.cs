using System.ComponentModel.DataAnnotations;

namespace FoodPL.ViewModel
{
    public class CategoryVM
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
