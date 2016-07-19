<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="HeliSound.Administration.Products" %>
<%@ MasterType VirtualPath="~/Administration/Administration.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
<div class="pageTitle">
 Products maintenace
 </div>
    <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                    <asp:Button ID="btnInsert" runat="server" Text="Insert New Product" 
                CssClass="button" onclick="btnInsert_Click" CausesValidation="False" />
                </div>
           <div  class="divdataLEFT">
                <asp:Label ID="Label4" runat="server" Text="OR"></asp:Label>
            </div>
        </div>
        
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="lblSupplier1" runat="server" 
                    Text="Select Supplier:"></asp:Label>
            </div>
            <div class="divdataRIGHT">
                <asp:DropDownList ID="dlSuppliers1" runat="server" AutoPostBack="True" 
                    CssClass="ddl" onselectedindexchanged="dlSuppliers1_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <asp:Label ID="lblError" runat="server" Text="Communication Error" 
        CssClass="rfVal" Visible="False"></asp:Label>
        <asp:Panel ID="pnlDetails" runat="server" CssClass="panel">
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label1" runat="server" Text="Product Name: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtProductName" CssClass="rfVal" 
                        ErrorMessage="Product Name Reuired">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblProductID" runat="server" Text="Product ID: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:Label ID="lbl_ID" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
         <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label2" runat="server" Text="Product Category: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlCategory" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="dlCategory" CssClass="rfVal" ErrorMessage="Select Category" 
                        InitialValue="-1">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label3" runat="server" Text="Product Supplier: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlProductSupplier" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="dlProductSupplier" CssClass="rfVal" 
                        ErrorMessage="Select supplier" InitialValue="-1">*</asp:RequiredFieldValidator>
                </div>
            </div>
         </div>
         <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblPrice" runat="server" Text="Retail Price: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPrice" CssClass="rfVal" ErrorMessage="Price Reuired">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblStatus" runat="server" Text="Product Status: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlStatus" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="dlStatus" CssClass="rfVal" ErrorMessage="Select status" 
                        InitialValue="-1">*</asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="divCenter">
             </div>
         </div>
          <div class="divCenter">
             <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button1" 
                  onclick="btnSave_Click"  />
             <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button1" 
                  onclick="btnUpdate_Click"  />
             <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button1" 
                  onclick="btnDelete_Click" CausesValidation="False" 
                  />
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button1" 
                  onclick="btnCancel_Click" CausesValidation="False" 
                  />
              <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                  CssClass="ValidationSummary" DisplayMode="List" style="text-align:right" />
         </div>
         
         

    </asp:Panel>
    
    <asp:GridView ID="gvProducts" runat="server" 
        onselectedindexchanged="gvProducts_SelectedIndexChanged" BackColor="White" 
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        HorizontalAlign="Right">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
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
   
    
    
    
 </div> <%--page--%>










</asp:Content>
