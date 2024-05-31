<%@ Page Title="Modify Farmers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyFarmers.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.ModifyFarmers" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Including the stylesheet for the page -->
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <!-- CSS styles for page elements -->
    <style>
        /* CSS styles for modifying farmers page */
        .modify-farmers-header { margin-top: 20px; }
        .description-container { display: flex; justify-content: space-between; align-items: center; margin-bottom: 20px; }
        .farmers-list { list-style: none; padding: 0; }
        .farmers-list li { display: flex; justify-content: space-between; align-items: center; background-color: #e2e2e2; border-radius: 5px; padding: 10px; margin-bottom: 10px; }
        .farmers-list li span { flex: 1; }
        .farmers-list .buttons { margin: 0 5px; }
        .overlay { position: fixed; top: 0; left: 0; width: 100%; height: 100%; background: rgba(0, 0, 0, 0.5); display: none; align-items: center; justify-content: center; z-index: 1000; }
        .popup { background-color: #e2e2e2; border-radius: 5px; padding: 20px; text-align: center; width: 300px; }
        .popup h3 { margin-bottom: 20px; }
        .popup .popup-buttons { display: flex; justify-content: space-around; }
        .popup .buttons { flex: 1; margin: 10px; padding: 10px; }
    </style>

    <!-- Main content container -->
    <div class="container">
        <!-- Header for modifying farmers -->
        <h2 class="modify-farmers-header">Modify Farmers</h2>
        <!-- Description container -->
        <div class="description-container">
            <!-- Description for the page -->
            <p>This page allows you to manage the list of farmers. You can modify the details of each farmer or delete them from the system.</p>
            <!-- Button for creating a new farmer -->
            <asp:Button ID="btnCreateNew" runat="server" Text="Create New" CssClass="buttons" OnClick="btnCreateNew_Click" />
        </div>
        <!-- List of farmers -->
        <ul class="farmers-list">
            <!-- Repeater for displaying farmer details -->
            <asp:Repeater ID="itemList" runat="server">
                <ItemTemplate>
                    <!-- Individual farmer item -->
                    <li>
                        <!-- Displaying farmer's username -->
                        <span><%# Eval("Username") %></span>
                        <div>
                            <!-- Button for modifying farmer details -->
                            <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="buttons" CommandArgument='<%# Eval("Id") %>' OnClick="btnModify_Click" />
                            <!-- Button for deleting farmer -->
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="buttons" OnClientClick='<%# "showPopup(\"" + Eval("Id") + "\"); return false;" %>' />
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>

    <!-- Overlay and popup for delete confirmation -->
    <div id="overlay" class="overlay">
        <div class="popup">
            <h3>Are you sure you want to delete this farmer?</h3>
            <!-- Hidden field to store farmer id -->
            <asp:HiddenField ID="hiddenFarmerId" runat="server" />
            <!-- Buttons for confirmation -->
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
            <!-- Button to continue after farmer removal -->
            <div class="popup-buttons">
                <asp:Button ID="btnContinueRemove" runat="server" Text="Continue" CssClass="buttons" OnClick="btnContinueRemove_Click" />
            </div>
        </div>
    </div>

    <!-- JavaScript for showing and hiding popups -->
    <script type="text/javascript">
        // Function to show delete confirmation popup
        function showPopup(farmerId) {
            // Set hidden field value to farmer id
            document.getElementById('<%= hiddenFarmerId.ClientID %>').value = farmerId;
            // Display the overlay
            document.getElementById('overlay').style.display = 'flex';
        }

        // Function to hide delete confirmation popup
        function hidePopup() {
            // Hide the overlay
            document.getElementById('overlay').style.display = 'none';
        }

        // Function to show farmer removal confirmation popup
        function showRemovePopup() {
            // Display the overlay
            document.getElementById('removeOverlay').style.display = 'flex';
        }

        // Function to hide farmer removal confirmation popup
        function hideRemovePopup() {
            // Hide the overlay
            document.getElementById('removeOverlay').style.display = 'none';
        }
    </script>
</asp:Content>
