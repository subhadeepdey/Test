using FDDWeb.BLL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FDDWeb
{
    public partial class Menu : System.Web.UI.Page
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
            }
        }

        protected void CategorySelected(object sender, EventArgs e)
        {
            if (Category.SelectedIndex != -1)
            {
                LoadMenu(new Guid(Category.SelectedValue));
            }
        }

        private void LoadMenu(Guid? foodCategoryID)
        {
            // Load Menu
            MenuList.DataSource = foodCategoryID.HasValue ? menuLogic.GetMenu() : menuLogic.GetMenu();
            MenuList.DataBind();
        }

        protected void AddMenu(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

                Int32.TryParse((item.FindControl("Quantity") as TextBox).Text, out int quantity);

                orderLogic.AddMenuToOrder(new Guid(e.CommandArgument.ToString()), quantity);

                LoadMenu(null);
            }
            else
            {
                Response.Redirect("/Account/Login");
            }
        }

        private void LoadCategory()
        {
            // Load Category
            Category.DataSource = menuLogic.GetFoodCategories();
            Category.DataBind();
            Category.SelectedIndex = -1;
        }
    }
}