<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="drinks.aspx.cs" Inherits="BcRMS.drinks" %>

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
</style>
<link rel="stylesheet" type="text/css" href="~/Css/HomePage.css"/>
</head>
<body>
<div class="header">
<h1>Drinks menu</h1>
</div>
<div class="menu">
<a href="menu.aspx">Back</a>
<a href="breakfast.aspx">Breakfast</a>
<a href="meal.aspx">Meal</a>
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
<td>Lassi</td>
<td><img src="sources/FoodItem/Drinks/lassi.jpg" alt="Lassi" 
                        style="width: 100px; height: 75px; background-image: url('sources/FoodItem/Drinks/lassi.jpg');" /></td>
<td>
<asp:TextBox ID="txtLassiQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtLassiQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtLassiPrice" runat="server" Text="40" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnLassi" runat="server" Text="Order Now" 
                        OnClick="btnLassi_Click" CssClass="button" PostBackUrl="cart.aspx" />
</td>
</tr>
<tr>
<td>Limbu Soda</td>
<td><img src="sources/FoodItem/Drinks/Limbu.jpg" alt="Limbu" 
                        style="border-color: #000000; width: 100px; height: 75px; background-image: url('sources/FoodItem/Drinks/Limbu.jpg');" /></td>
<td>
<asp:TextBox ID="txtLimbuQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtLimbuQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtLimbuPrice" runat="server" Text="50" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnLimbu" runat="server" Text="Order Now" 
                        OnClick="btnLimbu_Click" CssClass="button" PostBackUrl="cart.aspx" />
</td>
</tr>
<tr>
<td>Faluda</td>
<td><img src="sources/FoodItem/Drinks/faluda.jpg" alt="Faluda" 
                        style="width: 100px; height: 75px; background-image: url('sources/FoodItem/Drinks/faluda.jpg');" /></td>
<td>
<asp:TextBox ID="txtFaludaQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtFaludaQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtFaludaPrice" runat="server" Text="60" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnFaluda" runat="server" Text="Order Now" 
                        OnClick="btnFaluda_Click" CssClass="button" PostBackUrl="cart.aspx" />
</td>
</tr>
<tr>
<td>Choco Milkshek</td>
<td><img src="sources/FoodItem/Drinks/choc.jpg" alt="Choco" 
                        style="width: 100px; height: 75px; background-image: url('sources/FoodItem/Drinks/choc.jpg');" /></td>
<td>
<asp:TextBox ID="txtChocoQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtChocoQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtChocoPrice" runat="server" Text="10" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnChoco" runat="server" Text="Order Now" 
                        OnClick="btnChoco_Click" CssClass="button" PostBackUrl="cart.aspx" />
</td>
</tr>
</table>
<div class="header">
<h1>Welcome</h1>
</div>
</form>
</body>
</html>
