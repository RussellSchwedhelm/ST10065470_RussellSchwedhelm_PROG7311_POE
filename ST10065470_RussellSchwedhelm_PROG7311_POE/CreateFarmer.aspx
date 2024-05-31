<%@ Page Title="Modify Farmer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFarmer.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.CreateFarmer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Including the stylesheet for the page -->
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <!-- Styling the hero section -->
    <style>
        /* Hero section styling */
        .hero-section {
            background: url('<%= ResolveUrl("~/Resources/Images/CreateFarmerBanner.jpg") %>') no-repeat center;
            height: calc(100% + 60px); /* Original height + 60px */
            width: calc(100% + 60px); /* Original width + 60px */
            margin: -30px; /* Negative margin to expand the hero section */
            position: relative; /* Required for z-index */
            z-index: -1; /* Ensure hero section is behind other content */
        }

        /* Container styling for the form */
        .create-farmer-container {
            position: relative; /* Ensure it's above the hero section */
            z-index: 1; /* Ensure it's above the hero section */
        }
    </style>
    <!-- Hero section containing the form -->
    <div class="hero-section">
        <div class="create-farmer-container">
            <!-- Heading for the form -->
            <h2 id="heading-title">Modify Farmer</h2>
            <!-- Separator between sections -->
            <div class="section-separator"></div>
            <!-- Form elements for modifying farmer details -->
            <div class="form-group">
                <div class="section-title">Name</div>
                <!-- Textboxes for first name and surname -->
                <asp:TextBox ID="txtFirstName" runat="server" Placeholder="First Name" CssClass="form-control" />
                <asp:TextBox ID="txtSurname" runat="server" Placeholder="Surname" CssClass="form-control" />

                <!-- Separator between sections -->
                <div class="section-separator"></div>

                <div class="section-title">Address</div>
                <!-- Textboxes for address details -->
                <asp:TextBox ID="txtStreetNumber" runat="server" Placeholder="Street Number" CssClass="form-control" />
                <asp:TextBox ID="txtStreet" runat="server" Placeholder="Street" CssClass="form-control" />
                <asp:TextBox ID="txtSuburb" runat="server" Placeholder="Suburb" CssClass="form-control" />
                <asp:TextBox ID="txtCity" runat="server" Placeholder="City" CssClass="form-control" />
                <asp:TextBox ID="txtProvince" runat="server" Placeholder="Province" CssClass="form-control" />
                <asp:TextBox ID="txtCountry" runat="server" Placeholder="Country" CssClass="form-control" />

                <!-- Separator between sections -->
                <div class="section-separator"></div>

                <div class="section-title">Contact Info</div>
                <!-- Textboxes for contact information -->
                <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" CssClass="form-control" />
                <asp:TextBox ID="txtPhone" runat="server" Placeholder="Phone Number" CssClass="form-control" />
                <!-- Button to submit the form -->
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="buttons" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>
    <!-- Popup for success message -->
    <div id="overlay" class="overlay" style="display: none;">
        <div class="popup">
            <!-- Success message -->
            <p id="popupMessage"></p>
            <!-- Hidden field for storing farmer ID -->
            <asp:HiddenField ID="hiddenFarmerId" runat="server" />
            <!-- Button to continue -->
            <div class="popup-buttons">
                <button class="buttons" id="btnContinue" runat="server" onserverclick="btnContinue_Click">Continue</button>
            </div>
        </div>
    </div>

    <!-- JavaScript for form validation and functionality -->
    <script type="text/javascript">
        // Function to execute when the DOM is fully loaded
        document.addEventListener("DOMContentLoaded", function () {
            // Adding event listener for form submission
            document.getElementById('btnSubmit').addEventListener('click', function (event) {
                // Preventing default form submission
                event.preventDefault();

                // Input validation checks
                var firstName = document.getElementById('txtFirstName').value.trim();
                var lastName = document.getElementById('txtSurname').value.trim();
                var streetNumber = document.getElementById('txtStreetNumber').value.trim();
                var email = document.getElementById('txtEmail').value.trim();
                var phone = document.getElementById('txtPhone').value.trim();
                var country = document.getElementById('txtCountry').value.trim();

                // Validation for street number
                if (streetNumber.Any(char.IsLetter)) {
                    showPopup("Street Number Must Contain Only Numbers");
                    return false;
                }

                // Validation for email format
                if (!email.includes('@') || !email.includes('.')) {
                    showPopup("Please Enter A Valid Email");
                    return false;
                }

                // Validation for phone number
                if (phone.Any(char.IsLetter)) {
                    showPopup("Phone Number Must Contain Only Numbers");
                    return false;
                }

                // Validation for country name
                if (!country.Any(char.IsLetter)) {
                    showPopup("Country Name Cannot Contain Numbers");
                    return false;
                }
            });
        });

        // Function to display popup with message
        function showPopup(message) {
            document.getElementById('popupMessage').innerText = message;
            document.getElementById('overlay').style.display = 'flex';
        }

        // Function to hide the popup
        function hidePopup() {
            document.getElementById('overlay').style.display = 'none';
        }

        // Function to set the title of the form
        function setTitle() {
            document.getElementById('heading-title').innerText = "Create Farmer";
        }
    </script>
</asp:Content>