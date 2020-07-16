<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2169072-Create+a+text+delimited+string+of+content+and+display+separated+text+in+control+on+page.aspx.cs" Inherits="WebFormSamples._2169072_Create_a_text_delimited_string_of_content_and_display_separated_text_in_control_on_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater ID="rpt" runat="server">
            <ItemTemplate>
                <asp:TextBox runat="server"
                    Text="<%# Container.DataItem %>" ReadOnly="true"></asp:TextBox><br />
            </ItemTemplate>
        </asp:Repeater>
        <fieldset>
            New content:
            <asp:TextBox ID="txtNewData" runat="server"></asp:TextBox>
            <asp:Button ID="btnAddNew" runat="server" Text="Add new" OnClick="btnAddNew_Click" />
        </fieldset>
    </form>
</body>
</html>
