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
    public partial class ManageClass : System.Web.UI.Page
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

            gvClassDetail.DataSource = ds.Tables["Smart_Class"];
            gvClassDetail.DataBind();

            ClassNamesList.DataSource = ds;
            ClassNamesList.DataTextField = "Smart_Class_Name";
            ClassNamesList.DataValueField = "Smart_Class_Id";
            ClassNamesList.DataBind();

        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            var name = txtClassName.Text;
            var loaction = txtClassLocation.Text;   


            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert into Smart_Class(Smart_Class_Name,Smart_Class_Location) values ('" + name + "','" + loaction + "')";

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                msg.Text = "Class " + name + " has been added successfully";

                RefreshGrid();
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }

        }

        protected void ClassNamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Class = new SqlDataAdapter("Select * from Smart_Class where Smart_Class_Id =" + ClassNamesList.SelectedValue, conn);

            var ds = new DataSet();

            adpt_Class.Fill(ds, "Smart_Class");

            foreach (DataRow dr in ds.Tables["Smart_Class"].Rows)
            {

                txtClassName.Text = dr["Smart_Class_Name"].ToString();
                txtClassLocation.Text = dr["Smart_Class_Location"].ToString();

            }

            btnAddClass.Visible = false;
            btnUpdateClass.Visible = true;

        }

        protected void btnUpdateClass_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var adpt_Class = new SqlDataAdapter("Select * from Smart_Class where Smart_Class_Id =" + ClassNamesList.SelectedValue, conn);

            var ds = new DataSet();

            adpt_Class.Fill(ds, "Smart_Class");

            foreach (DataRow dr in ds.Tables["Smart_Class"].Rows)
            {
                dr["Smart_Class_Name"] = txtClassName.Text;
                dr["Smart_Class_Location"] = txtClassLocation.Text;

            }

            SqlCommandBuilder buil = new SqlCommandBuilder(adpt_Class);
            adpt_Class.Update(ds, "Smart_Class");

            btnAddClass.Visible = true;
            btnUpdateClass.Visible = false;

            RefreshGrid();
        }

        protected void btnDeleteClass_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP-SMLF48T;Initial Catalog=Smart_School;Integrated Security=true;");

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Delete from Smart_Class where Smart_Class_Id = " + ClassNamesList.SelectedValue;

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
                conn.Close();

                msg.Text = "Class has been deleted successfully";

                RefreshGrid();
                btnAddClass.Visible = true;
                btnUpdateClass.Visible = false;
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }
    }
}