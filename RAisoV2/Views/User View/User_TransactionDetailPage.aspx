<%@ Page Title="" Language="C#" MasterPageFile="~/Views/User View/User_MasterPage.Master" AutoEventWireup="true" CodeBehind="User_TransactionDetailPage.aspx.cs" Inherits="RAisoV2.Views.User_View.User_TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:GridView ID="GVShow" runat="server" AutoGenerateColumns="False" Width="412px">
        <Columns>
            <asp:BoundField DataField="StationeryName" HeaderText="StationeryName" SortExpression="StationeryName" />
            <asp:BoundField DataField="StationeryPrice" HeaderText="StationeryPrice" SortExpression="StationeryPrice" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
        </Columns>
    </asp:GridView>
</asp:Content>
