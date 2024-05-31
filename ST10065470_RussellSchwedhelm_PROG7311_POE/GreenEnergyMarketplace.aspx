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
        .search-bar input, .search-bar select, .search-bar .buttons {
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-right: 10px;
            width: auto; /* Make the width auto to wrap content */
        }
        .supplier-list, .items-list {
            max-height: 250px;
            overflow-y: scroll;
            padding: 0;
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
            <div class="search-bar" style="display: flex; align-items: center; flex-wrap: wrap;">
                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search Suppliers/Items" CssClass="form-control" />
                <input type="date" id="dp_fromDate" name="dateOfProduction" runat="server" CssClass="form-control" />
                <input type="date" id="dp_toDate" name="dateOfProduction" runat="server" CssClass="form-control" /> 
                <select id="sel_category" name="category" runat="server" CssClass="form-control"></select>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="buttons" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="buttons" />
            </div>
        </div>

        <ul class="supplier-list">
            <asp:Repeater ID="supplierList" runat="server" OnItemCommand="SupplierList_ItemCommand">
                <ItemTemplate>
                    <li>
                        <div style="overflow: hidden;">
                            <span style="float: left;"><%# Eval("FirstName") %> <%# Eval("Surname") %></span>
                            <asp:Button ID="btnSelectSupplier" runat="server" Text="Select" CommandName="SelectSupplier" CommandArgument='<%# Eval("UserId") %>' CssClass="buttons" style="float: right;" />
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

        <div id="AllItems" runat="server">
            <div class="store-header">
                <h2 class="section-title">All Items</h2>
            </div>
            <ul class="items-list">
                <asp:Repeater ID="allItemList" runat="server">
                    <ItemTemplate>
                        <li><%# Eval("ProductName") %> &nbsp;&nbsp;|&nbsp;&nbsp; <%# Eval("Category") %> &nbsp;&nbsp;|&nbsp;&nbsp; <%# Eval("PDate", "{0:yyyy-MM-dd}") %></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>

        <div id="MyStore" runat="server">
            <div class="store-header">
                <h2 class="section-title">My Store</h2>
                <asp:Button PostBackUrl="~/CreateItem.aspx" Text="Create New Item" runat="server" CssClass="buttons" />
            </div>
            <ul class="items-list">
                <asp:Repeater ID="itemList" runat="server">
                    <ItemTemplate>
                        <li><%# Eval("ProductName") %> &nbsp;&nbsp;|&nbsp;&nbsp; <%# Eval("Category") %> &nbsp;&nbsp;|&nbsp;&nbsp; <%# Eval("PDate", "{0:yyyy-MM-dd}") %></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</asp:Content>
