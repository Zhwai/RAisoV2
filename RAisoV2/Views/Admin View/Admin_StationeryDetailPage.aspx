 <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin View/Admin_MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin_StationeryDetailPage.aspx.cs" Inherits="RAisoV2.Views.Admin_View.Admin_StationeryDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="LblName" runat="server" Text="Name : "></asp:Label>
        <asp:Label ID="LblNameShow" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Label ID="LblPrice" runat="server" Text="Price : "></asp:Label>
        <asp:Label ID="LblPriceShow" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
