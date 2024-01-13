using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseConnectivity
{
    public partial class SearchClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RefreshGrid();
        }

        private void RefreshGrid()
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Class = new SqlDataAdapter("Select * from Smart_Class", conn);

            var ds = new DataSet();

            adpt_Class.Fill(ds, "Smart_Class");

            gvClassDetail.DataSource = ds;
            gvClassDetail.DataBind();


        }

        protected void btnSearchClass_Click(object sender, EventArgs e)
        {
            var name = txtClassName.Text;
            var location = txtClassLocation.Text;

            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Class = new SqlDataAdapter("Select * from Smart_Class where Smart_Class_Name Like '%" + name + "%' and Smart_Class_Location Like '%" + location + "%'", conn);

            var ds = new DataSet();

            adpt_Class.Fill(ds, "Smart_Student");

            gvClassDetail.DataSource = ds;
            gvClassDetail.DataBind();
        }
    }
}