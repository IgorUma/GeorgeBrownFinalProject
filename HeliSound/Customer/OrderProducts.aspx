<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="OrderProducts.aspx.cs" Inherits="HeliSound.Customer.OrderProducts" %>
<%@ MasterType VirtualPath="~/Customer/Customer.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page">
    <div class="pageTitle">Search product:</div>
    <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label1" runat="server" Text="Selecte a Supplier: "></asp:Label>
            </div>
            <div class="divdataRIGHT">
                <asp:DropDownList ID="dlSuppliers" runat="server" CssClass="ddl" 
                    AutoPostBack="True" onselectedindexchanged="dlSuppliers_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
         <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label2" runat="server" Text="Selecte Category: "></asp:Label>
            </div>
            <div class="divdataRIGHT">
                <asp:DropDownList ID="dlCategory" runat="server" CssClass="ddl" 
                    AutoPostBack="True" 
                    onselectedindexchanged="dlCategory_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
     </div>
     <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label3" runat="server" Text="Selecte Product: "></asp:Label>
            </div>
            <div class="divdataRIGHT">
                <asp:DropDownList ID="dlProduct" runat="server" CssClass="ddl" 
                    AutoPostBack="True" onselectedindexchanged="dlProduct_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        
        </div>
        <div class="divHalfRow">
            <div class="divdataRIGHT">
                <asp:Button ID="btnClear" runat="server" Text="Clear Selection" 
                    onclick="btnClear_Click" />
            </div>
        </div>
     
     </div>
     <div class="divCenter">
         <asp:Label ID="lblNoFit" runat="server" Text="No Products fit requirements please select other supplier" Visible="False">
         </asp:Label>
         <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" 
             BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
             CellPadding="4" onselectedindexchanged="gvDetails_SelectedIndexChanged" 
             CssClass="Center">
             <Columns>
                 <asp:CommandField SelectText="Order" ShowSelectButton="True" />
                 <asp:BoundField DataField="ProductName" HeaderText="Name" />
                 <asp:BoundField DataField="Price" DataFormatString="{0:C02}" 
                     HeaderText="Price" />
                 <asp:BoundField DataField="Supplier" HeaderText="Supplier" />
                 <asp:BoundField DataField="Description" HeaderText="Description" />
                 <asp:BoundField DataField="ProductID" HeaderText="ID" />
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
        <asp:Panel ID="pnlOrderInfo" runat="server" CssClass="pnlDashed" 
            Visible="True">
        <div class="panelTitle">Payment detailes</div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label4" runat="server" Text="Card holder Name:"></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCardholder" runat="server" CssClass="rfVal" 
                        ErrorMessage="Card holder name required" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label5" runat="server" Text="Credit Card Type:"></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlCardType" runat="server" CssClass="ddl">
                        <asp:ListItem Value="-1">Select</asp:ListItem>
                        <asp:ListItem Value="1">Visa</asp:ListItem>
                        <asp:ListItem Value="2">MasterCard</asp:ListItem>
                        <asp:ListItem Value="3">American Express</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="dlCardType" CssClass="rfVal" Display="Dynamic" 
                        ErrorMessage="Choose card type" InitialValue="-1">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label6" runat="server" Text="Card Number: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCardholder0" runat="server" CssClass="rfVal" 
                        ErrorMessage="Card number required" ControlToValidate="txtCardNumber">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblSecurityCode" runat="server" Text="Security Code: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtSecurityCode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfSecCode" runat="server" CssClass="rfVal" 
                        ErrorMessage="Security Code required" 
                        ControlToValidate="txtSecurityCode">*</asp:RequiredFieldValidator>
                </div>
            </div>
           </div>
            <div class="divRow">
                <div class="divHalfRow">
                    <div class="divdataLEFT">
                        <asp:Label ID="Label7" runat="server" Text="Expire, Month: "></asp:Label>
                    </div>
                    <div class="divdataRIGHT">
                        <asp:DropDownList ID="dlMonthExpire" runat="server" CssClass="ddl">
                            <asp:ListItem Value="-1">Select</asp:ListItem>
                            <asp:ListItem Value="1">January</asp:ListItem>
                            <asp:ListItem Value="2">February</asp:ListItem>
                            <asp:ListItem Value="3">March</asp:ListItem>
                            <asp:ListItem Value="4">April</asp:ListItem>
                            <asp:ListItem Value="5">May</asp:ListItem>
                            <asp:ListItem Value="6">June</asp:ListItem>
                            <asp:ListItem Value="7">July</asp:ListItem>
                            <asp:ListItem Value="8">August</asp:ListItem>
                            <asp:ListItem Value="9">September</asp:ListItem>
                            <asp:ListItem Value="10">October</asp:ListItem>
                            <asp:ListItem Value="11">November</asp:ListItem>
                            <asp:ListItem Value="12">December</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="dlMonthExpire" Display="Dynamic" ErrorMessage="Choose expiration month" 
                            InitialValue="-1" CssClass="rfVal">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="divHalfRow">
                    <div class="divdataLEFT">
                        <asp:Label ID="Label8" runat="server" Text="Expire, Year: "></asp:Label>
                    </div>
                    <div class="divdataRIGHT">
                        <asp:DropDownList ID="dlYearExpire" runat="server" CssClass="ddl">
                            <asp:ListItem Value="-1">Select</asp:ListItem>
                            <asp:ListItem>2016</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="dlYearExpire" CssClass="rfVal" Display="Dynamic" 
                            ErrorMessage="Choose expiration year" InitialValue="-1">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <div class="panelTitle">Shippment Address</div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label9" runat="server" Text="House Number: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtHouse" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCardholder6" runat="server" CssClass="rfVal" 
                        ErrorMessage="House number required" ControlToValidate="txtHouse">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label10" runat="server" Text="Street: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCardholder5" runat="server" CssClass="rfVal" 
                        ErrorMessage="Street required" ControlToValidate="txtStreet">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label11" runat="server" Text="Suite/Appartment: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtSuite" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCardholder2" runat="server" CssClass="rfVal" 
                        ErrorMessage="Suite/App required" ControlToValidate="txtSuite">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label12" runat="server" Text="City: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCardholder4" runat="server" CssClass="rfVal" 
                        ErrorMessage="City required" ControlToValidate="txtCity">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label13" runat="server" Text="Postal Code: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfCardholder3" runat="server" CssClass="rfVal" 
                        ErrorMessage="Postal Code required" ControlToValidate="txtPostalCode">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblProvince" runat="server" Text="Province: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlProvince" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="dlProvince" CssClass="rfVal" Display="Dynamic" 
                        ErrorMessage="Choose province" InitialValue="-1">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                CssClass="ValidationSummaryRight" DisplayMode="List" />
        </div>
        <div class="Center">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Order" 
                onclick="btnSubmit_Click" CssClass="button1" />
            <asp:Button ID="btnClearData" runat="server" CssClass="button1" 
                onclick="btnClearData_Click" Text="Clear All" ValidationGroup="None" />
            <asp:Button ID="btnCancel" runat="server" CssClass="button1" 
                onclick="btnClancel_Click" Text="Cancel" ValidationGroup="None" />
        </div>
        <div class="Center">
            <asp:Label ID="lblError" runat="server" Text="Communication Error" CssClass="ValidationSummary" Visible="False"></asp:Label>
        </div>
        </asp:Panel>
     
     

</div>
</asp:Content>
