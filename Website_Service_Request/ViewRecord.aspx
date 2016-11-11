<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRecord.aspx.cs" Inherits="Website_Service_Request.ViewRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Website Service Request View Request</title>
    <style>
        body{font-family:Arial;
                 font-size:0.8em;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Website Service Request View Request</h1>
                <h3>Your Information:</h3>
        <table width="500px">
            <tr><td width="50%" valign="top">
                 Requester's Name:<br />
                
        <asp:Label ID="reqNametxtbox" runat="server" Text=""></asp:Label>
        <br /><br />

Phone Number:<br />
        <asp:Label ID="phonenumbertxtbox" runat="server"></asp:Label>
        <br /><br />

Email Address:<br />
        <asp:Label ID="emailtxtbox" runat="server"></asp:Label>
        <br /><br />
                </td>
                <td width="50%" valign="top">
                    Division:<br />
        <asp:Label ID="divisiontxtbox" runat="server"></asp:Label>
        <br /><br />

Branch/Unit:<br />
        <asp:Label ID="branchtxtbox" runat="server"></asp:Label>
        <br /><br />
                </td></tr>
        </table>
       <hr />
<h3>Request Information:</h3>
Type of Request: <br />
         <asp:RadioButtonList ID="typeRbl" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem>Internet (DMV website)</asp:ListItem>
            <asp:ListItem>Intranet (DMV Driver)</asp:ListItem>
        </asp:RadioButtonList>
        <br />
Description of website content being requested: <br />
        <asp:TextBox ID="descriptionTxtbox" runat="server" Width="90%"></asp:TextBox>
        <br /><br />

        Does this request add, modify or delete a DMV publication (for example, Fast Facts, How To Brochure, Handbook, Manual, Memo, etc)? : <br />
        <asp:RadioButtonList ID="pubRbl" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem>Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:RadioButtonList>
        <br />

        Detailed Description (If amending existing content please cut and paste the complete URL (website address, e.g., https://www.dmv.ca.gov/portal/dmv/detail/vr/smog) and content in the box below: <br />
        <asp:TextBox ID="detailedDescriptiontxtbox" runat="server" Width="90%" Height="90px" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
        <br /><br />
        Attachments: <i>*Optional</i><br /><br />
        <asp:Label ID="fileupdloadLbl" runat="server" Text=" "></asp:Label><br />
        <span style="font-size:0.8em"> SR# <asp:Label ID="srNumLbl" runat="server" Text="srNumLbl"></asp:Label></span>
        <br /><br />
        <asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click" />

    </div>
    </form>
</body>
</html>
