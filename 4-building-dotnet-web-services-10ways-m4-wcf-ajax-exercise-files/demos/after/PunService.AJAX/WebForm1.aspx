<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PunService.AJAX.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager runat="server" ID="ScriptManager">
        <Services>
            <asp:ServiceReference Path="~/PunService.svc"/>
        </Services>
    </asp:ScriptManager>
        <script type="text/javascript">
            new PunService().CreatePun({ PunID: 0, Title: 'test', Joke: 'test' }, function() { alert('done'); });
        </script>
    </div>
    </form>
</body>
</html>
