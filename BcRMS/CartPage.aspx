<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="BcRMS.CartPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Shopping Cart</title>
    <link rel="stylesheet" type="text/css" href="~/Css/Cart.css" />
     <link rel="stylesheet" type="text/css" href="~/Css/HomePage.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Shopping Cart</h1>
            <asp:Repeater ID="RepeaterCartItems" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>Item</th>
                                <th>Price</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ItemName") %></td>
                        <td><%# Eval("Price", "{0:C}") %></td>
                        <td>
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("FoodItemID") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label ID="lblTotalPrice" runat="server" Text="Total: "></asp:Label>
            <br />
            <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" OnClick="btnCheckout_Click" />
        </div>
    </form>
</body>
</html>