using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Customer {
    public partial class TrackOrders : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                SetFocus(txtInvoiceN);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            clearMessage();
            clearDetails();
            string orderIDstr = txtInvoiceN.Text;
            int userID = Master.getUserID();
            int orderID;
            if (int.TryParse(orderIDstr, out orderID)) {
                DataLayer DL = new DataLayer();
                DataSet ds = new DataSet();
                ds = DL.getOrderDetails(orderID, userID);
                if (ds != null && ds.Tables[0].Rows.Count > 0) {
                    //check if shipped
                    string dateSh = ds.Tables[0].Rows[0]["DateShipped"].ToString();
                    if (dateSh.Length>0) {//ds.Tables[0].Rows[0]["DateShipped"] != null
                        
                        gvDetailsShipped.DataSource = ds;
                        gvDetailsShipped.DataBind();
                    }
                    else {
                        gvDetails.DataSource = ds;
                        gvDetails.DataBind();

                    }
                }
                else { errormMessage("Order was not Found"); }
            }
            else { errormMessage("Invalid Order Number"); }
        }
        protected void errormMessage(string message) {
            lblError.Text = message;
            lblError.Visible = true;
        }
        protected void clearMessage() {
            lblError.Text = string.Empty;
            lblError.Visible = false;
        }
        protected void clearDetails() {
            gvDetailsShipped.DataSource = null;
            gvDetailsShipped.DataBind();
            gvDetails.DataSource = null;
            gvDetails.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            clearDetails();
            clearMessage();
            txtInvoiceN.Text = string.Empty;
        }
    }
}
