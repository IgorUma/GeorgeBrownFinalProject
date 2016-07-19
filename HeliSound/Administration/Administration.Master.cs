using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Administration {
    public partial class Administration : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                setUserNameLabel();
            }
        }
        public void setUserNameLabel() {
            string sessionID = string.Empty;
            sessionID = Request.QueryString["SessionID"];
            if (sessionID != "new") {
                string userName = getUserInfoBySessionID(sessionID);
                if (userName != "UNKNOWN") {
                    lblFullName.Text = userName;
                }
                else {
                    Response.Redirect("~/welcome.aspx");
                }
            }
        }

        public void verifyIfUserBelongs() {
            string sessionID = string.Empty;
            sessionID = Request.QueryString["SessionID"];
            DataLayer DL = new DataLayer();
            int role = DL.getRoleBySess(sessionID);
            if (role != 2) {
                goLogIn();
            }
        }
        private string getUserInfoBySessionID(string sessionID) {
            string userName = string.Empty;
            DataLayer DL = new DataLayer();
            DataSet ds;
            ds = DL.getUserInfoBySession(sessionID);
            if (ds != null && ds.Tables[0].Rows.Count > 0) {
                userName = ds.Tables[0].Rows[0]["fullName"].ToString(); ;
                txtID.Text = ds.Tables[0].Rows[0]["UserID"].ToString();
                return userName;
            }
            else { return "UNKNOWN"; }

        }

        public int getUserID() {
            string userID = txtID.Text;
            return int.Parse(userID);

        }
        

        protected void mnuMain_MenuItemClick(object sender, MenuEventArgs e) {
            // indicate  menu item selected by user
            string menuOption = mnuMain.SelectedValue.ToString();
            //get the username to pass to lincked page
            string sess = Request.QueryString["SessionID"].ToString();

            switch (menuOption) {
                case "Home":
                  goHome(sess); break;
                case "Categories":
                  goCategories(sess); break;
                case "Products":
                    goProducts(sess); break;
                case "Suppliers":
                    goSuppliers(sess); break;
                case "Customers":
                    goCustomers(sess); break;
                case "Orders":
                    goOrders(sess); break;
                case "Roles":
                    goRoles(sess); break;
                case "Reports":
                    goReports(sess); break;
                case "Users":
                  goUsers(sess); break;
                case "Log Out":
                    goLogout(sess);
                    break;
                case "Change Password":
                    //goChangePassword(sess);
                    break;
                case "History":
                    //goHistory(sess);
                    break;

            }
        }
        private void goLogout(string sess) {
            DataLayer DL = new DataLayer();
            int seccsess=0;
            seccsess=DL.closeSess(sess);
            if (seccsess > 0) {
                string path = "~/LogOff.aspx";
                Response.Redirect(path);
            }
          }
        private void goUsers(string sess) {
            string path = "~/Administration/UserMaintenance.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goOrders(string sess) {
            string path = "~/Administration/Orders.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goReports(string sess) {
            string path = "~/Administration/Reports.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goSuppliers(string sess) {
            string path = "~/Administration/Suppliers.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goRoles(string sess) {
            string path = "~/Administration/Roles.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goProducts(string sess) {
            string path = "~/Administration/Products.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goCustomers(string sess) {
                string path = "~/Administration/Customers.aspx?SessionID=" + sess;
            Response.Redirect(path);
            }
        private void goHome(string sess) {
            string path = "~/Administration/Default.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goCategories(string sess) {
            string path = "~/Administration/Category.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goLogIn() {
            string path = "~/welcome.aspx";
            Response.Redirect(path);
        }
    }
}