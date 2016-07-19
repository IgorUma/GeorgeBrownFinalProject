using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Administration {
    public partial class Category : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Master.verifyIfUserBelongs();
                loadAllCategories();
                clearErrorMessage();
            }
            clearErrorMessage();
        }

        protected void btnCreate_Click(object sender, EventArgs e) {
            //clearDetails();
            //dlStatus.Items.Clear();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnInsert.Visible = true;
            btnCancel.Visible = true;
            txtCategoryName.Text = string.Empty;
            lbl_ID.Text = string.Empty;
            clearErrorMessage();
            lbl_ID.Visible = false;
            lblCaregoryID.Visible = false;
            gvList.Visible = true;
            loadStatusTable();
            SetFocus(txtCategoryName);
            pnlCategoryDetails.Visible = true;
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
        protected void loadAllCategories() {
            clearErrorMessage();
            clearCategories();
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getCategories();
            if (dataSet != null) {
                //Bind DropDownList to GrudView
                gvList.DataSource = dataSet;
                gvList.DataBind();
            }
        }

        protected void gvList_SelectedIndexChanged(object sender, EventArgs e) {
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnInsert.Visible = false;
            btnCancel.Visible = true;
            string categoryName = gvList.SelectedRow.Cells[1].Text;
            DataLayer dl = new DataLayer();
            DataSet ds = new DataSet();
            ds = dl.loadCategory(categoryName);//null
            if (ds.Tables[0].Rows.Count > 0) {
                lbl_ID.Text = ds.Tables[0].Rows[0]["CategoryID"].ToString();

                txtCategoryName.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                loadStatusTable();
                string status = ds.Tables[0].Rows[0]["Status"].ToString();
                dlStatus.SelectedIndex = dlStatus.Items.IndexOf(dlStatus.Items.FindByText(status));
                lblCaregoryID.Visible = true;
                lbl_ID.Visible = true;
                pnlCategoryDetails.Visible = true;
            }
            else {
                errorMessage();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e) {
            clearErrorMessage();
            // check existanse of company with same name

            string categoryName = txtCategoryName.Text.Trim();
            if (!alreadyExists(categoryName)) {
                lblError.Visible = false;
                int status = int.Parse(dlStatus.SelectedValue);
                if (status >= 0) {
                    
                    int categoryID = insertCategory(categoryName,status);
                    if (categoryID <= 0) {
                        errorMessage();
                    }
                    else {
                        //if OK display ID
                        lbl_ID.Text = categoryID.ToString();
                        lbl_ID.Visible = true;

                        lblCaregoryID.Visible = true;
                        loadAllCategories();
                    }
                }
                else {
                    errorMessage("Select Status");
                }
            }
            else {
                errorMessage("Category with this name already exists");
            }
        }
        private bool alreadyExists(string categoryName) {
            bool exists = false;
            int rows = gvList.Rows.Count;
            for (int i = 0; i < rows; i++) {
                string dbName = gvList.Rows[i].Cells[1].Text;
                if (String.Equals(dbName.ToLower(), categoryName.ToLower())) {
                    exists = true;
                }
            }

            return exists;
        }
        private int insertCategory(string categoryName, int status) {
            clearDetails();
            int id = 0;
            DataLayer DL = new DataLayer();
            id = DL.insertCategory(categoryName, status);
            return id;
        }
     

        protected void btnUpdate_Click(object sender, EventArgs e) {
            int updated = 0;
            // Get data
            int categoryID;
            if (int.TryParse(lbl_ID.Text, out categoryID)) {
                string categoryName = txtCategoryName.Text.Trim();
                int status = int.Parse(dlStatus.SelectedValue);
                if (status >= 0) {
                    DataLayer DL = new DataLayer();
                    updated = DL.updateCategory(categoryID, categoryName, status);
                    if (updated > 0) {
                        loadAllCategories();
                    }
                    else {
                        errorMessage();
                    }
                }
                else {
                    errorMessage("Select status");
                }
            }
            else {
                errorMessage("Select Category from the list");
            }
            }
        
     

        protected void btnDelete_Click(object sender, EventArgs e) {
            int categoryID;
            if (int.TryParse(lbl_ID.Text, out categoryID)) {

                DataLayer DL = new DataLayer();
                bool deleted = DL.deleteCategory(categoryID);
                if (deleted) {
                    clearDetails();
                    pnlCategoryDetails.Visible = false;
                    loadAllCategories();
                }
                else {
                    errorMessage();
                }

            }
            else { errorMessage("Select Category from the list"); }
        }
        protected void clearDetails() {
            txtCategoryName.Text = string.Empty;
            lbl_ID.Text = string.Empty;
            lbl_ID.Visible = false;
            lblCaregoryID.Visible = false;
            dlStatus.SelectedValue = "-1";

        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            clearDetails();
            clearErrorMessage();
            pnlCategoryDetails.Visible = false;
        }
        private void clearCategories() {

            gvList.DataSource = null;
            gvList.DataBind();
        }
    }
}