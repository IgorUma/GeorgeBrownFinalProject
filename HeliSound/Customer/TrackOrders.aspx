<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="TrackOrders.aspx.cs" Inherits="HeliSound.Customer.TrackOrders" %>
<%@ MasterType VirtualPath="~/Customer/Customer.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
    <div class="pageTitle">Tracking Orders</div>
    <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label1" runat="server" Text="Enter Order Number:"></asp:Label>
            </div>
            <div class="divdataRIGHT">
                <asp:TextBox ID="txtInvoiceN" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="divHalfRow">
        <div class="divdataLEFT">
            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                onclick="btnSearch_Click" />
        </div>
        <div class="divdataRIGHT">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                onclick="btnCancel_Click" />
        </div>
        </div>
    </div>
    <div class="Center">
        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4">
            <Columns>
                <asp:BoundField DataField="Item" HeaderText="Item" />
                <asp:BoundField DataField="Ordered" DataFormatString="{0:MMM/dd/yy}" 
                    HeaderText="Ordered" />
                <asp:BoundField DataField="Total" DataFormatString="{0:C2}" HeaderText="Total" 
                    ReadOnly="True" />
                <asp:BoundField DataField="Shipping Status" HeaderText="Shipping Status" />
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
        <asp:GridView ID="gvDetailsShipped" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4">
            <Columns>
                <asp:BoundField DataField="Item" HeaderText="Item" />
                <asp:BoundField DataField="Ordered" DataFormatString="{0:MMM/dd/yy}" 
                    HeaderText="Ordered" />
                <asp:BoundField DataField="Total" DataFormatString="{0:C2}" HeaderText="Total" 
                    ReadOnly="True" />
                <asp:BoundField DataField="Shipping Status" HeaderText="Shipping Status" />
                <asp:BoundField DataField="DateShipped" DataFormatString="{0:MMM/dd/yy}" 
                    HeaderText="Shipped" />
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
        <asp:Label ID="lblError" runat="server" Text="Error" Visible="False"></asp:Label>
    </div>
  </div>
</asp:Content>
