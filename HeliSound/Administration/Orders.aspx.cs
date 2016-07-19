using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeliSound.Administration {
    public partial class Orders : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Master.verifyIfUserBelongs();
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
        protected void clearDetails() {
            dlProducts.ClearSelection();
            txtTotal.Text = string.Empty;
            txtAddressID.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            //txtProductID.Text = string.Empty;
            txtStreetAdd.Text = string.Empty;
            txtSuite.Text = string.Empty;
            dlProvince.ClearSelection();
        }
        

        protected void btnDisplay_Click(object sender, EventArgs e) {
            pnlOrderInfo.Visible = false;
            clearDetails();
            clearErrorMessage();
            gvList.DataSource = null;
            gvList.DataBind();
            string id = txtInvoiceNumber.Text.Trim();
            int orderID;
            if (int.TryParse(id, out orderID)) {
                displayOrder(orderID);
            }
            else { errorMessage("Invalid Order Number"); }
        }
        private void displayOrder(int orderID) {
            DataLayer DL = new DataLayer();
            DataSet ds = DL.getOrderByOrderID(orderID);
            if (ds != null) {
                if (ds.Tables[0].Rows.Count > 0) {
                    gvList.DataSource = ds;
                    gvList.DataBind();
                    txtProductID.Text = ds.Tables[0].Rows[0]["ProductID"].ToString();
                    txtAddressID.Text = ds.Tables[0].Rows[0]["AddressID"].ToString();
                }
                else { errorMessage("Order Not found"); }
            }
            else { errorMessage(); }
        }

        protected void gvList_SelectedIndexChanged(object sender, EventArgs e) {
            loadProvinces();
            loadProducts();
            int orderID=int.Parse(gvList.Rows[0].Cells[1].Text);
            displeyAdress(orderID);
            string status = gvList.Rows[0].Cells[6].Text;
            if (status == "Shipped") { btnSubmit.Visible = false; }
        }
        protected void loadProvinces() {
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();
            int country = 1;//Canada
            dataSet = DL.getProvinces(country);
            if (dataSet != null) {

                //Bind DropDownList to DataSet


                dlProvince.DataTextField = "Province";
                dlProvince.DataValueField = "ProvinceID";
                dlProvince.DataSource = dataSet;
                dlProvince.DataBind();
                dlProvince.Items.Insert(0, new ListItem("Select", "-1"));
            }
            else { errorMessage(); }
        }
        protected void displeyAdress(int orderID) {
            DataLayer DL = new DataLayer();
            DataSet ds = new DataSet();
            ds = DL.getAddressByOrderID(orderID);
            if (ds != null && ds.Tables[0].Rows.Count > 0) {
                txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                txtStreetAdd.Text = ds.Tables[0].Rows[0]["StreetAddress"].ToString();
                txtPostalCode.Text = ds.Tables[0].Rows[0]["PostalCode"].ToString();
                txtSuite.Text = ds.Tables[0].Rows[0]["Suite"].ToString();
                dlProvince.SelectedValue = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                //dlProvince.SelectedValue = ds.Tables[0].Rows[0]["countryID"].ToString();// load countries if outside Canada
                pnlOrderInfo.Visible = true;
                
            }
            else { errorMessage(); }
            txtTotal.Text = gvList.Rows[0].Cells[4].Text.Substring(1);
            //txtItem.Text = gvList.Rows[0].Cells[3].Text;
            dlProducts.SelectedValue = txtProductID.Text;
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            clearErrorMessage();
            string strAddress = txtStreetAdd.Text;
            string suite = txtSuite.Text;
            string city = txtCity.Text;
            string postalCode = txtPostalCode.Text;
            int province = int.Parse(dlProvince.SelectedValue);
            int country = int.Parse(dlCountry.SelectedValue);
            int addressID = int.Parse(txtAddressID.Text);
            string totalSTR = txtTotal.Text.Trim();
            double total;
            if (double.TryParse(totalSTR, out total)) {
                int productID=int.Parse(txtProductID.Text);
                if (productID > 0) {
                    int orderID = int.Parse(gvList.Rows[0].Cells[1].Text);
                    DataLayer DL = new DataLayer();
                    int updated = DL.updateOrder(addressID, strAddress, suite, city, postalCode, province, country,orderID, productID, total);
                    //loadProducts();
                    displayOrder(orderID);
                }
                else { errorMessage(" Select product"); }
            }
            else { errorMessage(" 'Total' format doesn't fit"); }
        }
        protected void loadProducts() {
            DataLayer DL = new DataLayer();
            DataSet dataSet = new DataSet();

            dataSet = DL.loadProducts();
            if (dataSet != null) {

                //Bind DropDownList to DataSet


                dlProducts.DataTextField = "ProductName";
                dlProducts.DataValueField = "ProductID";
                dlProducts.DataSource = dataSet;
                dlProducts.DataBind();
                dlProducts.Items.Insert(0, new ListItem("Select", "-1"));
            }
            else { errorMessage(); }
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            clearDetails();
            pnlOrderInfo.Visible = false;
        }
    }
}