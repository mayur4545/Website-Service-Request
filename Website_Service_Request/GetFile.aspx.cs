using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website_Service_Request
{
    public partial class GetFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string filename = "";
            string recID = "";
            try
            {
                filename = Request.QueryString[1].ToString();
                recID = Request.QueryString[0].ToString();
            }
            catch
            {
                filename = "";
            }
            if ((filename != null) && (filename.Length > 0))
            {
                getfiles(filename, recID);
            }
        }

        private void getfiles(string filename, string recID)
        {
            try
            {

                string filepath = (Server.MapPath("App_Data/Attachments/" + recID + "/" + filename));
                Response.Buffer = true;
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + filename.Substring(18));
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(filepath);

            }
            catch (Exception ex)
            {
                // Response.Write(ex.ToString());
                Response.Write("Record is not found");
                reportError("Failed at getfiles(string filename) GetFile.aspx.cs <br /> " + ex.ToString());
            }
        }

        private void reportError(string input)
        {
            string MsgFrom = "DMVWEB@dmv.ca.gov";
            string MsgTo = "DMVWEB@dmv.ca.gov";
            string MsgSubject = "ISD Service Request";

            string MessageBody = "ISD Service Request";
            MessageBody += "<br /><br />";
            MessageBody += "USER: " + Request.ServerVariables["LOGON_USER"].ToString().ToUpper();
            MessageBody += "<br /><br />";
            MessageBody += input;
            System.Net.Mail.MailMessage MessageToSend = new System.Net.Mail.MailMessage(MsgFrom, MsgTo, MsgSubject, MessageBody);
            MessageToSend.IsBodyHtml = true;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("PRDFRDV01.ad.dmv.ca.gov");
            client.Send(MessageToSend); //uncomment when not debugging
        }
    }
}