using FDDWeb.BLL;
using FDDWeb.Utility;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FDDWeb
{
    public partial class Menu : PageBase
    {
        [Dependency]
        public MenuLogic menuLogic { get; set; }

        [Dependency]
        public OrderLogic orderLogic { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Load menu Items.
                LoadMenu(null);
                LoadCategory();
                LoadCart();
            }
        }

        protected void PlaceOrder(object sender, EventArgs e)
        {
            if (orderLogic.PlaceOrder(USERNAME))
            {
                SuccessMessage.Text = "Order Placed Successfully.";
                LoadCart();
            }
            else
            {
                ErrorMessage.Text = "Error occurred.";
            }
        }

        protected void CategorySelected(object sender, EventArgs e)
        {
            if (Category.SelectedIndex != -1)
            {
                LoadMenu(new Guid(Category.SelectedValue));
            }
        }

        protected void AddMenuToCart(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (!string.IsNullOrEmpty(USERNAME))
            {
                RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

                if (!Int32.TryParse((item.FindControl("Quantity") as TextBox).Text, out int quantity))
                {
                    ErrorMessage.Text = "Please select quantity.";
                    return;
                }

                orderLogic.AddMenuToOrder(USERNAME, new Guid(e.CommandArgument.ToString()), quantity);

                LoadCart();
            }
            else
            {
                Response.Redirect("/Account/Login");
            }
        }

        private void LoadMenu(Guid? foodCategoryID)
        {
            // Load Menu
            MenuList.DataSource = menuLogic.GetMenu(foodCategoryID);
            MenuList.DataBind();
        }

        private void LoadCategory()
        {
            // Load Category
            Category.DataSource = menuLogic.GetFoodCategories();
            Category.SelectedIndex = -1;
            Category.DataBind();
        }

        private void LoadCart()
        {
            if (!string.IsNullOrEmpty(USERNAME))
            {
                var orders = orderLogic.GetCurrentOrder(USERNAME);
                if (!orders.Any())
                {
                    CartDetail.Visible = false; return;
                }
                CartDetail.Visible = true;
                CartDetail.DataSource = orders.First().UserMenuItems;
                CartDetail.DataBind();
            }
        }

        protected void CartDetailItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var menu = (Tuple<FDDWeb.Models.MenuItem, int>)e.Item.DataItem;

                ((Label)e.Item.FindControl("Item")).Text = ((FDDWeb.Models.MenuItem)menu.Item1).Name;
                ((Label)e.Item.FindControl("Quantity")).Text = menu.Item2.ToString();
                ((Label)e.Item.FindControl("Price")).Text = ((FDDWeb.Models.MenuItem)menu.Item1).Price.ToString();
            }
        }
    }
}