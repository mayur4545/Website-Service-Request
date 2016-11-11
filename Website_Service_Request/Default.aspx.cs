using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website_Service_Request
{
    public partial class Default : System.Web.UI.Page
    {
        string rStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (checkUser())
            {
                try
                {
                    rStr = Session["rStr"].ToString();
                }
                catch (Exception ex)
                {
                    rStr = Guid.NewGuid().ToString();
                    Session["rStr"] = rStr;
                }
                srNumLbl.Text = rStr;
                fileupdloadLbl.Text = "<iframe src=\"UploadAttachments.aspx\" width=\"500px\" height=\"150px\" frameBorder=\"0\"></iframe> ";
            }
            else
            {
                //Redirect to unauthorized page
                Response.Redirect("Unauthorized.aspx");
            }
        }

        private bool checkUser()
        {
            bool valid = false;

            string username;
            username = ConfigurationManager.AppSettings["UserAD"].ToString().ToUpper();
            if(username == "")
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

                while (reader.Read() == true) //Load user info
                {
                    reqNametxtbox.Text = reader["reqname"].ToString();
                    divisiontxtbox.Text = reader["reqdivision"].ToString();
                    phonenumbertxtbox.Text = reader["reqphone"].ToString();
                    branchtxtbox.Text = reader["reqbranch"].ToString();
                    emailtxtbox.Text = reader["reqemail"].ToString();
                    valid = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            conn.Close();
            return valid;
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            ServiceRequest sr = new ServiceRequest();
            sr.timeSubmitted = DateTime.Now; 
            sr.reqname = reqNametxtbox.Text;
            sr.reqdivision = divisiontxtbox.Text;
            sr.reqphone = phonenumbertxtbox.Text;
            sr.reqbranch = branchtxtbox.Text;
            sr.reqemail = emailtxtbox.Text;
            sr.reqtype = typeRbl.SelectedValue;
            sr.reqdescription = descriptionTxtbox.Text;
            sr.reqpub = pubRbl.SelectedValue;
            sr.reqdetaildescription = detailedDescriptiontxtbox.Text;
            sr.sruid = Session["rStr"].ToString();
            sr.reqStatus = "PENDING";

            if(sr.insertInDB()) //insert data in DB
            {
                Response.Write("Success");
                sr.sendEmail(); //Submit email
                //Response.Write(sr.getSrDetails());
            }
            else
            {
                
            }
        }
        
    }
}