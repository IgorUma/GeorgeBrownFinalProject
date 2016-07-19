using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Administration {
    public partial class Suppliers : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Master.verifyIfUserBelongs();

                loadAllSuppliears();
            }
        }
        private void loadAllSuppliears() {
            clearErrorMessage();
            clearSuppliers();
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getSuppliers();
            if (dataSet != null) {
                if (dataSet.Tables[0].Rows.Count > 0) {
                    //Bind DropDownList to GrudView
                    gvSuppliers.DataSource = dataSet;
                    gvSuppliers.DataBind();
                }
                else { errorMessage("List is Empty"); }
            }
            else {
                errorMessage();
            }
        }
        private void clearSuppliers(){
            gvSuppliers.DataSource = null;
            gvSuppliers.DataBind();
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

        protected void btnSave_Click(object sender, EventArgs e) {
            clearErrorMessage();
            // check existanse of company with same name
            string companyName = txtCompanyName.Text.Trim();
            if (!alreadyexists(companyName)) {
                lblError.Visible = false;
                //get supplier data and create object
                PostalAddress address;
                address = createAddressObj();
                string lastName = txtLastName.Text.Trim();
                string firstName = txtFirstName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                int status = int.Parse(dlStatus.SelectedValue);
                if (status >= 0) {
                    Supplier company = new Supplier(companyName, firstName, lastName, phone, status, address);
                    int supplierID = company.insertSupplier();
                    if (supplierID <= 0) {
                        errorMessage();
                    }
                    else {
                        //if OK display ID
                        lbl_ID.Text = supplierID.ToString();
                        lbl_ID.Visible = true;
                        lblSupplierID.Visible = true;
                        loadAllSuppliears();
                        btnSave.Visible = false;
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                    }
                }
                else {
                    errorMessage("Select Status");
                }
            }
            else {
                errorMessage("Company with this name already exists");
            }
           
        }

        protected PostalAddress createAddressObj() {
            string streetAddress=txtStreetAddress.Text.Trim();
            string suite=txtSuite.Text.Trim();
            string city=txtCity.Text.Trim();
            string code=txtPostalCode.Text.Trim();
            int province = int.Parse(dlProvince.SelectedValue.ToString());
            int country = int.Parse(dlCountry.SelectedValue.ToString());
            if (province > 0 && country > 0) {
                int userID = -1;//not a user
                PostalAddress address = new PostalAddress(streetAddress, suite, city, province, country, code, userID);
                return address;
            }
            else {
                errorMessage("Select Country/Province");
                return null;
            }
        }
        protected void loadCountries() {
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getCountries();
            if (dataSet != null) {

                //Bind DropDownList to DataSet


                dlCountry.DataTextField = "Country";
                dlCountry.DataValueField = "CountryID";
                dlCountry.DataSource = dataSet;
                dlCountry.DataBind();
                //dlSuppliers.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }
        protected void loadProvinces(int country) {
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
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
        protected void loadStatusTable() {
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getStatusTable();
            if (dataSet != null) {

                //Bind DropDownList to DataSet

                
                dlStatus.DataTextField ="Status";
                dlStatus.DataValueField = "Value";
                dlStatus.DataSource = dataSet;
                dlStatus.DataBind();
                dlStatus.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }

        protected void dlCountry_SelectedIndexChanged(object sender, EventArgs e) {
            int country = int.Parse(dlCountry.SelectedValue.ToString());
            if (country > 0) { 
                //clear provinces
                dlProvince.DataSource = null;
                dlProvince.DataBind();

                loadProvinces(country);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e) {
            clearErrorMessage();
            if (Page.IsValid) {
                int supplierID;
                if (int.TryParse(lbl_ID.Text, out supplierID)) {
                    lblError.Visible = false;PostalAddress address = new PostalAddress();
                    address = createAddressObj();
                    string companyName = txtCompanyName.Text.Trim();
                    string lastName = txtLastName.Text.Trim();
                    string firstName = txtFirstName.Text.Trim();
                    string phone = txtPhone.Text.Trim();
                    int status = int.Parse(dlStatus.SelectedValue);
                    if (address != null) {
                        Supplier company = new Supplier(companyName, firstName, lastName, phone, status, address);
                        bool updated = company.updateSupplier(supplierID);
                        loadAllSuppliears();
                        if (!updated) {
                            errorMessage();
                        }
                    }
                    else { errorMessage("Select Company from the list"); }
                    pnlSuppDetails.Visible = false;
                    pnlSuppList.Visible = true;
                }
            }
        }

        protected void btnCreatNewSupplier_Click(object sender, EventArgs e) {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            clearErrorMessage();
            clearDetails();
            lbl_ID.Visible = false;
            lblSupplierID.Visible = false;
            pnlSuppDetails.Visible = true;
            loadStatusTable();
            loadCountries(); // Canada by default
            loadProvinces(1); // load all Canadian active provinces/ territories
            SetFocus(txtCompanyName);
            pnlSuppDetails.Visible = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e) {
            int supplierID;
            if (int.TryParse(lbl_ID.Text, out supplierID)) {
                
                DataLayer DL = new DataLayer();
                bool deleted = DL.deleteSuplier(supplierID);
                if (deleted) {
                    clearDetails();
                    pnlSuppDetails.Visible = false;
                    loadAllSuppliears();
                }
                else {
                    errorMessage();
                }
            }
            else { errorMessage("Select Company from the list"); }
        }
        protected void clearDetails() {
            txtCity.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtStreetAddress.Text = string.Empty;
            txtSuite.Text = string.Empty;
            lbl_ID.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            btnSave.Visible = true;
            btnUpdate.Visible= true;
            btnDelete.Visible = true; 
            clearDetails();
            clearErrorMessage();
            pnlSuppDetails.Visible = false;
        }
        private bool alreadyexists(string companyName) {
            bool exists = false;

            int rows=gvSuppliers.Rows.Count;
            for (int i=0; i<rows;i++){
                string dbName=gvSuppliers.Rows[i].Cells[2].Text;
                if (String.Equals(dbName, companyName)) {
                    exists = true;
                }
            }

            return exists;
        }

        protected void gvSuppliers_SelectedIndexChanged(object sender, EventArgs e) {
            
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            lbl_ID.Visible = true;
            lblSupplierID.Visible = true;
            string supplierName = gvSuppliers.SelectedRow.Cells[2].Text;
            DataLayer dl = new DataLayer();
            DataSet ds = new DataSet();
            ds = dl.loadSupplier(supplierName);//null
            if (ds.Tables[0].Rows.Count > 0) {
                lbl_ID.Text = ds.Tables[0].Rows[0]["SupplierID"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                txtCompanyName.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["ContactFirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["ContactLastName"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                txtPostalCode.Text = ds.Tables[0].Rows[0]["PostalCode"].ToString();
                txtStreetAddress.Text = ds.Tables[0].Rows[0]["StreetAddress"].ToString();
                txtSuite.Text = ds.Tables[0].Rows[0]["Suite"].ToString();
                string country = ds.Tables[0].Rows[0]["Country"].ToString();
                loadCountries();
                dlCountry.SelectedIndex = dlCountry.Items.IndexOf(dlCountry.Items.FindByValue(country));
                
                loadProvinces(int.Parse(country));
                string province = ds.Tables[0].Rows[0]["Province"].ToString();
                dlProvince.SelectedIndex =  dlProvince.Items.IndexOf( dlProvince.Items.FindByValue(province));
                loadStatusTable();
                
                string status = ds.Tables[0].Rows[0]["Status"].ToString();
                dlStatus.SelectedIndex = dlStatus.Items.IndexOf(dlStatus.Items.FindByValue(status));
                pnlSuppDetails.Visible = true;
            }
            else {
                errorMessage();
            }
        }
    }
}