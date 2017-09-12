using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var strDate = "2017-06-21T01:12:54.878";
            var cdt = Convert.ToDateTime(strDate);
            var currentDate = DateTime.UtcNow;
            divTest1.InnerHtml = "<span class='toLocaldate'>" + cdt.ToString() + "</span>";
            //divTest2.InnerHtml = "<span class='toLocaldate'>" + DateTimeOffset.Parse(currentDate.ToString()) + "</span>";
        }
    }
}