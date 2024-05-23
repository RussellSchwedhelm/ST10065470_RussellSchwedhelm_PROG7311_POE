<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <style>
        .main-banner {
            background: url('<%= ResolveUrl("~/Resources/Images/HomeBanner.jpg") %>') no-repeat center;
            height: 400px;
            color: white;
            text-align: center;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }
    </style>

    <div class="main-banner">
        <h1>Welcome to Agri-Energy Connect</h1>
        <p>Your Hub for Sustainable Agriculture and Green Energy Solutions</p>
        <div class="buttons">
            <asp:Button ID="btnLearnMore" runat="server" Text="Learn More" CssClass="buttons" OnClick="btnLearnMore_Click" />
        </div>
    </div>
    <div class="container">
        <div class="about-message-container">
            <div class="about-us">
                <h2>About Us</h2>
                <p>
                    Agri-Energy Connect is a digital platform bridging sustainable agriculture and green energy solutions in South Africa.
                    We foster collaboration, innovation, and resource sharing to promote eco-friendly and sustainable agricultural practices.
                </p>
            </div>
            <div class="message-box">
                <h3>Messages</h3>
                <ul class="contact-list">
                    <li><span class="unread">John Doe (Unread)</span></li>
                    <li>Jane Smith (Read)</li>
                    <li>Mark Johnson (Unread)</li>
                </ul>
            </div>
        </div>
        <h2>Features</h2>
        <div class="features-grid">
            <div class="feature-item">Interactive forums for farmers and energy experts</div>
            <div class="feature-item">Resource center for sustainable farming practices</div>
            <div class="feature-item">Marketplace for green energy solutions</div>
            <div class="feature-item">Educational resources and training</div>
            <div class="feature-item">Project collaboration and funding opportunities</div>
            <div class="feature-item">Additional Feature Placeholder</div>
        </div>
    </div>
</asp:Content>
