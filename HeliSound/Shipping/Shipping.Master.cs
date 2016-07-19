using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Shipping {
    public partial class Shipping : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                setUserNameLabel();
            }
        }

        public void verifyIfUserBelongs() {
            string sessionID = string.Empty;
            sessionID = Request.QueryString["SessionID"];
            DataLayer DL = new DataLayer();
            int role = DL.getRoleBySess(sessionID);
            if (!((role==2)||(role==3))){
                goLogIn();
            }
        }
        private void goLogIn() {
            string path = "~/welcome.aspx";
            Response.Redirect(path);
        }
        
        public void setUserNameLabel() {
            string sessionID = string.Empty;
            sessionID = Request.QueryString["SessionID"];
            if (sessionID != "new") {
                string userName = getUserInfoBySessionID(sessionID);
                if (userName != "UNKNOWN") {
                    lblFullName.Text = userName;
                    string role = txtRole.Text;
                    setBackLink(role);
                }
                else {
                    Response.Redirect("~/welcome.aspx");
                }
            }


        }

        private void setBackLink(string role) {


            if (role == "2") {
                lnkbtnBack.Text = "To Administration Section";
                lnkbtnBack.Visible = true;
            }

            else {
                lnkbtnBack.Visible = false;
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
                txtRole.Text = ds.Tables[0].Rows[0]["Role"].ToString();
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
                case "Shipping":
                    goShipping(sess); break;
                case "Profile":
                    goProfile(sess); break;
                case "Customer Functions":
                    goCustomerFunctions(sess); break;
                case "Log Out":
                    goLogout(sess);
                    break;
                

            }
        }
       
        private void goLogout(string sess) {
            DataLayer DL = new DataLayer();
            int seccsess = 0;
            seccsess = DL.closeSess(sess);
            if (seccsess > 0) {
                string path = "~/LogOff.aspx";
                Response.Redirect(path);
            }
        }
        private void goHome(string sess) {
            string path = "~/Shipping/Default.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goLogIn(string sess) {
            string path = "~/welcome.aspx";//?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goShipping(string sess) {
            string path = "~/Shipping/Shipping.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goProfile(string sess) {
            string path = "~/Account/Register.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goCustomerFunctions(string sess) {
            string path = "~/Customer/Default.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        
        private void goTrackOrder(string sess) {
            string path = "~/Customer/TrackOrders.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }

        protected void lnkbtnBack_Click(object sender, EventArgs e) {
            
            
            string sess = string.Empty;
            sess = Request.QueryString["SessionID"];

            string path = "~/Administration/Default.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
     }
}