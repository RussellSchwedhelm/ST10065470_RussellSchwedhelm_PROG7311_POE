<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <div class="login-container">
        <h2>Register</h2>
        <div>
            <label for="inp_firstName">First Name:</label>
            <asp:TextBox ID="inp_firstName" runat="server" CssClass="login-container-input" MaxLength="50"></asp:TextBox>
        </div>
        <div>
            <label for="inp_lastName">Last Name:</label>
            <asp:TextBox ID="inp_lastName" runat="server" CssClass="login-container-input" MaxLength="50"></asp:TextBox>
        </div>
        <div>
            <label for="inp_email">Email:</label>
            <asp:TextBox ID="inp_email" runat="server" CssClass="login-container-input"></asp:TextBox>
        </div>
        <div>
            <label for="inp_password">Password:</label>
            <asp:TextBox ID="inp_password" runat="server" CssClass="login-container-input" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <label for="inp_confirmPassword">Confirm Password:</label>
            <asp:TextBox ID="inp_confirmPassword" runat="server" CssClass="login-container-input" TextMode="Password"></asp:TextBox>
        </div>
        <div style="display:flex; flex: 1;">
            <asp:CheckBox ID="employeeCheck" runat="server"/>
            <label style="margin-left: 10px">Employee</label>
        </div>
        <div id="employeeIdContainer" runat="server" style="display:none;">
            <label for="inp_employeeCode">Employee Code:</label>
            <asp:TextBox ID="inp_employeeCode" runat="server" CssClass="login-container-input" MaxLength="12"></asp:TextBox>
        </div>
        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="buttons" OnClick="btnRegister_Click" />
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttons" PostBackUrl="~/Login.aspx" />
    </div>
    <script type="text/javascript">
        document.getElementById('<%= employeeCheck.ClientID %>').addEventListener('change', function () {
            var employeeIdContainer = document.getElementById('<%= employeeIdContainer.ClientID %>');
            if (this.checked) {
                employeeIdContainer.style.display = 'block';
            } else {
                employeeIdContainer.style.display = 'none';
            }
        });

        document.getElementById('<%= btnRegister.ClientID %>').addEventListener('click', function () {
            var firstName = document.getElementById('<%= inp_firstName.ClientID %>').value;
            var lastName = document.getElementById('<%= inp_lastName.ClientID %>').value;
            var password = document.getElementById('<%= inp_password.ClientID %>').value;
            var repassword = document.getElementById('<%= inp_confirmPassword.ClientID %>').value;

            if (firstName.length > 50) {
                alert("First Name Cannot Exceed 50 Characters");
                return false;
            }

            if (lastName.length > 50) {
                alert("Surname Cannot Exceed 50 Characters");
                return false;
            }

            if (password.length < 12) {
                alert("Password Must Be At Least 12 Characters");
                return false;
            }

            if (password != repassword) {
                alert("Passwords Must Match");
                return false;
            }

            if (!/\d/.test(password) || !/[A-Z]/.test(password)) {
                alert("Password Must Contain At Least One Number And One Capital Letter");
                return false;
            }
        });
    </script>
</asp:Content>
