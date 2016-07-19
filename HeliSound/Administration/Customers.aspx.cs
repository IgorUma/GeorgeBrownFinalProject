using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Administration {
    public partial class Customers : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Master.verifyIfUserBelongs();
                SetFocus(txtSearchName);
                loadStatusTable();
                clearErrorMessage();
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
        protected void btnSearchByName_Click(object sender, EventArgs e) {
            clearErrorMessage();
            clearData();
            pnlData.Visible = false;
            txtSearchID.Text = string.Empty;
            gvListUnbind();
            loadCustomersNameLike();
        }
        protected void loadCustomersNameLike() {
            bool check = chbIncludeInactive.Checked;
            string nameStarts = txtSearchName.Text.Trim();
            DataLayer DL = new DataLayer();
            DataSet dataSet;
            if (check) {
                dataSet = DL.searchAllCastomersByNameLike(nameStarts);
            }
            else {
                dataSet = DL.searchActiveCastomersByNameLike(nameStarts);
            }
            if (dataSet != null) {
                if (dataSet.Tables[0].Rows.Count > 0) {
                    gvList.DataSource = dataSet;
                    gvList.DataBind();
                }
                else { errorMessage("No Customer name starsts with '" + nameStarts + "'."); }
            }
            else { errorMessage(); }

        }

        protected void gvList_SelectedIndexChanged(object sender, EventArgs e) {
            clearErrorMessage();
            loadStatusTable();
            int row = gvList.SelectedIndex;
            int customerID = int.Parse(gvList.SelectedRow.Cells[1].Text.Trim());
            DataLayer DL = new DataLayer();
            DataSet dataSet = DL.getCustomerDataByCustomerID(customerID);
            if (dataSet != null) {
                displayData(dataSet);
            }
            else { errorMessage(); }
        }
        protected void displayData(DataSet dataSet) {
            clearErrorMessage();
            dlStatus.SelectedValue = dataSet.Tables[0].Rows[0]["Status"].ToString();
            lbl_ID.Text = dataSet.Tables[0].Rows[0]["UserID"].ToString();
            txtFirstName.Text = dataSet.Tables[0].Rows[0]["FirstName"].ToString();
            txtLastName.Text = dataSet.Tables[0].Rows[0]["LastName"].ToString();
            txtEmail.Text = dataSet.Tables[0].Rows[0]["EmailAddress"].ToString();
            txtPhone.Text = dataSet.Tables[0].Rows[0]["Phone"].ToString();
            pnlData.Visible = true;
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

        protected void btnUpdate_Click(object sender, EventArgs e) {
            clearErrorMessage();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            int status = int.Parse(dlStatus.SelectedValue);
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            int customerID=int.Parse(lbl_ID.Text);
            DataLayer DL = new DataLayer();
            int affected = DL.updateCustomer(customerID, firstName, lastName, phone, email, status);
            if (affected > 0) {
                gvListUnbind();
                chbIncludeInactive.Checked=true;
                loadCustomersNameLike();
                
            }
            else { errorMessage(); }
        }
        protected void gvListUnbind(){
            gvList.DataSource=null;
            gvList.DataBind();

        }

        protected void btnDelete_Click(object sender, EventArgs e) {
            clearErrorMessage();
            int id;
            if (int.TryParse(lbl_ID.Text, out id)) {
                DataLayer DL = new DataLayer();
                int affected = DL.deleteCustomer(id);
                if (affected <= 0) { errorMessage(); }
                else { 
                    loadCustomersNameLike();
                    clearData();
                    pnlData.Visible = false;
                }
            }
        }
        protected void clearData() {
            //pnlData.Visible = false;
            clearErrorMessage();
            lbl_ID.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            dlStatus.ClearSelection();
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            clearData();
            pnlData.Visible = false;
        }

        protected void btnSearchByID_Click(object sender, EventArgs e) {
            clearErrorMessage();
            txtSearchName.Text = string.Empty;
            clearData();
            pnlData.Visible = false;
            gvListUnbind();
            int customerID;
            string id=txtSearchID.Text.Trim();
            if (int.TryParse(id, out customerID)) {
                gvListUnbind();
                loadUserByID(customerID);
                
            }
            else {
                errorMessage("Customer ID format is incorrect");

            }
        }
        protected void loadUserByID(int userID) {

            DataLayer DL = new DataLayer();
            //DataSet dataSet = DL.getCustomerDataByCustomerID(userID);
            DataSet dataSet = DL.LoadCustomerByID(userID);
            
            if (dataSet != null) {
                if (dataSet.Tables[0].Rows.Count > 0) {
                    displayData(dataSet);
                    
                }
                else {

                    errorMessage("No customer fits search criterion");
                }
            }
            else { errorMessage(); }

        }
       
        
    }
}