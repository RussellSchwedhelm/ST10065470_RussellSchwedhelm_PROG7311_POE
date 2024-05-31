<%@ Page Title="Expanded Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExpandedChat.aspx.cs" Inherits="ST10065470_RussellSchwedhelm_PROG7311_POE.ExpandedChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Include stylesheet -->
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" type="text/css" />

    <!-- HTML content -->
    <div class="container">
        <!-- Chat forum -->
        <div class="chat-forum">
            <!-- Chat title -->
            <div class="chat-title">Chat Title Here</div>

            <!-- Chat description -->
            <div class="chat-description">This is a description of the chat. It provides an overview or context for the discussion.</div>

            <!-- Messages section -->
            <div class="messages">
                <!-- Individual message -->
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
                <!-- Textarea for reply input -->
                <textarea style="width: 100%" rows="4" placeholder="Enter your reply here..."></textarea>
                <!-- Button to post reply -->
                <button class="buttons">Post Reply</button>
            </div>
        </div>
    </div>
</asp:Content>
