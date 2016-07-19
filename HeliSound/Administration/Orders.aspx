<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="HeliSound.Administration.Orders" %>
<%@ MasterType VirtualPath="~/Administration/Administration.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page">
 <div class="pageTitle">
     Order review</div>
 
    <asp:Panel ID="Panel1" runat="server" CssClass="pnlDashed">
    <div class="divRow">
        <div class="divHalfRow">
            <div class="divdataLEFT">
                <asp:Label ID="Label1" runat="server" Text="Enter Order Number:"></asp:Label>
            </div>
            <div class="divdataRIGHT">
                <asp:TextBox ID="txtInvoiceNumber" runat="server"></asp:TextBox>
            </div>
        </div>
        
            <div class="divHalfRow">
               <div class="divdataLEFT">
                <asp:Button ID="btnDisplay" runat="server" Text="Display Order" 
                    CssClass="button" onclick="btnDisplay_Click" />
            </div>
        </div>
    </div>
    </asp:Panel>
   <asp:Label ID="lblError" runat="server" Text="Communication Error" CssClass="rfVal" 
        Visible="False"></asp:Label>
         <asp:GridView ID="gvList" runat="server" 
        onselectedindexchanged="gvList_SelectedIndexChanged" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4">
             <Columns>
                 <asp:CommandField ShowSelectButton="True" SelectText="Details" />
                 <asp:BoundField DataField="OrderID" HeaderText="Order ID">
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="Ordered" DataFormatString="{0:MMM/dd/yy}" 
                     HeaderText="Ordered">
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="ProductName" HeaderText="Item">
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="Total" DataFormatString="{0:C2}" HeaderText="Total">
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="Name" HeaderText="Customer Name">
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="Shipping Status" HeaderText="Shipping Status">
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
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
    <asp:Panel ID="pnlOrderInfo" runat="server" CssClass="pnlDashed" 
            Visible="False">
            <div class="panelTitle">Order Details</div>
            <div class="divRow">
                
                        <asp:TextBox ID="txtProductID" runat="server" ReadOnly="True" Visible="False" 
                            Width="1px"></asp:TextBox>
                    </div>
                
                <asp:TextBox ID="txtAddressID" runat="server" ReadOnly="True" Visible="False" 
                    Width="1px"></asp:TextBox>
             
            <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    Item:
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlProducts" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    Total:
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="panelTitle">Shippment Address</div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    Street Address:
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtStreetAdd" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label10" runat="server" Text="Suite/Appartment: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtSuite" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="divRow">
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label11" runat="server" Text="City: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="Label12" runat="server" Text="Province: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlProvince" runat="server" CssClass="ddl">
                    </asp:DropDownList>
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
                </div>
            </div>
            <div class="divHalfRow">
                <div class="divdataLEFT">
                    <asp:Label ID="lblProvince" runat="server" Text="Country: "></asp:Label>
                </div>
                <div class="divdataRIGHT">
                    <asp:DropDownList ID="dlCountry" runat="server" CssClass="ddl">
                        <asp:ListItem Value="1">Canada</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="Center">
            <asp:Button ID="btnSubmit" runat="server" Text="Save Changes" 
                onclick="btnSubmit_Click" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" CssClass="button1" 
                onclick="btnCancel_Click" Text="Cancel" />
        </div>
        
        </asp:Panel>
    </div>
</asp:Content>
