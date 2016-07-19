using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace HeliSound {
    public class DataLayer {
        SqlDataAdapter da; // Data Adapter
        SqlCommand cmd; // command object
        DataSet ds; // dataset object
        SqlConnection conn; // connection object

        public DataLayer()
        {
            Initialize(); // call the method to actually make the connection.
        }

        public void Initialize()
        {
            string DBString = ConfigurationManager.ConnectionStrings["HeliSound"].ConnectionString;
            conn = new SqlConnection(DBString);
        }

        public DataSet getCustomerDataByEmail(string email) {

            da = new SqlDataAdapter("Get_Customer_Data_By_Email", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", email);
            
            ds = new DataSet();
            try {
                da.SelectCommand.Prepare();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {
                
                return null;
            }
            finally {
                conn.Close();
            }
        }
        /// <summary>
        /// the method creates sess and returns two(2) tables: users Role and Sess( newly created sessionID)
        /// </summary>
        /// <param name="email"></param>
        /// <param name="sess"></param>
        /// <returns></returns>
        public DataSet insertUserSessionAndGetRole(string email, string sess) {
            //sess = FormsAuthentication.HashPasswordForStoringInConfigFile(sess, "SHA1");
            da = new SqlDataAdapter("Insert_User_Session_And_Get_Role", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@email", email);
            da.SelectCommand.Parameters.AddWithValue("@Sess", sess);
            ds = new DataSet();
            try {
                da.SelectCommand.Prepare();
                da.Fill(ds);
                return ds;
                }
            catch (Exception ex) {
                return null;
            }
            finally {
                conn.Close();
            }
        }

        
        public int createCustomer(string firstName, string lastName, string passWord, string email, string phone, int role,int status, int q1, string a1, int q2, string a2) {
            int CustomerID = 0;

            cmd = new SqlCommand("User_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@passWord", passWord);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@q1", q1);
            cmd.Parameters.AddWithValue("@a1", a1);
            cmd.Parameters.AddWithValue("@a2", a2);
            cmd.Parameters.AddWithValue("@q2", q2);
            try {
                conn.Open();
                cmd.Prepare();
                CustomerID = (int)cmd.ExecuteScalar();
                return CustomerID;
            }
            catch (Exception ex) {
                return -1;
            }
        }
        /// <summary>
        /// The method checks existans of user with passed email addresss.
        /// if email exists in Users table returns 1;
        /// if not returns 0;
        /// in case of  communication error returns -1;
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int EmailExists(string email) {

            da = new SqlDataAdapter("Get_Customer_Data_By_Email", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", email);

            ds = new DataSet();
            try {
                da.SelectCommand.Prepare();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return 1;
                }
                else {
                    return 0;
                }
            }
            catch (Exception ex) {

                return -1;
            }
            finally {
                conn.Close();
            }
        }
        //==========General Usage ==============

        public string getFullName(string session) {
            string fullName = string.Empty;
            int CustomerID = getCustomerIDbySession(session);
            if (CustomerID > 0) {
                DataSet ds = getCustomerDataByCustomerID(CustomerID);
                if (ds != null && ds.Tables[0].Rows.Count > 0) {
                    string firstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    string lastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                fullName = firstName + " " + lastName;
                }
            }
            return fullName;
        }

        public int getCustomerIDbySession(string session) {
            int CustomerID = 0;

            cmd = new SqlCommand("Get_CustomerID_by_Session", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@session", session);
            
            try {
                conn.Open();
                cmd.Prepare();
                CustomerID = (int)cmd.ExecuteScalar();
                return CustomerID;
            }
            catch (Exception ex) {
                return -1;
            }
           
        }
        public DataSet getUserProfile(int userID) {
            da = new SqlDataAdapter("Get_User_Profile", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@userID", userID);
            ds = new DataSet();
            try {
                da.SelectCommand.Prepare();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else { return null; }

            }
            catch (Exception ex) {

                return null;
            }
            finally {
                conn.Close();
            }
        }
        public DataSet getUsersProfileBySession (string session) {
            da = new SqlDataAdapter("Get_Users_Profile_by_Session", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@session", session);
            ds = new DataSet();
            try {
                da.SelectCommand.Prepare();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else { return null; }
                
            }
            catch (Exception ex) {

                return null;
            }
            finally {
                conn.Close();
            }
        }
        public DataSet getUserInfoBySession(string session) {
            da = new SqlDataAdapter("Get_Users_Info_by_Session", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@session", session);
            ds = new DataSet();
            try {
                da.SelectCommand.Prepare();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else { return null; }
                
            }
            catch (Exception ex) {

                return null;
            }
            finally {
                conn.Close();
            }
        }

        public DataSet getCustomerDataByCustomerID(int CustomerID) {
            da = new SqlDataAdapter("Get_Customer_Data_by_CustomerID", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@CustomerID", CustomerID);

            ds = new DataSet();
            try {
                da.SelectCommand.Prepare();
                da.Fill(ds);
                
                    return ds;
               }
            catch (Exception ex) {

                return null;
            }
            finally {
                conn.Close();
            }
        }

        public int updateProfile(int userID, string firstN, string lastN, string phone) {
             int affected = 0;
           
            cmd = new SqlCommand("User_Profile_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@firstName", firstN);
            cmd.Parameters.AddWithValue("@lastName", lastN);
            cmd.Parameters.AddWithValue("@phone", phone);
            
            try {
                conn.Open();
                cmd.Prepare();
                affected = (int)cmd.ExecuteNonQuery();
                return affected;
            }
            catch (Exception ex) {
                return -1;
            }
           
        }

        
        //======== for orderProducts ============
        
        public DataSet getSuppliers() {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Suppliers", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try {
                da.Fill(ds); 
                    return ds;
                
            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
       // getCategories
        public DataSet getCategories() {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Categories", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try {
                da.Fill(ds); if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }

        public DataSet getProducts(int supplier,int category){
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Products_by_Supplier_and_category", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@SupplierID", supplier);
            da.SelectCommand.Parameters.AddWithValue("@CategoryID", category);
            try {
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
          }

        public DataSet productInfo(int productID) {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Product_info_by_ID", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@productID", productID);
            try {
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }

        }


        public DataSet getStatusTable() {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Status_Table", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@active", 1);

            try {
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }


        public DataSet getCountries() {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Countries", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Status", 1);
            
            try {
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
        public DataSet getProvinces(int country) {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Provinces_by_Country", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Status", 1);
            da.SelectCommand.Parameters.AddWithValue("@Country", country);
            try {
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
        public int insertSupplier(Supplier company) {
            int supplierID = 0;
            cmd = new SqlCommand("Supplier_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstName", company.ContactFirstName);
            cmd.Parameters.AddWithValue("@lastName", company.ContactLastName);
            cmd.Parameters.AddWithValue("@SupplierName",company.SupplierName);
            cmd.Parameters.AddWithValue("@Phone", company.Phone);
            cmd.Parameters.AddWithValue("@Status", company.Status);
            //address
            cmd.Parameters.AddWithValue("@StreetAddress", company.Address.StreetAddress);
            cmd.Parameters.AddWithValue("@Suite", company.Address.Suite);
            cmd.Parameters.AddWithValue("@City", company.Address.City);
            cmd.Parameters.AddWithValue("@Province", company.Address.Province);
            cmd.Parameters.AddWithValue("@Contry", company.Address.Contry);
            cmd.Parameters.AddWithValue("@PostalCode", company.Address.PostalCode);
            try {
                conn.Open();
                cmd.Prepare();
                supplierID = (int)cmd.ExecuteScalar();
                return supplierID;
            }
            catch (Exception ex) {
                return -1;
            }
        }
        public double getTaxRate() {
            double taxRate = -1;
            cmd = new SqlCommand("Get_Tax_Rate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            try {
                conn.Open();
                cmd.Prepare();
                string taxRateSTR = cmd.ExecuteScalar().ToString();
                //taxRate = (double)cmd.ExecuteScalar();
                taxRate = double.Parse(taxRateSTR);
                return taxRate;
            }
            catch (Exception ex) {
                return -1;
            }
        }

        public int updateSupplier(Supplier company) {
            int affected = 0;
           
            cmd = new SqlCommand("Supplier_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@supplierID", company.SupplierID);
            cmd.Parameters.AddWithValue("@firstName", company.ContactFirstName);
            cmd.Parameters.AddWithValue("@lastName", company.ContactLastName);
            cmd.Parameters.AddWithValue("@SupplierName", company.SupplierName);
            cmd.Parameters.AddWithValue("@Phone", company.Phone);
            cmd.Parameters.AddWithValue("@Status", company.Status);
            //address
            cmd.Parameters.AddWithValue("@StreetAddress", company.Address.StreetAddress);
            cmd.Parameters.AddWithValue("@Suite", company.Address.Suite);
            cmd.Parameters.AddWithValue("@City", company.Address.City);
            cmd.Parameters.AddWithValue("@Province", company.Address.Province);
            cmd.Parameters.AddWithValue("@Contry", company.Address.Contry);
            cmd.Parameters.AddWithValue("@PostalCode", company.Address.PostalCode);
            try {
                conn.Open();
                cmd.Prepare();
                affected = (int)cmd.ExecuteNonQuery();
                return affected;
            }
            catch (Exception ex) {
                return -1;
            }
           // return affected;
        }
        public bool deleteSuplier(int supplierID) {
            bool deleted=false;
            cmd = new SqlCommand("Supplier_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@supplierID", supplierID);
            
            try {
                conn.Open();
                cmd.Prepare();
                int affected = (int)cmd.ExecuteNonQuery();
                if (affected > 0) { deleted = true; }
            }
            catch (Exception ex) {
                
            }

            return deleted;
        }

        public DataSet loadSupplier(string supplierName) {
            ds = new DataSet();
            //da = new SqlDataAdapter("Load_Supplier_by_ID", conn);
            da = new SqlDataAdapter("Load_Supplier_by_Name", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@supplierName", supplierName);

            try {
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
        public DataSet loadCategory(string categoryName) {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Category_by_Name", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@categoryName", categoryName);

            try {
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
        public int insertCategory(string categoryName, int status) {
            int categoryID = 0;
            cmd = new SqlCommand("Category_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@categoryName", categoryName);
            cmd.Parameters.AddWithValue("@status", status);
            
            try {
                conn.Open();
                cmd.Prepare();
                categoryID = (int)cmd.ExecuteScalar();
                return categoryID;
            }
            catch (Exception ex) {
                return -1;
            }
        }

        public int updateCategory(int categoryID,string categoryName,int status ) {
            int affected = 0;

            cmd = new SqlCommand("Category_Update_by_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@categoryID", categoryID);
            cmd.Parameters.AddWithValue("@categoryName", categoryName);
            cmd.Parameters.AddWithValue("@status", status);
            try {
                conn.Open();
                cmd.Prepare();
                affected = (int)cmd.ExecuteNonQuery();
                return affected;
            }
            catch (Exception ex) {
                return -1;
            }   
        }
        
            public bool deleteCategory(int categoryID) {
            bool deleted=false;
            cmd = new SqlCommand("Category_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@categoryID", categoryID);
            
            try {
                conn.Open();
                cmd.Prepare();
                int affected = (int)cmd.ExecuteNonQuery();
                if (affected > 0) { deleted = true; }
            }
            catch (Exception ex) {
                
            }

            return deleted;
        }

            public DataSet loadAllRoles() {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Roles", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try {
                da.Fill(ds); if (ds.Tables[0].Rows.Count > 0) {
                    return ds;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
       
            public int insertRole(string roleName, int status) {
                int roleID = 0;
                cmd = new SqlCommand("Role_Insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleName", roleName);
                cmd.Parameters.AddWithValue("@status", status);

                try {
                    conn.Open();
                    cmd.Prepare();
                    roleID = (int)cmd.ExecuteScalar();
                    return roleID;
                }
                catch (Exception ex) {
                    return -1;
                }
            }
        
            public DataSet getUsers() {
                ds = new DataSet();
                da = new SqlDataAdapter("Load_All_Users", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try {
                    da.Fill(ds); if (ds.Tables[0].Rows.Count > 0) {
                        return ds;
                    }
                    else {
                        return null;
                    }
                }
                catch (Exception ex) {
                    return null;
                }
                finally {
                    // precaution
                    conn.Close();
                }
            }
        //insertUser(firstName,lastName, role, status)
            public int insertUser(string firstName,string lastName,int role,int status) {
                int userID = 0;
                cmd = new SqlCommand("User_Insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@role", role);

                try {
                    conn.Open();
                    cmd.Prepare();
                    userID = (int)cmd.ExecuteScalar();
                    return userID;
                }
                catch (Exception ex) {
                    return -1;
                }
            }
        //
            public int updateUser(int userID, string firstName,string lastName,string phone, int role,int status) {
                int affected = 0;

                cmd = new SqlCommand("User_Update_by_ID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@status", status);
                try {
                    conn.Open();
                    cmd.Prepare();
                    affected = (int)cmd.ExecuteNonQuery();
                    return affected;
                }
                catch (Exception ex) {
                    return -1;
                }
            }
            public int deleteUser(int userID) {
                int affected = 0;

                cmd = new SqlCommand("User_Delete", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                
                try {
                    conn.Open();
                    cmd.Prepare();
                    affected = (int)cmd.ExecuteNonQuery();
                    return affected;
                }
                catch (Exception ex) {
                    return -1;
                }
            }
       
            public DataSet getProductsBySupplier(int supplierID) {
                ds = new DataSet();
                da = new SqlDataAdapter("Load_Products_By_SupplierID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@supplierID", supplierID);

                try {
                    da.Fill(ds);
                    //if (ds.Tables[0].Rows.Count > 0) {
                        return ds;
                    //}
                    //else {
                    //    return null;
                    //}
                }
                catch (Exception ex) {
                    return null;
                }
                finally {
                    // precaution
                    conn.Close();
                }
            }
        
             public int insertProduct(string productName, float price, int category, int supplier, int status) {
                 int productID = 0;
                cmd = new SqlCommand("Product_Insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@supplier", supplier);
                cmd.Parameters.AddWithValue("@status", status);
                

                try {
                    conn.Open();
                    cmd.Prepare();
                    productID = (int)cmd.ExecuteScalar();
                    return productID;
                }
                catch (Exception ex) {
                    return -1;
                }
            }
      
          public int updateProduct(int productID, string productName, float price, int category, int supplier, int status) {
                 int affected = 0;

                 cmd = new SqlCommand("Product_Update", conn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@productID", productID);
                 cmd.Parameters.AddWithValue("@productName", productName);
                 cmd.Parameters.AddWithValue("@price", price);
                 cmd.Parameters.AddWithValue("@category", category);
                 cmd.Parameters.AddWithValue("@supplier", supplier);
                 cmd.Parameters.AddWithValue("@status", status);
                 try {
                     conn.Open();
                     cmd.Prepare();
                     affected = (int)cmd.ExecuteNonQuery();
                     return affected;
                 }
                 catch (Exception ex) {
                     return -1;
                 }
             }

             public int getProductID(string name, int category, int supplier) {

                 int productID = 0;

                 cmd = new SqlCommand("Get_ProductID", conn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@name", name);
                 cmd.Parameters.AddWithValue("@category", category);
                 cmd.Parameters.AddWithValue("@supplier", supplier);

                 try {
                     conn.Open();
                     cmd.Prepare();
                     productID = (int)cmd.ExecuteScalar();
                     return productID;
                 }
                 catch (Exception ex) {
                     return -1;
                 }
             }
             public int deleteProduct(int productID) {
                 int affected = 0;

                 cmd = new SqlCommand("Product_Delete", conn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@productID", productID);

                 try {
                     conn.Open();
                     cmd.Prepare();
                     affected = (int)cmd.ExecuteNonQuery();
                     return affected;
                 }
                 catch (Exception ex) {
                     return -1;
                 }
             }
        //searchUserByName(nameStarts)
             public DataSet searchUserByName(string nameStarts) {
                 ds = new DataSet();
                 da = new SqlDataAdapter("Search_User_By_Name", conn);
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.AddWithValue("@nameStarts", nameStarts);

                 try {
                     da.Fill(ds);
                     //if (ds.Tables[0].Rows.Count > 0) {
                         return ds;
                     //}
                     //else {
                       //  return null;
                     //}
                 }
                 catch (Exception ex) {
                     return null;
                 }
                 finally {
                     // precaution
                     conn.Close();
                 }
             }
            
       
     public int updateCustomer(int customerID, string firstName, string lastName, string phone, string email, int status) {
                 int affected = 0;

                 cmd = new SqlCommand("Customer_Update", conn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@customerID", customerID);
                 cmd.Parameters.AddWithValue("@firstName", firstName);
                 cmd.Parameters.AddWithValue("@lastName", lastName);
                 cmd.Parameters.AddWithValue("@phone", phone);
                 cmd.Parameters.AddWithValue("@email", email);
                 cmd.Parameters.AddWithValue("@status", status);
                 try {
                     conn.Open();
                     cmd.Prepare();
                     affected = (int)cmd.ExecuteNonQuery();
                     return affected;
                 }
                 catch (Exception ex) {
                     return -1;
                 }
        }
        //Search_All_Customers_By_Name_Like
     public DataSet searchAllCastomersByNameLike(string nameStarts) {
         ds = new DataSet();
         da = new SqlDataAdapter("Search_All_Customers_By_Name_Like", conn);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;
         da.SelectCommand.Parameters.AddWithValue("@nameStarts", nameStarts);

         try {
             da.Fill(ds);
             //if (ds.Tables[0].Rows.Count > 0) {
             return ds;
             //}
             //else {
             //  return null;
             //}
         }
         catch (Exception ex) {
             return null;
         }
         finally {
             // precaution
             conn.Close();
         }
     }
        
     public DataSet searchActiveCastomersByNameLike(string nameStarts) {
         ds = new DataSet();
         da = new SqlDataAdapter("Search_Active_Customers_By_Name_Like", conn);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;
         da.SelectCommand.Parameters.AddWithValue("@nameStarts", nameStarts);

         try {
             da.Fill(ds);
             //if (ds.Tables[0].Rows.Count > 0) {
             return ds;
             //}
             //else {
             //  return null;
             //}
         }
         catch (Exception ex) {
             return null;
         }
         finally {
             // precaution
             conn.Close();
         }
     }
     public int deleteCustomer(int customerID) {
         int affected = 0;

                cmd = new SqlCommand("Customer_Delete", conn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerID", customerID);
                
                try {
                    conn.Open();
                    cmd.Prepare();
                    affected = (int)cmd.ExecuteNonQuery();
                    return affected;
                }
                catch (Exception ex) {
                    return -1;
                }
            }
     public DataSet getOrderByOrderID(int orderID) {
         ds = new DataSet();
         da = new SqlDataAdapter("Load_Order_By_OrderID", conn);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;
         da.SelectCommand.Parameters.AddWithValue("@orderID", orderID);

         try {
             da.Fill(ds);
             //if (ds.Tables[0].Rows.Count > 0) {
             return ds;
             //}
             //else {
             //  return null;
             //}
         }
         catch (Exception ex) {
             return null;
         }
         finally {
             // precaution
             conn.Close();
         }
     }
     public DataSet LoadCustomerByID(int userID) {
         ds = new DataSet();
         da = new SqlDataAdapter("Load_Customer_By_ID", conn);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;
         da.SelectCommand.Parameters.AddWithValue("@userID", userID);

         try {
             da.Fill(ds);
             //if (ds.Tables[0].Rows.Count > 0) {
             return ds;
             //}
             //else {
             //  return null;
             //}
         }
         catch (Exception ex) {
             return null;
         }
         finally {
             // precaution
             conn.Close();
         }
     }

     public int insertOrder(Invoice order) {
         int orderID = 0;
         cmd = new SqlCommand("Order_Insert", conn);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@UserID", order.UserID);
         cmd.Parameters.AddWithValue("@ProductID", order.ProductID);
         cmd.Parameters.AddWithValue("@Total", order.Total);
         cmd.Parameters.AddWithValue("@DateCreated", order.DateCreated);
         cmd.Parameters.AddWithValue("@AddressID", order.ShippingAddressID);
         cmd.Parameters.AddWithValue("@Status",1);

         try {
             conn.Open();
             cmd.Prepare();
             orderID = (int)cmd.ExecuteScalar();
             return orderID;
         }
         catch (Exception ex) {
             return -1;
         }
     }
     public int insertAddress(PostalAddress address) {
         int addressID = 0;
         cmd = new SqlCommand("Address_Insert", conn);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@StreetAddress", address.StreetAddress);
         cmd.Parameters.AddWithValue("@Suite", address.Suite);
         cmd.Parameters.AddWithValue("@City", address.City);
         cmd.Parameters.AddWithValue("@Province", address.Province);
         cmd.Parameters.AddWithValue("@Contry", address.Contry);
         cmd.Parameters.AddWithValue("@PostalCode", address.PostalCode);
         cmd.Parameters.AddWithValue("@UserID", address.UserID);
         try {
             conn.Open();
             cmd.Prepare();
             addressID = (int)cmd.ExecuteScalar();
             return addressID;
         }
         catch (Exception ex) {
             return -1;
         }
         

     }
     public DataSet getOrderDetails(int orderID,int userID) {
         ds = new DataSet();
         da = new SqlDataAdapter("Load_Order_Details_By_ID", conn);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;
         da.SelectCommand.Parameters.AddWithValue("@orderID", orderID);
         da.SelectCommand.Parameters.AddWithValue("@userID", userID);
         try {
             da.Fill(ds);
            
             return ds;
             
         }
         catch (Exception ex) {
             return null;
         }
         finally {
             // precaution
             conn.Close();
         }
     }
     public DataSet loadSecretQuesrions() {
         ds = new DataSet();
         da = new SqlDataAdapter("Load_Secret_Quesrions", conn);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;
         
         try {
             da.Fill(ds);

             return ds;

         }
         catch (Exception ex) {
             return null;
         }
         finally {
             // precaution
             conn.Close();
         }
        }

        /// <summary>
        /// The method gets data needed for user authentication to change the password
        /// </summary>
        /// <returns></returns>
     public DataSet loadToVerifyInput(string email ) {
         ds = new DataSet();
         da = new SqlDataAdapter("Load_user_info", conn);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;
         da.SelectCommand.Parameters.AddWithValue("@email", email);
         try {
             da.Fill(ds);

             return ds;

         }
         catch (Exception ex) {
             return null;
         }
         finally {
             // precaution
             conn.Close();
         }
     }
        public int updatePW(int sessID,string encryptedPswd){
             int affected = 0;

                 cmd = new SqlCommand("PW_Update", conn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@sessID", sessID);
                 cmd.Parameters.AddWithValue("@Pswd", encryptedPswd);
                 
                 try {
                     conn.Open();
                     cmd.Prepare();
                     affected = (int)cmd.ExecuteNonQuery();
                     return affected;
                 }
                 catch (Exception ex) {
                     return -1;
                 }
        }
        public DataSet getOrderHistory(string sess) {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_order_history", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@sess", sess);
            try {
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
        public DataSet loadTodaysOrders() {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Todays_Orders", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@date", DateTime.Today);
            try {
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
        public int closeSess(string sess) {
            
            int affected = 0;

            cmd = new SqlCommand("End_Session", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sess", sess);
            

            try {
                conn.Open();
                cmd.Prepare();
                affected = (int)cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex) {
                
            }
            return affected;
        }
        
        public DataSet loadOrderes(int status) {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Orders", conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@status", status);
            try {
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
        //changeToShipped
        public int changeToShipped(int orderID) {

            int affected = 0;

            cmd = new SqlCommand("Change_To_Shipped", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderID", orderID);


            try {
                conn.Open();
                cmd.Prepare();
                affected = (int)cmd.ExecuteNonQuery();

            }
            catch (Exception ex) {

            }
            return affected;
        }
        
        public DataSet getAddressByOrderID(int orderID) {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_Address_By_OrderID", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@orderID", orderID);

            try {
                da.Fill(ds);
                return ds;
               }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
        
        public DataSet loadProducts() {
            ds = new DataSet();
            da = new SqlDataAdapter("Load_All_Products", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            

            try {
                da.Fill(ds);
                return ds;
              }
            catch (Exception ex) {
                return null;
            }
            finally {
                // precaution
                conn.Close();
            }
        }
        
        public int updateOrder(int addressID, string strAddress, string suite, string city,  string postalCode , int province, int country,int orderID, int productID,double total) {
            int affected = 0;

            cmd = new SqlCommand("Order_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@addressID", addressID);
            cmd.Parameters.AddWithValue("@StreetAddress", strAddress);
            cmd.Parameters.AddWithValue("@Suite", suite);
            cmd.Parameters.AddWithValue("@City", city);
            cmd.Parameters.AddWithValue("@Province", province);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.Parameters.AddWithValue("@PostalCode", postalCode);
            ///////////
            cmd.Parameters.AddWithValue("@orderID", orderID);
            cmd.Parameters.AddWithValue("@productID", productID);
            cmd.Parameters.AddWithValue("@total", total);

            try {
                conn.Open();
                cmd.Prepare();
                affected = (int)cmd.ExecuteNonQuery();
                return affected;
            }
            catch (Exception ex) {
                return -1;
            }
        }
        public int getRoleBySess(string sessionID){
            int role = 0;

            cmd = new SqlCommand("Get_Role_by_Session", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@session", sessionID);
            
            try {
                conn.Open();
                cmd.Prepare();
                role= (int)cmd.ExecuteScalar();
                return role;
            }
            catch (Exception ex) {
                return -1;
            }
        }
        public int updateUserPW(int userID, string firstName, string lastName, string phone, int role, int status, string Password) {
            int affected = 0;

            cmd = new SqlCommand("User_Update_with_PW", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@Password", Password);
            

            try {
                conn.Open();
                cmd.Prepare();
                affected = (int)cmd.ExecuteNonQuery();
                return affected;
            }
            catch (Exception ex) {
                return -1;
            }
        }
    }
}
