<%@ Page Culture="en-IN"  Language="C#" AutoEventWireup="true" CodeBehind="FMViewItem.aspx.cs" Inherits="BcRMS.ViewIteam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Restaurant Management System</title>
        <link rel="stylesheet" type="text/css" href="~/Css/HomePage.css"/>
        <style type="text/css">
            #form1
            {
                height: 515px;
            }
        </style>
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
                <h2>View Item</h2>
            </div>
               
        </div>          
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="5" ForeColor="Black" 
            GridLines="None" 
            HorizontalAlign="Center" Width="999px" 
            AllowSorting="True" onsorting="GridView1_Sorting" onsorted="Page_Load" 
            ViewStateMode="Enabled" >
            <AlternatingRowStyle BackColor="PaleGoldenrod" BorderStyle="Ridge" />
            <Columns>
                <asp:BoundField DataField="CategoryId" HeaderText="Category Id" SortExpression="CategoryId" />
                <asp:BoundField DataField="itemName" HeaderText="Item Name" SortExpression="itemName" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:c}"/>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="106px" ImageAlign="Middle" 
                            ImageUrl='<%# Eval("ImageDataBase64") %>'  />
                            
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <EmptyDataRowStyle BorderStyle="None" />
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" 
                HorizontalAlign="Center" VerticalAlign="Middle" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" BorderStyle="Dashed" 
                HorizontalAlign="Center" VerticalAlign="Middle" />
            <SortedAscendingHeaderStyle BackColor="Tan" HorizontalAlign="Center" 
                BorderStyle="Dashed" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" HorizontalAlign="Center" />
            <SortedDescendingHeaderStyle BackColor="White" BorderStyle="Dashed" 
                HorizontalAlign="Center" />
        </asp:GridView>
        </form>
    </body>
 
</html>