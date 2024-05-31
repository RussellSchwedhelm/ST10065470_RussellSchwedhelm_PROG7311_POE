<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Including the stylesheet for the page -->
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <!-- Styling the main banner -->
    <style>
        /* Styling for the main banner */
        .main-banner {
            background: url('<%= ResolveUrl("~/Resources/Images/HomeBanner.jpg") %>') no-repeat center;
            height: 400px; /* Fixed height for the main banner */
            color: white;
            text-align: center;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }
    </style>

    <!-- Main banner section -->
    <div class="main-banner">
        <!-- Heading and description for the main banner -->
        <h1>Welcome to Agri-Energy Connect</h1>
        <p>Your Hub for Sustainable Agriculture and Green Energy Solutions</p>
        <!-- Button for learning more -->
        <div class="buttons">
            <asp:Button ID="btnLearnMore" runat="server" Text="Learn More" CssClass="buttons" OnClick="btnLearnMore_Click" />
        </div>
    </div>
    <!-- Main content container -->
    <div class="container">
        <!-- Features section -->
        <h2>Features</h2>
            <!-- Grid for displaying features -->
            <div class="features-grid">
                <!-- Individual feature items with onclick events -->
                <div class="feature-item" onclick="redirectToForums()">Interactive Forums For Farmers And Energy Experts</div>
                <div class="feature-item" onclick="redirectToMarketplace()">Marketplace For Green Energy Solutions And Sales</div>
                <div class="feature-item" onclick="redirectToResources()">Educational Resources</div>
                <div class="feature-item" onclick="redirectToCollaboration()">Project Collaboration And Funding Opportunities</div>
            </div>
            <!-- Message box section -->
            <div class="message-box" onclick="redirectToForums()">
                <h3>Messages</h3>
                <!-- List of contact messages -->
                <ul class="contact-list">
                    <li><span class="unread">John Doe (Unread)</span></li>
                    <li>Jane Smith (Read)</li>
                    <li>Mark Johnson (Unread)</li>
                </ul>
            </div>
        </div>
    
    <!-- JavaScript for redirecting to different pages -->
    <script>
        // Function to redirect to forums page
        function redirectToForums() {
            window.location.href = "Forum.aspx";
        }

        // Function to redirect to green energy marketplace page
        function redirectToMarketplace() {
            window.location.href = "GreenEnergyMarketplace.aspx";
        }

        // Function to redirect to educational resources page
        function redirectToResources() {
            window.location.href = "EducationalResources.aspx";
        }

        // Function to redirect to project collaboration page
        function redirectToCollaboration() {
            window.location.href = "ProjectCollaboration.aspx";
        }
    </script>
</asp:Content>
