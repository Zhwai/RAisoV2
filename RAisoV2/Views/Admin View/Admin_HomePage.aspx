<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin View/Admin_MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin_HomePage.aspx.cs" Inherits="RAisoV2.Views.Admin_View.Admin_HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1> Welcome To RAiso My Lovely Admin </h1>
    </div>

    <div>
        <asp:GridView ID="GVStationery" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="GVStationery_SelectedIndexChanging" Width="395px" OnRowEditing="GVStationery_RowEditing" OnRowDeleting="GVStationery_RowDeleting">
            <Columns>
                <asp:BoundField DataField="StationeryName" HeaderText="Stationery" SortExpression="StationeryName" />
                <asp:CommandField ButtonType="Button" HeaderText="View Details" ShowHeader="True" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Button" EditText="Update" HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>

    <div>
        <asp:Label ID="LblInsert" runat="server" Text="Insert Stationary : "></asp:Label>
        <asp:Button ID="BtnInsert" runat="server" Text="Insert" Onclick="BtnInsert_Click"/>
    </div>

    <div>
        <asp:Label ID="Lbltesting" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
