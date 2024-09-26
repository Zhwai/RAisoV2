<%@ Page Title="" Language="C#" MasterPageFile="~/Views/User View/User_MasterPage.Master" AutoEventWireup="true" CodeBehind="User_UpdateProfilePage.aspx.cs" Inherits="RAisoV2.Views.User_View.User_UpdateProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1> Update Profile </h1>
    </div>

    <div>
        <asp:Label ID="LblName" runat="server" Text="Name : "></asp:Label>
        <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="LblDOB" runat="server" Text="Date Of Birth : "></asp:Label>
        <asp:Calendar ID="CldDOB" runat="server"></asp:Calendar>
    </div>

    <div>
        <asp:Label ID="LblGender" runat="server" Text="Gender : "></asp:Label>
        <asp:RadioButton ID="RBMale" runat="server" Text="Male" GroupName="Gender"/>
        <asp:RadioButton ID="RBFemale" runat="server" Text="Female" GroupName="Gender"/>
    </div>

    <div>
        <asp:Label ID="LblAddress" runat="server" Text="Address : "></asp:Label>
        <asp:TextBox ID="TBAddress" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="LblPassword" runat="server" Text="Password : "></asp:Label>
        <asp:TextBox ID="TBPassword" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="LblPhone" runat="server" Text="Phone : "></asp:Label>
        <asp:TextBox ID="TBPhone" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="BtnConfirm" runat="server" Text="Confirm" OnClick="BtnConfirm_Click" />
    </div>

    <div>
        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
