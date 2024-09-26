<%@ Page Title="" Language="C#" MasterPageFile="~/Views/User View/User_MasterPage.Master" AutoEventWireup="true" CodeBehind="User_StationeryDetailPage.aspx.cs" Inherits="RAisoV2.Views.User_View.User_StationeryDetailPage" %>
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

    <div>
        <asp:Label ID="LblQuantity" runat="server" Text="Quantity : "></asp:Label>
        <asp:TextBox ID="TBQuantity" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="BtnConfirm" runat="server" Text="Add" OnClick="BtnConfirm_Click" />
    </div>

    <div>
        <asp:Label ID="Lblerror" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
