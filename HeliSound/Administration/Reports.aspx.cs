using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Administration {
    public partial class Reports : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Master.verifyIfUserBelongs();

                loadList();
            }
        }
        protected void loadList() {
            DataLayer DL = new DataLayer();
            DataSet ds = new DataSet();
            ds = DL.loadTodaysOrders();
            if (ds != null) {
                if (ds.Tables[0].Rows.Count > 0) {
                    gvList.DataSource = ds;
                    gvList.DataBind();
                    displayTotal(ds);
                }
                else { errorMessage("No Orders for Today"); }
            }
            else { errorMessage("Communication Error"); }
        }
        protected void displayTotal(DataSet ds) {
            int nOfRows = ds.Tables[0].Rows.Count;
            double total = 0;
            for (int i = 0; i < nOfRows; i++) {
                total += double.Parse(ds.Tables[0].Rows[i]["Total"].ToString());
            }
            txtTotal.Text = String.Format("{0:0.00}", total);
            txtNumOfOrders.Text = nOfRows.ToString();
        }
        private void errorMessage() {
            lblError.Visible = true;
        }
        private void errorMessage(string message) {
            lblError.Text = message;
            lblError.Visible = true;
        }
        
    }
}