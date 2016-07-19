<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="HeliSound.welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 480px;
            height: 160px;
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page">
        <div class="quaterPageLeft">
        <div class="pageTitle">New servises</div>
            <img alt="screen" src="Images/images.png" />
            </div>
        <div class="quaterPageRight"> <%--upper right- login part--%>
            <div class="divRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label1" runat="server" Text="Email:  " ></asp:Label>
              </div>
              <div class="divdataRIGHT">
                <asp:TextBox
                    ID="txtEmail" runat="server" ></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfEmail" runat="server" 
                      ControlToValidate="txtEmail" ErrorMessage="Email Address Required" 
                      Font-Bold="True" ToolTip="Email Address Required" CssClass="rfVal">*</asp:RequiredFieldValidator>
                  &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                      ControlToValidate="txtEmail" ErrorMessage="Email Format Is Incorrect" Font-Bold="True" 
                      ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                      CssClass="rfVal" ToolTip="john@example.com">*</asp:RegularExpressionValidator>
                </div>
             </div>
             <div class="divRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label2" runat="server" Text="Password:  " ></asp:Label>
              </div>
              <div class="divdataRIGHT">
                <asp:TextBox
                    ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfPassword" runat="server" 
                      ControlToValidate="txtPassword" ErrorMessage="Password required" 
                      Font-Bold="True" ToolTip="Password required" CssClass="rfVal">*</asp:RequiredFieldValidator>
                </div>
             </div>
             <div class="divRow">
                <div class="divdataLEFT">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button" 
                        onclick="btnRegister_Click" CausesValidation="False" />
                </div>
                <div class="divdataRIGHT">
                    <asp:Button ID="btnLogIn" runat="server" Text="Log In" CssClass="button" 
                        onclick="btnLogIn_Click" />
                    <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot Password" 
                        CssClass="button" onclick="btnForgotPassword_Click" 
                        CausesValidation="False" />
            <asp:Label ID="lblError" runat="server" Text="Error" Visible="False" 
                CssClass="rfVal"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        CssClass="ValidationSummary" DisplayMode="List" />
                </div>
             </div>
             &nbsp;</div>
      
        <div class="quaterPageLeft">
        <div class="pageTitle">New arrivals</div>
            <img alt="old TV" src="Images/oldTV.jpg" /></div>

            <div class="lowRightQ">
            <div class="pageTitle">New tech...</div>
             <img alt="green grass" class="style1" src="Images/fresh-green-grass-banner.jpg" /></div>
        </div>
    
    
    
</asp:Content>