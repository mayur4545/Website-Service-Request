<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Website_Service_Request.ManageUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Website Service Request</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Website Service Request</h1>
        <h3>Manage Users</h3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowSorting="True" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True"></asp:CommandField>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                <asp:BoundField DataField="adname" HeaderText="adname" SortExpression="adname"></asp:BoundField>
                <asp:BoundField DataField="reqname" HeaderText="reqname" SortExpression="reqname"></asp:BoundField>
                <asp:BoundField DataField="reqdivision" HeaderText="reqdivision" SortExpression="reqdivision"></asp:BoundField>
                <asp:BoundField DataField="reqphone" HeaderText="reqphone" SortExpression="reqphone"></asp:BoundField>
                <asp:BoundField DataField="reqbranch" HeaderText="reqbranch" SortExpression="reqbranch"></asp:BoundField>
                <asp:BoundField DataField="reqemail" HeaderText="reqemail" SortExpression="reqemail"></asp:BoundField>
                <asp:BoundField DataField="reqrole" HeaderText="reqrole" SortExpression="reqrole"></asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCC99"></FooterStyle>

            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Right" BackColor="#F7F7DE" ForeColor="Black"></PagerStyle>

            <RowStyle BackColor="#F7F7DE"></RowStyle>

            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#FBFBF2"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#848384"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#EAEAD3"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#575357"></SortedDescendingHeaderStyle>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString_SQLEXPRESS %>' SelectCommand="SELECT * FROM [Users] ORDER BY [reqname]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Users] WHERE [ID] = @original_ID AND (([adname] = @original_adname) OR ([adname] IS NULL AND @original_adname IS NULL)) AND (([reqname] = @original_reqname) OR ([reqname] IS NULL AND @original_reqname IS NULL)) AND (([reqdivision] = @original_reqdivision) OR ([reqdivision] IS NULL AND @original_reqdivision IS NULL)) AND (([reqphone] = @original_reqphone) OR ([reqphone] IS NULL AND @original_reqphone IS NULL)) AND (([reqbranch] = @original_reqbranch) OR ([reqbranch] IS NULL AND @original_reqbranch IS NULL)) AND (([reqemail] = @original_reqemail) OR ([reqemail] IS NULL AND @original_reqemail IS NULL)) AND (([reqrole] = @original_reqrole) OR ([reqrole] IS NULL AND @original_reqrole IS NULL))" InsertCommand="INSERT INTO [Users] ([adname], [reqname], [reqdivision], [reqphone], [reqbranch], [reqemail], [reqrole]) VALUES (@adname, @reqname, @reqdivision, @reqphone, @reqbranch, @reqemail, @reqrole)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Users] SET [adname] = @adname, [reqname] = @reqname, [reqdivision] = @reqdivision, [reqphone] = @reqphone, [reqbranch] = @reqbranch, [reqemail] = @reqemail, [reqrole] = @reqrole WHERE [ID] = @original_ID AND (([adname] = @original_adname) OR ([adname] IS NULL AND @original_adname IS NULL)) AND (([reqname] = @original_reqname) OR ([reqname] IS NULL AND @original_reqname IS NULL)) AND (([reqdivision] = @original_reqdivision) OR ([reqdivision] IS NULL AND @original_reqdivision IS NULL)) AND (([reqphone] = @original_reqphone) OR ([reqphone] IS NULL AND @original_reqphone IS NULL)) AND (([reqbranch] = @original_reqbranch) OR ([reqbranch] IS NULL AND @original_reqbranch IS NULL)) AND (([reqemail] = @original_reqemail) OR ([reqemail] IS NULL AND @original_reqemail IS NULL)) AND (([reqrole] = @original_reqrole) OR ([reqrole] IS NULL AND @original_reqrole IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="original_adname" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqname" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqdivision" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqphone" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqbranch" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqemail" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqrole" Type="String"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="adname" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqname" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqdivision" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqphone" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqbranch" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqemail" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqrole" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="adname" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqname" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqdivision" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqphone" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqbranch" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqemail" Type="String"></asp:Parameter>
                <asp:Parameter Name="reqrole" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_ID" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="original_adname" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqname" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqdivision" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqphone" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqbranch" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqemail" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_reqrole" Type="String"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
