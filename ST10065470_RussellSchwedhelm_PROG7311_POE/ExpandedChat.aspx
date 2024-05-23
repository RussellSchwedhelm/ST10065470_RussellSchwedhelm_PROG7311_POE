<%@ Page Title="Expanded Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExpandedChat.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.ExpandedChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />
    <style>
        .chat-forum {
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
        }

        .chat-title {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        .chat-description {
            font-size: 16px;
            margin-bottom: 20px;
        }

        .message {
            border-bottom: 1px solid #ccc;
            padding: 10px 0;
        }

        .message .user {
            font-weight: bold;
        }

        .message .text {
            margin-top: 5px;
        }

        .reply-form {
            margin-top: 20px;
            width: 100%
        }

        .reply-form textarea {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-bottom: 10px;
        }

    </style>

    <div class="container">
        <div class="chat-forum">
            <div class="chat-title">Chat Title Here</div>

            <div class="chat-description">This is a description of the chat. It provides an overview or context for the discussion.</div>

            <!-- Messages -->
            <div class="messages">
                <div class="message">
                    <div class="user">User1:</div>
                    <div class="text">This is a message from User1.</div>
                </div>
                <div class="message">
                    <div class="user">User2:</div>
                    <div class="text">This is a message from User2.</div>
                </div>
                <div class="message">
                    <div class="user">User3:</div>
                    <div class="text">This is a message from User3.</div>
                </div>
            </div>

            <!-- Reply Form -->
            <div class="reply-form">
                <textarea style="width: 100%" rows="4" placeholder="Enter your reply here..."></textarea>
                <button class="buttons">Post Reply</button>
            </div>
        </div>
    </div>
</asp:Content>
