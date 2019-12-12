using System;

namespace FDDWeb.Models
{
    public class MenuItem
    {
        public Guid MenuID { get; set; }
        public string FoodCategory { get; set; }
        public Guid FoodCategoryID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}