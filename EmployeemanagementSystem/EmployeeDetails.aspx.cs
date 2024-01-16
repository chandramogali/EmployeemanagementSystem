using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeemanagementSystem
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecord();
            }
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            
            int employeeID = int.Parse(txtEmpID.Text);
            string FirstName= txtFirstName.Text;
             string LastName=txtLastName.Text;
            int Age = int.Parse(txtAge.Text);
            string Email =txtEmail.Text;
             string PhoneNumber =txtPhoneNumber.Text;   
             decimal Salary= (int)decimal.Parse(txtSalary.Text);
            string Department = ddlDepartment.SelectedValue;
            DateTime JoiningDate = DateTime.Parse(txtJoining.Text);
            string City =txtCity.Text;
            sqlConnection.Open();
            SqlCommand insert = new SqlCommand("exec sp_InsertEmployee '" + employeeID + "', '" + FirstName + "' , '" + LastName + "', '" + Age + "', '" + Email + "', '" + PhoneNumber + "','" + Salary + "' ,'" + Department + "' ,'" +JoiningDate+"','" + City+ "' ", sqlConnection);

            insert.ExecuteNonQuery();
            sqlConnection.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted.');", true);
            LoadRecord();


        }
        void GetEmployeesList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            
            SqlCommand co = new SqlCommand("exec sp_GetAllEmployees", sqlConnection);
            SqlDataAdapter sd = new SqlDataAdapter(co);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        void LoadRecord()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("exec sp_GetAllEmployees", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        protected void Update_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            int employeeID = int.Parse(txtEmpID.Text);
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            int Age = int.Parse(txtAge.Text);
            string Email = txtEmail.Text;
            string PhoneNumber = txtPhoneNumber.Text;
            decimal Salary = (int)decimal.Parse(txtSalary.Text);
            string Department = ddlDepartment.SelectedValue;
            DateTime JoiningDate = DateTime.Parse(txtJoining.Text);
            string City = txtCity.Text;
            sqlConnection.Open();
            SqlCommand update = new SqlCommand("exec sp_UpdateEmployee '" + employeeID + "', '" + FirstName + "' , '" + LastName + "', '" + Age + "', '" + Email + "', '" + PhoneNumber + "','" + Salary + "' ,'" + Department + "' ,'" + JoiningDate + "','" + City + "' ", sqlConnection);

            update.ExecuteNonQuery();
            sqlConnection.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully updated.');", true);
            LoadRecord();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            int employeeID = int.Parse(txtEmpID.Text);
   
            sqlConnection.Open();
            SqlCommand delete = new SqlCommand("exec sp_DeleteEmployee '" + employeeID +"'", sqlConnection);

            delete.ExecuteNonQuery();
            sqlConnection.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully deleted.');", true);
            LoadRecord();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            
                string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            int employeeID = int.Parse(txtEmpID.Text);

            sqlConnection.Open();
            SqlCommand search = new SqlCommand("exec sp_SearchEmployeeByID '" + employeeID + "'", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(search);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}