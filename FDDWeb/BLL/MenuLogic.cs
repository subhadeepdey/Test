using FDDWeb.DAO;
using FDDWeb.Models;
using System;
using System.Collections.Generic;

namespace FDDWeb.BLL
{
    public interface IMenuLogic
    {
        IList<MenuItem> GetMenu(Guid? categoryID = null);

        bool AddMenu(MenuItem menu);

        IList<FoodCategory> GetFoodCategories();

        bool DeleteMenu(Guid ID);
    }

    public class MenuLogic : IMenuLogic
    {
        public IMenuDao menuDao { get; set; }

        public MenuLogic(IMenuDao menuDao)
        {
            this.menuDao = menuDao;
        }

        public IList<MenuItem> GetMenu(Guid? categoryID = null) => categoryID.HasValue ? menuDao.GetMenuItemsByCategory(categoryID.Value) : menuDao.GetMenuItems();

        public bool AddMenu(MenuItem menu) => menuDao.AddMenu(menu);

        public IList<FoodCategory> GetFoodCategories() => menuDao.GetFoodCategories();

        public bool DeleteMenu(Guid ID) => menuDao.DeleteMenu(ID);
    }
}