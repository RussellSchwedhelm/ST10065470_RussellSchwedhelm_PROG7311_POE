<%@ Page Title="Modify Farmer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFarmer.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.CreateFarmer" %>
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

        /* Popup styles */
        .overlay {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            z-index: 1000;
        }

        .popup {
            background-color: #fff;
            border-radius: 5px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            text-align: center;
        }
    </style>

    <div class="create-farmer-container">
        <h2>Modify Farmer</h2>
        <div class="section-separator"></div>
        
        <div class="form-group">
            <div class="section-title">Name</div>
            <asp:TextBox ID="txtFirstName" runat="server" Placeholder="First Name" CssClass="form-control" />
            <asp:TextBox ID="txtSurname" runat="server" Placeholder="Surname" CssClass="form-control" />
            
            <div class="section-separator"></div>
            
            <div class="section-title">Address</div>
            <asp:TextBox ID="txtStreetNumber" runat="server" Placeholder="Street Number" CssClass="form-control" />
            <asp:TextBox ID="txtStreet" runat="server" Placeholder="Street" CssClass="form-control" />
            <asp:TextBox ID="txtSuburb" runat="server" Placeholder="Suburb" CssClass="form-control" />
            <asp:TextBox ID="txtCity" runat="server" Placeholder="City" CssClass="form-control" />
            <asp:TextBox ID="txtProvince" runat="server" Placeholder="Province" CssClass="form-control" />
            <asp:TextBox ID="txtCountry" runat="server" Placeholder="Country" CssClass="form-control" />
            
            <div class="section-separator"></div>
            
            <div class="section-title">Contact Info</div>
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" CssClass="form-control" />
            <asp:TextBox ID="txtPhone" runat="server" Placeholder="Phone Number" CssClass="form-control" />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="buttons" OnClick="btnSubmit_Click" />
        </div>
    </div>

    <!-- Popup for success message -->
    <div class="overlay" id="popupOverlay">
        <div class="popup">
            <p id="popupMessage"></p>
            <button class="buttons" id="btnContinue" OnClick="btnContinue_Click">Continue</button>
        </div>
    </div>

    <script>
        document.getElementById('btnSubmit').addEventListener('click', function (event) {
            event.preventDefault();

            // Input validation checks
            var firstName = document.getElementById('txtFirstName').value.trim();
            var lastName = document.getElementById('txtSurname').value.trim();
            var streetNumber = document.getElementById('txtStreetNumber').value.trim(); // Added street number check
            var email = document.getElementById('txtEmail').value.trim();
            var phone = document.getElementById('txtPhone').value.trim();
            var country = document.getElementById('txtCountry').value.trim();

            if (firstName === '') {
                alert("Please Enter A First Name");
                return false;
            }

            if (lastName === '') {
                alert("Please Enter A Surname");
                return false;
            }

            if (!/^\d+$/.test(streetNumber)) {
                alert("Street Number Must Contain Only Numbers");
                return false;
            }

            if (!email.includes('@') || !email.includes('.')) {
                alert("Please Enter A Valid Email");
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

            // If all checks pass, display the popup
            document.getElementById('popupOverlay').style.display = 'block';
        });

        function showPopup(message) {
            document.getElementById('popupOverlay').style.display = 'block';
            document.getElementById('popupMessage').innerText = message;
        }

        // Continue button action
        document.getElementById('btnContinue').addEventListener('click', function () {
            window.location.href = 'ModifyFarmers.aspx';
        }
    </script>
</asp:Content>