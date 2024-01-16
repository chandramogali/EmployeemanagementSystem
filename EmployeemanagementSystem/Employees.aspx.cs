using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EmployeemanagementSystem
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                GridView1.DataBind();
                LoadRecord();
            }
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

           
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            int Age = int.Parse(txtAge.Text);
            string Email = txtEmail.Text;
            string PhoneNumber = txtPhoneNumber.Text;
            decimal Salary = (int)decimal.Parse(txtSalary.Text);
            string Department = ddlDepartment.SelectedValue;
           
            string City = txtCity.Text;
            sqlConnection.Open();
            SqlCommand insert = new SqlCommand("exec sp_InsertEmployees  '" + FirstName + "' , '" + LastName + "', '" + Age + "', '" + Email + "', '" + PhoneNumber + "','" + Salary + "' ,'" + Department + "' ,'" + txtJoining.Text + "','" + City + "' ", sqlConnection);

            insert.ExecuteNonQuery();
            sqlConnection.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted.');", true);
            LoadRecord();
            clear();


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
        void clear()
        {
            
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAge.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtSalary.Text = "";
            ddlDepartment.SelectedValue = "";
            txtJoining.Text = "";
             txtCity.Text="";
        }
       

     

        protected void Reset_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Reset values.');", true);
            clear();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
            LoadRecord(); // Call a method to bind data to the GridView
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
           
            LoadRecord();
            // Call a method to bind data to the GridView
        }


        private void UpdateEmployee(int employeeID, string firstName, string lastName, int age, string email, string phoneNumber, decimal salary, string department, DateTime joiningDate, string city)
        {
            //Response.Write(employeeID);
            //Response.Write(firstName); 
            //Response.Write(lastName); 
            //Response.Write(age); 
            //Response.Write(email);
            //Response.Write(phoneNumber);
            //Response. Write(salary); 
            //Response.Write(department);
            //Response.Write(joiningDate);
            //Response.Write(city);
            // Replace the connection string and update logic with your actual implementation
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();


            // string updateQuery = " UPDATE Employees SET FiristName = '" + firstName + "', LastName='" + lastName + "', Age='" + age + "' ,Email='" + email + "',PhoneNumber='" + phoneNumber + "',Salary='" + salary + "',Department='" + department + "',JoiningDate='" + joiningDate + "',City='" + city + "' WHERE EmployeeID = " + employeeID + "";
            string updateQuery = "UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, Age=@Age, Email=@Email, " +
                      "PhoneNumber=@PhoneNumber, Salary=@Salary, Department=@Department, JoiningDate=@JoiningDate, City=@City " +
                      "WHERE EmployeeID=@EmployeeID";

            using (SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection))
            {
                updateCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                updateCommand.Parameters.AddWithValue("@FirstName", firstName);
                updateCommand.Parameters.AddWithValue("@LastName", lastName);
                updateCommand.Parameters.AddWithValue("@Age", age);
                updateCommand.Parameters.AddWithValue("@Email", email);
                updateCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                updateCommand.Parameters.AddWithValue("@Salary", salary);
                updateCommand.Parameters.AddWithValue("@Department", department);
                updateCommand.Parameters.AddWithValue("@JoiningDate", joiningDate);
                updateCommand.Parameters.AddWithValue("@City", city);

                updateCommand.ExecuteNonQuery();
            }

            Console.WriteLine("\nData updated successfully");
            sqlConnection.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully updated.');", true);
            GridView1.EditIndex = -1;
            LoadRecord();
            clear();
            //    SqlCommand update = new SqlCommand("sp_UpdateEmployee", sqlConnection);
            //    update.CommandType = CommandType.StoredProcedure;

            //    // Add parameters to the stored procedure
            //    update.Parameters.AddWithValue("@EmployeeID", employeeID);

            //    update.Parameters.AddWithValue("@FirstName", firstName);
            //    update.Parameters.AddWithValue("@LastName", lastName);
            //    update.Parameters.AddWithValue("@Age", age);
            //    update.Parameters.AddWithValue("@Email", email);
            //    update.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            //    update.Parameters.AddWithValue("@Salary", salary);
            //    update.Parameters.AddWithValue("@Department", department);
            //    update.Parameters.AddWithValue("@JoiningDate", joiningDate);
            //    update.Parameters.AddWithValue("@City", city);

            // Execute the stored procedure
            //update.ExecuteNonQuery();
            //sqlConnection.Close();
            ////ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully deleted.');", true);
            GridView1.EditIndex = -1;
                LoadRecord();
               

            
        }
            protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                int rowIndex = e.RowIndex;
                int employeeID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                string firstName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                string lastName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                int age = int.Parse(((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text);
                string email = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
                string phoneNumber = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
                decimal salary = decimal.Parse(((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text);
                string department = ((TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
                DateTime joiningDate = DateTime.Parse(((TextBox)GridView1.Rows[e.RowIndex].Cells[8].Controls[0]).Text);
                string city = ((TextBox)GridView1.Rows[e.RowIndex].Cells[9].Controls[0]).Text;

                UpdateEmployee(employeeID, firstName, lastName, age, email, phoneNumber, salary, department, joiningDate, city);
                //string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

                //SqlConnection sqlConnection = new SqlConnection(connectionString);

                //sqlConnection.Open();

                //string updateQuery = " UPDATE Employees SET FiristName = '" + firstName + "', LastName='"+lastName+ "', Age='"+age+ "' ,Email='"+email+ "',PhoneNumber='"+phoneNumber+ "',Salary='"+salary+ "',Department='"+department+ "',JoiningDate='"+joiningDate+ "',City='"+city+"' WHERE EmployeeID = " + employeeID + "";
                //SqlCommand updateCommond = new SqlCommand(updateQuery, sqlConnection);

                //updateCommond.ExecuteNonQuery();


                //Console.WriteLine("\nData updated successfully");
                //sqlConnection.Close();

                // Execute the stored procedure
               
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully updated.');", true);
                //GridView1.EditIndex = -1;
                //LoadRecord();
                //clear();

            }
            catch (Exception ex)
            {
                // Handle the exception, for example, log it or display an error message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"alert('Error: {ex.Message}');", true);
            }


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
               
                int employeeID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                // Delete the data using the obtained EmployeeID
                string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(connectionString);

                sqlConnection.Open();
                SqlCommand delete = new SqlCommand("exec sp_DeleteEmployee '" + employeeID + "'", sqlConnection);

                delete.ExecuteNonQuery();
                sqlConnection.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"alert('ID {employeeID} Deleted Successfully .');", true);
                LoadRecord();
                clear();
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or display an error message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"alert('Error: {ex.Message}');", true);
            }
        }

        
    }
}