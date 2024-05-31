<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateItem.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.CreateItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Include stylesheet -->
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <!-- Define styles -->
    <style>
        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background: url('<%= ResolveUrl("~/Resources/Images/CreateItemBanner.jpg") %>') no-repeat center;
            background-size: cover;
            padding: 50px; /* Ensure background image peeks out */
        }

        .create-item-container {
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            width: 100%;
            text-align: center;
            display: flex;
            flex-direction: column; /* Ensure items are stacked */
            align-items: center; /* Center items horizontally */
            padding: 50px; /* Ensure background image peeks out */
        }

        .create-item-container label,
        .create-item-container input[type="text"],
        .create-item-container select,
        .create-item-container input[type="date"],
        .create-item-container textarea,
        .create-item-container .buttons {
            margin-bottom: 15px;
            width: 100%;
        }

        .create-item-container input[type="text"],
        .create-item-container select,
        .create-item-container input[type="date"],
        .create-item-container textarea {
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 10px;
        }

        .create-item-container textarea {
            resize: vertical;
            height: 100px;
        }

    </style>

    <!-- Define JavaScript function to show category input -->
    <script type="text/javascript">
        function showCategoryInput() {
            document.getElementById('<%= inp_newCategory.ClientID %>').style.display = 'block';
        }
    </script>

    <!-- HTML content -->
    <div class="container">
        <!-- Form for creating new item -->
        <div class="create-item-container">
            <h1>Create Item</h1>

            <!-- Input field for item name -->
            <label for="inp_itemName">Item Name</label>
            <input type="text" id="inp_itemName" name="itemName" runat="server" />

            <!-- Dropdown for selecting category -->
            <label for="sel_category">Category</label>
            <select id="sel_category" name="category" runat="server"></select>

            <!-- Input field for new category, initially hidden -->
            <input type="text" id="inp_newCategory" name="newCategory" runat="server" placeholder="Enter new category" style="display: none;" />
            
            <!-- Button to reveal new category input -->
            <asp:Button ID="btnNewCat" CssClass="buttons" runat="server" Text="New Category" OnClientClick="showCategoryInput(); return false;" />

            <!-- Input field for date of production -->
            <label for="inp_dateOfProduction">Date of Production</label>
            <input type="date" id="inp_dateOfProduction" name="dateOfProduction" runat="server" />

            <!-- Input field for item description -->
            <label for="inp_description">Description</label>
            <textarea id="inp_description" name="description" runat="server"></textarea>

            <!-- Button to create the item -->
            <asp:Button ID="btnCreateItem" CssClass="buttons" runat="server" Text="Create Item" OnClick="btnCreateItem_Click" />
        </div>
    </div>
</asp:Content>
