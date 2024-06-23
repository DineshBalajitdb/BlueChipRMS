<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="BcRMS.Loginpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <link rel="stylesheet" type="text/css" href="~/Css/Loginpage.css"/>
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form1-Login">
            <h2>Login</h2>
        </div>
        <div class="form1-input">
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <asp:Label ID="lblLoginType" runat="server" Text="Select Login Type:"></asp:Label>
                <asp:DropDownList ID="ddlLoginType" runat="server">
                    <asp:ListItem Value="0">Admin Login</asp:ListItem>
                    <asp:ListItem Value="1">User Login</asp:ListItem>
                </asp:DropDownList>
                <br/><br/>
                <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
         
                 <br />
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        
        <div class= "form1button">
            <asp:Button ID="Button2" runat="server" Text="Login" onclick="btnLogin_Click" 
                Width="399px" />
        </div>
        <div class ="form1-p">
            <p>If Your Not Registered. Go To <a href="Registrationpage.aspx"><b>Register..!</b></a></p>
        </div>
    </form>
   
</body>
</html>

