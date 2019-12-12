using FDDWeb.Models;
using FDDWeb.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FDDWeb.DAO
{
    public interface IOrderDao
    {
        IList<Order> GetOrdersOnStatus(Guid orderStatusID);

        bool UpdateOrder(Guid orderID, Guid orderStatusID);

        bool CreateOrder(Order order);

        bool AddMenuToOrder(string username, Guid menuID, int quantity);
    }

    public class OrderDao : IOrderDao
    {
        public bool AddMenuToOrder(string username, Guid menuID, int quantity)
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ADD_MENU_TO_ORDER"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@MenuID", menuID);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Connection = con;
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (!(result > 0)) return false;
                    return true;
                }
            }
        }

        public bool CreateOrder(Order order)
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                var orderID = Guid.NewGuid();
                var userID = new Guid();
                using (SqlCommand cmd = new SqlCommand("CREATE_ORDER"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", orderID);
                    cmd.Parameters.AddWithValue("@UserID", userID);


                    foreach (var item in order.UserMenuItems)
                    {

                        cmd.Parameters.AddWithValue("@MenuID", ((MenuItem)item.Key).MenuID);
                        cmd.Parameters.AddWithValue("@Quantity", item.Value);
                        cmd.Connection = con;
                        con.Open();
                        var result = cmd.ExecuteNonQuery();
                        if (!(result > 0)) return false;
                    }
                    return true;
                }
            }
        }

        public IList<Order> GetOrdersOnStatus(Guid orderStatusID)
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GET_ORDER_ON_STATUS"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = con;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        IList<Order> orders = new List<Order>();
                        while (reader.Read())
                        {

                            orders.Add(new Order
                            {

                                ID = reader.GetFieldValue<Guid>("ID"),
                                MenuItem = Tuple.Create(new MenuItem
                                {
                                    FoodCategory = reader.GetFieldValue<string>("CATEGORY"),
                                    FoodCategoryID = reader.GetFieldValue<Guid>("FOOD_CATEGORY_ID"),
                                    Name = reader.GetFieldValue<string>("NAME"),
                                    Price = reader.GetFieldValue<decimal>("PRICE"),
                                    MenuID = reader.GetFieldValue<Guid>("MENU_ID")
                                },
                                            reader.GetFieldValue<int>("QUANTITY")),
                                OrderStatus = reader.GetFieldValue<string>("STATUS"),
                                OrderStatusID = reader.GetFieldValue<Guid>("ORDER_STATUS_ID"),
                                User = new ApplicationUser
                                {
                                    UserID = reader.GetFieldValue<Guid>("USER_ID"),
                                    Name = reader.GetFieldValue<string>("NAME")
                                }
                            });
                        }
                        return orders;
                    }
                }
            }
        }

        public bool UpdateOrder(Guid orderID, Guid orderStatusID)
        {
            throw new NotImplementedException();
        }
    }
}