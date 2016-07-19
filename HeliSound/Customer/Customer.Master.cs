using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Customer {
    public partial class Customer : System.Web.UI.MasterPage {
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
                    string role = txtRole.Text;
                    setBackLink(role);
                }
                else {
                    Response.Redirect("~/welcome.aspx");
                }
            }
        }
        private void setBackLink(string role) {
            

            switch (role) {
               
                case "2":
                    lnkbtnBack.Text = "To Administration Section";
                    lnkbtnBack.Visible = true;
                    break;
                case "3":
                    lnkbtnBack.Text = "To Shippment Section";
                    lnkbtnBack.Visible = true;
                    break;
                default:
                    lnkbtnBack.Visible = false;
                    break;

            }
            
        }

        private string getUserInfoBySessionID(string sessionID){
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

        public string getFullName() {
            return lblFullName.Text;
        }
      
        protected void mnuMain_MenuItemClick(object sender, MenuEventArgs e) {
            // indicate  menu item selected by user
            string menuOption = mnuMain.SelectedValue.ToString();
            //get the username to pass to lincked page
            string sess = Request.QueryString["SessionID"].ToString();

            switch (menuOption) {
                case "Home":
                    goHome(sess); break;
                case "Profile":
                    goProfile(sess); break;
                case "Order":
                    goOrder(sess); break;
                case "Track Order":
                    goTrackOrder(sess); break;
                case "Log Out":
                    goLogout(sess);
                    break;
                case "Change Password":
                    goChangePassword(sess);
                    break;
                case "History":
                    goHistory(sess);
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
        private void goHistory(string sess) {
            string path = "~/Customer/OrderHistory.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goLogIn(string sess) {
            DataLayer DL=new DataLayer();
            int close=DL.closeSess(sess);
            string path = "~/welcome.aspx";//?SessionID=" + sess;
            Response.Redirect(path);
        }
        public void goChangePassword(string sess) {
            string path = "~/Customer/ChangePassword.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        public void goProfile(string sess) {
            string path = "~/Account/Register.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        public void goOrder(string sess){
            string path = "~/Customer/OrderProducts.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        public void goHome(string sess) {
            
            string path = "~/Customer/Default.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        private void goTrackOrder(string sess) {
            string path = "~/Customer/TrackOrders.aspx?SessionID=" + sess;
            Response.Redirect(path);
        }
        /// <summary>
        /// the method will make menu and logIn button invisible for unregestered user
        /// </summary>
        public void secureProfile(bool visible) {
            mnuMain.Visible = visible;
            lblFullName.Visible = visible;

        }

        protected void lnkbtnBack_Click(object sender, EventArgs e) {
            string role = txtRole.Text;
            string sess = string.Empty;
            sess = Request.QueryString["SessionID"];
            
            string path = "~/";
            string pathEnd = "/Default.aspx?SessionID=" + sess;
            
            switch (role) {
               
                    
                case "2":
                    path = path + "Administration" + pathEnd;
                    break;
                case"3":
                    path = path + "Shipping" + pathEnd;
                    break;
                default:
                    goLogIn(sess);
                    break;
                    
            }
            Response.Redirect(path);
        }
    }
   
}
