<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="HeliSound.Administration.Roles" %>
<%@ MasterType VirtualPath="~/Administration/Administration.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
<div class="pageTitle">
 Roles maintenace
 </div>
    <asp:Button ID="btnCreate" runat="server" Text="Create new Role" 
        onclick="btnCreate_Click" />
    <asp:Panel ID="pnlCategoryDetails" runat="server" 
        Visible="False">
        <div class="divRow" >
         <div class="divdataLEFT">
             <asp:Label ID="lblRoleID" runat="server" Text="Role ID: "></asp:Label>
             </div>
             <div class="divdataRIGHT">
                 <asp:Label ID="lbl_ID" runat="server" Text="ID"></asp:Label>
             </div>
         </div>
         <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblRoleName" runat="server" Text="Role Description: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfRoleName" runat="server" 
                        ControlToValidate="txtRoleName" CssClass="rfVal" 
                        ErrorMessage="Role name required" ValidationGroup="info">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblRoleStatus" runat="server" Text="Role Status: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    &nbsp;<asp:DropDownList ID="dlStatus" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </div>
            </div>
         </div>

         <div class="divCenter">
             <asp:Button ID="btnInsert" runat="server" Text="Save" CssClass="button1" 
                  ValidationGroup="info" onclick="btnInsert_Click" />
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button1" onclick="btnCancel_Click" 
                  />
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                 CssClass="ValidationSummary" DisplayMode="List" ValidationGroup="info" style="text-align:right" />
         </div>



    </asp:Panel>



    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="Description" HeaderText="Role" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
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
    
    <asp:Label ID="lblError" runat="server" Text="Connection Error" CssClass="rfVal" 
             Visible="False"></asp:Label>
</div>
</asp:Content>
