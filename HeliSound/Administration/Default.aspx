<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HeliSound.Administration.Default" %>
<%@ MasterType VirtualPath="~/Administration/Administration.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
<div class="pageTitle">Administrasion</div>
   <div class="panelTitle">Go To...</div>
    <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Button ID="btnShipment" runat="server" Text="Shipment" 
                    onclick="btnShipment_Click" />
            </div>
            <div class="divdataRIGHT">
                <asp:Button ID="btnCustomer" runat="server" Text="Customer section" 
                    onclick="btnCustomer_Click" />
            </div>
        
        </div>
        
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Button ID="btnProfile" runat="server" Text="Profile" Height="26px" 
                        onclick="btnProfile_Click" />
                </div>
            </div>
       
    
    
    </div>
</div>
</asp:Content>
