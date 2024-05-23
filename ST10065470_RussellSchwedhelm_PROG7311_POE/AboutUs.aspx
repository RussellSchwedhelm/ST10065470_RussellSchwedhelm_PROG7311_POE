<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
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
        .section-content h3 {
            margin-top: 20px;
        }
        .section-content p {
            margin-left: 20px;
        }
    </style>
    <div class="hero-section">
        <h1>About Us</h1>
        <p>Empowering Farmers with Sustainable Practices</p>
    </div>
    <div class="container">
        <h2 class="section-title">Introduction</h2>
        <p class="section-content">
            Agri-Energy Connect is a pioneering initiative developed in response 
            to the increasing demand for sustainable agricultural practices and the 
            integration of green energy solutions within South Africa. This innovative 
            platform aims to bridge the gap between the agricultural sector and green 
            energy technology providers, fostering a collaborative environment that 
            promotes sustainable growth and technological advancement.
        </p>
        <h2 class="section-title">Our Vision</h2>
        <p class="section-content">
            Our vision is to create a dynamic digital ecosystem where farmers, green 
            energy experts, and enthusiasts can interact, share resources, and drive 
            innovations in sustainable agriculture and renewable energy. We are 
            committed to facilitating a seamless integration of green technologies 
            into agricultural practices, thereby enhancing productivity and sustainability.
        </p>
        <h2 class="section-title">Objectives</h2>
        <div class="section-content">
            <h3>Promote Sustainable Farming</h3>
            <p>Provide a comprehensive resource center featuring best practices in 
                sustainable farming, including organic farming techniques, water 
                conservation methods, and soil health maintenance.</p>

            <h3>Facilitate Green Energy Solutions</h3>
            <p>Establish a marketplace tailored to agricultural needs, offering solutions 
                such as solar-powered irrigation systems, wind turbines, and biogas energy options.</p>

            <h3>Educational Empowerment</h3>
            <p>Offer online courses, webinars, and workshops focused on integrating
                green energy technologies in agriculture, highlighting the benefits
                and practicalities of adopting renewable energy sources.</p>

            <h3>Foster Collaboration</h3>
            <p>Enable project collaboration and provide information on funding 
                opportunities, grants, and subsidies to support green initiatives in agriculture.</p>
        </div>
        <h2 class="section-title">Key Features</h2>
        <div class="section-content">
            <h3>Sustainable Farming Hub:</h3>
            <ul>
                <li>A comprehensive resource center for sustainable farming practices.</li>
                <li>Interactive forums for farmers to exchange advice, experiences, 
                    and collaborate on initiatives.</li>
            </ul>
            <h3>Green Energy Marketplace:</h3>
            <ul>
                <li>A platform for comparing and reviewing green energy products.</li>
                <li>Connects farmers with technology providers for tailored solutions.</li>
            </ul>
            <h3>Educational and Training Resources:</h3>
            <ul>
                <li>Online courses and workshops on green energy technologies.</li>
                <li>Practical guides on adopting renewable energy sources in farming.</li>
            </ul>
            <h3>Project Collaboration and Funding:</h3>
            <ul>
                <li>A space for proposing and collaborating on joint projects.</li>
                <li>Access to information on grants, subsidies, and other funding opportunities.</li>
            </ul>
        </div>
        <h2 class="section-title">Our Commitment</h2>
        <p class="section-content">
            Agri-Energy Connect is dedicated to driving the future of sustainable 
            agriculture through innovative green energy solutions. We believe in 
            the power of collaboration and are committed to supporting the agricultural 
            community in achieving greater sustainability and efficiency.
        </p>
        <h2 class="section-title">Features</h2>
        <ul class="features-list">
            <li>Comprehensive guides on sustainable farming techniques</li>
            <li>Interactive forums for discussion and knowledge sharing</li>
            <li>Case studies showcasing successful sustainable farms</li>
            <li>Access to the latest research and innovations in sustainable agriculture</li>
            <li>Connections to suppliers of sustainable farming equipment and materials</li>
        </ul>
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
