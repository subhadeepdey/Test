﻿using FDDWeb.BLL;
using FDDWeb.Models;
using FDDWeb.Utility;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FDDWeb.Admin
{
    public partial class ManageOrder : PageBase
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
            Orders.DataSource = orderLogic.GetOrders();
            Orders.DataBind();
        }

        protected void OrdersItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var order = (Order)e.Item.DataItem;
                ((Label)e.Item.FindControl("Name")).Text = order.User.Name;
                ((Label)e.Item.FindControl("Items")).Text = string.Join("<br/>", order.UserMenuItems.Select(i => string.Format("{0}({1}),", ((Models.MenuItem)i.Item1).Name, i.Item2)));
                ((Label)e.Item.FindControl("TotalPrice")).Text = String.Format("Order Total: {0:C}", order.UserMenuItems.Select(i => ((Models.MenuItem)i.Item1).Price * i.Item2).Sum()); ;
                ((Label)e.Item.FindControl("OrderDate")).Text = string.Format("{0:g}", order.OrderDate);
                ((Button)e.Item.FindControl("Approve")).Visible = orderLogic.CanOrderStatusChange(order.OrderStatus);
                ((Button)e.Item.FindControl("Cancel")).Visible = orderLogic.CanOrderStatusChange(order.OrderStatus);
            }
        }

        protected void UpdateOrderStatus(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            var orderStatus = e.CommandName;
            orderLogic.UpdateOrderStatus(new Guid(e.CommandArgument.ToString()), e.CommandName);
            LoadOrder();
        }

    }
}