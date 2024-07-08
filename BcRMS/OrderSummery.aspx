<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSummery.aspx.cs" Inherits="BcRMS.OrderSummery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Order Summary</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Order Summary</h2>
            <div>
                <asp:Label ID="lblOrderId" runat="server" Text="Order ID: "></asp:Label>
                <asp:Label ID="lblOrderIdValue" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount: "></asp:Label>
                <asp:Label ID="lblTotalAmountValue" runat="server" Text=""></asp:Label>
            </div>
            <hr />
            <h3>Order Details</h3>
            <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Item" HeaderText="Item" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>