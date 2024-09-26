<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin View/Admin_MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin_InsertStationeryPage.aspx.cs" Inherits="RAisoV2.Views.Admin_View.Admin_InsertStationeryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1> Insert A New Stationery</h1>

    <div>
        <asp:Label ID="LblName" runat="server" Text="Name : "></asp:Label>
        <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="LblPrice" runat="server" Text="Price : "></asp:Label>
        <asp:TextBox ID="TBPrice" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="BtnConfirm" runat="server" Text="Confirm" Onclick="BtnConfirm_Click"/>
    </div>

    <div>
        <asp:Label ID="Lblerror" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
