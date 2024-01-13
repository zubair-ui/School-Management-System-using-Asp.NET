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
    public partial class ManageSubject : System.Web.UI.Page
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

            gvSubjectDetail.DataSource = ds.Tables["Smart_Subject"];
            gvSubjectDetail.DataBind();

            SubjectNamesList.DataSource = ds;
            SubjectNamesList.DataTextField = "Smart_Subject_Name";
            SubjectNamesList.DataValueField = "Smart_Subject_Id";
            SubjectNamesList.DataBind();

            var adpt_Teacher = new SqlDataAdapter("Select * from Smart_Teacher", conn);

            var ds2 = new DataSet();

            adpt_Teacher.Fill(ds2, "Smart_Teacher");

            ddlSubjectTeacher.DataSource = ds2;
            ddlSubjectTeacher.DataTextField = "Smart_Teacher_Name";
            ddlSubjectTeacher.DataValueField = "Smart_Teacher_Id";
            ddlSubjectTeacher.DataBind();

        }

        protected void btnAddSubject_Click(object sender, EventArgs e)
        {
            var name = txtSubjectName.Text;
            var book = txtSubjectBook.Text;
            var teacherId = ddlSubjectTeacher.SelectedValue;


            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert into Smart_Subject(Smart_Subject_Name,Smart_Subject_Book,Smart_Subject_Teacher_Id) values ('" + name + "','" +book + "'," + teacherId + ")";

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                msg.Text = "Subaject " + name + " has been added successfully";

                RefreshGrid();
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }

        }

        protected void SubjectNamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Subject = new SqlDataAdapter("Select * from Smart_Subject where Smart_Subject_Id =" + SubjectNamesList.SelectedValue, conn);

            var ds = new DataSet();

            adpt_Subject.Fill(ds, "Smart_Subject");
            foreach (DataRow dr in ds.Tables["Smart_Subject"].Rows)
            {

                txtSubjectName.Text = dr["Smart_Subject_Name"].ToString();
                txtSubjectBook.Text = dr["Smart_Subject_Book"].ToString();
                ddlSubjectTeacher.SelectedValue = dr["Smart_Subject_Teacher_Id"].ToString();

            }


            btnAddSubject.Visible = false;
            btnUpdateSubject.Visible = true;

        }

        protected void btnUpdateSubject_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Subject = new SqlDataAdapter("Select * from Smart_Subject where  Smart_Subject_Id =" + SubjectNamesList.SelectedValue, conn);

            var ds = new DataSet();

            adpt_Subject.Fill(ds, "Smart_Subject");

            foreach (DataRow dr in ds.Tables["Smart_Subject"].Rows)
            {
                dr["Smart_Subject_Name"] = txtSubjectName.Text;
                dr["Smart_Subject_Book"] = txtSubjectBook.Text;
                dr["Smart_Subject_Teacher_Id"] = ddlSubjectTeacher.SelectedValue;

            }

            SqlCommandBuilder buil = new SqlCommandBuilder(adpt_Subject);
            adpt_Subject.Update(ds, "Smart_Subject");

            btnAddSubject.Visible = true;
            btnUpdateSubject.Visible = false;

            RefreshGrid();
        }

        protected void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Delete from Smart_Subject where  Smart_Subject_Id = " + SubjectNamesList.SelectedValue;

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
                conn.Close();

                msg.Text = "Subject has been deleted successfully";

                RefreshGrid();
                btnAddSubject.Visible = true;
                btnUpdateSubject.Visible = false;
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }

    }
}