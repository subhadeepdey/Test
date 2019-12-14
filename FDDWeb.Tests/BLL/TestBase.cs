using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Data.SqlClient;

namespace FDDWeb.BLL.Tests
{
    public class TestBase
    {
        [TestInitialize]
        public void DataSetUp()
        {

            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            do
            {
                location = System.IO.Directory.GetParent(location).FullName;
            }
            while (!location.EndsWith(".Tests"));
            var scriptFolder = System.IO.Path.Combine(location, "SQL");

            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = con;
                    con.Open();

                    // Create the database.
                    foreach (var script in new System.Collections.Generic.List<string>
                {
                    "FDD_TEST.sql",
                })
                    {
                        var scriptPath = System.IO.Path.Combine(scriptFolder, script);
                        cmd.CommandText = System.IO.File.ReadAllText(scriptPath);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}