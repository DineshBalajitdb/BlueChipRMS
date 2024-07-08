<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MealPage.aspx.cs" Inherits="BcRMS.MealPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Restaurant Management System</title>
    <link rel="stylesheet" type="text/css" href="~/Css/Demomenu.css"/>
    <link rel="stylesheet" type="text/css" href="~/Css/MealPage.css"/>
    <script src="JScript1.js"></script>
</head>

<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
       
        <div class="header">
            <asp:Label ID="lblUserId" runat="server" CssClass="username"></asp:Label>
            <asp:LinkButton ID="btnLogout" runat="server" CssClass="logout" 
                 onclientclick="btnLogout_Click">Logout</asp:LinkButton>
            <h1>Restaurant Management System&nbsp;&nbsp;&nbsp; </h1>
             <div>
            <%-- <asp:LinkButton ID="lnkChangePassword" runat="server" CssClass="link-button" 
                OnClientClick="changePassword(); return false;" 
                onclick="lnkChangePassword_Click">
                <i class="fas fa-key"></i> Change Password
            </asp:LinkButton>--%>
             </div>
        </div>
        
        <div class="content">
            <div class="welcome">
                <h2>Welcome</h2>
            </div>
            <div class="menu">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="Button2" runat="server" PostBackUrl="~/Cart.aspx" Text="Cart" />
            </div>
        </div>  
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand1">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="product-image">
                                <img src='<%# GetBase64Image(Container.DataItem as BcRMS.MenuItem) %>' width="200px" height="150px" class="product-image" alt='<%# Eval("ItemName") %>' />
                            </div>
                            <div class="product-details">
                                <h2><%# Eval("ItemName") %></h2>
                                <p>Price: <%# Eval("Price", "{0:C}") %></p>
                                <asp:DropDownList ID="ddlQuantity" runat="server">
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                </asp:DropDownList>
                                <asp:Button ID="Button1" runat="server" Text="Add to Cart" CommandName="Order" CommandArgument='<%# Eval("FoodItemID") %>' CssClass="btn-cart" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>

              <!-- The Modal -->
        <div id="modal" class="modal">
            <div class="modal-content">
                <span class="close" onclick="closeModal()">&times;</span>
                <div id="passwordResetContent" style="display:none;">
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
                        <asp:TextBox ID="conformPassword" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="Enter Conform Password" ForeColor="Red" 
                            ControlToValidate="conformPassword">Enter Conform Password</asp:RequiredFieldValidator>
                         <br/>
                         <br/>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="txtNewPassword" ControlToValidate="conformPassword" 
                            ErrorMessage="Password didn't Match" ForeColor="Red">Password didn&#39;t Match</asp:CompareValidator>
                         <br/>                         
                         <br/>
                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Mobile Number:"></asp:Label><span class="mandatory">*</span>
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ValidationExpression="\d{10}"
                        ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid Mobile Number" 
                        ForeColor="Red">Invalid Mobile Number</asp:RegularExpressionValidator>
                    <br /><br />
                    <asp:Button ID="btnSendPasswordReset" runat="server" Text="Change" 
                         onclientclick="btnPasswordReset_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
