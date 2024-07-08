<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderConfiramtion.aspx.cs" Inherits="BcRMS.orderConfiramtion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Order Confirmation</title>
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
 
        .order-details {
            margin-bottom: 20px;
        }
 
        .order-details label {
            font-weight: bold;
        }
 
        .order-details span {
            margin-left: 10px;
        }
 
        .error-message {
            color: red;
            font-style: italic;
        }
 
        .btn-payment {
            display: block;
            width: 100px;
            margin: auto;
            margin-top: 20px;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
        }
 
        .btn-payment:hover {
            background-color: #45a049;
        }
</style>
</head>
<body>
<form id="form1" runat="server">
<div class="container">
<h2>Order Confirmation</h2>
 
            <div class="order-details">
<label>Order ID:</label>
<span><%= OrderId %></span>
</div>
 
            <div class="order-details">
<label>Order Date:</label>
<span><%= OrderDate.ToShortDateString() %></span>
</div>
 
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>
 
            <div>
<asp:Button ID="btnProceedToPayment" runat="server" CssClass="btn-payment" Text="Proceed to Payment" OnClick="btnProceedToPayment_Click" />
</div>
</div>
</form>
</body>
</html>