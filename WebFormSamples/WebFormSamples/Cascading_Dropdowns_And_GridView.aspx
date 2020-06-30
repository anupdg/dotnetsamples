<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cascading_Dropdowns_And_GridView.aspx.cs" Inherits="WebFormSamples.Cascading_Dropdowns_And_GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="states" runat="server" AutoPostBack="True" OnSelectedIndexChanged="states_SelectedIndexChanged"></asp:DropDownList><br />
        <asp:DropDownList ID="cities" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cities_SelectedIndexChanged"></asp:DropDownList><br />
        <asp:GridView ID="gvData" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
