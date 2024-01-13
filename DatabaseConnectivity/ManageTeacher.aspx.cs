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
    public partial class ManageTeacher : System.Web.UI.Page
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

            gvTeacherDetail.DataSource = ds.Tables["Smart_Teacher"];
            gvTeacherDetail.DataBind();

            TeacherNamesList.DataSource = ds;
            TeacherNamesList.DataTextField = "Smart_Teacher_Name";
            TeacherNamesList.DataValueField = "Smart_Teacher_Id";
            TeacherNamesList.DataBind();

        }

        protected void btnAddTeacher_Click(object sender, EventArgs e)
        {
            var name = txtTeacherName.Text;
            var contactNo = txtTeacherContactNo.Text;
            var email = txtTeacherEmail.Text;
            var qualification = txtTeacherQualification.Text;


            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert into Smart_Teacher(Smart_Teacher_Name,Smart_Teacher_Qualification,Smart_Teacher_ContactNo,Smart_Teacher_Email) values ('" + name + "','"+qualification+"','" + contactNo + "','" + email + "')";

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                msg.Text = "Teacher " + name + " has been added successfully";

                RefreshGrid();
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }

        }

        protected void TeacherNamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Teacher = new SqlDataAdapter("Select * from Smart_Teacher where Smart_Teacher_Id =" + TeacherNamesList.SelectedValue, conn);

            var ds = new DataSet();

            adpt_Teacher.Fill(ds, "Smart_Teacher");

            foreach (DataRow dr in ds.Tables["Smart_Teacher"].Rows)
            {

                txtTeacherName.Text = dr["Smart_Teacher_Name"].ToString();
                txtTeacherEmail.Text = dr["Smart_Teacher_Email"].ToString();
                txtTeacherContactNo.Text = dr["Smart_Teacher_ContactNo"].ToString();
                txtTeacherQualification.Text = dr["Smart_Teacher_Qualification"].ToString();

            }

            btnAddTeacher.Visible = false;
            btnUpdateTeacher.Visible = true;

        }

        protected void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Teacher = new SqlDataAdapter("Select * from Smart_Teacher where Smart_Teacher_Id =" + TeacherNamesList.SelectedValue, conn);

            var ds = new DataSet();

            adpt_Teacher.Fill(ds, "Smart_Teacher");

            foreach (DataRow dr in ds.Tables["Smart_Teacher"].Rows)
            {
                dr["Smart_Teacher_Name"] = txtTeacherName.Text;
                dr["Smart_Teacher_Email"] = txtTeacherEmail.Text;
                dr["Smart_Teacher_ContactNo"] = txtTeacherContactNo.Text;
                dr["Smart_Teacher_Qualification"] = txtTeacherQualification.Text;

            }

            SqlCommandBuilder buil = new SqlCommandBuilder(adpt_Teacher);
            adpt_Teacher.Update(ds, "Smart_Teacher");

            btnAddTeacher.Visible = true;
            btnUpdateTeacher.Visible = false;

            RefreshGrid();
        }

        protected void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Delete from Smart_Teacher where Smart_Teacher_Id = " + TeacherNamesList.SelectedValue;

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
                conn.Close();

                msg.Text = "Teacher has been deleted successfully";

                RefreshGrid();
                btnAddTeacher.Visible = true;
                btnUpdateTeacher.Visible = false;
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }
    }
}