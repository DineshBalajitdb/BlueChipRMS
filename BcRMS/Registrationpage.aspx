<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrationpage.aspx.cs" Inherits="BcRMS.Registrationpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UserRegister form</title>
    <link rel="stylesheet" type="text/css" href="~/Css/Registrationpage.css"/>
</head>
<body>
   
   <form id="form1" runat="server">
    <h2>User Registration Form</h2>
    <div>
                <br />
    <asp:Label ID="Label6" runat="server" Text="UserName"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server" ></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="TextBox6" ErrorMessage="Invalid E-mail Id" ForeColor="Red" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            Font-Bold="True"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="usernamevalidation" runat="server" 
        ErrorMessage="Enter the Username" ForeColor="Red" 
        ControlToValidate="TextBox6">Enter the Username</asp:RequiredFieldValidator>
          <br />
    </div>
    <div>
  
        <asp:Label ID="Label7" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" 
         TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox7" ErrorMessage="Enter the Password " ForeColor="Red">Enter the Password </asp:RequiredFieldValidator>
    <br />
    </div>
    <div>
    <asp:Label ID="Label8" runat="server" Text="Confirm Password"></asp:Label>
    <asp:TextBox ID="TextBox8" runat="server" 
        TextMode="Password"></asp:TextBox>
     <br/>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="TextBox7" ControlToValidate="TextBox8" 
        ErrorMessage="Password didn't Match" ForeColor="Red">Password didn&#39;t Match</asp:CompareValidator>
     
    <br />
    </div>
    <div  class ="Registerbutton "style="height: 169px">
        <br />
        <asp:Label ID="Label4" runat="server" Text="Phone Number"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" TextMode="Phone"></asp:TextBox>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ValidationExpression="\d{10}"
                ControlToValidate="TextBox4" ErrorMessage="Invalid Mobile Number" 
                ForeColor="Red">Invalid Mobile Number</asp:RegularExpressionValidator>
            
        <br />
        <br />
            
        <asp:Button ID="Button1" runat="server" Text="Register" 
            onclick="Button1_Click" />
            
        <br />
            
        <br />
        <asp:Label ID="notificationlbl" runat="server" Font-Size="Larger" 
            ForeColor="#66FF66" Height="67px" Text="Label" Width="347px"></asp:Label>
            
    </div>
    <div>
     <p>If Your Already Registered. Go To <a href="Loginpage.aspx"><b>Login..!</b></a></p>
     </div>
       
    </form> 
    

</body>
</html>