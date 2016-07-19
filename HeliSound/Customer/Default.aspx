<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HeliSound.Customer.Default" %>
<%@ MasterType VirtualPath="~/Customer/Customer.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
    <div class="pageTitle">Welcom to HeliSound !</div>
    <div class="divRow">
        <div class="divHalfRow">
            <asp:Button ID="btnSearch" runat="server" Text="To Select Your Product " 
                CssClass="button" onclick="btnSearch_Click" />
        </div>
    <div class="divHalfRow">
            <asp:Button ID="btnProfile" runat="server" Text="To Your Profile " 
                CssClass="button" onclick="btnProfile_Click" />
        </div>
    
    </div>
</div>
</asp:Content>
