<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MealPage.aspx.cs" Inherits="BcRMS.MealPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Restaurant Management System</title>
    <link rel="stylesheet" type="text/css" href="~/Css/Demomenu.css"/>
    <link rel="stylesheet" type="text/css" href="~/Css/MealPage.css"/>
  
</head>

<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
       
        <div class="header">
            <asp:Label ID="lblUserId" runat="server" CssClass="username"></asp:Label>
            <asp:LinkButton ID="btnLogout" runat="server" CssClass="logout" 
                 onclick="btnLogout_Click">Logout</asp:LinkButton>
            <h1>Restaurant Management System&nbsp;&nbsp;&nbsp; </h1>
             <div>
             <asp:LinkButton ID="lnkChangePassword" runat="server" CssClass="link-button" 
                PostBackUrl="~/PassWordReset.aspx">
                <i class="fas fa-key"></i> Change Password
             </asp:LinkButton>

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
    </form>
</body>
</html>
