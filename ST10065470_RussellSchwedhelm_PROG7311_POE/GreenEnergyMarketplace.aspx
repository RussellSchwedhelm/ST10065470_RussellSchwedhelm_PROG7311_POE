<%@ Page Title="Green Energy Marketplace" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GreenEnergyMarketplace.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.GreenEnergyMarketplace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <style>
        .hero-section {
            background: url('<%= ResolveUrl("~/Resources/Images/GreenEnergyBanner.jpg") %>') no-repeat center;
            height: 400px;
            color: white;
            text-align: center;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }
        .marketplace-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 20px 0;
        }
        .store-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 20px 0;
        }
        #txtSearch {
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-right: 10px;
        }
    </style>
    <div class="hero-section">
        <h1>Green Energy Marketplace</h1>
        <p>Connecting You with Sustainable Energy Solutions</p>
    </div>
    <div class="container">
        <h2 class="section-title">Introduction</h2>
        <p class="section-content">
            Welcome to the Green Energy Marketplace, where you can find innovative and sustainable energy solutions for your agricultural needs.
            Our platform connects farmers, suppliers, and experts in green energy to promote the use of eco-friendly and renewable energy sources.
        </p>
        <div class="marketplace-header">
            <h2 class="section-title">Marketplace</h2>
            <div class="search-bar">
                <input type="text" id="txtSearch" placeholder="Search Suppliers..." />
                <button type="button" class="buttons">Search</button>
            </div>
        </div>
        <ul id="supplierList" class="supplier-list">
            <li>Supplier 1</li>
            <li>Supplier 2</li>
            <li>Supplier 3</li>
            <li>Supplier 4</li>
            <li>Supplier 5</li>
        </ul>
        <div class="store-header">
            <h2 class="section-title">My Store</h2>
            <button type="button" PostBackUrl="~/CreateItem.aspx"class="buttons">Create New Item</button>
        </div>
        <ul id="itemList" class="supplier-list">
            <li>Item 1</li>
            <li>Item 2</li>
            <li>Item 3</li>
            <li>Item 4</li>
            <li>Item 5</li>
        </ul>
    </div>
</asp:Content>
