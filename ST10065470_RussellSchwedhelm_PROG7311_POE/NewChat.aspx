<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewChat.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.NewChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <style>
        .new-chat-form {
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
            width: 100%;
            box-sizing: border-box;
        }

        .form-group {
            margin-bottom: 20px;
            width: 100%;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            width: 100%;
        }

        .form-group input[type="text"],
        .form-group textarea {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .form-group input[type="submit"] {
            background-color: #4CAF50;
            border: none;
            border-radius: 5px;
            color: white;
            cursor: pointer;
            padding: 10px;
            transition: background-color 0.3s;
            width: 100%;
        }

        .form-group input[type="submit"]:hover {
            background-color: #45a049;
        }
    </style>
    <div class="container">
        <div class="new-chat-form">
            <asp:Panel ID="pnlNewChat" runat="server">
                <div class="chips-container">
                    <div class="chip" onclick="toggleChip(this)">Seek Advice</div>
                    <div class="chip" onclick="toggleChip(this)">Experiences</div>
                    <div class="chip" onclick="toggleChip(this)">Collaborate</div>
                    <button class="buttons" style="margin-left: auto;">Create Chat</button>
                </div>

                <div class="form-group">
                    <label for="chatTitle">Chat Title</label>
                    <asp:TextBox ID="txtChatTitle" runat="server" CssClass="form-control" placeholder="Enter chat title" Required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="chatDescription">Chat Description</label>
                    <asp:TextBox ID="txtChatDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Enter chat description" Required="true"></asp:TextBox>
                </div>
            </asp:Panel>
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