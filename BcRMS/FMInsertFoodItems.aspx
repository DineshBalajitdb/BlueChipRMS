<%@ Page Culture="en-IN"  Language="C#" AutoEventWireup="true" CodeBehind="FMInsertFoodItems.aspx.cs" Inherits="BcRMS.InsertFoodItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Restaurant Management System</title>
        <link rel="stylesheet" type="text/css" href="~/Css/HomePage.css"/>
    </head>
    <body>
        <form id="form1" runat="server">
        <div class="header">
            <h1>Food Management System</h1>
        </div>
        <div class="menu">
            <a href="HomePage.aspx">Home Page</a>
            <a href="FMInsertFoodItems.aspx">Add Item</a>
            <a href="FMViewItem.aspx">View Item</a>
            <a href="FMAlterItem.aspx">Alter Item</a>
        </div>
        <div class="content">
            <div class="welcome">
                <h2>Add Item</h2>
            </div>
               
        </div>          
        <asp:Panel ID="CancelImgButton" runat="server" Height="241px" Font-Bold="False" 
            HorizontalAlign="Left" Width="1038px">
            <asp:Label ID="lblCategory" runat="server" Text="Category" Font-Bold="True" 
                Height="20px" Width="90px"></asp:Label>
            <asp:DropDownList ID="ddlCategoryList" runat="server" Font-Bold="True" 
                Font-Size="Medium" Height="20px" Width="90px">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1001">Break Fast</asp:ListItem>
                <asp:ListItem Value="1002">Meal</asp:ListItem>
                <asp:ListItem Value="1003">Drinks</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblImage" runat="server" Font-Bold="True" Height="20px" 
                Text="Image" Width="90px"></asp:Label>
            <asp:FileUpload ID="ImageFileUpload" runat="server" Font-Bold="False" 
                Height="25px" />
            <br />
            <asp:Label ID="lblItem" runat="server" Font-Bold="True" Height="20px" 
                Text="Item Name" Width="90px"></asp:Label>
            <asp:TextBox ID="ItemTxt" runat="server" Height="20px" 
                Width="160px"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrice" runat="server" Font-Bold="True" Height="20px" 
                Text="Price" Width="90px"></asp:Label>
            <asp:TextBox ID="PriceTxt" runat="server" TextMode="Number" Width="161px"></asp:TextBox>
            <br />
            <asp:ImageButton ID="InsertImgButton" runat="server" Height="55px" 
                ImageAlign="AbsBottom" ImageUrl="~/sources/insert-picture-icon.png" 
                onclick="InsertImgButton_Click" Width="62px"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="cancelImagebutton" runat="server" Height="60px" 
                ImageAlign="AbsBottom" ImageUrl="~/sources/cancel.png" 
                onclick="CancelImgButton_Click"/>
            <br />
            <br />
            <asp:Label ID="lberror" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </asp:Panel>
        </form>
    </body>
 
</html>