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
        #txtSearch {
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-right: 10px;
        }
        .supplier-list, .item-list {
            max-height: 200px;
            overflow-y: scroll;
            padding: 0;
            list-style: none;
        }
        .supplier-list li, .item-list li {
            padding: 10px;
            border-bottom: 1px solid #ccc;
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
            <div class="search-bar" style="display: flex; align-items: center;">
                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search Suppliers or Items..." CssClass="form-control" />
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="buttons" />
            </div>
        </div>
        <asp:Repeater ID="supplierList" runat="server">
            <ItemTemplate>
                <li><%# Eval("FirstName") %> <%# Eval("Surname") %></li>
            </ItemTemplate>
        </asp:Repeater>
        <div id="MyStore" runat="server">
            <div class="store-header">
                <h2 class="section-title">My Store</h2>
                <asp:Button PostBackUrl="~/CreateItem.aspx" Text="Create New Item" runat="server" CssClass="buttons" />
            </div>
            <asp:Repeater ID="itemList" runat="server">
                <ItemTemplate>
                    <li><%# Eval("ProductName") %></li>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
