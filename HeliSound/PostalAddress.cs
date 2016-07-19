using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeliSound {
    public class PostalAddress {

        public string StreetAddress { get; set; }
        public string Suite  { get; set; }
        public string City { get; set; }
        public int Province { get; set; }
        public int Contry { get; set; }
        public string PostalCode { get; set; }
        public int UserID { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PostalAddress(){}

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="address"></param>
        public PostalAddress(PostalAddress address) {
            StreetAddress = address.StreetAddress;
            Suite = address.Suite;
            City = address.City;
            Province = address.Province;
            Contry = address.Contry;
            PostalCode = address.PostalCode;
            UserID = address.UserID;
        }
        /// <summary>
        /// overloaded Constructor
        /// </summary>
        /// <param name="streetAddress"></param>
        /// <param name="suite"></param>
        /// <param name="city"></param>
        /// <param name="province"></param>
        /// <param name="contry"></param>
        /// <param name="postalcode"></param>
        public PostalAddress(string streetAddress, string suite, string city, int province, int contry, string postalcode,int userID) {
            StreetAddress=streetAddress;
            Suite=suite;
            City =city;
            Province=province;
            Contry=contry;
            PostalCode = postalcode;
            UserID = userID;
        }
        public int insertAddress() {
            int addressID;
            DataLayer DL = new DataLayer();
            addressID = DL.insertAddress(this);
            return addressID;
        }
    }
}