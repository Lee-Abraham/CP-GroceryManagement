using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace groceryManagement
{
    public class Vendor : SqlConnect
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
            //Gets the connection string from the abstract class
            string connString = GetConnectionString();

            //SQL command to insert
            string query = "INSERT INTO vendor (VendorID, VendorName, VendorDesc) VALUES (@id, @name, @desc)";

            //Opens sql
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                //Inserts value into table
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", vendorID);
                    cmd.Parameters.AddWithValue("@name", vendorName);
                    cmd.Parameters.AddWithValue("@desc", vendorDesc);

                    //IMPORTANT!!!
                    //Execute the commands
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Get all vendor ID
        public List<int> getAllVendorID()
        {
            List<int> vendorIDS = new List<int>(); //Creates a list to return

            string connString = GetConnectionString(); //Gets the connection string from the abstract class

            string query = "SELECT VendorID FROM vendor"; //Selects and get all VendorID

            using(MySqlConnection conn = new MySqlConnection( connString)) //Create instance with connection string
            {
                conn.Open(); //Opens connection

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) //Create instance with our sql command and connection to database
                {
                
                    using (MySqlDataReader reader = cmd.ExecuteReader()) //Read the executed command
                    {
                        try //Check if there is a vendor present
                        {
                            while (reader.Read()) //While the reader is reader each line
                            {
                                vendorIDS.Add(reader.GetInt32(0)); //Adds the vendor ID to the List
                            }
                        }
                        catch (Exception ex) //If there are no vendor
                        {
                            Console.WriteLine("An error retrieving vendor IDs: " + ex.Message); //Log error

                            return new List<int>(); //Returns empty list
                        }
                    }
                }
            }

            return vendorIDS; //Returns all the vendor IDs
        }

        //Check specific Vendor
        public Vendor getVendor(int vendorID)
        {

            Vendor vendor = new Vendor(); //Creates method to return

            string connString = GetConnectionString(); //Gets connection string

            string query = $"SELECT * from VENDOR WHERE VendorID = @VendorID"; //Selects specific id

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VendorID", vendorID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) //Check if data exist
                        {
                            vendor = new Vendor()
                            {
                                VendorID = reader.GetInt32(0),
                                VendorName = reader.GetString(1),
                                VendorDescription = reader.GetString(2)
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }

            return vendor;
        }
    }
}
