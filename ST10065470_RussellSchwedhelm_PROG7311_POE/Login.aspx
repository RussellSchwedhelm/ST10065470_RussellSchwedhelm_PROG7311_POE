<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Including the stylesheet for the page -->
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <!-- Styling the hero section -->
    <style>
        /* Styling for the hero section */
        .hero-section {
            background: url('<%= ResolveUrl("~/Resources/Images/LoginBanner.png") %>') no-repeat center center;
            background-size: cover;
            height: 90vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        /* Styling for the login container */
        .login-container {
            background-color: rgba(255, 255, 255, 0.8); /* Semi-transparent white background */
            padding: 20px;
            border-radius: 10px;
            text-align: center;
        }
    </style>
    <!-- Hero section with login form -->
    <div class="hero-section">
        <div class="login-container">
            <!-- Heading for the login form -->
            <h2>Login</h2>
            <!-- Form elements for email and password -->
            <div>
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="email">Email:</asp:Label>
                <asp:TextBox ID="email" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="password">Password:</asp:Label>
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <!-- Button for login -->
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttons" OnClick="btnLogin_Click" OnClientClick="return validateEmail();" />
            <!-- Button for registration -->
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="buttons" PostBackUrl="~/Register.aspx" />
            <!-- Button for password reset -->
            <asp:Button ID="btnPasswordReset" runat="server" Text="Reset Password" CssClass="buttons" PostBackUrl="~/ResetPassword.aspx" />
        </div>
    </div>
    <!-- JavaScript for client-side email validation -->
    <script type="text/javascript">
        // Function to validate email format
        function validateEmail() {
            var email = document.getElementById("<%= email.ClientID %>").value;
            // Checking if email contains "@" symbol
            if (email.indexOf("@") === -1) {
                // Alerting the user if email is invalid
                alert("Please enter a valid email address.");
                return false;
            }
            // Returning true if email is valid
            return true;
        }
    </script>
</asp:Content>
