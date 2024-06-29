<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="demomenu.aspx.cs" Inherits="BcRMS.demomenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Restaurant Management System</title>
    <link rel="stylesheet" type="text/css" href="~/Css/Demomenu.css"/>
    <style>
        .header {
            position: relative;
        }
        .logout, .username, .cart {
            position: absolute;
            top: 10px;
        }
        .username {
            right: 150px;
        }
        .cart {
            right: 80px;
        }
        .logout {
            right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="header">
            <h1>Restaurant Management System</h1>
            <asp:Label ID="lblUserId" runat="server" CssClass="username"></asp:Label>
            <asp:LinkButton ID="btnCart" runat="server" CssClass="cart" PostBackUrl="~/CartPage.aspx">Cart</asp:LinkButton>
            <asp:LinkButton ID="btnLogout" runat="server" CssClass="logout" OnClick="btnLogout_Click">Logout</asp:LinkButton>
        </div>
        
        <div class="content">
            <div class="welcome">
                <h2>Welcome</h2>
            </div>
        </div>  
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                DataSourceID="ObjectDataSource1" DataTextField="CategoryName" 
                DataValueField="CategoryId" Height="16px" onprerender="Page_PreRender" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                ViewStateMode="Enabled" Width="144px">
            </asp:DropDownList>
        </div>
        <div>
            <asp:Repeater ID="Repeater1" runat="server" ViewStateMode="Enabled" >
                <ItemTemplate>
                    <div class="product-item">
                        <div class="product-image">
                            <img src='<%# GetBase64Image(Container.DataItem as BcRMS.MenuItem) %>' width="200px" height="150px" class="product-image" alt='<%# Eval("ItemName") %>' />
                        </div>
                        <div class="product-details">
                            <h2><%# Eval("ItemName") %></h2>
                            <p>Price: <%# Eval("Price", "{0:C}") %></p>
                            <asp:Button ID="BTNBUY" runat="server" Text="Order Now" CommandName="Order" CommandArgument='<%# Eval("FoodItemID") %>' CssClass="btn-buy" />
                            <asp:Button ID="Button1" runat="server" Text="Add to Cart" CommandName="cart" CommandArgument='<%# Eval("FoodItemID") %>' CssClass="btn-cart" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
         
        </div>
        <div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="GetAllCategory" TypeName="BcRMS.CategoryListDataAccessLayer">
            </asp:ObjectDataSource>
        </div>     
    </form>
</body>
</html>
