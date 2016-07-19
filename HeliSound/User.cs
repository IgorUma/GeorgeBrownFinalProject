using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HeliSound {
    public class User {

        //class properties + interface
        public int UserID { get; private set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Role { get; set; }
        // secret q and a
        public int QuestinID1 { get; set; }
        public int QuestinID2 { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public int Status { get; set; }

        // default constructor
        public User() {}

        // overloaded constructor
        public User(string firstName, string lastName, string passWord, string email, string phone, int role,int q1, string a1,int q2,string a2) {
            FirstName = firstName;
            Lastname = lastName;
            Password = passWord;
            Email = email;
            Phone = phone;
            Role = role;
            QuestinID1 = q1;
            QuestinID2 = q2;
            Answer1 = a1;
            Answer2 = a2;
            Status=1;
        }
        // for admin user insert
        public User(string firstName, string lastName, string passWord, string email, string phone, int role, int status) {
            FirstName = firstName;
            Lastname = lastName;
            Password = passWord;
            Email = email;
            Phone = phone;
            Role = role;
            Status = status;

            QuestinID1 = -1;
            QuestinID2 = -1;
            Answer1 = string.Empty;
            Answer2 = string.Empty;
        }
        public int insertCustomer() {
            int userID = 0;
            string encryptedPswd = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");
            Answer1 = FormsAuthentication.HashPasswordForStoringInConfigFile(Answer1, "SHA1");
            Answer2 = FormsAuthentication.HashPasswordForStoringInConfigFile(Answer2, "SHA1");
            DataLayer DL = new DataLayer();
            userID = DL.createCustomer(FirstName, Lastname, encryptedPswd, Email, Phone, Role,Status, QuestinID1, Answer1, QuestinID2, Answer2);
            if (userID > 0) { UserID = userID; } //set UserID object property
            return userID;
        }
        
   
        public int updateUserPW(int userID, string firstName, string lastName, string phone, int role, int status, string Password) {
            int affected = 0;
            string encryptedPswd = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");
            DataLayer DL = new DataLayer();
            affected=DL.updateUserPW(userID, firstName, lastName, phone, role, status, encryptedPswd);


            return affected;
        }
    }
}