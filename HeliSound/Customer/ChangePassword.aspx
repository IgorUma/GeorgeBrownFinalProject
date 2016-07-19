<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HeliSound.Customer.ChangePassword" %>
<%@ MasterType VirtualPath="~/Customer/Customer.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
<div class="pageTitle">Password Change</div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label3" runat="server" Text="Enter email address : "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfFName" runat="server" 
                        ControlToValidate="txtEmail" CssClass="rfVal" 
                        ErrorMessage="Current Password requiered" ToolTip="Enter Current Password">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label4" runat="server" Text="Select Secret  Question: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                      <asp:DropDownList ID="dlQuest" runat="server">
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="dlQuest" CssClass="rfVal" ErrorMessage="Select Question" 
                          InitialValue="-1">*</asp:RequiredFieldValidator>
                </div>
                </div>
                 <div class="divHalfRow">
                <div class="divdataLEFT">
                        <asp:Label ID="Label9" runat="server" Text="Answer :"></asp:Label>
                </div>
                <div class="divdataRIGHT">
                     <asp:TextBox ID="txtAns" runat="server" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfA1" runat="server" 
                         ControlToValidate="txtAns" CssClass="rfVal" EnableTheming="False" 
                         ErrorMessage="Answer is missing." >*</asp:RequiredFieldValidator>
                </div>
            </div>

        </div>


        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label1" runat="server" Text="Enter New Password: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfFName0" runat="server" 
                        ControlToValidate="txtNewPassword" CssClass="rfVal" 
                        ErrorMessage="Enter password!" ToolTip="First Name requiered">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label2" runat="server" Text="Confirm New Password: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfPWConfirm" runat="server" 
                        ControlToValidate="txtConfirm" CssClass="rfVal" 
                        ErrorMessage="Confirm password">*</asp:RequiredFieldValidator>
                &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtNewPassword" ControlToValidate="txtConfirm" 
                        CssClass="rfVal" ErrorMessage="Confirm password">*</asp:CompareValidator>
                </div>
            </div>
        </div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    
                </div>
                <div class="divdataRIGHT">
                    <asp:Button ID="btnChange" runat="server" Text="Save" 
                        CssClass="button" onclick="btnChange_Click" />
                </div>
            </div>
        </div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    
                </div>
                <div class="divdataRIGHT">
                    <asp:Label ID="lblError" runat="server" Text="Error" Visible="False" 
                        CssClass="rfVal"></asp:Label>
                </div>
            </div>
        </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="ValidationSummary" DisplayMode="List" />
</div>
</asp:Content>
