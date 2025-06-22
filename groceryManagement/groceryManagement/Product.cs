using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groceryManagement
{
    public class Product:SqlConnect
    {
        //Attributes
        private int productID;
        private int prodVendorID;
        private string productName;
        private string productDescription;

        //Getters and setters for attributes

        public int ProductID { get { return productID; } set { productID = value; } }

        public int ProdVendorID { get {return prodVendorID; } set { prodVendorID = value; } }

        public string ProductName { get { return productName; } set {productName = value; } }

        public string ProductDescription { get { return productDescription; } set {productDescription = value; } }


        //Constructors
        public Product() { }

        public Product(int productID, int prodVendorID, string productName, string productDescription)
        {
            ProductID = productID;
            ProdVendorID = prodVendorID;
            ProductName = productName;
            ProductDescription = productDescription;
        }
    }
}
