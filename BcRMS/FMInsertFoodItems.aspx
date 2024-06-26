﻿<%@ Page Culture="en-IN"  Language="C#" AutoEventWireup="true" CodeBehind="FMInsertFoodItems.aspx.cs" Inherits="BcRMS.InsertFoodItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Restaurant Management System</title>
    <link rel="stylesheet" type="text/css" href="~/Css/HomePage.css"/>
    <style type="text/css">
        .GridView1
        {
            width: 525px;
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
    </div>
    <div class="Body"><%--Body Div Open--%>
        
            <div class="Column GridView1"><%--GridView1 Open--%>
            <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" 
                    BorderColor="Tan" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                    GridLines="None" AutoGenerateColumns="False" DataKeyNames="FoodItemID" 
                    DataSourceID="ObjectDataSource1" BorderStyle="Solid" 
                    HorizontalAlign="Left" 
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="528px">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="FoodItemID" HeaderText="FoodItemID" 
                            SortExpression="FoodItemID" />
                        <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" 
                            SortExpression="CategoryName" />
                        <asp:BoundField DataField="ItemName" HeaderText="ItemName" 
                            SortExpression="ItemName" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:c}" />
                        <%--<asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server"  Height="100px" Width="106px" ImageAlign="Middle"
                                    ImageUrl='<%# Eval("ImageDataBase64") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                    <EditRowStyle HorizontalAlign="Center" />
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                        HorizontalAlign="Center" />
                    <RowStyle BorderStyle="Solid" Height="40px" HorizontalAlign="Center" 
                        Width="60px" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>
                </div><%--GridView1 Close--%>
                 <div class="Column GridView2"><%--GridView2 Open--%>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                CellPadding="2" DataSourceID="ObjectDataSource4" ForeColor="Black" 
                GridLines="None">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="FoodItemID" HeaderText="FoodItemID" 
                        SortExpression="FoodItemID" />
                    <asp:BoundField DataField="CategoryId" HeaderText="CategoryId" 
                        SortExpression="CategoryId" />
                    <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" 
                        SortExpression="CategoryName" />
                    <asp:BoundField DataField="ItemName" HeaderText="ItemName" 
                        SortExpression="ItemName" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="50px" 
                                ImageUrl='<%# Eval("ImageDataBase64") %>' Width="50px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                    HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
         </div><%--GridView2 Close--%> 
         <div class="DetialViews"><%--DetialViews open--%>
         <asp:DetailsView ID="DetailsView1" runat="server" 
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                CellPadding="2" ForeColor="Black" GridLines="None" Height="50px" 
                Width="177px" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" 
                AutoGenerateInsertButton="True" AutoGenerateRows="False" 
                DataSourceID="ObjectDataSource2" DataKeyNames="FoodItemID" 
                onitemdeleted="DetailsView1_ItemDeleted" 
                oniteminserted="DetailsView1_ItemInserted" 
                onitemupdated="DetailsView1_ItemUpdated" 
                 onprerender="GridView1_SelectedIndexChanged" 
                 oniteminserting="DetailsView1_ItemInserting1" 
                 onitemupdating="DetailsView1_ItemUpdating">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <Fields>
                    <asp:BoundField DataField="FoodItemID" HeaderText="FoodItemID" 
                        SortExpression="FoodItemID" InsertVisible="False" ReadOnly="True" />
                    <asp:TemplateField HeaderText="CategoryType">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" 
                                DataSourceID="ObjectDataSource3" DataTextField="CategoryName" 
                                DataValueField="CategoryId">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ItemName" HeaderText="ItemName" 
                        SortExpression="ItemName" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:TemplateField HeaderText="ImageField">
                        <ItemTemplate>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </div><%--DetialViews Close--%>
        <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetBasicFoodMenuItem" 
            TypeName="BcRMS.FoodListDataAccessLayer">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetAllFoodMenuItembyFooditemId" 
                TypeName="BcRMS.FoodListDataAccessLayer" DeleteMethod="DeleteItem" 
                InsertMethod="InsertItem" UpdateMethod="UpdateItem">
            <DeleteParameters>
                <asp:Parameter Name="FoodItemId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="categoryId" Type="Int32" />
                <asp:Parameter Name="itemName" Type="String" />
                <asp:Parameter Name="price" Type="Decimal" />
                <asp:Parameter Name="bytes" Type="Object" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="FoodItemID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="FoodItemId" Type="Int32" />
                <asp:Parameter Name="CategoryId" Type="Int32" />
                <asp:Parameter Name="ItemName" Type="String" />
                <asp:Parameter Name="Price" Type="Decimal" />
                <asp:Parameter Name="bytes" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
            SelectMethod="GetAllCategory" TypeName="BcRMS.CategoryListDataAccessLayer">
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
        SelectMethod="GetAllFoodMenuItembyFooditemId" 
        TypeName="BcRMS.FoodListDataAccessLayer">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="FoodItemID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
        </div>

    </div><%--Body Div Close--%>
    </form>
</body>
 
</html>

         <%--<div>        
        <asp:Panel ID="CancelImgButton" runat="server" Height="241px" Font-Bold="False" 
            HorizontalAlign="Left" Width="1038px">
            <br />
            <asp:Label ID="lblCategory" runat="server" Text="Category" Font-Bold="True" 
                Height="20px" Width="90px"></asp:Label>
            <asp:DropDownList ID="ddlCategoryList" runat="server" Font-Bold="True" 
                Font-Size="Small" Height="20px" Width="90px">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1001">Break Fast</asp:ListItem>
                <asp:ListItem Value="1002">Meal</asp:ListItem>
                <asp:ListItem Value="1003">Drinks</asp:ListItem>
            </asp:DropDownList>
            <br />
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
        </div>--%>