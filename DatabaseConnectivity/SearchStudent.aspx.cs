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
    public partial class SearchStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RefreshGrid();
        }

        private void RefreshGrid()
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Student = new SqlDataAdapter("Select * from Smart_Student", conn);

            var ds = new DataSet();

            adpt_Student.Fill(ds, "Smart_Student");

            gvStudentDetail.DataSource = ds;
            gvStudentDetail.DataBind();

           
        }

        protected void btnSearchStudent_Click(object sender, EventArgs e)
        {
            var name = txtStudentName.Text;
            var fathername = txtFatherName.Text;
            var dob = txtDOB.Text;
            var gender = genderList.SelectedValue;
            var contactNo = txtContactNo.Text;
            var email = txtEmail.Text;
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Student = new SqlDataAdapter("Select * from Smart_Student where Name Like '%"+name+"%' and FatherName Like '%"+fathername+"%'and DOB Like '%"+dob+"%' and Gender Like '%"+gender+"%' and ContactNo Like '%"+contactNo+"%' and Email Like '%"+email+"%' ", conn);

            var ds = new DataSet();

            adpt_Student.Fill(ds, "Smart_Student");

            gvStudentDetail.DataSource = ds;
            gvStudentDetail.DataBind();
        }
    }
}