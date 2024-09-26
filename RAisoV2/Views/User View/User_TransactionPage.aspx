<%@ Page Title="" Language="C#" MasterPageFile="~/Views/User View/User_MasterPage.Master" AutoEventWireup="true" CodeBehind="User_TransactionPage.aspx.cs" Inherits="RAisoV2.Views.User_View.User_TransactionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:GridView ID="GVHistory" runat="server" AutoGenerateColumns="False" Width="560px" OnSelectedIndexChanging="GVHistory_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" SortExpression="TransactionID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="TransactionDate" SortExpression="TransactionDate" />
                <asp:BoundField DataField="UserName" HeaderText="CustomerName" SortExpression="UserName" />
                <asp:CommandField ButtonType="Button" HeaderText="Details" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
