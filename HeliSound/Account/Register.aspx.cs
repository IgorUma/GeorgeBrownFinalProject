using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace HeliSound.Account {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                lblError.Visible = false;
                
                loadSecretQuesrions();
                setPage();
            }
            
        }
        protected void setPage() {
            string sess = string.Empty;
            sess = Request.QueryString["SessionID"];
            //string userName = getUserInfoBySessionID(sessionID);
            if (sess=="new") {
                Master.secureProfile(false);
                SetFocus(txtFirstName);
            }
            else {
                Master.secureProfile(true);
                btnRegister.Text = "Update";
                btnClear.Text = "Cancel";
                displayUserInfo(sess);
               
                pnlSecretQ.Visible = false;
                SeqretQrequiredField(false);
                pnlPassword.Visible = false;
                passworddField(false);
                btnChangePassword.Visible = true;
            }
        }
        /// <summary>
        /// switch the required fild validation for Secret Question section
        /// </summary>
        /// <param name="?"></param>
        protected void SeqretQrequiredField(bool turn) {
            rfA1.Enabled = turn;
            rfA2.Enabled = turn;

        }
        /// <summary>
        /// switch the required fild validation for password section
        /// </summary>
        /// <param name="?"></param>
        protected void passworddField(bool turn) {
            rfPassword.Enabled = turn;
            rfConfipmPW.Enabled = turn;
           

        }
        protected void displayUserInfo(string sess) {
            
            DataLayer DL = new DataLayer();
            DataSet ds = new DataSet();
            ds = DL.getUsersProfileBySession(sess);
            txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
            txtEmail.ReadOnly = true;
            txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();

        }
      protected void loadSecretQuesrions(){
          DataLayer DL = new DataLayer();
          DataSet ds = new DataSet();
          ds = DL.loadSecretQuesrions();
          if (ds != null) {
              setQuest(dlSecretQ1, ds);
              setQuest(dlSecretQ2, ds);     
          }

      }
        protected void setQuest(DropDownList dl,DataSet ds){
          dl.DataTextField = "Question";
          dl.DataValueField = "QuestionID";
          dl.DataSource = ds;
          dl.DataBind();
          dl.Items.Insert(0, new ListItem("Select", "-1"));

        }
        protected void btnRegister_Click(object sender, EventArgs e) {
            string sess = string.Empty;
            sess = Request.QueryString["SessionID"];
            if (sess == "new") {
                lblError.Visible = false;
                if (createUser() > 0) {
                    // redirect to welcome
                    string path = "~/welcome.aspx";
                    Response.Redirect(path);
                }
                // else ERROR
            }
            else {
                updateProfile();
               
            }
        }

        protected void updateProfile() {
            string firstN = txtFirstName.Text;
            string lastN = txtLastName.Text;
            string phone = txtPhone.Text;
            DataLayer DL = new DataLayer();
            int userID=Master.getUserID();
            int updated = DL.updateProfile(userID, firstN, lastN, phone);
            if (updated>0) {
                errorMessage("Profile updated");
            }
            else {
                errorMessage("Error");
            }
            
        }
        private int createUser() {
            int userID = 0;
            //get users data
            string fName = txtFirstName.Text.Trim();
            string lName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string pswrd = txtPassword.Text.Trim();
            string pswrdConf = txtConfirmPassword.Text.Trim();

            //sec qust
            int secretQ1 = int.Parse(dlSecretQ1.SelectedValue);
            int secretQ2 = int.Parse(dlSecretQ2.SelectedValue);
            string secretA1 = txtSecretQ1.Text.Trim();
            string secretA2 = txtSecretQ2.Text.Trim(); ;
            if (secretQ1 > -1 && secretQ2 > -1 && secretA1.Length > 0 && secretA2.Length > 0) {
                if (String.Equals(pswrd, pswrdConf)) {
                    if (emailIsUnique(email)) {
                        int role = 1;//customer
                        
                        User newCustomer = new User(fName, lName, pswrd, email, phone, role,secretQ1,secretA1,secretQ2,secretA2);
                        userID = newCustomer.insertCustomer();

                    }
                    else {
                        // email is taken.
                        errorMessage("Please enter other email addresss");
                    }
                }
                else {
                    // password and conf. the pass. are not equal
                    errorMessage("Please confirm the password");
                }
            }
            else {
                // password and conf. the pass. are not equal
                errorMessage("Please answer two secret questions.");
            }
            
        
            return userID;
        }
        private bool emailIsUnique(string email){
            bool unique=false;
            DataLayer DL = new DataLayer();
            
            int emailCount= DL.EmailExists(email);
            if (emailCount == 0) {
                unique = true; ;
            }
            else if(emailCount < 0){
                // comunication error: Please try later
                errorMessage("Error. Please try again");
                
            }
            return unique;
        }
        private void errorMessage(string message) {
            lblError.Text = message;
            lblError.Visible = true;
        }

        protected void btnClear_Click(object sender, EventArgs e) {
            string sess = string.Empty;
            sess = Request.QueryString["SessionID"];
            if (sess == "new") {
                txtConfirmPassword.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtPhone.Text = string.Empty;
                lblError.Visible = false;
            }
            else {
                Master.goHome(sess);
            }
        }

        protected void lbChangePassword_Click(object sender, EventArgs e) {
            pnlPassword.Visible = !pnlPassword.Visible;
        }

        protected void lnkbtnSecQuest_Click(object sender, EventArgs e) {
            pnlSecretQ.Visible = !pnlPassword.Visible;
        }

        protected void btnChangePassword_Click(object sender, EventArgs e) {
            string sess = string.Empty;
            sess = Request.QueryString["SessionID"];
            Master.goChangePassword(sess);
        }

    }
}