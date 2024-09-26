<%@ Page Title="" Language="C#" MasterPageFile="~/Views/User View/User_MasterPage.Master" AutoEventWireup="true" CodeBehind="User_CartPage.aspx.cs" Inherits="RAisoV2.Views.User_View.User_CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1> You're Cart </h1>
    </div>

    <div>
        <asp:GridView ID="GVCart" runat="server" AutoGenerateColumns="False"  Width="474px" OnRowEditing="GVCart_RowEditing" OnRowDeleting="GVCart_RowDeleting">
            <Columns>
                <asp:BoundField DataField="StationeryName" HeaderText="Name" SortExpression="StationeryName" />
                <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="StationeryPrice" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>

    <div>
        <asp:Button ID="BtnCheckOut" runat="server" Text="CheckOut" OnClick="BtnCheckOut_Click"/>
    </div>

    <div>
        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
