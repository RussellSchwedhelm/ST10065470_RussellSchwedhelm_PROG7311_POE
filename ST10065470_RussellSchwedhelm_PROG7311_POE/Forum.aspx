<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.Forum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <style>
        .forum-container {
            display: flex;
            flex-direction: column;
            margin-top: 20px;
        }

        .chat-section {
            margin-bottom: 20px;
        }

        .chat-header {
            background-color: #4CAF50;
            color: white;
            padding: 10px;
            border-radius: 5px 5px 0 0;
        }

        .chat-content {
            background-color: #fff;
            border: 1px solid #ccc;
            border-top: none;
            border-radius: 0 0 5px 5px;
            padding: 10px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .chips-container {
            display: flex;
            align-items: center;
        }

        .button-container {
            margin-left: auto;
        }
    </style>

    <div class="container">
        <h1>Forum</h1>
        <div class="chips-container">
            <div class="chip" onclick="toggleChip(this)">Seek Advice</div>
            <div class="chip" onclick="toggleChip(this)">Experiences</div>
            <div class="chip" onclick="toggleChip(this)">Collaborate</div>
            <div class="button-container">
                <asp:Button runat="server" Text="New Chat" CssClass="buttons" OnClick="NewChat_Click" />
            </div>
        </div>

        <div class="forum-container">
            <div class="chat-section">
                <div class="chat-header">
                    Chat 1
                </div>
                <div class="chat-content">
                    <p>This Is The Description Of Chat 1</p>
                    <asp:Button runat="server" Text="Expand" CssClass="buttons" OnClick="ExpandChat_Click" CommandArgument="1" />
                </div>
            </div>
            <div class="chat-section">
                <div class="chat-header">
                    Chat 2
                </div>
                <div class="chat-content">
                    <p>This Is The Description Of Chat 2</p>
                    <asp:Button runat="server" Text="Expand" CssClass="buttons" OnClick="ExpandChat_Click" CommandArgument="2" />
                </div>
            </div>
            <div class="chat-section">
                <div class="chat-header">
                    Chat 3
                </div>
                <div class="chat-content">
                    <p>This Is The Description Of Chat 3</p>
                    <asp:Button runat="server" Text="Expand" CssClass="buttons" OnClick="ExpandChat_Click" CommandArgument="3" />
                </div>
            </div>
        </div>
    </div>

    <script>
        function toggleChip(chip) {
            // Unselect all chips
            var chips = document.querySelectorAll('.chip');
            chips.forEach(function (c) {
                c.classList.remove('selected');
            });
            // Select the clicked chip
            chip.classList.add("selected");
        }
    </script>
</asp:Content>
