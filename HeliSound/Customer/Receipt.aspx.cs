using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeliSound.Customer {
    public partial class Receipt : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string total = Request.QueryString["Total"];
            lblTotal.Text = total;//ToString(IFormatProvider)
            string name = Request.QueryString["Name"];
            //txtFullName.Text = name;
            lblFullName.Text = name;
            lblDate.Text = DateTime.Today.ToShortDateString();
            string item = Request.QueryString["Item"];
            lblItem.Text = item;
        }

        protected void btnBack_Click(object sender, EventArgs e) {
            string sessionID = string.Empty;
            sessionID = Request.QueryString["SessionID"];
            Master.goOrder(sessionID);
        }
    }
}