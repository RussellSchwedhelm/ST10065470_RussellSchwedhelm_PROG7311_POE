<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Including the stylesheet for the page -->
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <!-- Styling the hero section -->
    <style>
        .hero-section {
            background: url('<%= ResolveUrl("~/Resources/Images/AboutUsBanner.jpg") %>') no-repeat center;
            height: 400px;
            color: white;
            text-align: center;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }
    </style>
    <!-- Hero section with a title and a brief description -->
    <div class="hero-section">
        <h1>About Us</h1>
        <p>Empowering Farmers with Sustainable Practices</p>
    </div>
    <!-- Main content container -->
    <div class="container">
        <!-- Introduction section -->
        <h2 class="section-title">Introduction</h2>
        <p class="section-content">
            Agri-Energy Connect was created in response to the increasing demand for 
            sustainable agricultural practices and the integration of green energy 
            solutions within South Africa. We aim to bridge the gap between the 
            agricultural sector and green energy providers, while fostering a 
            collaborative environment that promotes sustainable growth and 
            technological advancement.
        </p>
        <!-- Vision section -->
        <h2 class="section-title">Our Vision</h2>
        <p class="section-content">
            Our vision is to create a dynamic digital ecosystem where farmers, green 
            energy experts, and enthusiasts can interact, share resources, and drive 
            innovations in sustainable agriculture and renewable energy. We are 
            committed to facilitating a seamless integration of green technologies 
            into agricultural practices, thereby enhancing productivity and sustainability.
        </p>
        <!-- Objectives section -->
        <h2 class="section-title">Objectives</h2>
        <div class="section-content">
            <!-- Promote Sustainable Farming -->
            <h3>Promote Sustainable Farming</h3>
            <p>Provide a comprehensive resource center featuring best practices in 
                sustainable farming, including organic farming techniques, water 
                conservation methods, and soil health maintenance.</p>

            <!-- Facilitate Green Energy Solutions -->
            <h3>Facilitate Green Energy Solutions</h3>
            <p>Establish a marketplace tailored to agricultural needs, offering solutions 
                such as solar-powered irrigation systems, wind turbines, and biogas energy options.</p>

            <!-- Educational Empowerment -->
            <h3>Educational Empowerment</h3>
            <p>Offer online courses, webinars, and workshops focused on integrating
                green energy technologies in agriculture, highlighting the benefits
                and practicalities of adopting renewable energy sources.</p>

            <!-- Foster Collaboration -->
            <h3>Foster Collaboration</h3>
            <p>Enable project collaboration and provide information on funding 
                opportunities, grants, and subsidies to support green initiatives in agriculture.</p>
        </div>
        <!-- Key Features section -->
        <h2 class="section-title">Key Features</h2>
        <div class="section-content">
            <!-- Sustainable Farming Hub -->
            <h3>Sustainable Farming Hub:</h3>
            <ul>
                <li>A comprehensive resource center for sustainable farming practices.</li>
                <li>Interactive forums for farmers to exchange advice, experiences, 
                    and collaborate on initiatives.</li>
            </ul>
            <!-- Green Energy Marketplace -->
            <h3>Green Energy Marketplace:</h3>
            <ul>
                <li>A platform for comparing and reviewing green energy products.</li>
                <li>Connects farmers with technology providers for tailored solutions.</li>
            </ul>
            <!-- Educational and Training Resources -->
            <h3>Educational and Training Resources:</h3>
            <ul>
                <li>Online courses and workshops on green energy technologies.</li>
                <li>Practical guides on adopting renewable energy sources in farming.</li>
            </ul>
            <!-- Project Collaboration and Funding -->
            <h3>Project Collaboration and Funding:</h3>
            <ul>
                <li>A space for proposing and collaborating on joint projects.</li>
                <li>Access to information on grants, subsidies, and other funding opportunities.</li>
            </ul>
        </div>
        <!-- Our Commitment section -->
        <h2 class="section-title">Our Commitment</h2>
        <p class="section-content">
            Agri-Energy Connect is dedicated to driving the future of sustainable 
            agriculture through innovative green energy solutions. We believe in 
            the power of collaboration and are committed to supporting the agricultural 
            community in achieving greater sustainability and efficiency.
        </p>
        <!-- Features section -->
        <h2 class="section-title">Features</h2>
        <ul class="features-list">
            <li>Comprehensive guides on sustainable farming techniques</li>
            <li>Interactive forums for discussion and knowledge sharing</li>
            <li>Case studies showcasing successful sustainable farms</li>
            <li>Access to the latest research and innovations in sustainable agriculture</li>
            <li>Connections to suppliers of sustainable farming equipment and materials</li>
        </ul>
        <!-- Resources section -->
        <h2 class="section-title">Resources</h2>
        <ul class="resources-list">
            <li><a href="#">Guide to Crop Rotation</a></li>
            <li><a href="#">Organic Pest Control Methods</a></li>
            <li><a href="#">Water Conservation Techniques</a></li>
            <li><a href="#">Soil Health Management</a></li>
            <li><a href="#">Sustainable Livestock Farming</a></li>
        </ul>
    </div>
</asp:Content>
