using FDDWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FDDWeb.Utility;

namespace FDDWeb.DAO
{
    public interface IMenuDao
    {
        bool AddMenu(MenuItem item);
        IList<MenuItem> GetMenuItems();

    }
    public class MenuDao : IMenuDao
    {
        public bool AddMenu(MenuItem menu)
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_MENU"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", menu.Name);
                    cmd.Parameters.AddWithValue("@Price", menu.Price);
                    cmd.Parameters.AddWithValue("@Description", menu.Description);
                    cmd.Parameters.AddWithValue("@FoodCategoryID", menu.CategoryID);
                    cmd.Connection = con;
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        public IList<MenuItem> GetMenuItems()
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GET_MENU"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = con;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        IList<MenuItem> menuItems = new List<MenuItem>();
                        while (reader.Read())
                        {
                            menuItems.Add(new MenuItem
                            {
                                MenuID = reader.GetFieldValue<Guid>("ID"),
                                Name = reader.GetFieldValue<string>("NAME"),
                                Description = reader.GetFieldValue<string>("DESCRIPTION"),
                                Price = reader.GetFieldValue<decimal>("PRICE"),
                                CategoryID = reader.GetFieldValue<Guid>("FOOD_CATEGORY_ID"),
                                Category = reader.GetFieldValue<string>("CATEGORY"),
                            });
                        }
                        return menuItems;
                    }
                }
            }
        }
    }
}