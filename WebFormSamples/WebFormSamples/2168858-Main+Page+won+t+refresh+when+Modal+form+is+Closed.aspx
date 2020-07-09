<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2168858-Main+Page+won+t+refresh+when+Modal+form+is+Closed.aspx.cs" Inherits="WebFormSamples._2168858_Main_Page_won_t_refresh_when_Modal_form_is_Closed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <script>
            $(function () {
                $("#opener").click(function () {
                    event.preventDefault();
                    opendialog("http://localhost:41822/MyModal.aspx");
                })
                function opendialog(page) {
                    var $dialog = $('#somediv')
                        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            title: "Modal Test",
                            autoOpen: false,
                            dialogClass: 'dialog_fixed,ui-widget-header',
                            modal: true,
                            height: 500,
                            width: 900,
                            minWidth: 400,
                            minHeight: 400,
                            draggable: true,
                            close: function () { $(this).remove(); },
                            buttons: { "Close": function () { $(this).dialog("close"); $("#Button1").click(); } }
                        });
                    $dialog.dialog('open');
                }
            })
        </script>
        <a id="opener" href="return:void()"> Open dialog</a>
        <div id="somediv" style="display:none">Dialog content</div>
        <asp:Button ID="Button1" runat="server" Text="Button" style ="display:none" OnClick="Button1_Click" />
    </form>
</body>
</html>
