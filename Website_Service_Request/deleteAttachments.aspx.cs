using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website_Service_Request
{
    public partial class deleteAttachments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filename = "";
            try
            {
                filename = Request.QueryString[0].ToString();
            }
            catch
            {
                filename = "";
            }
            if ((filename != null) && (filename.Length > 0))
            {
                deleteFile(filename);
            }
        }

        private void deleteFile(string filename)
        {
            try
            {
                File.Delete(Server.MapPath("App_Data/Attachments/" + Session["rStr"].ToString() + "/" + filename));
                Response.Redirect("uploadAttachments.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString() + "<br /><a href=\"javascript:history.back()\">Go back</a>");
            }
        }
    }
}
