<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebApplication10.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <div>
                     <asp:Label runat="server" Text="Phone"></asp:Label>
                     <asp:TextBox runat="server" ID="Pnum"></asp:TextBox>
                </div>
            <div>
                <asp:Label runat="server" Text="Please enter message"></asp:Label>
                <asp:TextBox runat="server" ID="MSG"></asp:TextBox>
            </div>
            <asp:Button runat="server" Text="Send" OnClick="Unnamed_Click" />

        </div>
    </form>
</body>
</html>
