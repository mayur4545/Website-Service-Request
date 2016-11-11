using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Website_Service_Request
{
    public class ServiceRequest
    {
        private int recNum;

     
        public DateTime timeSubmitted { get; set; }
        public string reqname { get; set; }
        public string reqdivision { get; set; }
        public string reqphone { get; set; }
        public string reqbranch { get; set; }
        public string reqemail { get; set; }
        public string reqtype { get; set; }
        public string reqdescription { get; set; }
        public string reqpub { get; set; }
        public string reqdetaildescription { get; set; }
        public string sruid { get; set; }
        public string reqStatus { get; set; }
        public string approvedBy { get; set; }
        public DateTime approvalTime { get; set; }
        public int id { get; set; }


        internal bool insertInDB()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ConnectionString_SQLEXPRESS"];
            string connectionString = settings.ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            bool dbInserted = false;
            try
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO Requests ([timeSubmitted], [reqname], [reqdivision], [reqphone], [reqbranch], [reqemail], [reqtype], [reqdescription], [reqpub], [reqdetaildescription], [sruid], [reqStatus]) VALUES (@timeSubmitted, @reqname, @reqdivision, @reqphone, @reqbranch, @reqemail, @reqtype, @reqdescription, @reqpub, @reqdetaildescription, @sruid, @reqStatus);SELECT CAST(scope_identity() AS int);");
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = connection;
                cmd1.Parameters.AddWithValue("@timeSubmitted", this.timeSubmitted);
                cmd1.Parameters.AddWithValue("@reqname", this.reqname);
                cmd1.Parameters.AddWithValue("@reqdivision", this.reqdivision);
                cmd1.Parameters.AddWithValue("@reqphone", this.reqphone);
                cmd1.Parameters.AddWithValue("@reqbranch", this.reqbranch);
                cmd1.Parameters.AddWithValue("@reqemail", this.reqemail);
                cmd1.Parameters.AddWithValue("@reqtype", this.reqtype);
                cmd1.Parameters.AddWithValue("@reqdescription", this.reqdescription);
                cmd1.Parameters.AddWithValue("@reqpub", this.reqpub);
                cmd1.Parameters.AddWithValue("@reqdetaildescription", this.reqdetaildescription);
                cmd1.Parameters.AddWithValue("@sruid", this.sruid);
                cmd1.Parameters.AddWithValue("@reqStatus", this.reqStatus);

                connection.Open();
                this.id = (int)cmd1.ExecuteScalar();
                connection.Close();
                dbInserted = true;
            }
            catch (Exception ex)
            {
                connection.Close();
                dbInserted = false;
            }

            string test = this.id.ToString();
            return dbInserted;
        }

        internal void sendEmail()
        {
            try
            {
                string MsgFrom = "DMVWEB@dmv.ca.gov";
                string MsgTo = "Mayur.Patel@dmv.ca.gov";
                string MsgSubject = "Service Request Submitted by-" + this.reqname + ", Status: " + this.reqStatus;
                string MessageBody = this.getSrDetails();

                System.Net.Mail.MailMessage MessageToSend = new System.Net.Mail.MailMessage(MsgFrom, MsgTo, MsgSubject, MessageBody);
                MessageToSend.IsBodyHtml = true;

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("PRDFRDV01.ad.dmv.ca.gov");
                client.Send(MessageToSend); //uncomment when not debugging
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }
        }

        internal string getSrDetails()
        {
            string host = ConfigurationManager.AppSettings["EnvHost"].ToString();
            string output = "";
            output += "Requester's Name: " + this.reqname + "<br /><br />"
                + "Division: " + this.reqdivision + "<br /><br />"
                + "Phone Number: " + this.reqphone + "<br /><br />"
                + "Branch/Unit: " + this.reqbranch + "<br /><br />"
                + "Email Address: " + this.reqemail + "<br /><br />"
                + "Type of Request: " + this.reqtype + "<br /><br />"
                + "Description of website content being requested: " + this.reqdescription + "<br /><br />"
                + "Does this request add, modify or delete a DMV publication (for example, Fast Facts, How To Brochure, Handbook, Manual, Memo, etc)? : " + this.reqpub + "<br /><br />"
                + "Type of Request: " + this.reqpub + "<br /><br />"
                + "Detailed Description: " + this.reqdetaildescription + "<br /><br />"
                + "Status: " + this.reqStatus + "<br /><br />"
                + "ID: " + this.id+ "  " + "SRUID: " + this.sruid + " <br /><br />"
                + "<a href='" + host + "ViewRecord.aspx?RecID=" + this.id + "'>View Request</a>";
            return output;
        }
    }
}