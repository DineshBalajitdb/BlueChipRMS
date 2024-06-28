<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MealPage.aspx.cs" Inherits="BcRMS.MealPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Restaurant Management System</title>
    <link rel="stylesheet" type="text/css" href="~/Css/Demomenu.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>Restaurant Management System</h1>
        </div>
        <div class="menu">
            <a href="BreakFastpage.aspx">BreakFast</a>
            <a href="DrinkPage.aspx">Drinks</a>
            <a href="cart.aspx">Cart</a>
        </div>
        <div class="content">
            <div class="welcome">
                <h2>Welcome</h2>
            </div>
        </div>  
        <div>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
                <ItemTemplate>
                    <div class="product-item">
                        <div class="product-image">
                            <img src='<%# GetBase64Image(Container.DataItem as BcRMS.MenuItem) %>' width="200px" height="150px" class="product-image" alt='<%# Eval("ItemName") %>' />
                        </div>
                        <div class="product-details">
                            <h2><%# Eval("ItemName") %></h2>
                            <p>Price: <%# Eval("Price", "{0:C}") %></p>
                            <asp:Button ID="BTNBUY" runat="server" Text="Order Now" CommandName="Buy" CommandArgument='<%# Eval("FoodItemID") %>' CssClass="btn-buy" />
                            <asp:Button ID="Button1" runat="server" Text="Add to Cart" CommandName="cart" CommandArgument='<%# Eval("FoodItemID") %>' CssClass="btn-cart" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
         
        </div>
        <div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetMenuItem" TypeName="BcRMS.MenuDataAccessLayer">
            </asp:ObjectDataSource>
        </div>     
    </form>
</body>
</html>
