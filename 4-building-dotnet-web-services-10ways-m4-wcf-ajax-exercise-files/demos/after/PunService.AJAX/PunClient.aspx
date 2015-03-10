<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PunClient.aspx.cs" Inherits="PunService.AJAX.PunClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Services>
                <asp:ServiceReference Path="~/PunService.svc"/>
            </Services>
        </asp:ScriptManager>
        <script type="text/javascript">
            var service = new PunService();
            
            service.CreatePun({
                Title: "Chicken Poet",
                Joke: "A chicken crossing the road is poultry in motion"
            }, function () {
                alert("Created pun");
            }, function(error) {
                alert("An error occurred: " + error._message);
            });

            service.GetPuns(function(puns) {
                var table = document.getElementById("punlist");
                var output = "";
                for (var i = 0; i < puns.length; i++) {
                    output += "<tr><td>" + puns[i].PunID + "</td><td>" +
                        puns[i].Title + "</td><td>" + puns[i].Joke + "</td></tr>";
                }
                table.innerHTML = output;
            });
        </script>
    <div>
        <table id="punlist"></table>
    </div>
    </form>
</body>
</html>
