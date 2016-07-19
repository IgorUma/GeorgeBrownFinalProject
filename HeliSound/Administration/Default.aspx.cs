using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeliSound.Administration {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Master.verifyIfUserBelongs();
            }
        }

        protected void btnShipment_Click(object sender, EventArgs e) {
            string sessionID = string.Empty;
            sessionID = Request.QueryString["SessionID"];
            string path = "~/Shipping/Default.aspx?SessionID=" + sessionID;
            Response.Redirect(path);
        }

        protected void btnCustomer_Click(object sender, EventArgs e) {
            string sessionID = string.Empty;
            sessionID = Request.QueryString["SessionID"];
            string path = "~/Customer/Default.aspx?SessionID=" + sessionID;
            Response.Redirect(path);
        }

        protected void btnProfile_Click(object sender, EventArgs e) {
            string sessionID = string.Empty;
            sessionID = Request.QueryString["SessionID"];
            string path = "~/Account/Register.aspx?SessionID=" + sessionID;
            Response.Redirect(path);
        }
           
    }
}