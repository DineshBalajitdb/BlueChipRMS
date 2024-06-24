<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="breakfast.aspx.cs" Inherits="BcRMS.breakfast" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
<style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
        }
 
        .header {
            background-color: #F00;
            color: #fff;
            padding: 20px;
            text-align: center;
        }
 
        table {
            width: 100%;
            border-collapse: collapse;
        }
 
        th, td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }
 
        th {
            background-color: #4CAF50;
            color: white;
        }
 
        .button {
            background-color: #4CAF50;
            border: none;
            color: white;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
        }
        .style1
        {
            height: 92px;
        }
</style>
<link rel="stylesheet" type="text/css" href="~/Css/HomePage.css"/>
</head>
<body>
<div class="header">
<h1>Breakfast Menu</h1>
</div>
<div class="menu">
<a href="menu.aspx">Back</a>
<a href="meal.aspx">Meal</a>
<a href="drinks.aspx">Drinks</a>
<a href="cart.aspx">Cart</a>
 
</div>
<form id="form1" runat="server">
<table>
<tr>
<th>Item</th>
<th>Image</th>
<th>Quantity</th>
<th>Price</th>
<th>Action</th>
</tr>
<tr>
<td>idli</td>
<td><img src="sources/FoodItem/BreakFast/idli.jpg" alt="idli" 
                        style="width: 100px; height: 75px; background-image: url('sources/FoodItem/BreakFast/idli.jpg');" /></td>
<td>
<asp:TextBox ID="txtidliQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtidliQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtidliPrice" runat="server" Text="40" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnidli" runat="server" Text="Order Now" OnClick="btnidli_Click" CssClass="button" />
</td>
</tr>
<tr>
<td>dosa</td>
<td><img src="sources/FoodItem/BreakFast/dosa.jpg" alt="dosa" 
                        style="width: 100px; height: 75px; background-image: url('sources/FoodItem/BreakFast/dosa.jpg');" /></td>
<td>
<asp:TextBox ID="txtdosaQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtdosaQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtdosaPrice" runat="server" Text="50" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btndosa" runat="server" Text="Order Now" OnClick="btndosa_Click" CssClass="button" />
</td>
</tr>
<tr>
<td>puri</td>
<td><img src="sources/FoodItem/BreakFast/puri.jpg" alt="puri" 
                        style="width: 100px; height: 75px; background-image: url('sources/FoodItem/BreakFast/puri.jpg');" /></td>
<td>
<asp:TextBox ID="txtpuriQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtpuriQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtpuriPrice" runat="server" Text="60" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnpuri" runat="server" Text="Order Now" OnClick="btnpuri_Click" CssClass="button" />
</td>
</tr>
<tr>
<td class="style1">tea</td>
<td class="style1"><img src="sources/FoodItem/BreakFast/tea.jpg" alt="tea" 
                        style="width: 100px; height: 75px; background-image: url('sources/FoodItem/BreakFast/tea.jpg');" /></td>
<td class="style1">
<asp:TextBox ID="txtteaQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtteaQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td class="style1">
<asp:TextBox ID="txtteaPrice" runat="server" Text="10" ReadOnly="true"></asp:TextBox>
</td>
<td class="style1">
<asp:Button ID="btntea" runat="server" Text="Order Now" OnClick="btntea_Click" CssClass="button" />
</td>
</tr>
</table>
<div class="header">
<h1>Welcome</h1>
</div>
 
 
    </form>
</body>
</html>
