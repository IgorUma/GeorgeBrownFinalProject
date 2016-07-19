using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeliSound {
    public class Supplier {

        //class properties + interface
        public int SupplierID { get; private set; }
        public string SupplierName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
        public PostalAddress Address { get; set; }
        


        // default constructor
        public Supplier() { }

        // overloaded constructor
        public Supplier(string companyName, string firstName, string lastName, string phone, int status, PostalAddress address) {
            ContactFirstName = firstName;
            ContactLastName = lastName;
            SupplierName = companyName;
            Phone = phone;
            Status = status;
            Address = new PostalAddress(address);
        }

        public int insertSupplier() {
            SupplierID = 0;
            DataLayer DL = new DataLayer();
            int supplierID =DL.insertSupplier(this);
            if (supplierID > 0) {
                SupplierID = supplierID;
            }
            return SupplierID;
        }
        public bool updateSupplier(int supplierID) {
            SupplierID = supplierID;
            bool updated = false;
            DataLayer DL = new DataLayer();
            int affected = DL.updateSupplier(this);
            if (affected > 0) {
                updated = true;
            }

            return updated;
        }
    }
}