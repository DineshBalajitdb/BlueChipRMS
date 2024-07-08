<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassWordReset.aspx.cs" Inherits="BcRMS.PassWordReset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PassWord Reset</title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
            <div id="modal" class="modal">
            <div class="modal-content">
                <div id="passwordResetContent">
                    <h2>Password Reset</h2>
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label><span class="mandatory">*</span>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtEmail" ErrorMessage="Invalid E-mail Id" ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                Font-Bold="True"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="usernamevalidation" runat="server" 
                            ErrorMessage="Enter the Username" ForeColor="Red" 
                            ControlToValidate="txtEmail">Enter the Email</asp:RequiredFieldValidator>
                            <br/>
                            <br/>
                        <asp:Label ID="Label2" runat="server" Text="Old Password"></asp:Label><span class="mandatory">*</span>
                        <asp:TextBox ID="txtoldPassword" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Enter Old Password" ForeColor="Red" 
                            ControlToValidate="txtoldPassword">Enter Old Password</asp:RequiredFieldValidator>
                         <br/>
                         <br/>
                        <asp:Label ID="Label3" runat="server" Text="New Password"></asp:Label><span class="mandatory">*</span>
                        <asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="Enter New Password" ForeColor="Red" 
                            ControlToValidate="txtNewPassword">Enter New Password</asp:RequiredFieldValidator>
                         <br/>
                         <br/>
                        <asp:Label ID="Label4" runat="server" Text="Conform Password"></asp:Label><span class="mandatory">*</span>
                        <asp:TextBox ID="txtconformPassword" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="Enter Conform Password" ForeColor="Red" 
                            ControlToValidate="txtconformPassword">Enter Conform Password</asp:RequiredFieldValidator>
                         &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="txtconformPassword" ControlToValidate="txtNewPassword" 
                            ErrorMessage="Password didn't Match" ForeColor="Red">Password didn&#39;t Match</asp:CompareValidator>
                         <br/>
                         <br/>
                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Mobile Number:"></asp:Label><span class="mandatory">*</span>
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ValidationExpression="\d{10}"
                        ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid Mobile Number" 
                        ForeColor="Red">Invalid Mobile Number</asp:RegularExpressionValidator>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ErrorMessage="RequiredFieldValidator" ForeColor="Red"  ControlToValidate="txtPhoneNumber"></asp:RequiredFieldValidator>
                    <br /><br />
                    <asp:Button ID="btnSendPasswordReset" runat="server" Text="Change" 
                        onclick="btnSendPasswordReset_Click" />
                </div>               
            </div>
        </div>
    </div>
    </form>
</body>
</html>
