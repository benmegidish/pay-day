<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication10.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <link rel="stylesheet" href="StyleSheet1.css" />
    <title></title>
</head>
<body class="body">
    <header style="text-align:left">
        <svg height="130" width="300">
            <defs>
                <linearGradient id="grad1" x1="0%" y1="0%" x2="100%" y2="0%">
                    <stop offset="0%" style="stop-color:rgb(255,255,0);stop-opacity:1" />
                    <stop offset="100%" style="stop-color:rgb(255,0,0);stop-opacity:1" />
                </linearGradient>
            </defs>
            <ellipse cx="100" cy="70" rx="85" ry="55" fill="url(#grad1)" />
            <text fill="#ffffff" font-size="38" font-family="Verdana" x="18" y="86">PAY-DAY</text>
            <a href="HtmlPage1.html" class="sign-buttom">HOME</a>

        </svg>
      </header>
    <form id="form1" runat="server">
        <div style="left:50%" >
            
        <h2 style="font-style: italic; text-decoration: underline">LogIN Page</h2>

        </div>
    
        <div class="container">
            <table class="col-md">
                <tr>
                    <td><asp:Label runat="server">
                        User Name
                    </asp:Label></td>
                    <td ><asp:TextBox runat="server" ID="Username"></asp:TextBox></td>
                </tr>
                <tr>
                   <td> <asp:Label runat="server">
                        Password
                    </asp:Label></td>
                   <td><asp:TextBox runat="server" ID="password" textmode="Password"></asp:TextBox></td>
                  </tr>
            </table>
            <asp:Button runat="server" ID="log" text="Login" OnClick="log_Click"/>

        </div>
    </form>
   <script src="js/jquery-3.6.0.min.js"></script>
   <script src="js/bootstrap.js"></script>
</body>
</html>
