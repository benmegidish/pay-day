<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication10.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="StyleSheet1.css" /> 
     <meta name="viewport" content="width=device-width, initial-scale=1"/>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>

    <link rel="stylesheet" href="StyleSheet1.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.6.2/chart.min.js" integrity="sha512-tMabqarPtykgDtdtSqCL3uLVM0gS1ZkUAVhRFu1vSEFgvB73niFQWJuvviDyBGBH22Lcau4rHB5p2K2T0Xvr6Q==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    
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
        <a href="HtmlPage1.html" class="sign-buttom">HOME</a>
    </header>
    <h2 style="color:coral; font-family:'Bernard MT'; text-decoration:underline dashed">Your First account lets go!</h2>
    
    <form runat="server" id="form1">
    <div class="container">
        <table class="table align-content-center">
            <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">ID</td>
                <td><asp:TextBox runat="server" ID="id"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator runat="server" ErrorMessage="Field required!" ControlToValidate="id" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">FirstNAME</td>
                <td><asp:TextBox runat="server" ID="firstname" ></asp:TextBox></td>
                <td><asp:RequiredFieldValidator runat="server" ErrorMessage="Field required!" ControlToValidate="firstname" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">LastName</td> 
                <td><asp:TextBox runat="server" ID="lastname"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator runat="server" ErrorMessage="Field required!" ControlToValidate="lastname" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
             <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">Gender</td>
               <td><asp:DropDownList runat="server" ID="gender">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:DropDownList></td> 
             </tr>
             <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">Email</td>
                <td><asp:TextBox runat="server" ID="email"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator runat="server" ErrorMessage="Field required!" ControlToValidate="email" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr >
            <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">Password</td>
                <td><asp:TextBox runat="server" ID="password" TextMode="Password"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator runat="server" ErrorMessage="Field required!" ControlToValidate="password" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">Address</td>
                <td><asp:TextBox runat="server" ID="address"></asp:TextBox></td>
            </tr>
             <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">UserName</td>
                <td><asp:TextBox runat="server" ID="username"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator runat="server" ErrorMessage="Field required!" ControlToValidate="username" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
             <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">Birthday</td>
                <td><asp:TextBox runat="server" ID="Bday" ></asp:TextBox></td>
                 <td><asp:RequiredFieldValidator runat="server" ErrorMessage="Field required!" ControlToValidate="Bday" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
             <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">Phone</td>
                <td><asp:TextBox runat="server" ID="userphone" ></asp:TextBox></td>
                 <td><asp:RequiredFieldValidator runat="server" ErrorMessage="Field required!" ControlToValidate="userphone" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
          <tr class="d-table-row">
                <td class="d-xl-table-cell text-black fw-bold">Choose Profile Pic</td>
                <td ><asp:FileUpload runat="server" ID="fileupload2" /></td>
            </tr>
          
            
        </table >
    </div>
        <br />
        <br />
        <div align="center">
            <p>Please Enter a few more details to begin your progress!</p>
            <table>
                <tr>
                    <td>Name of work place</td>
                    <td><asp:TextBox runat="server" ID="workplace"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Payment per Hour</td>
                    <td><asp:TextBox runat="server" ID="PerHour"></asp:TextBox></td>
                    
                </tr>
            </table>
        </div>
        <asp:Button runat="server" ID="Button1"  Text="submit" OnClick="Button1_Click"  />
    
    </form>

    <footer style="text-align:left; position:fixed">
        <h2 style="color:gray">
            BEN-MEGIDISH production...
      </h2>
    </footer>

   <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
     <script src="Scripts/jquery.signalR-2.2.2.min.js"></script>
    </body>

</html>
