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
            align-items:center;
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
            align-items:center;
        }

        .create-item-container textarea {
            resize: vertical;
            height: 100px;
            width: 100%;
            align-items:center;
        }

        .create-item-container select {
            appearance: none; /* Remove default appearance */
            -webkit-appearance: none; /* Remove default appearance for Safari */
            -moz-appearance: none; /* Remove default appearance for Firefox */
            align-items:center;
        }
    </style>

    <div class="container">
        <h1>Create Item</h1>

        <div class="create-item-container">
            <label for="itemName">Item Name</label>
            <input type="text" id="itemName" name="itemName" required />

            <label for="category">Category</label>
                <select id="category" name="category" required>
                    <option value="electronics">Electronics</option>
                    <option value="clothing">Clothing</option>
                    <option value="home-goods">Home Goods</option>
                </select>
                <button type="button" class="buttons" onclick="showCategoryInput()">New Category</button>
            <input type="text" id="newCategory" name="newCategory" placeholder="Enter new category" style="display: none;" />

            <label for="dateOfProduction">Date of Production</label>
            <input type="date" id="dateOfProduction" name="dateOfProduction" required />

            <label for="description">Description</label>
            <textarea id="description" name="description" required></textarea>

            <input type="submit" class="buttons" value="Create Item" />
        </div>
    </div>
</asp:Content>
