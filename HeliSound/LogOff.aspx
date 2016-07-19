<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="LogOff.aspx.cs" Inherits="HeliSound.LogOff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
  <div class="pageTitle">You have successfully logged out.</br>
  Come Again Soon!
  </div>
  <div class="divCenter">
      <asp:Button ID="btnLogIn" runat="server" Text="To Log In" CssClass="button1" 
          onclick="btnLogIn_Click" />
  </div>
  </div>
</asp:Content>
