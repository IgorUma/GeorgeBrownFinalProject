using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace HeliSound.Customer {
    public partial class ChangePassword : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                setPage();
                loadSecretQuesrions();
            }
        }
        protected void setPage() {
            string sess = string.Empty;
            sess = Request.QueryString["SessionID"];
            //string userName = getUserInfoBySessionID(sessionID);
            if (sess == "new") {
                Master.secureProfile(false);
                }
        }
        protected void loadSecretQuesrions(){
          DataLayer DL = new DataLayer();
          DataSet ds = new DataSet();
          ds = DL.loadSecretQuesrions();
          if (ds != null) {
              dlQuest.DataTextField = "Question";
              dlQuest.DataValueField = "QuestionID";
              dlQuest.DataSource = ds;
              dlQuest.DataBind();
              dlQuest.Items.Insert(0, new ListItem("Select", "-1"));
          }
        }
        protected void btnChange_Click(object sender, EventArgs e) {
            clearErrorMessage();
            if (Page.IsValid) {
                
                bool verified = verifyInput();
                if (verified) {
                    
                    updatePW();
                }
                else {
                    errorMessage("Authentication failed");
                }
                string path = "~/welcome.aspx";
                Response.Redirect(path);
                
            }//is valid
        }
        
        
        private bool verifyInput() {
            bool verified = false;
            int secretQ = int.Parse(dlQuest.SelectedValue);
            if (secretQ > -1) {
                string email = txtEmail.Text.Trim();
                DataLayer DL = new DataLayer();
                string ans = txtAns.Text.Trim();
                ans = FormsAuthentication.HashPasswordForStoringInConfigFile(ans, "SHA1");
                DataSet ds = DL.loadToVerifyInput(email);
                if (ds != null && ds.Tables[0].Rows.Count > 1) {

                    //string emailDB = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    int quest1 = int.Parse(ds.Tables[0].Rows[0]["QuestionID"].ToString());
                    string ans1 = ds.Tables[0].Rows[0]["Answer"].ToString();
                    int quest2 = int.Parse(ds.Tables[0].Rows[1]["QuestionID"].ToString());
                    string ans2 = ds.Tables[0].Rows[1]["Answer"].ToString();
                    bool set1Fit = (secretQ == quest1) && Equals(ans, ans1);
                    bool set2Fit = (secretQ == quest2) && Equals(ans, ans2);
                    if (set1Fit || set2Fit) {
                        verified = true;
                    }
                }
            }
            else { errorMessage("Select Secret Question"); }
                return verified;
        }
       
        protected void updatePW() {
            DataLayer DL = new DataLayer();
            DataSet ds = new DataSet();
            string email=txtEmail.Text.Trim();
            string sess = Page.Session.SessionID.ToString();
            ds=DL.insertUserSessionAndGetRole(email,sess);
            if(ds!=null){
                string sessIDstr = ds.Tables[1].Rows[0]["SessID"].ToString();
                int sessID;
                if (int.TryParse(sessIDstr, out sessID)) {
                    string passWord = txtNewPassword.Text.Trim();
                    string confirmPW = txtConfirm.Text.Trim();
                    string encryptedPswd = FormsAuthentication.HashPasswordForStoringInConfigFile(passWord, "SHA1");
                    int dbPW = DL.updatePW(sessID, encryptedPswd);
                }
                
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
    }
}