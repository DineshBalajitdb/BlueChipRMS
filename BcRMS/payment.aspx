<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="BcRMS.payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Payment Page</title>
<style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 20px;
            padding: 0;
        }
 
        .container {
            max-width: 600px;
            margin: auto;
            background-color: #fff;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
 
        .form-group {
            margin-bottom: 20px;
        }
 
        .form-group label {
            font-weight: bold;
        }
 
        .form-control {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
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
 
        .error-message {
            color: red;
            font-style: italic;
            margin-top: 10px;
        }
</style>
</head>
<body>
<form id="form1" runat="server">
<div class="container">
<h2>Secure Payment</h2>
 
            <div class="form-group">
<label for="txtCardNumber">Card Number:</label>
<asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control" MaxLength="16"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtCardNumber" ErrorMessage="twelve Digit Required" 
                    ForeColor="Red" ValidationExpression="\d{12}"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtCardNumber" ErrorMessage="Card Number is Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
</div>
 
            <div class="form-group">
<label for="txtNameOnCard">Name on Card:</label>
<asp:TextBox ID="txtNameOnCard" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtNameOnCard" ErrorMessage="Card Hold Name Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
</div>
 
            <div class="form-group">
<label for="ddlExpirationMonth">Expiration Month:</label>
<select id="ddlExpirationMonth" runat="server" class="form-control">
<option value="1">January</option>
<option value="2">February</option>
<option value="3">March</option>
<option value="4">April</option>
<option value="5">May</option>
<option value="6">June</option>
<option value="7">July</option>
<option value="8">August</option>
<option value="9">September</option>
<option value="10">October</option>
<option value="11">November</option>
<option value="12">December</option>
</select><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlExpirationMonth" ErrorMessage="RequiredFieldValidator" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;</div>
 
            <div class="form-group">
<label for="txtCVV">CVV:</label>
<asp:TextBox ID="txtCVV" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="txtCVV" ErrorMessage="Not more then four Digit " 
                    ForeColor="Red" MaximumValue="4"></asp:RangeValidator>
</div>
 
            <div class="form-group">
<label for="txtBillingAddress">Billing Address:</label>
<asp:TextBox ID="txtBillingAddress" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtBillingAddress" 
                    ErrorMessage="BilingAddress not to be empty" ForeColor="Red"></asp:RequiredFieldValidator>
</div>
 
            <asp:Button ID="btnProcessPayment" runat="server" CssClass="btn-payment" Text="Process Payment" OnClick="btnProcessPayment_Click" />
<asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>
</div>
</form>
</body>
</html>