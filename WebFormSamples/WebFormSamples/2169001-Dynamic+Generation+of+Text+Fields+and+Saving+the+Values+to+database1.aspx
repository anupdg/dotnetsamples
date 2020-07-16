<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2169001-Dynamic+Generation+of+Text+Fields+and+Saving+the+Values+to+database1.aspx.cs" Inherits="WebFormSamples._2169001_Dynamic_Generation_of_Text_Fields_and_Saving_the_Values_to_database1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="container" ></asp:Panel>
        <asp:LinkButton ID="btnAddAnother" runat="server" OnClick="btnAddAnother_Click">+ Add new</asp:LinkButton>
        <br />
        <asp:Button ID="btnGetValues" runat="server" Text="Get values" OnClick="btnGetValues_Click"  />
    </form>
</body>
</html>
