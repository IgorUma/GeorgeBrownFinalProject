using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Administration {
    public partial class Products : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Master.verifyIfUserBelongs();

                loadAllSuppliears();
                loadStatusTable();
                loadCategories();
                loadProductSupplier();

                pnlDetails.Visible = false;
                
            }
        }
        private void loadAllSuppliears() {// to select products
            //clearErrorMessage();
            
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getSuppliers();
            if (dataSet != null) {
                //Bind DropDownList to GrudView
                
                dlSuppliers1.DataTextField = "Supplier";
                dlSuppliers1.DataValueField = "SupplierID";
                dlSuppliers1.DataSource = dataSet;
                dlSuppliers1.DataBind();
                dlSuppliers1.Items.Insert(0, new ListItem("Select", "-1"));
            }
            else {
                errorMessage();
            }
        }
        
        private void loadProductSupplier() {// to display product details
            clearErrorMessage();

            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getSuppliers();
            if (dataSet != null) {
                //Bind DropDownList to GrudView
               
                dlProductSupplier.DataTextField = "Supplier";
                dlProductSupplier.DataValueField = "SupplierID";
                dlProductSupplier.DataSource = dataSet;
                dlProductSupplier.DataBind();
                dlProductSupplier.Items.Insert(0, new ListItem("Select", "-1"));
            }
            else {
                errorMessage();
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

        protected void btnInsert_Click(object sender, EventArgs e) {
            clearErrorMessage();
            clearData();
            loadStatusTable();
            loadCategories();
            loadProductSupplier();

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            pnlDetails.Visible = true;
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
        protected void loadStatusTable() {
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getStatusTable();
            if (dataSet != null) {

                //Bind DropDownList to DataSet


                dlStatus.DataTextField = "Status";
                dlStatus.DataValueField = "Value";
                dlStatus.DataSource = dataSet;
                dlStatus.DataBind();
                dlStatus.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }

        protected void dlSuppliers1_SelectedIndexChanged(object sender, EventArgs e) {
            clearErrorMessage();
            int supplierID;
            if (int.TryParse(dlSuppliers1.SelectedValue, out supplierID) && supplierID > 0) {
                loadProductsBySupplier(supplierID);

            }
            else {
                gvProducts.DataSource = null;
                gvProducts.DataBind();
                errorMessage("Select Supplier");
            }
        }
        protected void loadProductsBySupplier(int supplierID) {
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getProductsBySupplier(supplierID);
            if (dataSet != null) {
                if (dataSet.Tables[0].Rows.Count > 0) {

                    //Bind DropDownList to GrudView
                    gvProducts.DataSource = dataSet;
                    gvProducts.DataBind();
                }
                //if no products
                else {
                    errorMessage("List is empty");
                    gvProducts.DataSource = null;
                    gvProducts.DataBind();
                }
            }
            else {
                errorMessage();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            clearErrorMessage();
            // check existanse of company with same name
            if (lbl_ID.Text == string.Empty) {
                string productName = txtProductName.Text.Trim();
                string priceSTR = txtPrice.Text.Trim();
                float price;
                if(float.TryParse(priceSTR,out price)){
                lblError.Visible = false;
                int status = int.Parse(dlStatus.SelectedValue);
                int category = int.Parse(dlCategory.SelectedValue);
                int supplier = int.Parse(dlProductSupplier.SelectedValue);
                if (supplier > 0 && category>0) {
                    loadProductsBySupplier(supplier);
                    bool exists = productExists(productName);
                    if (!exists) {
                        if (status >= 0 ) {
                            DataLayer DL = new DataLayer();
                            int productID = DL.insertProduct(productName, price, category, supplier, status);
                            if (productID <= 0) {
                                errorMessage();
                            }
                            else {
                                //if OK display ID
                                lbl_ID.Text = productID.ToString();
                                lbl_ID.Visible = true;

                                lblProductID.Visible = true;
                                loadProductsBySupplier(supplier);
                            }
                        }
                        else {
                            errorMessage("Select Status");
                        }
                        // ask,exists
                    }
                    else { errorMessage("product exists"); }
                }
                else { errorMessage("Select Supplier and Category"); }
            }
                else { errorMessage("Enter correct price"); }
            }
            else { errorMessage("Please Press 'Insert' Button"); }
        }

        protected bool productExists(string productName) {
            bool exists = false;
            string category = dlCategory.SelectedItem.Text.Trim();
            string supplier = dlProductSupplier.SelectedItem.Text.Trim();
            string listProductName;
            string listCategory;
            string listSupplier;
            for (int i = 0; i < gvProducts.Rows.Count; i++) {
                listProductName = gvProducts.Rows[i].Cells[1].Text.Trim();
                listSupplier = gvProducts.Rows[i].Cells[2].Text.Trim();
                listCategory = gvProducts.Rows[i].Cells[3].Text.Trim();

                if (productName == listProductName && supplier == listSupplier && listCategory == category) {
                    exists = true;
                }
            }
            return exists;
        }
        protected void clearData() {
            clearErrorMessage();
            lbl_ID.Text = string.Empty;
            lbl_ID.Visible = false;
            lblProductID.Visible = false;
            txtProductName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            dlCategory.ClearSelection();
            dlProductSupplier.ClearSelection();
            dlStatus.ClearSelection();
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e) {
            clearData();
            clearErrorMessage();
            
            //if(productID>0){
            int i = gvProducts.SelectedIndex;
            string listProductName = gvProducts.Rows[i].Cells[1].Text.Trim();
            string listSupplier = gvProducts.Rows[i].Cells[2].Text.Trim();
            string listCategory = gvProducts.Rows[i].Cells[3].Text.Trim();
            string price = gvProducts.Rows[i].Cells[4].Text.Trim();
            string status = gvProducts.Rows[i].Cells[5].Text.Trim();
            
            dlProductSupplier.SelectedIndex = dlProductSupplier.Items.IndexOf(dlProductSupplier.Items.FindByText(listSupplier));
            dlCategory.SelectedIndex = dlCategory.Items.IndexOf(dlCategory.Items.FindByText(listCategory));
            dlStatus.SelectedIndex = dlStatus.Items.IndexOf(dlStatus.Items.FindByText(status));
            int category = int.Parse(dlCategory.SelectedValue);
            int supplier = int.Parse(dlProductSupplier.SelectedValue);
            int productID = getProductID(listProductName, category, supplier);
            if (productID > 0) { 
                lbl_ID.Text = productID.ToString();
                lblProductID.Visible = true;
                lbl_ID.Visible = true;
                txtProductName.Text = listProductName;
                
                txtPrice.Text = price;

                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                pnlDetails.Visible = true;
            }
            else {
                clearData();
                errorMessage(); }
        }
        private int getProductID(string name, int category, int supplier) {
            int productID = 0;
            DataLayer DL = new DataLayer();
            productID = DL.getProductID(name, category, supplier);

            return productID;
        }

        protected void btnUpdate_Click(object sender, EventArgs e) {
             clearErrorMessage();
            // check existanse of company with same name
            int productID;
            if (int.TryParse(lbl_ID.Text.Trim(), out productID))  {
                string productName = txtProductName.Text.Trim();
                string priceSTR = txtPrice.Text.Trim();
                float price;
                if(float.TryParse(priceSTR,out price)){
                    lblError.Visible = false;
                    int status = int.Parse(dlStatus.SelectedValue);
                    if (status >= 0) { 
                        int category = int.Parse(dlCategory.SelectedValue);
                        int supplier = int.Parse(dlProductSupplier.SelectedValue);
                        if (supplier > 0 && category>0 ) {
                            int affected = updateProduct(productID, productName, price, category, supplier, status);
                            if (affected > 0) { 
                                loadProductsBySupplier(supplier);
                                loadProductsBySupplier(supplier);
                            }
                            else { errorMessage(); }
                        }
                        else { errorMessage("Select Supplier and Category"); }
                    }
                    else { errorMessage("Select Status");}
                }
                else { errorMessage("Enter correct price"); }
            }
            else { errorMessage("Select Product From the List"); }
        }
        private int updateProduct(int productID, string productName, float price, int category, int supplier, int status) {
            int affected = 0;
            DataLayer DL = new DataLayer();
            affected = DL.updateProduct(productID, productName, price, category, supplier, status);
            return affected;
        }

        protected void btnDelete_Click(object sender, EventArgs e) {
            string productIDstr=lbl_ID.Text.Trim();
            int productID;
            if(int.TryParse(productIDstr, out productID)){
                DataLayer DL = new DataLayer();
                int affected = DL.deleteProduct(productID);
                if (affected > 0) {
                    int supplierID=int.Parse(dlProductSupplier.SelectedValue.Trim());
                    loadProductsBySupplier(supplierID);
                    clearData();
                    pnlDetails.Visible = false;
                }
                else { errorMessage(); }
                }
            else { errorMessage("Select Product From the List"); }
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            clearData();
            pnlDetails.Visible = false;
        }
        
    }
}
