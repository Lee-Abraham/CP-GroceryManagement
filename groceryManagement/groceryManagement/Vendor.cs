using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groceryManagement
{
    public class Vendor
    {
        //Attributes
        private string name;

        private string description;

        private int vendorID;

        
        //Constructor
        public Vendor()
        {

        }

        public Vendor(string name, string description, int vendorID)
        {
            this.name = name;
            this.description = description;
            this.vendorID = vendorID;
        }



        //----------------------------------------------------------------------//
        //Getters and setters for private attributes

        //Vendor name
        public  string VendorName
        {
            get { return name; }
            set { name = value; }
        }

        //Vendor description

        public string VendorDescription
        {
            get { return description; }
            set { description = value; }
        }

        //Vendor ID
        public int VendorID
        {
            get { return vendorID; }
            set { vendorID = value; }
        }

        //----------------------------------------------------------------------//
        //Methods

        //Set new vendor
        public void addNewVendor(string vendorName, string vendorDesc, int vendorID)
        {

        }

        //Get all vendor
        public List<int> getAllVendor()
        {
            return new List<int>();
        }

        //Check specific Vendor
        public int getVendor(int vendorID)
        {
            return 0;
        }
    }
}
