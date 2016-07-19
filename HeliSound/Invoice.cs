using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeliSound {
    public class Invoice {
        public int UserID { get;  set; }
        public int ProductID { get; set; }
        public double Total { get; set; }
        public DateTime DateCreated { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public int ShippingAddressID { get;
            set; }
    }
}