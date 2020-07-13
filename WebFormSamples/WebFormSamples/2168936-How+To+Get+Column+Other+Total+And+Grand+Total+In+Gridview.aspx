<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2168936-How+To+Get+Column+Other+Total+And+Grand+Total+In+Gridview.aspx.cs" Inherits="WebFormSamples._2168936_How_To_Get_Column_Other_Total_And_Grand_Total_In_Gridview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.5.1.js" integrity="sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.10.2/underscore-min.js" integrity="sha512-HKvDCFVKg8ZPGjecy6on7UECEpE76Y86h3GaE4JMCz+deFWdjcW/tWnh0hCfaBvURvlOa9f5CNVzt7EFkulYbw==" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Card_No" HeaderText="Card No" />
                <asp:BoundField DataField="Day" HeaderText="Day" />
                <asp:BoundField DataField="Dates" HeaderText="Date" />
                <asp:BoundField DataField="ItemName" HeaderText="ItemName" />
                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                <asp:BoundField DataField="Value" HeaderText="Value" />
            </Columns>
        </asp:GridView>

        <script>
            function insertRow(table, quantity, value, index, totalString) {
                $('<tr>')
                    .append($('<td colspan=4 align="right">').html(totalString))
                    .append($('<td>').html(quantity))
                    .append($('<td>').html(value))
                    .insertAfter(table.find("tr:nth-child(" + (index) + ")"));
            }

            var group = [];
            var table = $("#GridView1")
            table.find("tr:nth-child(n+2)").each(function (i, item) {
                var card = $(item).find("td:first").text();
                var q = $(item).find("td:nth-child(5)").text();
                var v = $(item).find("td:nth-child(6)").text();

                var index = _.findIndex(group, function (obj) {
                    return obj.card == card
                });
                if (index < 0) {
                    var obj = {};
                    obj.card = card;
                    obj.count = 0;
                    obj.quantity = 0;
                    obj.value = 0;
                    index = group.length;
                    group[index] = obj;
                }
                group[index].lastIndex = i;
                group[index].count++;
                group[index].quantity += parseInt(q, 10);
                group[index].value += parseInt(v, 10);
            });

            var count1 = _.filter(group, function (item) { return item.count == 1 })
            insertRow(table,
                _.reduce(count1, function (sum, item) { return sum + item.quantity; }, 0),
                _.reduce(count1, function (sum, item) { return sum + item.value; }, 0),
                table.find("tr").length,
                'Other total');

            var group1 = _.filter(group, function (item) { return item.count != 1 });
            for (var i = group1.length - 1; i > -1; i--) {
                insertRow(table, group1[i].quantity, group1[i].value, group1[i].lastIndex + 2, 'Total');
            }
            insertRow(table,
                _.reduce(group, function (sum, item) { return sum + item.quantity; }, 0),
                _.reduce(group, function (sum, item) { return sum + item.value; }, 0),
                table.find("tr").length,
                'Grand Total');
        </script>
    </form>
</body>
</html>
