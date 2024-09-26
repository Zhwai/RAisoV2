<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Guest View/Guest_MasterPage.Master" AutoEventWireup="true" CodeBehind="Guest_LoginPage.aspx.cs" Inherits="RAisoV2.Views.Guest_View.Guest_LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="LblUserName" runat="server" Text="Username : "></asp:Label>
        <asp:TextBox ID="TBUserName" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="LblPassword" runat="server" Text="Password : "></asp:Label>
        <asp:TextBox ID="TBPassword" runat="server"></asp:TextBox>
    </div>

    <div>   
        <asp:Label ID="LblRemember" runat="server" Text="Remember Me"></asp:Label>
        <asp:CheckBox ID="CBRemember" runat="server"/>
    </div>

    <div>
        <asp:Button ID="BtnConfirm" runat="server" Text="Confirm" OnClick="BtnConfirm_Click" AutoPostBack="false"/>
    </div>

    <div>
        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
