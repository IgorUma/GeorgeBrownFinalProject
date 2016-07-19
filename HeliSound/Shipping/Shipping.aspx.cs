using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Shipping {
    public partial class Shipping1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Master.verifyIfUserBelongs();
                loadOrders(0);
            }
        }


        protected void gvList_SelectedIndexChanged(object sender, EventArgs e) {
            string selected = gvList.SelectedRow.Cells[1].Text;
            int orderID = int.Parse(selected);

            DataLayer DL = new DataLayer();
            int changed = DL.changeToShipped(orderID);
            loadOrders(0);
            if (gvShipped.Rows.Count>0) { //if unshipt orders were loaded, reload
                unBind(1);
                loadOrders(1);
            }
        }

        protected void btnShipped_Click(object sender, EventArgs e) {
            unBind(1);
            loadOrders(1);
            gvShipped.Visible = true;
            btnHide.Visible = true;
            btnShipped.Visible = false;
        }
        /// <summary>
        /// the method loads orders with respect to shipment status :0 for unshipped and 1for shipped
        /// </summary>
        /// <param name="status"></param>
        protected void loadOrders(int status) {
            DataLayer DL = new DataLayer();
            DataSet ds = new DataSet();
            ds = DL.loadOrderes(status);//shipped
            if (ds != null) {
                int rows = ds.Tables[0].Rows.Count;
                unBind(status);
                switch (status) {
                    case 0://unshipped orders
                        if (rows > 0) {
                            gvList.DataSource = ds;
                            gvList.DataBind();
                        }
                        else { errorMessage("No Unshipped Orders"); }
                        break;

                    case 1:
                        if (rows > 0) {
                            gvShipped.DataSource = ds;
                            gvShipped.DataBind();
                        }
                        else { errorMessage("No Shipped Orders"); }
                        break;
                }
            }
            else {errorMessage();}
        }
            protected void unBind(int status){
            switch (status) {
                case 0:
                    gvList.DataSource = null;
                    gvList.DataBind();
                    break;
                 case 1://unshipped orders
                    gvShipped.DataSource = null;
                    gvShipped.DataBind();
                    break;
                    
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

            protected void btnHide_Click(object sender, EventArgs e) {
                gvShipped.Visible = false;
                btnHide.Visible = false;
                btnShipped.Visible = true;
            }
    }
}