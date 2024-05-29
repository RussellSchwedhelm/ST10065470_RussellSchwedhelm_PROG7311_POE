<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
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
            <h2>Register</h2>
            <div class="section-separator"></div>
            
            <!-- Form fields -->
            <div class="form-group">
                <!-- Name -->
                <div class="section-title">Name</div>
                <asp:TextBox ID="inp_firstName" runat="server" Placeholder="First Name" CssClass="form-control" />
                <asp:TextBox ID="inp_surname" runat="server" Placeholder="Surname" CssClass="form-control" />
                
                <div class="section-separator"></div>
                
                <!-- Address -->
                <div class="section-title">Address</div>
                <asp:TextBox ID="txtStreetNumber" runat="server" Placeholder="Street Number" CssClass="form-control" />
                <asp:TextBox ID="txtStreet" runat="server" Placeholder="Street" CssClass="form-control" />
                <asp:TextBox ID="txtSuburb" runat="server" Placeholder="Suburb" CssClass="form-control" />
                <asp:TextBox ID="txtCity" runat="server" Placeholder="City" CssClass="form-control" />
                <asp:TextBox ID="txtProvince" runat="server" Placeholder="Province" CssClass="form-control" />
                <asp:TextBox ID="txtCountry" runat="server" Placeholder="Country" CssClass="form-control" />
                
                <div class="section-separator"></div>
                
                <!-- Contact Info -->
                <div class="section-title">Contact Info</div>
                <asp:TextBox ID="inp_email" runat="server" Placeholder="Email" CssClass="form-control" />
                <asp:TextBox ID="txtPhone" runat="server" Placeholder="Phone Number" CssClass="form-control" />
    
                <div class="section-separator"></div>
                
                <!-- Password -->
                <div class="section-title">Password Info</div>
                <asp:TextBox ID="inp_password" TextMode="Password" runat="server" Placeholder="Password" CssClass="form-control" />

                <!-- Confirm Password -->
                    <asp:TextBox ID="inp_confirmPassword" TextMode="Password" runat="server" Placeholder="Confirm Password" CssClass="form-control" />

                <div class="section-separator"></div>

                <!-- Employee Checkbox -->
                <div style="display:flex; flex: 1;">
                    <asp:CheckBox ID="employeeCheck" runat="server"/>
                    <label style="margin-left: 10px">Employee</label>
                </div>
                <!-- Employee Code Container (Initially Hidden) -->
                    <asp:TextBox ID="inp_employeeCode" runat="server" style="display:none;" Placeholder="Employee Code" CssClass="form-control" MaxLength="12"/>
                <!-- Register and Login Buttons -->
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="buttons" OnClick="btnRegister_Click" />
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttons" PostBackUrl="~/Login.aspx" />
            </div>
        </div>
        
    <!-- JavaScript for input validation -->
        <script type="text/javascript">
            document.getElementById('<%= employeeCheck.ClientID %>').addEventListener('change', function () {
                var inp_employeeCode = document.getElementById('<%= inp_employeeCode.ClientID %>');
                if (this.checked) {
                    inp_employeeCode.style.display = 'block';
                } else {
                    inp_employeeCode.style.display = 'none';
                }
            });

        // Client-side input validation
        document.getElementById('<%= btnRegister.ClientID %>').addEventListener('click', function () {
            // Retrieve form field values
            var firstName = document.getElementById('<%= inp_firstName.ClientID %>').value.trim();
            var lastName = document.getElementById('<%= inp_surname.ClientID %>').value.trim();
            var password = document.getElementById('<%= inp_password.ClientID %>').value;
            var repassword = document.getElementById('<%= inp_confirmPassword.ClientID %>').value;
            var email = document.getElementById('<%= inp_email.ClientID %>').value.trim();
            var phone = document.getElementById('<%= txtPhone.ClientID %>').value.trim();
            var country = document.getElementById('<%= txtCountry.ClientID %>').value.trim();

            // Validation checks
            if (firstName === '') {
                alert("Please Enter A First Name");
                return false;
            } else if (firstName.length > 50) {
                alert("First Name Cannot Exceed 50 Characters");
                return false;
            } else if (/\d/.test(firstName)) {
                alert("First Name Cannot Contain A Number");
                return false;
            }

            if (lastName === '') {
                alert("Please Enter A Surname");
                return false;
            } else if (lastName.length > 50) {
                alert("Surname Cannot Exceed 50 Characters");
                return false;
            } else if (/\d/.test(lastName)) {
                alert("Surname Cannot Contain A Number");
                return false;
            }

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

            if (!/^\d+$/.test(phone)) {
                alert("Phone Number Must Contain Only Numbers");
                return false;
            }

            if (/\d/.test(country)) {
                alert("Country Name Cannot Contain Numbers");
                return false;
            }

            return true;
        });
</script>
</asp:Content>
