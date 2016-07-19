using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;


namespace HeliSound {
    public partial class welcome : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            lblError.Visible = false;
            SetFocus(txtEmail);
        }

        protected void btnLogIn_Click(object sender, EventArgs e) {
            lblError.Visible = false;
            //getting users credentials
            string email = txtEmail.Text.Trim();
            string passWord = txtPassword.Text.Trim();
            if (verifyLogin(email, passWord)) {
                createSessionAndGetRole(email);
            }
            else {
                lblError.Visible = true;
            }
        }
        /// <summary>
        /// The method verifying that the user with username exists and active and that password is correct.
        /// if not, will return false
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        private bool verifyLogin(string email, string passWord) {
            bool verified = false;
            DataSet ds = new DataSet();
            ds = getDataByEmail(email);
            if (ds != null) {
                string dbPassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                string encryptedPswd = FormsAuthentication.HashPasswordForStoringInConfigFile(passWord, "SHA1");
                if (String.Equals(encryptedPswd, dbPassWord))
                    verified = true;
                lblError.Text = "Login Error";
            }
            else { lblError.Text = "Communication Error"; }
            return  verified;
        }

        
        /// <summary>
        /// The method returns dataset including:User ID,First Name, Last Name, password and role
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private DataSet getDataByEmail(string email) {
            DataLayer DL = new DataLayer();
            DataSet ds = new DataSet();
            ds = DL.getCustomerDataByEmail(email);
            return ds;
        }

        private void redirect(int role,string sess){
            string path = "~/";
            string pathEnd = "/Default.aspx?SessionID=" + sess;
            
            switch (role) {
                case 1:
                    path = path + "Customer" + pathEnd;
                    break;
                case 2:
                    path = path + "Administration" + pathEnd;
                    break;
                case 3:
                    path = path + "Shipping" + pathEnd;
                    break;
                default:
                    lblError.Text = "Error";
                    lblError.Visible = true;
                    break;
                    
            }
            Response.Redirect(path);
        }

        protected void createSessionAndGetRole(string email) { 
            string sess = Page.Session.SessionID.ToString();
            sess = FormsAuthentication.HashPasswordForStoringInConfigFile(sess, "SHA1");
            DataLayer DL = new DataLayer();
            DataSet ds = DL.insertUserSessionAndGetRole(email, sess);
            if(ds!= null && ds.Tables[1].Rows.Count>0){
                string roleSTR=ds.Tables[0].Rows[0]["Role"].ToString();
                int role;
                if(int.TryParse(roleSTR,out role)){
                    redirect(role,sess);
                }
            }
            lblError.Visible = true;
        }

        protected void btnRegister_Click(object sender, EventArgs e) {
            string path = "~/Account/Register.aspx?SessionID=new";
            Response.Redirect(path);
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e) {
            string path = "~/Customer/ChangePassword.aspx?SessionID=new";
            Response.Redirect(path);
        }
    }
        
}