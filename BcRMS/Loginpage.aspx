<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="BcRMS.Loginpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Css/Loginpage.css"/>
    <title>Login Page</title>
    <style>
        .modal {
            display: none;
            position: fixed;
            z-index: 1;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto;
            background-color: rgb(0,0,0);
            background-color: rgba(0,0,0,0.4);
            padding-top: 60px;
        }
        .modal-content {
            background-color: #fefefe;
            margin: 5% auto;
            padding: 20px;
            border: 1px solid #888;
            width: 30%;
        }
        .close {
            color: #aaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }
        .close:hover,
        .close:focus {
            color: black;
            text-decoration: none;
            cursor: pointer;
        }
        .mandatory {
        color: red;
    }
    </style>
    <script type="text/javascript">
        function openModal(type) {
            document.getElementById('modal').style.display = "block";
            if (type === 'password') {
                document.getElementById('passwordResetContent').style.display = "block";
                document.getElementById('usernameResetContent').style.display = "none";
            } else {
                document.getElementById('passwordResetContent').style.display = "none";
                document.getElementById('usernameResetContent').style.display = "block";
            }
        }

        function closeModal() {
            document.getElementById('modal').style.display = "none";
        }
    </script>
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
            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label><span class="mandatory">*</span>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label><span class="mandatory">*</span>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        
        <div class="form1button">
            <asp:Button ID="Button2" runat="server" Text="Login" OnClick="btnLogin_Click" 
                Width="399px" onclientclick="btnLogin_Click" />
            <br /><br />
            <asp:Button ID="btnForgetPassword" runat="server" Font-Bold="True" Font-Names="Times New Roman" 
                        OnClientClick="openModal('password'); return false;" Text="Forget Password" Width="115px" />
            <asp:Button ID="btnForgetUsername" runat="server" Font-Bold="True" Font-Names="Times New Roman" 
                        OnClientClick="openModal('username'); return false;" Text="Forget Username" Width="115px" />
        </div>
        <div class="form1-p">
            <p>If You Are Not Registered, Go To <a href="Registrationpage.aspx"><b>Register..!</b></a></p>
        </div>

        <!-- The Modal -->
        <div id="modal" class="modal">
            <div class="modal-content">
                <span class="close" onclick="closeModal()">&times;</span>
                <div id="passwordResetContent" style="display:none;">
                    <h2>Retrieve Password</h2>
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label><span class="mandatory">*</span>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtEmail" ErrorMessage="Invalid E-mail Id" ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                Font-Bold="True"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="usernamevalidation" runat="server" 
                            ErrorMessage="Enter the Username" ForeColor="Red" 
                            ControlToValidate="txtEmail">Enter the Username</asp:RequiredFieldValidator><br/><br/>
                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Mobile Number:"></asp:Label><span class="mandatory">*</span>
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ValidationExpression="\d{10}"
                        ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid Mobile Number" 
                        ForeColor="Red">Invalid Mobile Number</asp:RegularExpressionValidator>
                    <br /><br />
                    <asp:Button ID="btnSendPasswordReset" runat="server" Text="Send" OnClick="btnSendPasswordReset_Click" />
                </div>
                <div id="usernameResetContent" style="display:none;">
                    <h2>Retrieve Username</h2>
                    <asp:Label ID="lblMobileNumber" runat="server" Text="Enter your Mobile Number:"></asp:Label><span class="mandatory">*</span>
                    <asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ValidationExpression="\d{10}"
                        ControlToValidate="txtMobileNumber" ErrorMessage="Invalid Mobile Number" 
                        ForeColor="Red">Invalid Mobile Number</asp:RegularExpressionValidator>
                    <br /><br />
                    <asp:Button ID="btnSendUsername" runat="server" Text="Send" OnClick="btnSendUsername_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
