<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadAttachments.aspx.cs" Inherits="Website_Service_Request.UploadAttachments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Upload Attachments</title>
    <style>
        body {
            font-family: Arial;
        
            font-size: 0.8em;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="validationlbl" runat="server" Text=""></asp:Label><br />
    
     Attachment(s)  <asp:FileUpload ID="FileUpload1" runat="server" onchange="this.form.submit();"/> <br />    
       <table width="80%"><tr><td width="10%"></td><td width="60%">
           <asp:Label ID="fileListLbl" runat="server" Text="No File Attachments"></asp:Label></td></tr></table>
    </div>
    </form>
</body>
</html>