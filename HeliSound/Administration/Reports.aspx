<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="HeliSound.Administration.Reports" %>
<%@ MasterType VirtualPath="~/Administration/Administration.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
  <div class="pageTitle">Todays&nbsp; Sales Report</div>
      <div class="divCenter">
          <asp:GridView ID="gvList" runat="server" BackColor="White" 
              BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
              AutoGenerateColumns="False">
              <Columns>
                  <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                  <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                  <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                  <asp:BoundField DataField="Total" DataFormatString="{0:C}" HeaderText="Total" />
                  <asp:BoundField DataField="Description" HeaderText="Status" />
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
      <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label2" runat="server" Text="Numer of  Orders: "></asp:Label>
            </div>
            <div class="divdataRIGHT">
                <asp:TextBox ID="txtNumOfOrders" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        </div>

      <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label1" runat="server" Text="Todays Total: $"></asp:Label>
            </div>
            <div class="divdataRIGHT">
                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
          <asp:Label ID="lblError" runat="server" CssClass="rfVal" Text="Error" 
              Visible="False"></asp:Label>
      
  </div>
  </div>
</asp:Content>
