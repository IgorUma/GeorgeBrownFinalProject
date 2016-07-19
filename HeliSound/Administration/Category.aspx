<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="HeliSound.Administration.Category" %>
<%@ MasterType VirtualPath="~/Administration/Administration.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
<div class="pageTitle">
 Categories maintenace
 </div>
    <asp:Button ID="btnCreate" runat="server" Text="Create new Category" 
        onclick="btnCreate_Click" />
    <asp:Panel ID="pnlCategoryDetails" runat="server" CssClass="panelOne" 
        Visible="False">
        <div class="divRow" >
         <div class="divdataLEFT">
             <asp:Label ID="lblCaregoryID" runat="server" Text="Caregory ID: "></asp:Label>
             </div>
             <div class="divdataRIGHT">
                 <asp:Label ID="lbl_ID" runat="server" Text="ID"></asp:Label>
             </div>
         </div>
         <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblCaregoryName" runat="server" Text="Caregory Name: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCategoryName" runat="server" 
                        ControlToValidate="txtCategoryName" CssClass="rfVal" 
                        ErrorMessage="Category name required" ValidationGroup="info">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblCaregoryStatus" runat="server" Text="Caregory Status: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    &nbsp;<asp:DropDownList ID="dlStatus" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </div>
            </div>
         </div>

         <div class="divCenter">
             <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="button1" 
                  ValidationGroup="info" onclick="btnInsert_Click" />
             <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button1" 
                  ValidationGroup="info" onclick="btnUpdate_Click" />
             <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button1" onclick="btnDelete_Click" 
                  />
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button1" onclick="btnCancel_Click" 
                  />
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                 CssClass="ValidationSummary" DisplayMode="List" ValidationGroup="info"  />
         </div>



    </asp:Panel>
    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
        onselectedindexchanged="gvList_SelectedIndexChanged" CssClass="Center">
    <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Description" HeaderText="Categories" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
    </asp:GridView>
    <asp:Label ID="lblError" runat="server" Text="Connection Error" CssClass="rfVal" 
             Visible="False"></asp:Label>
</div>
</asp:Content>
