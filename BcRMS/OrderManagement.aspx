<%@ Page  Culture="en-IN" Language="C#" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="BcRMS.OrderManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Restaurant Management System</title>
        <link rel="stylesheet" type="text/css" href="~/Css/HomePage.css"/>
    </head>
    <body>
        <form id="form1" runat="server">
        <div class="header">
            <h1>Order Management System</h1>
        </div>
        <div class="menu">
            <a href="AdminPage.aspx">Admin</a>
            <a href="HomePage.aspx">Home Page</a>
        </div>
        <div class="content">
            <div class="welcome">
                <h2>Welcome</h2>
            </div>
    `       <div>
    
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="OrderID" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="OrderID" HeaderText="OrderID" InsertVisible="False" 
                            ReadOnly="True" SortExpression="OrderID" />
                        <asp:BoundField DataField="FoodItemID" HeaderText="FoodItemID" 
                            SortExpression="FoodItemID" />
                        <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" 
                            SortExpression="CustomerID" />
                        <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" 
                            SortExpression="OrderDate" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                            SortExpression="Quantity" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="TotalPrice" DataFormatString="{0:c}" 
                            SortExpression="TotalPrice" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DBCS %>" 
                    SelectCommand="SELECT * FROM [CustomerOrders]"></asp:SqlDataSource>
    
            </div>               
        </div>          
        </form>
    </body>
 
</html>
