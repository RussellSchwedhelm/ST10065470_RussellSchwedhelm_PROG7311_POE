<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        .create-farmer-container {
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            margin: 50px auto;
            max-width: 600px;
            text-align: center;
        }

        .create-farmer-container h2 {
            margin-bottom: 20px;
        }

        .form-group {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .create-farmer-container label {
            display: block;
            margin-bottom: 5px;
            margin-top: 10px;
        }

        .create-farmer-container input[type="text"],
        .create-farmer-container input[type="email"],
        .create-farmer-container input[type="tel"] {
            width: 80%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .create-farmer-container .buttons {
            width: 80%;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background-color: #4CAF50;
            color: white;
            cursor: pointer;
            margin-top: 20px;
        }

        .create-farmer-container .buttons:hover {
            background-color: #45a049;
        }

        .section-title {
            font-size: 20px;
            margin-top: 10px;
            margin-bottom: 5px;
            text-align: center;
        }

        .section-separator {
            border-top: 1px solid #ccc;
            width: 80%;
            margin: 20px auto 10px;
        }
    </style>
        <div class="create-farmer-container">
            <h2>Reset Password</h2>
            <div class="section-separator"></div>
            
            <!-- Form fields -->
            <div class="form-group">
                <label for="inp_email">Email:</label>
                <asp:TextBox ID="inp_email" runat="server" CssClass="form-control" />
    
                <div class="section-separator"></div>
    
                <!-- Password -->
                <div>
                    <label for="inp_oldPassword">Old Password:</label>
                    <asp:TextBox ID="inp_oldPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>

                <!-- Password -->
                <div>
                    <label for="inp_newPassword">New Password:</label>
                    <asp:TextBox ID="inp_newPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>
                <!-- Confirm Password -->
                <div>
                    <label for="inp_confirmNewPassword">Confirm New Password:</label>
                    <asp:TextBox ID="inp_confirmNewPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>
                <!-- Register and Login Buttons -->
                <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="buttons" OnClick="btnResetPassword_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="buttons" PostBackUrl="~/Login.aspx" />
            </div>
        </div>
        
    <!-- JavaScript for input validation -->
    <script type="text/javascript">
        // Client-side input validation
        document.getElementById('<%= btnResetPassword.ClientID %>').addEventListener('click', function () {
            // Retrieve form field values
            var password = document.getElementById('<%= inp_newPassword.ClientID %>').value;
            var repassword = document.getElementById('<%= inp_confirmNewPassword.ClientID %>').value;
            var email = document.getElementById('<%= inp_email.ClientID %>').value.trim();

            // Validation checks
            if (!email.includes('@') || !email.includes('.')) {
                alert("Please Enter A Valid Email");
                return false;
            }

            if (password.length < 12) {
                alert("Passwords Must Be At Least 12 Characters Long");
                return false;
            }

            if (password !== repassword) {
                alert("Passwords Must Match");
                return false;
            }

            if (!/\d/.test(password) || !/[A-Z]/.test(password)) {
                alert("Password Must Contain At Least One Number And One Capital Letter");
                return false;
            }

            return true;
        });
    </script>
</asp:Content>

