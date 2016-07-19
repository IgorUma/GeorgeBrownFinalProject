using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeliSound.Customer {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            string sess = Request.QueryString["SessionID"].ToString();
            Master.goOrder(sess);
        }

        protected void btnProfile_Click(object sender, EventArgs e) {
            string sess = Request.QueryString["SessionID"].ToString();
            Master.goProfile(sess);
        }
    }
}