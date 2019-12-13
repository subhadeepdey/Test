using FDDWeb.BLL;
using FDDWeb.Models;
using FDDWeb.Utility;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FDDWeb.Customer
{
    public partial class OrderHistory : PageBase
    {
        [Dependency]
        public IOrderLogic orderLogic { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrder();
            }
        }

        private void LoadOrder()
        {
            Orders.DataSource = orderLogic.GetOrders(USERNAME);
            Orders.DataBind();
        }

        protected void OrdersItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var order = (Order)e.Item.DataItem;

                ((Label)e.Item.FindControl("Items")).Text = string.Join("<br/>", order.UserMenuItems.Select(i => string.Format("{0}({1}),", ((Models.MenuItem)i.Item1).Name, i.Item2)));
                ((Label)e.Item.FindControl("TotalPrice")).Text = String.Format("Order Total: {0:C}", order.UserMenuItems.Select(i => ((Models.MenuItem)i.Item1).Price * i.Item2).Sum()); ;
                ((Label)e.Item.FindControl("OrderDate")).Text = string.Format("{0:g}", order.OrderDate);
            }
        }
    }
}