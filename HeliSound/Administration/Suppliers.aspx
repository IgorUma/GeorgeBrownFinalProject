<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Suppliers.aspx.cs" Inherits="HeliSound.Administration.Suppliers" %>
<%@ MasterType VirtualPath="~/Administration/Administration.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="page">
     <div class="pageTitle">
 Suppliers maintenace
 </div>
         <asp:Button ID="btnCreatNewSupplier" runat="server" Text="Insert New Supplier" 
             onclick="btnCreatNewSupplier_Click" CssClass="button" 
             ValidationGroup="None" />
         <asp:Panel ID="pnlSuppDetails" runat="server" CssClass="panel" Visible="False">
         <div class="divRow" >
         <div class="divdataLEFT">
             <asp:Label ID="lblSupplierID" runat="server" Text="Supplier ID: "></asp:Label>
             </div>
             <div class="divdataRIGHT">
                 <asp:Label ID="lbl_ID" runat="server" Text="ID"></asp:Label>
             </div>
         </div>
         <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label1" runat="server" Text="Company Name: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCompany" runat="server" 
                        ControlToValidate="txtCompanyName" CssClass="rfVal" 
                        ErrorMessage="Company name required">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label2" runat="server" Text="Company Status: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    &nbsp;<asp:DropDownList ID="dlStatus" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="dlStatus" CssClass="rfVal" ErrorMessage="Select Status" 
                        InitialValue="-1">*</asp:RequiredFieldValidator>
                </div>
            </div>
         </div>
        <div class="divRow">
         <div class="title" >Main Contact:</div>
         <div class="divHalfRow">
         <div class="divdataLEFT">
                    <asp:Label ID="Label4" runat="server" Text="Phone: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfPhone" runat="server" 
                        ControlToValidate="txtPhone" CssClass="rfVal" 
                        ErrorMessage="Contact Phone Required" ValidationGroup="info">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtPhone" ErrorMessage="Phone format is incorrect" 
                        ValidationExpression="\d{10}" CssClass="rfVal">*</asp:RegularExpressionValidator>
                </div>
            </div>
         
         </div>

         
          <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label3" runat="server" Text="First Name: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfFName" runat="server" 
                        ControlToValidate="txtFirstName" CssClass="rfVal" 
                        ErrorMessage="Contact First  Name Required">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label11" runat="server" Text="Last Name: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCompany1" runat="server" 
                        ControlToValidate="txtLastName" CssClass="rfVal" 
                        ErrorMessage="Contact Last Name Required">*</asp:RequiredFieldValidator>
                </div>
            </div>
            </div>
         <div class="title">Company Address:</div>
         <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label5" runat="server" Text="Street Address: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtStreetAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCompany2" runat="server" 
                        ControlToValidate="txtStreetAddress" CssClass="rfVal" 
                        ErrorMessage="Street Address required">*</asp:RequiredFieldValidator>
                </div>
                </div>
                </div>
                <div class="divRow">
                    <div class="divHalfRow">
                        <div class="divdataLEFT">
                            <asp:Label ID="Label9" runat="server" Text="Postal Code: "></asp:Label>
                        </div>
                        <div class="divdataRIGHT">
                            <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfCity0" runat="server" 
                                ControlToValidate="txtPostalCode" CssClass="rfVal" 
                                ErrorMessage="Postal Code required">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divHalfRow">
                        <div class="divdataLEFT">
                            <asp:Label ID="Label7" runat="server" Text="Province: "></asp:Label>
                        </div>
                        <div class="divdataRIGHT">
                            <asp:DropDownList ID="dlProvince" runat="server" CssClass="ddl">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="dlProvince" CssClass="rfVal" ErrorMessage="Select Province" 
                                InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label10" runat="server" Text="Suite: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtSuite" runat="server"></asp:TextBox>
                </div>
            </div>
          
         <div class="divRow">
         <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label6" runat="server" Text="City: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCity" runat="server" 
                        ControlToValidate="txtCity" CssClass="rfVal" 
                        ErrorMessage="City required">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label8" runat="server" Text="Country: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlCountry" runat="server" CssClass="ddl" 
                        AutoPostBack="True" onselectedindexchanged="dlCountry_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
    </div>
         <div class="divCenter">
             <asp:Button ID="btnSave" runat="server" Text="Insert" CssClass="button1" 
                 onclick="btnSave_Click" />
             <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button1" 
                 onclick="btnUpdate_Click" />
             <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button1" 
                 onclick="btnDelete_Click" ValidationGroup="None" />
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button1" 
                 onclick="btnCancel_Click" ValidationGroup="None" />
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                 CssClass="ValidationSummary" DisplayMode="List" style="text-align:right" />
         </div>

         </asp:Panel>

         
         <asp:Panel ID="pnlSuppList" runat="server" >
         <div class="scroll">
            <asp:GridView ID="gvSuppliers" runat="server" 
            
                 onselectedindexchanged="gvSuppliers_SelectedIndexChanged" 
                 HorizontalAlign="Left" BackColor="White" BorderColor="#CC9966" 
                 BorderStyle="None" BorderWidth="1px" CellPadding="4">
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
     
         <asp:Label ID="lblError" runat="server" Text="Connection Error" CssClass="rfVal" 
             Visible="False"></asp:Label>
             </div>
         </asp:Panel>
         
     
     
     
     
     
     
     
    </div> <%--page--%>
</asp:Content>
