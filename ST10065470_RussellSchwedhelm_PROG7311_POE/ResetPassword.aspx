<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        /* Styling for the hero section */
        .hero-section {
            background: url('<%= ResolveUrl("~/Resources/Images/ResetPasswordBanner.jpg") %>') no-repeat center;
            background-size: cover;
            height: 90vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        /* Styling for the reset password container */
        .create-farmer-container {
            background-color: rgba(255, 255, 255, 0.8); /* Semi-transparent white background */
            padding: 20px;
            border-radius: 10px;
            text-align: center;
        }
    </style>

    <!-- Hero section containing the reset password form -->
    <div class="hero-section">
        <div class="create-farmer-container">
            <h2>Reset Password</h2>
            <div class="section-separator"></div>

            <!-- Reset password form fields -->
            <div class="form-group">
                <label for="inp_email">Email:</label>
                <asp:TextBox ID="inp_email" runat="server" CssClass="form-control" />

                <div class="section-separator"></div>

                <!-- Old password field -->
                <div>
                    <label for="inp_oldPassword">Old Password:</label>
                    <asp:TextBox ID="inp_oldPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>

                <!-- New password field -->
                <div>
                    <label for="inp_newPassword">New Password:</label>
                    <asp:TextBox ID="inp_newPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>

                <!-- Confirm new password field -->
                <div>
                    <label for="inp_confirmNewPassword">Confirm New Password:</label>
                    <asp:TextBox ID="inp_confirmNewPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>

                <!-- Reset password and cancel buttons -->
                <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="buttons" OnClick="btnResetPassword_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="buttons" PostBackUrl="~/Login.aspx" />
            </div>
        </div>
    </div>

    <!-- JavaScript for input validation -->
    <script type="text/javascript">
        // Client-side input validation
        document.getElementById('<%= btnResetPassword.ClientID %>').addEventListener('click', function () {
            // Retrieve form field values
            var oldPassword = document.getElementById('<%= inp_oldPassword.ClientID %>').value;
            var password = document.getElementById('<%= inp_newPassword.ClientID %>').value;
            var repassword = document.getElementById('<%= inp_confirmNewPassword.ClientID %>').value;
            var email = document.getElementById('<%= inp_email.ClientID %>').value.trim();

            // Validation checks

            // Check if all fields are filled
            if (oldPassword == "" || password == "" || repassword == "" || email == "") {
                alert("All Fields Are Required");
                return false;
            }

            // Validate email format
            else if (!email.includes('@') || !email.includes('.')) {
                alert("Please Enter A Valid Email");
                return false;
            }

            // Validate password length
            else if (password.length < 12) {
                alert("Passwords Must Be At Least 12 Characters Long");
                return false;
            }

            // Validate password match
            else if (password !== repassword) {
                alert("Passwords Must Match");
                return false;
            }

            // Validate password complexity
            else if (!/\d/.test(password) || !/[A-Z]/.test(password)) {
                alert("Password Must Contain At Least One Number And One Capital Letter");
                return false;
            }

            return true;
        });
    </script>

</asp:Content>
