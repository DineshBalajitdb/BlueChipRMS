<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meal.aspx.cs" Inherits="BcRMS.meal" %>

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
<h1>Meal Menu</h1>
</div>
<div class="menu">
<a href="menu.aspx">Back</a>
<a href="breakfast.aspx">Breakfast</a>
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
<td>Biriyani</td>
<td><img src="sources/FoodItem/Meals/biryani.jpg" alt="biriyani" style="width: 100px; height: 75px; background-image: url('sources/FoodItem/Meals/biryani.jpg');" /></td>
<td>
<asp:TextBox ID="txtBiriyaniQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtBiriyaniQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtBiriyaniPrice" runat="server" Text="150" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnBiryani" runat="server" Text="Order Now" OnClick="btnBiryani_Click" CssClass="button" />
</td>
</tr>
<tr>
<td>Panjabi Thali</td>
<td><img src="sources/FoodItem/Meals/punjabi.jpg" alt="panjab" style="width: 100px; height: 75px; background-image: url('sources/FoodItem/Meals/punjabi.jpg');" /></td>
<td>
<asp:TextBox ID="txtPanjabiQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtPanjabiQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtPanjabiPrice" runat="server" Text="250" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnPanjabi" runat="server" Text="Order Now" OnClick="btnPanjabi_Click" CssClass="button" />
</td>
</tr>
<tr>
<td>North Indian Thali</td>
<td><img src="sources/FoodItem/Meals/north.jpg" alt="north" style="width: 100px; height: 75px; background-image: url('sources/FoodItem/Meals/north.jpg');" /></td>
<td>
<asp:TextBox ID="txtNorthQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtNorthQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtNorthPrice" runat="server" Text="200" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnNorth" runat="server" Text="Order Now" OnClick="btnNorth_Click" CssClass="button" />
</td>
</tr>
<tr>
<td>South Indian Thali</td>
<td><img src="sources/FoodItem/Meals/south.jpg" alt="south" style="width: 100px; height: 75px; background-image: url('sources/FoodItem/Meals/south.jpg');" /></td>
<td>
<asp:TextBox ID="txtSouthQty" runat="server" TextMode="Number" min="1" Text="1" OnTextChanged="txtSouthQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</td>
<td>
<asp:TextBox ID="txtSouthPrice" runat="server" Text="180" ReadOnly="true"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnSouth" runat="server" Text="Order Now" OnClick="btnSouth_Click" CssClass="button" />
</td>
</tr>
</table>
<div class="header">
<h1>Welcome</h1>
</div>
</form>
</body>
</html>