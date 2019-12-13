using System;
using System.Collections.Generic;

namespace FDDWeb.Models
{
    public class Order
    {
        public Guid ID { get; set; }
        public IList<Tuple<MenuItem, int>> UserMenuItems { get; set; } = new List<Tuple<MenuItem, int>>();
        public Tuple<MenuItem, int> MenuItem { get; set; }
        public User User { get; set; }
        public string OrderStatus { get; set; }
        public Guid OrderStatusID { get; set; }
        public decimal TotalPrice { get; internal set; }
    }
}