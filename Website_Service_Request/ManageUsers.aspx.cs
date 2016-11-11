using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website_Service_Request
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!checkUser())
                Response.Redirect("Unauthorized.aspx"); //Redirect to unauthorized page
        }

        private bool checkUser()
        {
            bool valid = false;

            string username;
            username = ConfigurationManager.AppSettings["UserAD"].ToString();
            if (username == "")
                username = Request.ServerVariables["LOGON_USER"].ToString().ToUpper();
            username = username.Replace("AD\\", "");
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString_SQLEXPRESS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.ConnectionString = connString;

            string query = "SELECT * FROM Users WHERE adname = " + "@adname" + ";";
            SqlCommand cmd1 = new SqlCommand(query, conn);

            try
            {
                cmd1.Connection.Open();
                cmd1.Parameters.AddWithValue("@adname", username);
                cmd1.ExecuteNonQuery();
                SqlDataReader reader = cmd1.ExecuteReader();
                string role = "";
                while (reader.Read() == true) //Load user info
                {
                    role = reader["reqrole"].ToString();
                    if (role.ToUpper() == "APPROVER")
                    {
                        valid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            conn.Close();
            return valid;
        }
        protected void addBtn_Click(object sender, EventArgs e)
        {
            if ((adNameTxtbox.Text.Trim().Length > 0) && (nameTxtbox.Text.Trim().Length > 0) && (divisionTxtbox.Text.Trim().Length > 0) && (phoneTxtbox.Text.Trim().Length > 0) && (branchTxtbox.Text.Trim().Length > 0) && (emailTxtbox.Text.Trim().Length > 0))
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ConnectionString_SQLEXPRESS"];
                string connectionString = settings.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                bool dbInserted = false;
                try
                {
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO Users ([adname], [reqname], [reqdivision], [reqphone], [reqbranch], [reqemail], [reqrole] ) VALUES (@adname, @reqname, @reqdivision, @reqphone, @reqbranch, @reqemail, @reqrole);SELECT CAST(scope_identity() AS int);");
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Connection = connection;
                    cmd1.Parameters.AddWithValue("@adname", adNameTxtbox.Text.Trim().ToUpper());
                    cmd1.Parameters.AddWithValue("@reqname", nameTxtbox.Text.Trim());
                    cmd1.Parameters.AddWithValue("@reqdivision", divisionTxtbox.Text.Trim());
                    cmd1.Parameters.AddWithValue("@reqphone", phoneTxtbox.Text.Trim());
                    cmd1.Parameters.AddWithValue("@reqbranch", branchTxtbox.Text.Trim());
                    cmd1.Parameters.AddWithValue("@reqemail", emailTxtbox.Text.Trim());
                    cmd1.Parameters.AddWithValue("@reqrole", roleDDL.SelectedValue);

                    connection.Open();
                    int id = (int)cmd1.ExecuteScalar();
                    connection.Close();
                    dbInserted = true;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Response.Write(ex.ToString());
                    dbInserted = false;
                }
                if (dbInserted)
                {
                    Response.Redirect("ManageUsers.aspx");
                }
            }
            else
            {
                Response.Write("Please complete all empty fields");
            }
        }
    }
}