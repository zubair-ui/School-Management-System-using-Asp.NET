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
    public partial class SearchSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RefreshGrid();
        }

        private void RefreshGrid()
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Subject = new SqlDataAdapter("Select * from Smart_Subject", conn);

            var ds = new DataSet();

            adpt_Subject.Fill(ds, "Smart_Subject");

            gvSubjectDetail.DataSource = ds;
            gvSubjectDetail.DataBind();


        }

        protected void btnSearchSubject_Click(object sender, EventArgs e)
        {
            var name = txtSubjectName.Text;
            var book = txtSubjectBook.Text;

            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Subject = new SqlDataAdapter("Select * from Smart_Subject where Smart_Subject_Name Like '%" + name + "%' and Smart_Subject_Book Like '%" + book + "%'", conn);

            var ds = new DataSet();

            adpt_Subject.Fill(ds, "Smart_Subject");

            gvSubjectDetail.DataSource = ds;
            gvSubjectDetail.DataBind();
        }
    }
}