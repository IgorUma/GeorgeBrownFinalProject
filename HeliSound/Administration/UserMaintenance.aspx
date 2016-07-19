<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="UserMaintenance.aspx.cs" Inherits="HeliSound.Administration.UserMaintenance" %>
<%@ MasterType VirtualPath="~/Administration/Administration.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
<div class="pageTitle">
 Users maintenace
 </div>
    <asp:Button ID="btnInsert" runat="server" Text="Insert New User" 
        CssClass="button1" onclick="btnInsert_Click" CausesValidation="False" />
    <asp:Panel ID="pnlDetails" runat="server" CssClass="panel" Visible="False">
        <div class="divRow" >
         <div class="divdataLEFT">
             <asp:Label ID="lblUserID" runat="server" Text="User ID: "></asp:Label>
             </div>
             <div class="divdataRIGHT">
                 <asp:Label ID="lbl_ID" runat="server" Text="ID"></asp:Label>
             </div>
         </div>
         <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfFirstName" runat="server" 
                        ControlToValidate="txtFirstName" CssClass="rfVal" 
                        ErrorMessage="First name required">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblStatus" runat="server" Text="Last Name: "></asp:Label>
                </div>
                <div class="divdataRIGHT" >
                   <asp:TextBox ID="txtLastName" runat="server" ></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="rfLastName" runat="server" 
                        ControlToValidate="txtLastName" CssClass="rfVal" 
                        ErrorMessage="Last Name Required">*</asp:RequiredFieldValidator>
                    
                </div>
            </div>
         </div>


         <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label5" runat="server" Text="email: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtEmail" CssClass="rfVal" 
                        ErrorMessage="email required" ToolTip="as a  LogIn">*</asp:RequiredFieldValidator>
                    &nbsp;<asp:RegularExpressionValidator ID="reEmail" runat="server" 
                        ControlToValidate="txtEmail" CssClass="rfVal" 
                        ErrorMessage="Email format is incorrect" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label6" runat="server" Text="Phone: "></asp:Label>
                </div>
                <div class="divdataRIGHT" >
                   <asp:TextBox ID="txtPhone" runat="server" ToolTip="10 digits e.g. 0123456789" 
                        Width="128px" ></asp:TextBox>
                    
                    
                    
                    <asp:RequiredFieldValidator ID="rfPhone" runat="server" 
                        ControlToValidate="txtPhone" CssClass="rfVal" ErrorMessage="Phone # Required">*</asp:RequiredFieldValidator>
                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ControlToValidate="txtPhone" CssClass="rfVal" 
                        ErrorMessage="phone format is incorresct" ToolTip="10 digits e.g. 0123456789" 
                        ValidationExpression="\d{10}">*</asp:RegularExpressionValidator>
                    
                    
                    
                </div>
            </div>
         </div>






         
         <div class="divRow">
            
            
            
          
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label1" runat="server" Text="Role: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    &nbsp;<asp:DropDownList ID="dlRole" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </div>
            
            </div>
              



            <div class="divHalfRow">
            <div class="divdataLEFT">
                    <asp:Label ID="Label2" runat="server" Text="Status: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    &nbsp;<asp:DropDownList ID="dlStatus" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                    </div>
                </div>
            </div>
        <asp:LinkButton ID="lnkbtnPW" runat="server" CssClass="panelTitle" 
            Visible="False" onclick="lnkbtnPW_Click" ValidationGroup="None">Change Password</asp:LinkButton>
        <asp:Panel ID="pnlPW" runat="server" Visible="False">
        <div class="panelTitle">Password</div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfPassword" runat="server" 
                        ControlToValidate="txtPassword" CssClass="rfVal" 
                        ErrorMessage="Insert Password">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label4" runat="server" Text="Confirm Passworn: "></asp:Label>
                </div>
                <div class="divdataRIGHT" >
                   <asp:TextBox ID="txtConPassword" runat="server" TextMode="Password" ></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="rfConPassword" runat="server" 
                        ControlToValidate="txtConPassword" CssClass="rfVal" 
                        ErrorMessage="Confirm Password">*</asp:RequiredFieldValidator>
                    
                    &nbsp;&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtPassword" ControlToValidate="txtConPassword" 
                        CssClass="rfVal" ErrorMessage="Password  validation failed">*</asp:CompareValidator>
                    
                    &nbsp;</div>
            </div>
         </div>
        </asp:Panel>

            
         <div class="divCenter">
             <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button1" 
                 onclick="btnSave_Click" />
             <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button1" 
                 onclick="btnUpdate_Click" />
             <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button1" 
                 onclick="btnDelete_Click" CausesValidation="False" 
                 ValidationGroup="None" />
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button1" 
                 onclick="btnCancel_Click" CausesValidation="False" 
                 ValidationGroup="None" />
         </div>
         
         <asp:Label ID="lblError" runat="server" CssClass="rfVal" 
            Text="Communication Error" Visible="False"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
            CssClass="ValidationSummaryRight" DisplayMode="List" />
         
        </asp:Panel>
        <div class="scroll">
    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" onselectedindexchanged="gvList_SelectedIndexChanged" 
        CssClass="scroll">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Description" HeaderText="Role" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
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
    </div>
 </div> <%--page--%>
</asp:Content>
