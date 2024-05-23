<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <div class="login-container">
        <h2>Register</h2>
        <div>
            <label for="fullName">Full Name:</label>
            <input type="text" id="fullName" name="fullName" class="login-container-input" />
        </div>
        <div>
            <label for="email">Email:</label>
            <input type="text" id="email" name="email" class="login-container-input" />
        </div>
        <div>
            <label for="password">Password:</label>
            <input type="password" id="password" name="password" class="login-container-input" />
        </div>
        <div>
            <label for="confirmPassword">Confirm Password:</label>
            <input type="password" id="confirmPassword" name="confirmPassword" class="login-container-input" />
        </div>
        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="buttons" OnClick="btnRegister_Click" />
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttons" PostBackUrl="~/Login.aspx" />
    </div>
</asp:Content>
