using FDDWeb.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
            Guid userId;
            int status = 0;
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
                    userId = new Guid(Convert.ToString(reader["ID"]));
                    status = Convert.ToInt32(reader["STATUS"]);
                    roles = reader["ROLE"].ToString();
                    con.Close();
                }
                switch (status)
                {
                    case -1:
                        return LoginStatus.Failure;
                    default:
                        return LoginStatus.Success;
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