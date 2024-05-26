<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateItem.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.CreateItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <style>
        .create-item-container {
            display: flex;
            flex-direction: column;
            margin-top: 20px;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            margin: 50px auto;
        }

        .create-item-container label {
            margin-bottom: 5px;
            align-items: center;
        }

        .create-item-container input[type="text"],
        .create-item-container select,
        .create-item-container input[type="date"],
        .create-item-container textarea {
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-bottom: 15px;
            padding: 10px;
            width: calc(100% - 22px);
            align-items: center;
        }

        .create-item-container textarea {
            resize: vertical;
            height: 100px;
            width: 100%;
            align-items: center;
        }

        .create-item-container select {
            appearance: none;
            -webkit-appearance: none;
            -moz-appearance: none;
            align-items: center;
        }
    </style>

    <script type="text/javascript">
        function showCategoryInput() {
            document.getElementById('<%= inp_newCategory.ClientID %>').style.display = 'block';
        }
    </script>

    <div class="container">
        <h1>Create Item</h1>

        <div class="create-item-container">
            <label for="inp_itemName">Item Name</label>
            <input type="text" id="inp_itemName" name="itemName" runat="server" />

            <label for="sel_category">Category</label>
            <select id="sel_category" name="category" runat="server">
            </select>
            <input type="text" id="inp_newCategory" name="newCategory" runat="server" placeholder="Enter new category" style="display: none;" />
            <asp:Button ID="btnNewCat" CssClass="buttons" runat="server" Text="New Category" OnClientClick="showCategoryInput(); return false;" />

            <label for="inp_dateOfProduction">Date of Production</label>
            <input type="date" id="inp_dateOfProduction" name="dateOfProduction" runat="server" />

            <label for="inp_description">Description</label>
            <textarea id="inp_description" name="description" runat="server"></textarea>

            <asp:Button ID="btnCreateItem" CssClass="buttons" runat="server" Text="Create Item" OnClick="btnCreateItem_Click" />
        </div>
    </div>
</asp:Content>
