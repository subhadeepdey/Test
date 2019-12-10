using System;
using System.Collections.Generic;

namespace FDDWeb.Models
{
    public class Order
    {
        public Guid ID { get; set; }
        public Dictionary<MenuItem, int> UserMenuItems { get; set; }
        public Tuple<MenuItem, int> MenuItem { get; set; }
        public ApplicationUser User { get; set; }
        public string OrderStatus { get; set; }
        public Guid OrderStatusID { get; set; }
        public decimal TotalPrice { get; internal set; }
    }
}