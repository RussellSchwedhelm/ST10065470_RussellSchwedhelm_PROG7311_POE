<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Link to external stylesheet -->
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />

    <style>
        /* Styling for the hero section */
        .hero-section {
            background: url('<%= ResolveUrl("~/Resources/Images/RegisterUserBanner.jpg") %>') no-repeat center;
            background-size: cover;
            height: fit-content;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        /* Styling for the registration container */
        .create-farmer-container {
            background-color: rgba(255, 255, 255, 0.8); /* Semi-transparent white background */
            padding: 20px;
            border-radius: 10px;
            text-align: center;
        }
    </style>

    <!-- Hero section containing the registration form -->
    <div class="hero-section">
        <div class="create-farmer-container">
            <h2>Register</h2>
            <div class="section-separator"></div>

            <!-- Registration form fields -->
            <div class="form-group">
                <!-- Name fields -->
                <div class="section-title">Name</div>
                <asp:TextBox ID="inp_firstName" runat="server" Placeholder="First Name" CssClass="form-control" />
                <asp:TextBox ID="inp_surname" runat="server" Placeholder="Surname" CssClass="form-control" />
                
                <div class="section-separator"></div>

                <!-- Address fields -->
                <div class="section-title">Address</div>
                <asp:TextBox ID="txtStreetNumber" runat="server" Placeholder="Street Number" CssClass="form-control" />
                <asp:TextBox ID="txtStreet" runat="server" Placeholder="Street" CssClass="form-control" />
                <asp:TextBox ID="txtSuburb" runat="server" Placeholder="Suburb" CssClass="form-control" />
                <asp:TextBox ID="txtCity" runat="server" Placeholder="City" CssClass="form-control" />
                <asp:TextBox ID="txtProvince" runat="server" Placeholder="Province" CssClass="form-control" />
                <asp:TextBox ID="txtCountry" runat="server" Placeholder="Country" CssClass="form-control" />

                <div class="section-separator"></div>

                <!-- Contact information fields -->
                <div class="section-title">Contact Info</div>
                <asp:TextBox ID="inp_email" runat="server" Placeholder="Email" CssClass="form-control" />
                <asp:TextBox ID="txtPhone" runat="server" Placeholder="Phone Number" CssClass="form-control" />

                <div class="section-separator"></div>

                <!-- Password fields -->
                <div class="section-title">Password Info</div>
                <asp:TextBox ID="inp_password" TextMode="Password" runat="server" Placeholder="Password" CssClass="form-control" />
                <asp:TextBox ID="inp_confirmPassword" TextMode="Password" runat="server" Placeholder="Confirm Password" CssClass="form-control" />

                <div class="section-separator"></div>

                <!-- Employee checkbox and code field (initially hidden) -->
                <div style="display:flex; flex: 1;">
                    <asp:CheckBox ID="employeeCheck" runat="server"/>
                    <label style="margin-left: 10px">Employee</label>
                </div>
                <asp:TextBox ID="inp_employeeCode" runat="server" style="display:none;" Placeholder="Employee Code" CssClass="form-control" MaxLength="12"/>
                
                <!-- Register and Login buttons -->
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="buttons" OnClick="btnRegister_Click" />
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttons" PostBackUrl="~/Login.aspx" />
            </div>
        </div>
    </div>

    <!-- JavaScript for form validation and employee code display toggle -->
    <script type="text/javascript">
        // Toggle display of employee code field based on checkbox state
        document.getElementById('<%= employeeCheck.ClientID %>').addEventListener('change', function () {
            var inp_employeeCode = document.getElementById('<%= inp_employeeCode.ClientID %>');
            if (this.checked) {
                inp_employeeCode.style.display = 'block';
            } else {
                inp_employeeCode.style.display = 'none';
            }
        });

        // Client-side input validation
        function validateForm() {
            // Retrieve form field values
            var firstName = document.getElementById('<%= inp_firstName.ClientID %>').value.trim();
            var lastName = document.getElementById('<%= inp_surname.ClientID %>').value.trim();
            var password = document.getElementById('<%= inp_password.ClientID %>').value;
            var repassword = document.getElementById('<%= inp_confirmPassword.ClientID %>').value;
            var email = document.getElementById('<%= inp_email.ClientID %>').value.trim();
            var phone = document.getElementById('<%= txtPhone.ClientID %>').value.trim();
            var country = document.getElementById('<%= txtCountry.ClientID %>').value.trim();

            // Validate first name
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

            // Validate last name
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

            // Validate email format
            if (!email.includes('@') || !email.includes('.')) {
                alert("Please Enter A Valid Email");
                return false;
            }

            // Validate password length
            if (password.length < 12) {
                alert("Passwords Must Be At Least 12 Characters Long");
                return false;
            }

            // Validate password match
            if (password !== repassword) {
                alert("Passwords Must Match");
                return false;
            }

            // Validate password complexity
            if (!/\d/.test(password) || !/[A-Z]/.test(password)) {
                alert("Password Must Contain At Least One Number And One Capital Letter");
                return false;
            }

            // Validate phone number format
            if (!/^\d+$/.test(phone)) {
                alert("Phone Number Must Contain Only Numbers");
                return false;
            }

            // Validate country name
            if (/\d/.test(country)) {
                alert("Country Name Cannot Contain Numbers");
                return false;
            }

            return true;
        }

        // Attach the validation function to the click event of the register button
        document.getElementById('<%= btnRegister.ClientID %>').addEventListener('click', function (event) {
            if (!validateForm()) {
                event.preventDefault(); // Prevent the default action (form submission)
            }
        });
    </script>

</asp:Content>