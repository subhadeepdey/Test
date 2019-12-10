using FDDWeb.Models;
using FDDWeb.Utility;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FDDWeb.DAO
{
    public interface IUserDao
    {
        bool Register(ApplicationUser user);
        ApplicationUser IsValidUser(string username, string password);
    }

    public class UserDao : IUserDao
    {
        public ApplicationUser IsValidUser(string username, string password)
        {
            string roles = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Connection = con;
                    con.Open();
                    ApplicationUser user = null;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new ApplicationUser
                            {
                                UserID = reader.GetFieldValue<Guid>("ID"),

                                Status = (LoginStatus)reader.GetFieldValue<int>("STATUS"),
                                Name = reader.GetFieldValue<string>("NAME"),
                                Phone = reader.GetFieldValue<string>("PHONE"),
                                Email = reader.GetFieldValue<string>("EMAIL"),
                                Address = reader.GetFieldValue<string>("ADDRESS"),
                                AlternateAddress = reader.GetFieldValue<string>("ALTERNATE_ADDRESS"),

                                //Roles = reader.GetFieldValue<string>("ROLE");
                            };
                            var role = new IdentityUserRole();
                            role.RoleId = reader.GetFieldValue<string>("ROLE");
                            user.Roles.Add(role);
                        }
                            return user;
                    }
                }

            }
        }

        public bool Register(ApplicationUser user)
        {
            Guid userId;
            string role = string.Empty;
            var status = LoginStatus.Failure;
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT_USER"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", user.UserName);
                    cmd.Parameters.AddWithValue("@Password", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@AlternateAddress", user.AlternateAddress);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    userId = new Guid(Convert.ToString(reader["USER_ID"]));
                    role = Convert.ToString(reader["ROLE"].ToString());
                    status = (LoginStatus)Convert.ToInt32(reader["STATUS"]);
                    con.Close();
                }
                return status == LoginStatus.Success;
            }
        }
    }
}