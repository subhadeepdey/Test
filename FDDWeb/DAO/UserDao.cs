using FDDWeb.Models;
using FDDWeb.Utility;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FDDWeb.DAO
{
    public interface IUserDao
    {
        User Register(User user);
        User IsValidUser(string username, string password);
        IList<User> GetUsers();
        bool UpgradeToPremium(string username);
        bool UpdateUserRole(string username, string role);
    }

    public class UserDao : IUserDao
    {
        public IList<User> GetUsers()
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GET_USERS"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        IList<User> users = new List<User>();
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserID = reader.GetFieldValue<Guid>("ID"),
                                Username = reader.GetFieldValue<string>("USERNAME"),
                                Status = (LoginStatus)reader.GetFieldValue<int>("STATUS"),
                                Name = reader.GetFieldValue<string>("NAME"),
                                Phone = reader.GetFieldValue<string>("PHONE"),
                                Email = reader.GetFieldValue<string>("EMAIL"),
                                Address = reader.GetFieldValue<string>("ADDRESS"),
                                AlternateAddress = reader.GetFieldValue<string>("ALTERNATE_ADDRESS"),
                                Role = reader.GetFieldValue<string>("ROLE"),
                                IsPremium = reader.GetFieldValue<bool>("IS_PREMIUM"),
                            });
                        }
                        return users;
                    }
                }
            }
        }

        public User IsValidUser(string username, string password)
        {
            string roles = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", MD5hash.GetMD5Hash(password));
                    cmd.Connection = con;
                    con.Open();
                    User user = null;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserID = reader.GetFieldValue<Guid>("ID"),
                                Username = reader.GetFieldValue<string>("USERNAME"),
                                Status = (LoginStatus)reader.GetFieldValue<int>("STATUS"),
                                Name = reader.GetFieldValue<string>("NAME"),
                                Phone = reader.GetFieldValue<string>("PHONE"),
                                Email = reader.GetFieldValue<string>("EMAIL"),
                                Address = reader.GetFieldValue<string>("ADDRESS"),
                                AlternateAddress = reader.GetFieldValue<string>("ALTERNATE_ADDRESS"),
                                Role = reader.GetFieldValue<string>("ROLE")
                            };
                        }
                        return user;
                    }
                }

            }
        }

        public User Register(User user)
        {
            string role = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT_USER"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", MD5hash.GetMD5Hash(user.Password));
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@AlternateAddress", user.AlternateAddress);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        User newUser = null;
                        if (reader.Read())
                        {
                            newUser = new User
                            {
                                UserID = reader.GetFieldValue<Guid>("ID"),
                                Username = reader.GetFieldValue<string>("USERNAME"),
                                Status = (LoginStatus)reader.GetFieldValue<int>("STATUS"),
                                Name = reader.GetFieldValue<string>("NAME"),
                                Phone = reader.GetFieldValue<string>("PHONE"),
                                Email = reader.GetFieldValue<string>("EMAIL"),
                                Address = reader.GetFieldValue<string>("ADDRESS"),
                                AlternateAddress = reader.GetFieldValue<string>("ALTERNATE_ADDRESS"),
                                Role = reader.GetFieldValue<string>("ROLE")
                            };
                        }
                        return newUser;
                    }
                }
            }
        }

        public bool UpgradeToPremium(string username)
        {
            string roles = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPGRADE_USER"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateUserRole(string username, string role)
        {
            string roles = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPGRADE_USER"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
