<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="BcRMS.cart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="
http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Cart</title>
<link rel="stylesheet" type="text/css" href="~/StyleSheet1.css"/>
</head>
<body>
<div class="header">
<h1>Add To Cart</h1>
</div>
<div class="menu">
<a href="menu.aspx">Back</a>
<a href="breakfast.aspx">Breakfast</a>
<a href="cart.aspx">Cart</a>
</div>
<form id="form1" runat="server">
<asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4" ForeColor="#333333">
<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>
<asp:BoundField DataField="ItemName" HeaderText="Item" />
<asp:BoundField DataField="Quantity" HeaderText="Quantity" />
<asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:c}" />
<asp:TemplateField HeaderText="Total">
<ItemTemplate>
<%# decimal.Parse(Eval("Quantity").ToString()) * decimal.Parse(Eval("Price").ToString()) %>
</ItemTemplate>
</asp:TemplateField>
</Columns>
<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
<SortedAscendingCellStyle BackColor="#E9E7E2" />
<SortedAscendingHeaderStyle BackColor="#506C8C" />
<SortedDescendingCellStyle BackColor="#FFFDF8" />
<SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
<br />
<asp:Button ID="btnCheckout" runat="server" Text="Checkout" CssClass="button" OnClick="btnCheckout_Click" />
</form>
</body>
</html>