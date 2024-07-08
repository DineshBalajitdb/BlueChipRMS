<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BcRMS.Cart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Shopping Cart</title>
<style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 20px;
            padding: 0;
        }
 
        .container {
            max-width: 800px;
            margin: auto;
            background-color: #fff;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
 
        h2 {
            color: #333;
            text-align: center;
            margin-bottom: 20px;
        }
 
        #gvCart {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }
 
        #gvCart th,
        #gvCart td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }
 
        #gvCart th {
            background-color: #f2f2f2;
        }
 
        #btnCheckout {
            display: block;
            margin: auto;
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            text-align: center;
            text-decoration: none;
        }
 
        #btnCheckout:hover {
            background-color: #45a049;
        }
</style>
</head>
<body>
<form id="form1" runat="server">
<div class="container">
<h2>Shopping Cart</h2>
 
             <div class="menu">
<a href="MealPage.aspx">Back</a>
</div>
<asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        CellPadding="2" ForeColor="Black" GridLines="None">
    <AlternatingRowStyle BackColor="PaleGoldenrod" />
<Columns>
<asp:BoundField DataField="ItemName" HeaderText="Item" />
<asp:BoundField DataField="Quantity" HeaderText="Quantity" />
<asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
<asp:TemplateField HeaderText="Remove">
            <ItemTemplate>
                <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="RemoveItem" CommandArgument='<%# Container.DataItemIndex %>' OnClick="btnRemove_Click" />
            </ItemTemplate>
</asp:TemplateField>
</Columns>
    <FooterStyle BackColor="Tan" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" />
    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
        HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    <SortedAscendingCellStyle BackColor="#FAFAE7" />
    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
    <SortedDescendingCellStyle BackColor="#E1DB9C" />
    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
</asp:GridView>
<br />
<asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label>
<br />
<asp:Button ID="btnCheckout" runat="server" Text="Pay" OnClick="btnCheckout_Click" />
</div>
</form>
</body>
</html>
