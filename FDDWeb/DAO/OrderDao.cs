using FDDWeb.Models;
using FDDWeb.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FDDWeb.DAO
{
    public interface IOrderDao
    {
        IList<Order> GetOrders(string username = null);

        bool UpdateOrderStatus(Guid orderID, string orderStatus);

        bool CreateOrder(Order order);

        bool AddMenuToOrder(string username, Guid menuID, int quantity);

        bool PlaceOrder(string username);

        IList<Order> GetCurrentOrder(string username);
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

                using (SqlCommand cmd = new SqlCommand("CREATE_ORDER"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", order.ID);
                    cmd.Parameters.AddWithValue("@Username", order.User.Username);


                    foreach (var item in order.UserMenuItems)
                    {

                        cmd.Parameters.AddWithValue("@MenuID", ((MenuItem)item.Item1).MenuID);
                        cmd.Parameters.AddWithValue("@Quantity", item.Item2);
                        cmd.Connection = con;
                        con.Open();
                        var result = cmd.ExecuteNonQuery();
                        if (!(result > 0)) return false;
                    }
                    return true;
                }
            }
        }

        public IList<Order> GetCurrentOrder(string username)
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GET_CURRENT_CART_ORDER"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);

                    cmd.Connection = con;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        IList<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            var orderID = reader.GetFieldValue<Guid>("ID");
                            var menuItem = Tuple.Create(new MenuItem
                            {
                                Name = reader.GetFieldValue<string>("MENU_NAME"),
                                Price = reader.GetFieldValue<decimal>("PRICE"),
                                MenuID = reader.GetFieldValue<Guid>("MENU_ID")
                            }, reader.GetFieldValue<int>("QUANTITY"));

                            var order = orders.FirstOrDefault(o => o.ID == orderID);
                            if (order != null)
                            {
                                order.UserMenuItems.Add(menuItem);
                            }
                            else
                            {
                                order = new Order
                                {

                                    ID = reader.GetFieldValue<Guid>("ID"),
                                    OrderStatus = reader.GetFieldValue<string>("STATUS"),
                                    OrderStatusID = reader.GetFieldValue<Guid>("ORDER_STATUS_ID"),
                                    OrderDate = reader.GetFieldValue<DateTime>("CREATEDDATE"),
                                    User = new User
                                    {
                                        UserID = reader.GetFieldValue<Guid>("USER_ID"),
                                        Name = reader.GetFieldValue<string>("USER_NAME"),
                                        Username = username
                                    }
                                };
                                order.UserMenuItems.Add(menuItem);
                                orders.Add(order);
                            }
                        }
                        return orders;
                    }
                }
            }
        }

        public IList<Order> GetOrders(string username = null)
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(string.IsNullOrEmpty(username) ? "GET_ALL_CURRENT_ORDERS" : "GET_USER_ORDERS"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(username))
                        cmd.Parameters.AddWithValue("@Username", username);

                    cmd.Connection = con;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        IList<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            var orderID = reader.GetFieldValue<Guid>("ID");
                            var menuItem = Tuple.Create(new MenuItem
                            {
                                Name = reader.GetFieldValue<string>("MENU_NAME"),
                                Price = reader.GetFieldValue<decimal>("PRICE"),
                                MenuID = reader.GetFieldValue<Guid>("MENU_ID")
                            }, reader.GetFieldValue<int>("QUANTITY"));

                            var order = orders.FirstOrDefault(o => o.ID == orderID);
                            if (order != null)
                            {
                                order.UserMenuItems.Add(menuItem);
                            }
                            else
                            {
                                order = new Order
                                {

                                    ID = reader.GetFieldValue<Guid>("ID"),
                                    OrderStatus = reader.GetFieldValue<string>("STATUS"),
                                    OrderStatusID = reader.GetFieldValue<Guid>("ORDER_STATUS_ID"),
                                    OrderDate = reader.GetFieldValue<DateTime>("CREATEDDATE"),
                                    User = new User
                                    {
                                        UserID = reader.GetFieldValue<Guid>("USER_ID"),
                                        Name = reader.GetFieldValue<string>("USER_NAME"),
                                        Username = username
                                    }
                                };
                                order.UserMenuItems.Add(menuItem);
                                orders.Add(order);
                            }
                        }
                        return orders;
                    }
                }
            }
        }

        public bool PlaceOrder(string username)
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("PLACE_ORDER"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Connection = con;
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        public bool UpdateOrderStatus(Guid orderID, string orderStatus)
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_ORDER_STATUS"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    cmd.Parameters.AddWithValue("@OrderStatus", orderStatus);
                    cmd.Connection = con;
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
    }
}