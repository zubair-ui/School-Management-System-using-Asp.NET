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
    public partial class SearchTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RefreshGrid();
        }

        private void RefreshGrid()
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Teacher = new SqlDataAdapter("Select * from Smart_Teacher", conn);

            var ds = new DataSet();

            adpt_Teacher.Fill(ds, "Smart_Teacher");

            gvTeacherDetail.DataSource = ds;
            gvTeacherDetail.DataBind();


        }

        protected void btnSearchTeacher_Click(object sender, EventArgs e)
        {
            var name = txtTeacherName.Text;
            var contactNo = txtTeacherContactNo.Text;
            var email = txtTeacherEmail.Text;
            var qualification = txtTeacherQualification.Text;

            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Teacher = new SqlDataAdapter("Select * from Smart_Teacher where Smart_Teacher_Name Like '%" + name + "%' and Smart_Teacher_ContactNo Like '%" + contactNo + "%' and Smart_Teacher_Email Like '%" + email + "%' and Smart_Teacher_Qualification Like '%" + qualification + "%'", conn);

            var ds = new DataSet();

            adpt_Teacher.Fill(ds, "Smart_Student");

            gvTeacherDetail.DataSource = ds;
            gvTeacherDetail.DataBind();
        }
    }
}