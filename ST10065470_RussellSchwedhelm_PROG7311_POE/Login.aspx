<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <div class="login-container">
        <h2>Login</h2>
        <div>
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="email">Email:</asp:Label>
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblPassword" runat="server" AssociatedControlID="password">Password:</asp:Label>
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttons" OnClick="btnLogin_Click" OnClientClick="return validateEmail();" />
        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="buttons" PostBackUrl="~/Register.aspx" />
    </div>

    <script type="text/javascript">
        function validateEmail() {
            var email = document.getElementById("<%= email.ClientID %>").value;
            if (email.indexOf("@") === -1) {
                alert("Please enter a valid email address.");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
