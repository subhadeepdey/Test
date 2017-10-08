using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            if (Session["ErrorID"] != null)
            {
                var errorID = Convert.ToString(Session["ErrorID"]);
                lblErrorID.Text = errorID;

            }
            base.OnPreRenderComplete(e);
        }
      
    }
}