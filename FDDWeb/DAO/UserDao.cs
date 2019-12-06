using FDDWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FDDWeb.DAO
{
    public interface IUserDao
    {
        bool Register(ApplicationUser user);
        LoginStatus IsValidUser(string username, string password);
    }

    public class UserDao : IUserDao
    {
        public LoginStatus IsValidUser(string username, string password)
        {
            LoginStatus status;
            int userId = 0;
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
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    userId = Convert.ToInt32(reader["UserId"]);
                    roles = reader["Roles"].ToString();
                    con.Close();
                }
                switch (userId)
                {
                    case -1:
                        return LoginStatus.Failure;
                    case -2:
                        return LoginStatus.InActive;
                    default:
                        return LoginStatus.Success;
                }
            }
        }

        public bool Register(ApplicationUser user)
        {
            return true;
        }
    }
}