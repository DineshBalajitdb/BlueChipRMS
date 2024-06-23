<%@ Page Culture="en-IN" Language="C#" AutoEventWireup="true" CodeBehind="FMAlterItem.aspx.cs" Inherits="BcRMS.FMAlterItem" %>

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
                <h2>Alter Item</h2>
            </div>
            <div>

               
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                    BorderWidth="1px" CellPadding="2" DataKeyNames="FoodItemID" 
                    DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" 
                    Height="196px" Width="995px">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="FoodItemID" HeaderText="FoodItemID" 
                            InsertVisible="False" ReadOnly="True" SortExpression="FoodItemID" />
                        <asp:BoundField DataField="CategoryId" HeaderText="CategoryId" 
                            SortExpression="CategoryId" />
                        <asp:BoundField DataField="ItemName" HeaderText="ItemName" 
                            SortExpression="ItemName" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:c}"/>
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageData") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle HorizontalAlign="Center" />
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                        HorizontalAlign="Center" />
                    <RowStyle BorderStyle="None" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>

               
                <asp:DetailsView ID="DetailsView1" runat="server" 
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                    CellPadding="2" ForeColor="Black" GridLines="None" Height="50px" Width="125px">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                        HorizontalAlign="Center" />
                </asp:DetailsView>
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:RMSConnectionString %>" 
                    SelectCommand="SELECT [FoodItemID], [CategoryId], [ItemName], [Price], [ImageData] FROM [tbl_FoodMenus]">
                </asp:SqlDataSource>
                <br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>

            </div>
               
        </div>          
        </form>
    </body>
 
</html>
