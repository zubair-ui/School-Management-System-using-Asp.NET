using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseConnectivity
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.BackColor = System.Drawing.Color.Red;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.BackColor= System.Drawing.Color.Green;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}