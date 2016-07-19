<%@ Page Title="" Language="C#" MasterPageFile="~/Shipping/Shipping.Master" AutoEventWireup="true" CodeBehind="Shipping.aspx.cs" Inherits="HeliSound.Shipping.Shipping1" %>
<%@ MasterType VirtualPath="~/Shipping/Shipping.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page">
<div class="pageTitle">Shippmemt</div>
<div class="scroll">
    <asp:GridView ID="gvList" runat="server" BackColor="White" BorderColor="#CC9966" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            onselectedindexchanged="gvList_SelectedIndexChanged" 
            AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="OrderID" HeaderText="Order ID" ReadOnly="True">
            <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="DateCreated" DataFormatString="{0:MMM/dd/yy}" 
                HeaderText="Created">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Shippment Status">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DateShipped" HeaderText="Date Shipped" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    </div>
    <div class="Center">
    <asp:Button ID="btnShipped" runat="server" Text="Display Shipped Orders" 
            CssClass="button" onclick="btnShipped_Click" />
            <asp:Button ID="btnHide" runat="server" CssClass="button" 
            onclick="btnHide_Click" Text="Hide Shipped Orders" Visible="False" />
            </div>
            <div class="scroll">
    <asp:GridView ID="gvShipped" runat="server" BackColor="White" BorderColor="#CC9966" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            onselectedindexchanged="gvList_SelectedIndexChanged" 
            AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="Order ID" ReadOnly="True">
            <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="DateCreated" DataFormatString="{0:MMM/dd/yy}" 
                HeaderText="Created">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Shippment Status">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DateShipped" HeaderText="Date Shipped" 
                DataFormatString="{0:MMM/dd/yy}" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
        <asp:Label ID="lblError" runat="server" Text="Communication Error" Visible="False" CssClass="ValidationSummary"></asp:Label>
    </div>
</div>
</asp:Content>
