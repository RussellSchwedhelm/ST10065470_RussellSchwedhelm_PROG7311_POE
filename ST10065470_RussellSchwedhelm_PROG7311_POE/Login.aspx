<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <div class="login-container">
        <h2>Login</h2>
        <div>
            <label for="username">Username:</label>
            <input type="text" id="username" name="username" />
        </div>
        <div>
            <label for="password">Password:</label>
            <input type="password" id="password" name="password" />
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttons" OnClick="btnLogin_Click" />
        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="buttons" PostBackUrl="~/Register.aspx" />
    </div>
</asp:Content>
