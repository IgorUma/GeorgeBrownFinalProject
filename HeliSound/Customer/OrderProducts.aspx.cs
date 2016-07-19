using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Customer {
    public partial class OrderProducts : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
            loadSuppliers();
            loadCategories();
            pnlOrderInfo.Visible = false;
            }
            
        }

        private void loadSuppliers() {
            clearProducts();
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getSuppliers();
            if (dataSet != null) {

                //Bind DropDownList to DataSet


                dlSuppliers.DataTextField = "Supplier";
                dlSuppliers.DataValueField = "SupplierID";
                dlSuppliers.DataSource = dataSet;
                dlSuppliers.DataBind();
                dlSuppliers.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }
        protected void loadProvinces() {
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            int country = 1;//Canada
            dataSet = DL.getProvinces(country);
            if (dataSet != null) {

                //Bind DropDownList to DataSet


                dlProvince.DataTextField = "Province";
                dlProvince.DataValueField = "ProvinceID";
                dlProvince.DataSource = dataSet;
                dlProvince.DataBind();
                dlProvince.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }
        private void loadCategories() {
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getCategories();
            if (dataSet != null) {
                //Bind DropDownList to DataSet
                dlCategory.DataTextField = "Description";
                dlCategory.DataValueField = "CategoryID";
                dlCategory.DataSource = dataSet;
                dlCategory.DataBind();
                dlCategory.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }
        private void loadProducts() {
            
            int supplier = int.Parse(dlSuppliers.SelectedValue.ToString());
            int category = int.Parse(dlCategory.SelectedValue.ToString());

            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getProducts(supplier, category);
            if (dataSet != null) {
                dlProduct.DataTextField = "ProductName";
                dlProduct.DataValueField = "ProductID";
                dlProduct.DataSource = dataSet;
                dlProduct.DataBind();
                dlProduct.Items.Insert(0, new ListItem("Select", "-1"));
            }
            else {
                lblNoFit.Visible = true;
                gvListClear();
            }
        }

        private void gvListClear() {
            gvDetails.DataSource = null;
            gvDetails.DataBind();
        }

        private void clearProducts() {
            
            dlProduct.Items.Clear();
            
        }

        protected void dlCategory_SelectedIndexChanged(object sender, EventArgs e) {
            clearProducts();
            
            if (dlCategory.SelectedValue != "-1") {
               
                lblNoFit.Visible = false;
                int supplier = int.Parse(dlSuppliers.SelectedIndex.ToString());
                if (supplier > 0) { // if supplier is selected
                    loadProducts();
                }
            }
            
        }

        protected void dlSuppliers_SelectedIndexChanged(object sender, EventArgs e) {
            
            clearProducts();

            if (dlSuppliers.SelectedValue != "-1") {
                gvListClear();
                clearProducts();
                lblNoFit.Visible = false;
                int category = int.Parse(dlCategory.SelectedIndex.ToString());
                if (category > 0) { // if category is selected
                    loadProducts();
                }
            }
            
        }

        protected void dlProduct_SelectedIndexChanged(object sender, EventArgs e) {
            gvListClear();
            int product = int.Parse(dlProduct.SelectedValue.ToString());
            if (product > 0) { // if product is selected
                dispayProductInfo(product);
            }
        }
        protected void dispayProductInfo(int productID) {
            
            DataLayer DL = new DataLayer();
            DataSet ds = new DataSet();
            ds = DL.productInfo(productID);
            if (ds != null && ds.Tables[0].Rows.Count > 0) {
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
            }

        }

        protected void btnClear_Click(object sender, EventArgs e) {
            dlCategory.ClearSelection();
            dlSuppliers.ClearSelection();
            dlProduct.ClearSelection();
            lblNoFit.Visible = false;
            clearErrorMessage();

        }

        protected void gvDetails_SelectedIndexChanged(object sender, EventArgs e) {
            pnlOrderInfo.Visible = true;
            clearErrorMessage();
            loadProvinces();
            pnlOrderInfo.Visible = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e) {
            double taxRate = getTaxRate();
            if (taxRate > 0) {
                int address = createAddress();
                if (address >0) {
                    int userID = getUserID();
                    if (userID > 0) {
                        string priceSTR = gvDetails.SelectedRow.Cells[2].Text.Substring(1); // getting price from GV w/o "$" sign
                        double price = double.Parse(priceSTR);

                        int productID = int.Parse(gvDetails.SelectedRow.Cells[5].Text);
                        string name = txtName.Text.Trim();
                        string cardNumber = txtCardNumber.Text.Trim();
                        string securityCode = txtSecurityCode.Text.Trim();
                        string expireMonth = dlMonthExpire.SelectedValue;
                        string expireYear = dlYearExpire.SelectedValue;
                        string cardType = dlCardType.SelectedItem.Text;
                        // Creat INVOICE object
                        Invoice order = new Invoice();
                        //to be processed and NOT saved in DB
                        order.CardHolderName = name;
                        order.CardNumber = cardNumber;
                        order.SecurityCode = securityCode;
                        order.ShippingAddressID = address;
                        
                        //to be saved in DB
                        order.UserID = userID;
                        order.DateCreated = DateTime.Today;
                        order.ProductID = productID;
                        order.ShippingAddressID = address;
                        order.Total = price * (1 + taxRate);
                        int orderID=insertOrder(order);
                        if (orderID > 0) {
                            goToPecipt(order.Total);
                        }
                        else { errorMessage(); }
                    }//userID
                    else { errorMessage(); }
                 }//address
            }//taxRate unavailable
            else { errorMessage(); }
            
        }
        private void goToPecipt(double total) {
            string sessionID = string.Empty;
            sessionID = Request.QueryString["SessionID"];
            string path = "~/Customer/Receipt.aspx?SessionID=" + sessionID;
            string fullName = Master.getFullName();
            string item = gvDetails.Rows[0].Cells[1].Text;
            path += "&Item=" + item;
            path += "&Name=" + fullName + "&Total=" + total.ToString("C2");
            Response.Redirect(path);
        }
        private int insertOrder(Invoice order) {
            DataLayer DL = new DataLayer();
            int orderID =-1;
            orderID = DL.insertOrder(order);
            return orderID;
        }
        private int getUserID() {
            int id = -1;
            DataLayer DL = new DataLayer();
            string sessionID = string.Empty;
            sessionID = Request.QueryString["SessionID"];
            id = DL.getCustomerIDbySession(sessionID);
            return id;
        }

        private double getTaxRate() {
            double rate = -1;
            DataLayer DL = new DataLayer();
            rate = DL.getTaxRate();
            return rate;
        }

        protected int createAddress() {
            string house = txtHouse.Text.Trim();
            string street = txtStreet.Text.Trim();
            string streetAddress = house + " " + street;
            string suite = txtSuite.Text.Trim();
            string city = txtCity.Text.Trim();
            string code = txtPostalCode.Text.Trim();
            int userID = Master.getUserID();
            int province = int.Parse(dlProvince.SelectedValue.ToString());
            int country = 1; // Canada
            if (province > 0) {
                PostalAddress address = new PostalAddress(streetAddress, suite, city, province, country, code,userID);
                int addressID = address.insertAddress();
                return addressID;
            }
            else {
                errorMessage("Select Province");
                return -1;
            }
        }
        private void errorMessage() {
            lblError.Visible = true;
        }
        private void errorMessage(string message) {
            lblError.Text = message;
            lblError.Visible = true;
        }
        private void clearErrorMessage() {
            lblError.Visible = false;
        }

        
        private void clearData() {
            txtCardNumber.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtHouse.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtSecurityCode.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtSuite.Text = string.Empty;
            dlCardType.SelectedValue = "-1";
            dlProvince.SelectedValue = "-1";
            dlYearExpire.SelectedValue = "-1";
            dlMonthExpire.SelectedValue = "-1";
        }

        protected void btnClearData_Click(object sender, EventArgs e) {
            clearData();
        }
        

        protected void btnClancel_Click(object sender, EventArgs e) {
            clearData();
            pnlOrderInfo.Visible = false;
            gvListClear();
        }
    }
}