<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Guest View/Guest_MasterPage.Master" AutoEventWireup="true" CodeBehind="Guest_StationeryDetailPage.aspx.cs" Inherits="RAisoV2.Views.Guest_View.Guest_StationeryDetail" %>
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
