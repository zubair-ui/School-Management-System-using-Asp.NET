using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DatabaseConnectivity
{
    public partial class ManageStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                RefreshGrid();
        }

        private void RefreshGrid()
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Student = new SqlDataAdapter("Select * from Smart_Student", conn);

            var ds = new DataSet();

            adpt_Student.Fill(ds, "Smart_Student");

            gvStudentDetail.DataSource = ds.Tables["Smart_Student"];
            gvStudentDetail.DataBind();

            StudentNamesList.DataSource = ds;
            StudentNamesList.DataTextField = "Name";
            StudentNamesList.DataValueField = "Id";
            StudentNamesList.DataBind();

            var adpt_Class = new SqlDataAdapter("Select * from Smart_Class", conn);

            var ds2 = new DataSet();

            adpt_Class.Fill(ds2, "Smart_Class");

            ddlStudentClass.DataSource = ds2;
            ddlStudentClass.DataTextField = "Smart_Class_Name";
            ddlStudentClass.DataValueField = "Smart_Class_Id";
            ddlStudentClass.DataBind();

        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            var name = txtStudentName.Text;
            var fathername = txtFatherName.Text;
            var dob = txtDOB.Text;
            var gender = genderList.SelectedValue;
            var contactNo = txtContactNo.Text;
            var email = txtEmail.Text;


            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert into Smart_Student(Name,FatherName,DOB,Gender,contactNo,email,Class_Id) values ('" + name + "','" + fathername + "','" + dob + "','" + gender + "','" + contactNo + "','" + email + "',"+ddlStudentClass.SelectedValue+")";
            
            try
            {
                conn.Open();
               
                cmd.ExecuteNonQuery();

                conn.Close();

                msg.Text = "Student " + name + " has been added successfully";

                RefreshGrid();
            }
            catch (Exception ex) { 
                msg.Text = ex.Message;
            }

        }

        protected void StudentNamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Student = new SqlDataAdapter("Select * from Smart_Student where id ="+StudentNamesList.SelectedValue, conn);

            var ds = new DataSet();

            adpt_Student.Fill(ds, "Smart_Student");
            foreach(DataRow dr in ds.Tables["Smart_Student"].Rows) {
                
                txtStudentName.Text = dr["Name"].ToString();
                txtFatherName.Text = dr["FatherName"].ToString();
                txtEmail.Text = dr["Email"].ToString();

                txtDOB.Text = Convert.ToDateTime(dr["DOB"]).ToString("dd/MM/yyyy");
                txtContactNo.Text = dr["ContactNo"].ToString();
                genderList.SelectedValue = dr["Gender"].ToString();

            }


            btnAddStudent.Visible = false;
            btnUpdateStudent.Visible = true;

        }

        protected void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Student = new SqlDataAdapter("Select * from Smart_Student where id =" + StudentNamesList.SelectedValue, conn);

            var ds = new DataSet();

            adpt_Student.Fill(ds, "Smart_Student");

            foreach (DataRow dr in ds.Tables["Smart_Student"].Rows)
            {
                dr["Name"] = txtStudentName.Text;
                dr["FatherName"] = txtFatherName.Text;
                dr["Email"] = txtEmail.Text;
                if(txtDOB.Text != "")
                    dr["DOB"] = Convert.ToDateTime(txtDOB.Text);
                dr["ContactNo"] = txtContactNo.Text;
                dr["Gender"] = genderList.SelectedValue;
                dr["Class_Id"] = ddlStudentClass.SelectedValue;

            }

            SqlCommandBuilder buil = new SqlCommandBuilder(adpt_Student);
            adpt_Student.Update(ds, "Smart_Student");

            btnAddStudent.Visible = true;
            btnUpdateStudent.Visible = false;

            RefreshGrid();
        }

        protected void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Delete from Smart_Student where id = " + StudentNamesList.SelectedValue;

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
                conn.Close();

                msg.Text = "Student has been deleted successfully";

                RefreshGrid();
                btnAddStudent.Visible = true;
                btnUpdateStudent.Visible = false;
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }
    }
}