<%@ Page Title="Modify Farmers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyFarmers.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.ModifyFarmers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <style>
        .modify-farmers-header {
            margin-top: 20px;
        }

        .description-container {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 20px;
        }

        .farmers-list {
            list-style: none;
            padding: 0;
        }

        .farmers-list li {
            display: flex;
            justify-content: space-between;
            align-items: center;
            background-color: #e2e2e2;
            border-radius: 5px;
            padding: 10px;
            margin-bottom: 10px;
        }

        .farmers-list li span {
            flex: 1;
        }

        .farmers-list .buttons {
            margin: 0 5px;
        }

        /* Overlay styles */
        .overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            display: none;
            align-items: center;
            justify-content: center;
            z-index: 1000;
        }

        .popup {
            background-color: #e2e2e2;
            border-radius: 5px;
            padding: 20px;
            text-align: center;
            width: 300px;
        }

        .popup h3 {
            margin-bottom: 20px;
        }

        .popup .popup-buttons {
            display: flex;
            justify-content: space-around;
        }

        .popup .buttons {
            flex: 1;
            margin: 10px;
            padding: 10px;
        }
    </style>

    <div class="container">
        <h2 class="modify-farmers-header">Modify Farmers</h2>
        <div class="description-container">
            <p>
                This page allows you to manage the list of farmers. You can modify the details of each farmer or delete them from the system.
            </p>
            <asp:Button ID="btnCreateNew" runat="server" Text="Create New" CssClass="buttons" OnClick="btnCreateNew_Click" />
        </div>
        <ul class="farmers-list">
            <li>
                <span>John Doe</span>
                <div>
                    <asp:Button ID="btnModifyJohn" runat="server" Text="Modify" CssClass="buttons" OnClick="btnModify_Click" />
                    <asp:Button ID="btnDeleteJohn" runat="server" Text="Delete" CssClass="buttons" OnClientClick="showPopup('John Doe'); return false;" />
                </div>
            </li>
            <li>
                <span>Jane Smith</span>
                <div>
                    <asp:Button ID="btnModifyJane" runat="server" Text="Modify" CssClass="buttons" OnClick="btnModify_Click" />
                    <asp:Button ID="btnDeleteJane" runat="server" Text="Delete" CssClass="buttons" OnClientClick="showPopup('Jane Smith'); return false;" />
                </div>
            </li>
            <li>
                <span>Mark Johnson</span>
                <div>
                    <asp:Button ID="btnModifyMark" runat="server" Text="Modify" CssClass="buttons" OnClick="btnModify_Click" />
                    <asp:Button ID="btnDeleteMark" runat="server" Text="Delete" CssClass="buttons" OnClientClick="showPopup('Mark Johnson'); return false;" />
                </div>
            </li>
            <!-- Additional farmers can be added here -->
        </ul>
    </div>

<!-- Overlay and popup for delete confirmation -->
<div id="overlay" class="overlay">
    <div class="popup">
        <h3>Are you sure you want to delete this farmer?</h3>
        <asp:HiddenField ID="hiddenFarmerName" runat="server" />
        <div class="popup-buttons">
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="buttons" OnClientClick="hidePopup(); return false;" />
            <asp:Button ID="btnContinue" runat="server" Text="Continue" CssClass="buttons" OnClick="btnDeleteConfirm_Click" />
        </div>
    </div>
</div>

<!-- Overlay and popup for farmer removal confirmation -->
<div id="removeOverlay" class="overlay">
    <div class="popup">
        <h3>Farmer has been removed from the database.</h3>
        <div class="popup-buttons">
            <asp:Button ID="btnContinueRemove" runat="server" Text="Continue" CssClass="buttons" OnClick="btnContinueRemove_Click" />
        </div>
    </div>
</div>

<script type="text/javascript">
    function showPopup(farmerName) {
        document.getElementById('<%= hiddenFarmerName.ClientID %>').value = farmerName;
        document.getElementById('overlay').style.display = 'flex';
    }

    function hidePopup() {
        document.getElementById('overlay').style.display = 'none';
    }

    function showRemovePopup() {
        document.getElementById('removeOverlay').style.display = 'flex';
    }
</script>
</asp:Content>
