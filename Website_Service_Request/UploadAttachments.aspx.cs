using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website_Service_Request
{
    public partial class UploadAttachments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Session["rStr"] = generateuniquefile();
                uploadFile(Session["rStr"].ToString());
            }
            catch (Exception ex)
            {
                //Response.Write("Your Session has expired. Please start over again" + "<br />" + ex.ToString());
            }
        }

        private void uploadFile(string p) //UPLOADS FILE TO "ATTACHMENTS" FOLDER
        {
            if (FileUpload1.HasFile)
            {
                if (!(Directory.Exists(Server.MapPath("App_Data/Attachments/" + p)))) //p = Session["rStr"] 
                {
                    Directory.CreateDirectory(Server.MapPath("App_Data/Attachments/" + p));  //p = Session["rStr"]
                }
            }
            if (FileUpload1.HasFile) //need to convert to uppercase
            {
                if ((FileUpload1.FileName.ToLower().EndsWith(".doc") || (FileUpload1.FileName.ToLower().EndsWith(".pdf")) || (FileUpload1.FileName.ToLower().EndsWith(".docx")) || (FileUpload1.FileName.ToLower().EndsWith(".xls")) || (FileUpload1.FileName.ToLower().EndsWith(".xlsx")) || (FileUpload1.FileName.ToLower().EndsWith(".xltx")) || (FileUpload1.FileName.ToLower().EndsWith(".tiff")) || (FileUpload1.FileName.ToLower().EndsWith(".jpg")) || (FileUpload1.FileName.ToLower().EndsWith(".png")) || (FileUpload1.FileName.ToLower().EndsWith(".gif"))))
                {

                    try
                    {
                        FileUpload1.SaveAs((Server.MapPath("App_Data/Attachments/" + Session["rStr"].ToString() + "/attachment_" + DateTime.Now.ToString("HHmmss") + "_" + FileUpload1.FileName)));
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                }
                else
                {
                    Response.Write("<span style=\"color:red; font-size:1.2em;\">Sorry, we only accept files with format in pdf,word,exel,jpg,png,gif</span>");
                }
            }
            showFiles();
        }

        private void showFiles()  // SHOWS WHICH FILES ARE ALREADY IN THE FOLDER
        {
            fileListLbl.Text = " ";
            string[] filePaths = Directory.GetFiles(Server.MapPath("App_Data/Attachments/" + Session["rStr"].ToString()));
            for (int i = 0; i < filePaths.Length; i++)
            {
                fileListLbl.Text += "<a href=\"GetFile.aspx?RecID=" + Session["rStr"].ToString() + "&filename=" + Path.GetFileName(filePaths[i]) + "\" target=\"_blank\">" + Path.GetFileName(filePaths[i]).Substring(18) + "</a>&nbsp;&nbsp;&nbsp; <a href=\"DeleteAttachments.aspx?File=" + Path.GetFileName(filePaths[i]) + "\">Delete<img src=\"images/document_delete.jpg\"></a><br />";
            }
            fileListLbl.Text += "<br />";
        }


    }
}