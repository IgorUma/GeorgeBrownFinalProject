using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Administration {
    public partial class UserMaintenance : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Master.verifyIfUserBelongs();

                clearErrorMessage();
                loadAllUsers();
                loadStatusTable();
                loadRolesTable();
            }
        }
        protected void loadUsers() {
            clearErrorMessage();
            clearUsers();
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getUsers();
            if (dataSet != null) {
                //Bind DropDownList to GrudView
                gvList.DataSource = dataSet;
                gvList.DataBind();
            }
        }
        private void clearUsers() {

            gvList.DataSource = null;
            gvList.DataBind();
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
            clearUserData();
            lblUserID.Visible = false;
            lbl_ID.Visible = false;
            lbl_ID.Text = string.Empty;
            loadStatusTable();
            loadRolesTable();
            pnlDetails.Visible = true;
            pnlPW.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            lnkbtnPW.Visible = false;

            txtEmail.ReadOnly = false;

            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            // enable rf controls. for PSWord
            rfPassword.Enabled = true;
            rfConPassword.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            clearErrorMessage();
            string email = txtEmail.Text.Trim();
            //is email address available as unique LogIn name
            bool unique = emailIsUnique(email);
            if (unique) {
                if (lbl_ID.Text == string.Empty) {
                    string firstName = txtFirstName.Text.Trim();
                    string lastName = txtLastName.Text.Trim();


                    string phone = txtPhone.Text.Trim();
                    lblError.Visible = false;
                    int status = int.Parse(dlStatus.SelectedValue);
                    int role = int.Parse(dlRole.SelectedValue);
                    string pw = txtPassword.Text.Trim();
                    
                    
                    if (status >= 0 && role > 0) {
                        DataLayer DL = new DataLayer();
                        User toInsert = new User(firstName, lastName, pw, email, phone, role, status);
                        int userID = toInsert.insertCustomer();
                        if (userID <= 0) {
                            errorMessage();
                        }
                        else {
                            //if OK display ID
                            lbl_ID.Text = userID.ToString();
                            lbl_ID.Visible = true;

                            lblUserID.Visible = true;
                            loadAllUsers();
                        }
                    }
                    else {
                        errorMessage("Select Role and Status");
                    }
                    // ask,exists
                }
                else { errorMessage("Press 'Insert' button to start"); }
            }
            else { errorMessage("user with this email already exists"); }
        }
        protected bool userExists(string firstName, string lastName){
            bool exists = false;
            string role = dlRole.SelectedItem.Text;
            string listFirstName;
            string listLastName;
            string listRole;
            for (int i = 0; i <gvList.Rows.Count; i++) {
                listFirstName=gvList.Rows[i].Cells[2].Text;
                listLastName=gvList.Rows[i].Cells[3].Text;
                listRole=gvList.Rows[i].Cells[1].ToString();
                if (firstName == listFirstName && lastName == listLastName && role == listRole) {
                    exists = true;
                }
            }
                return exists;
        }
        protected void loadAllUsers() {
            clearErrorMessage();
            clearList();
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getUsers();
            if (dataSet != null) {
                //Bind DropDownList to GrudView
                gvList.DataSource = dataSet;
                gvList.DataBind();
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
        //loadRoleTable();
        protected void loadRolesTable() {
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.loadAllRoles();
            if (dataSet != null) {

                //Bind DropDownList to DataSet


                dlRole.DataTextField = "Description";
                dlRole.DataValueField = "RoleID";
                dlRole.DataSource = dataSet;
                dlRole.DataBind();
                dlRole.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }
        private void clearList() {
            gvList.DataSource = null;
            gvList.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e) {
            clearErrorMessage();
            
            int supplierID;
            if (int.TryParse(lbl_ID.Text, out supplierID)) {
                lblError.Visible = false;


                string lastName = txtLastName.Text.Trim();
                string firstName = txtFirstName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                int status = int.Parse(dlStatus.SelectedValue);
                int userID = int.Parse(lbl_ID.Text);
                int role = int.Parse(dlRole.SelectedValue);
                
                if (status >= 0 && role > 0) {
                    DataLayer DL = new DataLayer();
                    int affected=-1;
                    //were PW changed?
                    string pw = txtPassword.Text.Trim();
                    if (pw == string.Empty) {
                        
                            affected = DL.updateUser(userID, firstName, lastName, phone, role, status);
                        
                    }
                    else {// change PW
                        string pwConfirme = txtConPassword.Text.Trim();
                        if (pw == pwConfirme) {
                            User toUpdate = new User();
                            affected = toUpdate.updateUserPW(userID, firstName, lastName, phone, role, status, pw);
                        }
                        else { errorMessage("Confirme Password"); }
                    }
                        if (affected <= 0) {
                            errorMessage();
                        }
                        else { loadAllUsers(); }
                    }

                else {
                    errorMessage("Select Status and Role");
                }
            }
            else { errorMessage("Select User from the list"); }
            }
            
       

        protected void gvList_SelectedIndexChanged(object sender, EventArgs e) {

            clearErrorMessage();
            // disable rf controls. Check by C#
            rfPassword.Enabled = false;
            rfConPassword.Enabled = false;

            int row = gvList.SelectedIndex;
            displayUserData(row);
            
            lbl_ID.Visible = true;
            lblUserID.Visible = true;
            pnlDetails.Visible = true;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

            pnlPW.Visible = false;
            lnkbtnPW.Visible = true;

            txtEmail.ReadOnly = true;
        }
        protected void displayUserData(int row){
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.getUsers();
            if (dataSet != null) {
                lbl_ID.Text = dataSet.Tables[0].Rows[row]["UserID"].ToString();
                txtFirstName.Text = dataSet.Tables[0].Rows[row]["FirstName"].ToString();
                txtLastName.Text = dataSet.Tables[0].Rows[row]["LastName"].ToString();
                txtEmail.Text = dataSet.Tables[0].Rows[row]["EmailAddress"].ToString();
                txtPhone.Text = dataSet.Tables[0].Rows[row]["Phone"].ToString();
                string role = dataSet.Tables[0].Rows[row]["Description"].ToString();
                string status = dataSet.Tables[0].Rows[row]["Status"].ToString();
                dlRole.SelectedIndex = dlRole.Items.IndexOf(dlRole.Items.FindByText(role));
                dlStatus.SelectedIndex = dlStatus.Items.IndexOf(dlStatus.Items.FindByText(status));
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e) {
            clearErrorMessage();
            pnlDetails.Visible = false;
            int id =0;
            if (int.TryParse(lbl_ID.Text, out id)) {
                
                DataLayer DL = new DataLayer();
                int deleted = DL.deleteUser(id);
                if (deleted > 0) {
                    clearUserData();
                    loadUsers();
                }
                else {
                    errorMessage();
                }
            }
            else {
                errorMessage("Select User From The List");
            }
        }
        protected void clearUserData() {
            lbl_ID.Text = string.Empty;
            lbl_ID.Visible = false;
            lblUserID.Visible = false;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;

            dlRole.ClearSelection();
            dlStatus.ClearSelection();
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            clearErrorMessage();
            clearUserData();
            pnlDetails.Visible = false;
        }

        protected void lnkbtnPW_Click(object sender, EventArgs e) {
            pnlPW.Visible = true;
            lnkbtnPW.Visible = false;
        }
        
        /// <summary>
        /// the method checks email availability via DB
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool emailIsUnique(string email) {
            bool unique = false;
            DataLayer DL = new DataLayer();

            int emailCount = DL.EmailExists(email);
            if (emailCount == 0) {
                unique = true; ;
            }
            else if (emailCount < 0) {
                // comunication error: Please try later
                errorMessage("Error. Please try again");

            }
            return unique;
        }
    }
}