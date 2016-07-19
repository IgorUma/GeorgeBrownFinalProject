<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HeliSound.Account.Register" %>
<%@ MasterType VirtualPath="~/Customer/Customer.Master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page">
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label1" runat="server" Text="First Name: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfFName" runat="server" 
                        ControlToValidate="txtFirstName" CssClass="rfVal" 
                        ErrorMessage="First Name requiered" ToolTip="First Name requiered">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfLastName" runat="server" 
                        ControlToValidate="txtLastName" CssClass="rfVal" EnableTheming="False" 
                        ErrorMessage="Last Name Required" ToolTip="Last Name Required">*</asp:RequiredFieldValidator>
                </div>
            </div>
        
        </div>

        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label3" runat="server" Text="Email address: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfEmail" runat="server" 
                        ControlToValidate="txtEmail" CssClass="rfVal" 
                        ErrorMessage="Email address Required">*</asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ControlToValidate="txtEmail" CssClass="rfVal" Display="Dynamic" 
                        ErrorMessage="Email format is incorrect" ToolTip="john@example.com" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label4" runat="server" Text="Phone Number:"></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfPhone" runat="server" 
                        ControlToValidate="txtPhone" CssClass="rfVal" EnableTheming="False" 
                        ErrorMessage="Phone Number requiered" ToolTip="Phone Number requiered">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtPhone" CssClass="rfVal" 
                        ErrorMessage="Phone format is incorrect" ToolTip="e.g. 0123456789" 
                        ValidationExpression="\d{10}">*</asp:RegularExpressionValidator>
                </div>
            </div>
         </div>

        <asp:Panel ID="pnlPassword" runat="server" CssClass="panelOne">
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label5" runat="server" Text="Password: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfPassword" runat="server" 
                        ControlToValidate="txtPassword" CssClass="rfVal" EnableTheming="False" 
                        ErrorMessage="Password Required">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label6" runat="server" Text="Confirm Password:"></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                &nbsp;
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                        CssClass="rfVal" ErrorMessage="Pasword Confirmaition failed">*</asp:CompareValidator>
                &nbsp;<asp:RequiredFieldValidator ID="rfConfipmPW" runat="server" 
                        ControlToValidate="txtPhone" CssClass="rfVal" EnableTheming="False" 
                        ErrorMessage="Please Confirm Password">*</asp:RequiredFieldValidator>
                </div>
            </div>
          </div>
        </asp:Panel>
          
        
        <asp:Panel ID="pnlSecretQ" runat="server" CssClass="panelOne">
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblSecretQ1" runat="server" Text="Select  Question #1:"></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlSecretQ1" runat="server" CssClass="ddlsq">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                        <asp:Label ID="Label9" runat="server" Text="SECRET Answer #1:"></asp:Label>
                </div>
                <div class="divdataRIGHT">
                     <asp:TextBox ID="txtSecretQ1" runat="server" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfA1" runat="server" 
                         ControlToValidate="txtSecretQ1" CssClass="rfVal" EnableTheming="False" 
                         ErrorMessage="First Secret answer is missing.">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label7" runat="server" Text="Select Question #2:"></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlSecretQ2" runat="server" CssClass="ddlsq">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label8" runat="server" Text="SECRET Answer #2:"></asp:Label>
                </div>
                <div class="divdataRIGHT">
                     <asp:TextBox ID="txtSecretQ2" runat="server" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfA2" runat="server" 
                         ControlToValidate="txtSecretQ2" CssClass="rfVal" EnableTheming="False" 
                         ErrorMessage="Second Secret answer is missing." 
                         ToolTip="Phone Number requiered">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        </asp:Panel>

        
             
                 <div class="divRow">
            
            <div class="divHalfRow">
            <div class="divdataRIGHT">
                    <asp:Button ID="btnClear" runat="server" Text="Clear All" CssClass="button" 
                        CausesValidation="False" onclick="btnClear_Click" />
                </div>
                <div class="divdataRIGHT">
                    
                </div>
             </div>
             <div class="divHalfRow">
            <div class="divdataRIGHT">
                </div>
                <div class="divdataLEFT">
                    
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button" 
                        onclick="btnRegister_Click" />
                    
                </div>
                <div class="divdataRIGHT">
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" 
                        CssClass="button" onclick="btnChangePassword_Click" Visible="False"  />
                </div>
             </div>
         </div>
         <asp:Label ID="lblError" runat="server" CssClass="ValidationSummary" 
            Text="Error" Visible="False"></asp:Label>
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                 CssClass="ValidationSummary" DisplayMode="List" />
           
</div>
</asp:Content>
