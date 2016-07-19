<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="HeliSound.Administration.Customers" %>
<%@ MasterType VirtualPath="~/Administration/Administration.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
 <div class="pageTitle">
 Customer maintenace
 </div>
 
    <asp:Panel ID="Panel1" runat="server" CssClass="pnlDashed">
     <div class="divRow">
    <div class="divHalfRow">
        <div class="divdataLEFT">
            <asp:Label ID="Label1" runat="server" Text="Search by Name:"></asp:Label>
        </div>
        <div class="divdataRIGHT">
            <asp:TextBox ID="txtSearchName" runat="server"></asp:TextBox>
        
        </div>
         </div>
         <div class="divHalfRow">
        <div class="divdataLEFT">
            <asp:Button ID="btnSearchByName" runat="server" Text="Search by Name" 
                CssClass="button" onclick="btnSearchByName_Click" ValidationGroup="None" />
           </div>
           <div class="divdataRIGHT">
           <asp:CheckBox ID="chbIncludeInactive" runat="server" 
                Text="Include Inactive Customers" Style="text-align:center " Checked="True"/>
           </div>
           </div>
         </div>
   
    <div class="divfRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label2" runat="server" Text="Search by ID:"></asp:Label>
            </div>
            <div class="divdataRIGHT">
                <asp:TextBox ID="txtSearchID" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="divHalfRow">
            <div class="divdataLEFT">
            <asp:Button ID="btnSearchByID" runat="server" Text="Search by ID" 
                CssClass="button" onclick="btnSearchByID_Click" ValidationGroup="None" />
                 </div>
        </div>
        </div>
    </asp:Panel>
        
    <asp:Panel ID="pnlData" runat="server" CssClass="pnlDashed" Visible="False">
    <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label3" runat="server" Text="Customer ID:"></asp:Label>

            </div>
            <div class="divdataRIGHT">
                <asp:Label ID="lbl_ID" runat="server" Text="ID"></asp:Label>
             </div>
        </div>
        <div class="divHalfRow">
            
            <div class="divdataLEFT">
            <asp:Label ID="Label4" runat="server" Text="Customer Status: "></asp:Label>
            
      
    
    
        </div>
        <div class="divdataRIGHT">
            <asp:DropDownList ID="dlStatus" runat="server" CssClass="ddl">
                </asp:DropDownList>
             </div>
    </div>
    </div>


    <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label5" runat="server" Text="First Name:"></asp:Label>

            </div>
            <div class="divdataRIGHT">
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfFirstName" runat="server" 
                    ControlToValidate="txtFirstName" CssClass="rfVal" 
                    ErrorMessage="First Name Required">*</asp:RequiredFieldValidator>
             </div>
        </div>
        <div class="divHalfRow">
        
            <div class="divdataLEFT">
             <asp:Label ID="Label6" runat="server" Text="Last Name:"></asp:Label>

            </div>
            <div class="divdataRIGHT">
            <asp:TextBox ID="txtLastName" runat="server" Width="132px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfFirstName0" runat="server" 
                    ControlToValidate="txtLastName" CssClass="rfVal" 
                    ErrorMessage="Last Name Required">*</asp:RequiredFieldValidator>
             </div>
      
    
    
        </div>
    </div>
    <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label7" runat="server" Text="email:"></asp:Label>

            </div>
            <div class="divdataRIGHT">
                <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" ToolTip="Read Only"></asp:TextBox>
             </div>
        </div>
        <div class="divHalfRow">
        
            <div class="divdataLEFT">
                <asp:Label ID="Label8" runat="server" Text="Phone: "></asp:Label>

            </div>
            <div class="divdataRIGHT">
            <asp:TextBox ID="txtPhone" runat="server" ToolTip="10 digits"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfFirstName1" runat="server" 
                    ControlToValidate="txtPhone" CssClass="rfVal" 
                    ErrorMessage="Phone number Required">*</asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" ControlToValidate="txtPhone" CssClass="rfVal" 
                    ErrorMessage="Phone format is incorrect" ValidationExpression="\d{10}">*</asp:RegularExpressionValidator>
             </div>
      
    
    
        </div>
    </div>
    <div class="divCenter">
             <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button1" 
                 onclick="btnUpdate_Click"   />
             <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button1" 
                 onclick="btnDelete_Click" ValidationGroup="None"  
                  />
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button1" 
                onclick="btnCancel_Click" ValidationGroup="None"  />
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                 CssClass="ValidationSummaryRight" DisplayMode="List" />
         </div>
    </asp:Panel>
    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    <div class="scroll">
         <asp:GridView ID="gvList" runat="server" 
        onselectedindexchanged="gvList_SelectedIndexChanged">
             <Columns>
                 <asp:CommandField ShowSelectButton="True" />
             </Columns>
    </asp:GridView>
    </div>
    </div>
  
 


   



</asp:Content>
