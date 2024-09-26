<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Guest View/Guest_MasterPage.Master" AutoEventWireup="true" CodeBehind="Guest_HomePage.aspx.cs" Inherits="RAisoV2.Views.Guest_View.Guest_HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
         <h1>
            Welcome To RAiso
        </h1>
    </div>

    <div>
        <asp:GridView ID="GVStationary" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="GVStationary_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="StationeryName" HeaderText="Stationery" SortExpression="StationeryName" />
                <asp:CommandField ButtonType="Button" HeaderText="View Details" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
