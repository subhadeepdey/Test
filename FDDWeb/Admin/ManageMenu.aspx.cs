using FDDWeb.BLL;
using FDDWeb.Models;
using Microsoft.Practices.Unity;
using System;

namespace FDDWeb.Admin
{
    public partial class ManageMenu : System.Web.UI.Page
    {
        [Dependency]
        public MenuLogic menuLogic { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();

                // Load menu Items.
                LoadMenu();
            }
        }

        protected void AddMenu(object sender, EventArgs e)
        {
            menuLogic.AddMenu(new MenuItem
            {
                FoodCategoryID = new Guid(Category.SelectedValue),
                Name = Name.Text,
                Description = Description.Text,
                Price = Convert.ToDecimal(Price.Text),
            });

            LoadMenu();
        }

        protected void DeleteMenu(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            menuLogic.DeleteMenu(new Guid(e.CommandArgument.ToString()));

            LoadMenu();
        }

        protected void Reset(object sender, EventArgs e)
        {
            Category.SelectedIndex = -1;
            Name.Text = string.Empty;
            Description.Text = string.Empty;
            Price.Text = string.Empty;
        }

        private void LoadCategory()
        {
            // Load Category
            Category.DataSource = menuLogic.GetFoodCategories();
            Category.DataBind();
        }

        private void LoadMenu()
        {
            // Load Menu
            Menu.DataSource = menuLogic.GetMenu();
            Menu.DataBind();
        }
    }
}