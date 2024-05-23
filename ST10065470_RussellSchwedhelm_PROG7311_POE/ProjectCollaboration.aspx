<%@ Page Title="Project Collaboration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectCollaboration.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.ProjectCollaboration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .hero-section {
            background: url('<%= ResolveUrl("~/Resources/Images/ProjectCollaborationBanner.jpg") %>') no-repeat center;
            height: 300px;
            color: white;
            text-align: center;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }
    </style>
    <div class="hero-section">
        <h1>Project Collaboration</h1>
        <p>Collaborate on Sustainable Projects</p>
    </div>
    <div class="container">
        <h2 class="section-title">Introduction</h2>
        <p class="section-content">
            Welcome to the Project Collaboration section, where you can join forces with other farmers, researchers, and experts to work on sustainable projects. Our platform facilitates collaboration by providing tools and resources for effective project management and communication.
        </p>
        <h2 class="section-title">Features</h2>
        <ul class="features-list">
            <li>Platform to find and join collaborative projects</li>
            <li>Project management tools and resources</li>
            <li>Forums for discussion and idea exchange</li>
            <li>Access to a network of experts and collaborators</li>
            <li>Showcase of successful collaborative projects</li>
        </ul>
        <h2 class="section-title">Resources</h2>
        <ul class="resources-list">
            <li><a href="#">Guide to Effective Collaboration</a></li>
            <li><a href="#">Project Management Tools</a></li>
            <li><a href="#">Case Studies of Collaborative Projects</a></li>
            <li><a href="#">Funding Opportunities for Joint Projects</a></li>
            <li><a href="#">Networking Events and Workshops</a></li>
        </ul>
    </div>
</asp:Content>
