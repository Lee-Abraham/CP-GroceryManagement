using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MySqlConnector;


namespace OOP_Lab9
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;



        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        //Setss the value to a defult.
        private void Initialize()
        {
            server = "localhost";
            database = "connectcsharptomysql";
            uid = "root";
            password = "2005@Braham";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);


        }

        public bool OpenConnection()
        {
            var Builder = new MySqlConnectionStringBuilder()
            {
                Server = "Localhost",
                Database = "connectcsharptomysql",
                UserID = "root",
                Password = "2005@Braham"
            };

            using (var connection = new MySqlConnection(Builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error opening connection: {ex.Message}");
                    return false;
                }

            }

            
        }

        //Close connection
        public bool CloseConnection()
        {
            var Builder = new MySqlConnectionStringBuilder()
            {
                Server = "Localhost",
                Database = "connectcsharptomysql",
                UserID = "root",
                Password = "2005@Braham"
            };

            using (var connection = new MySqlConnection(Builder.ConnectionString))
            {
                connection.Close();
                return true;

            }

        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";
            //If statement that opens connection
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Data inserted successfully.");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error");
                }
                finally
                {
                    this.CloseConnection();
                }
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            if(this.OpenConnection() == true)
            {
                //Creates a SQL command
                MySqlCommand cmd = new MySqlCommand();

                //Assigning the quesry with the use ot the command text
                cmd.CommandText = query;

                //Assignes connection
                cmd.Connection = connection;

                //Executes the command
                cmd.ExecuteNonQuery();

                //Close the connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand( query, connection);
                cmd.ExecuteNonQuery ();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM tableinfo";

            //Creates list that stores the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand (query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list[0].Add(reader["id"] + "");
                    list[1].Add(reader["name"] + "");
                    list[2].Add(reader["age"] + "");
                }

                reader.Close();

                this.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int count = -1;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand ( query, connection);

                count = int.Parse(cmd.ExecuteScalar()+ "");

                this.CloseConnection();

                return count;
            }
            else
            {
                return count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
              "\\MySqlBackup" + year + "-" + month + "-" + day +
              "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";

                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = @"C:\Program Files\MySQL\MySQL Server X.X\bin\mysqldump.exe"; ;
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                throw new ArgumentException("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = @"C:\Program Files\MySQL\MySQL Server X.X\bin\mysqldump.exe"; ;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                throw new ArgumentException("Error , unable to Restore!");
            }
        }
    }

    }
