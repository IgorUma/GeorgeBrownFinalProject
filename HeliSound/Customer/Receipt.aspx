<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="HeliSound.Customer.Receipt" %>
<%@ MasterType VirtualPath="~/Customer/Customer.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
    <div class="pageTitle">Thank You For Your Purchase!</div>
    <asp:Panel ID="Panel1" runat="server" CssClass="panelOne" BorderStyle="Dashed">
    <%--<div class="panelTitle">Receipt</div>--%>
    <div class="divRow">
    <div class="divHalfRow">
        <asp:Label ID="Label4" runat="server" Text="Receipt" 
            CssClass="panelTitle"></asp:Label>
    
    </div>
    <div class="divHalfRow">
        <asp:Label ID="Label2" runat="server" Text="HeliSond Inc." 
            CssClass="panelTitle"></asp:Label>
    
    </div>
    </div>
     <div class="divRow">
    
        <div class="divHalfRow">
             
                <asp:Label ID="Label1" runat="server" Text="To:   "></asp:Label>
                <asp:Label ID="lblFullName" runat="server" Text="Name"></asp:Label>
            
           
        </div>
         <div class="divHalfRow">
             
                 <asp:Label ID="Label6" runat="server" Text="Date:   "></asp:Label>
                 <asp:Label ID="lblDate" runat="server" Text="date"></asp:Label>
             
             
         </div>
    </div>
    <div class="divRow">
        <div class="divHalfRow">
            
                <asp:Label ID="Label5" runat="server" Text="Item:  "></asp:Label>
                <asp:Label ID="lblItem" runat="server" Text="item"></asp:Label>
            
            
        </div>
        <div class="divHalfRow">
            
                <asp:Label ID="Label3" runat="server" Text="Total: "></asp:Label>
                <asp:Label ID="lblTotal" runat="server" Text="total"></asp:Label>
            
            
        </div>
    </div>
    </asp:Panel>
    <div class="divCenter">
        <asp:Button ID="btnBack" runat="server" Text="New Search" CssClass="button1" 
            onclick="btnBack_Click" />
    </div>
    </div>
</asp:Content>
