using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Administration {
    public partial class Roles : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack){
                Master.verifyIfUserBelongs();

                loadAllRoles();
                }
        }

        protected void btnCreate_Click(object sender, EventArgs e) {
            txtRoleName.Text = string.Empty;
            lbl_ID.Text = string.Empty;
            clearErrorMessage();
            lbl_ID.Visible = false;
            lblRoleID.Visible = false;
            gvList.Visible = true;
            loadStatusTable();
            SetFocus(txtRoleName);
            pnlCategoryDetails.Visible = true;
        
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
            // check existanse of company with same name

            string roleName = txtRoleName.Text.Trim();
            if (!alreadyExists(roleName)) {
                lblError.Visible = false;
                int status = int.Parse(dlStatus.SelectedValue);
                if (status >= 0) {

                    int categoryID = insertRole(roleName, status);
                    if (categoryID <= 0) {
                        errorMessage();
                    }
                    else {
                        //if OK display ID
                        lbl_ID.Text = categoryID.ToString();
                        lbl_ID.Visible = true;
                        //txtRoleName
                        lblRoleID.Visible = true;
                        loadAllRoles();
                    }
                }
                else {
                    errorMessage("Select Status");
                }
            }
            else {
                errorMessage("Role with this name already exists");
            }
        }
        private int insertRole(string roleName, int status) {
            //clearDetails();
            int id = 0;
            DataLayer DL = new DataLayer();
            id = DL.insertRole(roleName, status);
            return id;
        }
        private bool alreadyExists(string roleName) {
            bool exists = false;
            int rows = gvList.Rows.Count;
            for (int i = 0; i < rows; i++) {
                string dbName = gvList.Rows[i].Cells[0].Text;
                if (String.Equals(dbName.ToLower(), roleName.ToLower())) {
                    exists = true;
                }
            }

            return exists;
        }
        protected void clearDetails() {
            txtRoleName.Text = string.Empty;
            lbl_ID.Text = string.Empty;
            lbl_ID.Visible = false;
            lblRoleID.Visible = false;
            dlStatus.SelectedValue = "-1";

        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            clearDetails();
            clearErrorMessage();
            pnlCategoryDetails.Visible = false;
        }
        protected void loadAllRoles() {
            clearErrorMessage();
            clearRoles();
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            dataSet = DL.loadAllRoles();
            if (dataSet != null) {
                //Bind DropDownList to GrudView
                gvList.DataSource = dataSet;
                gvList.DataBind();
            }
        }
        private void clearRoles() {

            gvList.DataSource = null;
            gvList.DataBind();
        }

        protected void gvList_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}