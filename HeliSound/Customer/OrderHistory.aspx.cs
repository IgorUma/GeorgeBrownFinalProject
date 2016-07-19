using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Customer {
    public partial class OrderHistory : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            getHistory();
        }
        private void getHistory() {
            DataLayer DL = new DataLayer();
            DataSet ds = new DataSet();
            string sess= Request.QueryString["SessionID"];
            ds = DL.getOrderHistory(sess);
            gvList.DataSource = ds;
            gvList.DataBind();
            
        }



    }
}