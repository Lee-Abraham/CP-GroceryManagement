using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MySqlConnector;



namespace OOP_Lab9
{
    public class Program
    {
        static void Main(string[] args)
        {
            DBConnect connect = new DBConnect();

            //connect.Insert();
            //connect.Update();
            //connect.Delete();
            //connect.Select();
            //connect.Count();

            //Could not make backup and restore to work. Access is denied.

            connect.Backup();
            connect.Restore();


            var Builder = new MySqlConnectionStringBuilder()
            {
                Server = "Localhost",
                Database = "connectcsharptomysql",
                UserID = "root",
                Password = "2005@Braham"
            };

            //Insert
            using (var connection = new MySqlConnection(Builder.ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";
                //Create a command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Executes the command
                cmd.ExecuteNonQuery();

                connection.Close();

            }

            //Update
            using (var connection = new MySqlConnection(Builder.ConnectionString))
            {
                connection.Open();

                string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";
                //Creates a SQL command
                MySqlCommand cmd = new MySqlCommand();

                //Assigning the quesry with the use ot the command text
                cmd.CommandText = query;

                //Assignes connection
                cmd.Connection = connection;

                //Executes the command
                cmd.ExecuteNonQuery();

                connection.Close();

            }

            //Delete
            using (var connection = new MySqlConnection(Builder.ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM tableinfo WHERE name='John Smith'";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                connection.Close();

            }

            //Select
            using (var connection = new MySqlConnection(Builder.ConnectionString))
            {
                string query = "SELECT * FROM tableinfo";

                //Creates list that stores the result
                List<string>[] list = new List<string>[3];
                list[0] = new List<string>();
                list[1] = new List<string>();
                list[2] = new List<string>();

                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list[0].Add(reader["id"] + "");
                    list[1].Add(reader["name"] + "");
                    list[2].Add(reader["age"] + "");
                }

                reader.Close();

                connection.Close();

            }

            //Count
            using (var connection = new MySqlConnection(Builder.ConnectionString))
            {
                connection.Open();

                string query = "SELECT Count(*) FROM tableinfo";
                int count = -1;

                MySqlCommand cmd = new MySqlCommand(query, connection);

                count = int.Parse(cmd.ExecuteScalar() + "");

                connection.Close();

            }

            //        //Backup
            //        using (var connection = new MySqlConnection(Builder.ConnectionString))
            //        {
            //            connection.Open();

            //            DateTime Time = DateTime.Now;
            //            int year = Time.Year;
            //            int month = Time.Month;
            //            int day = Time.Day;
            //            int hour = Time.Hour;
            //            int minute = Time.Minute;
            //            int second = Time.Second;
            //            int millisecond = Time.Millisecond;

            //            string Server = "Localhost";
            //            string Database = "connectcsharptomysql";
            //            string UserID = "root";
            //            string Password = "2005@Braham";
            //            try
            //            {
            //                string path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
            //"-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";

            //                StreamWriter file = new StreamWriter(path);

            //                ProcessStartInfo psi = new ProcessStartInfo();
            //                psi.FileName = "Unnamed";
            //                psi.RedirectStandardInput = false;
            //                psi.RedirectStandardOutput = true;
            //                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
            //                    UserID, Password, Server, Database);
            //                psi.UseShellExecute = false;

            //                Process process = Process.Start(psi);

            //                string output;
            //                output = process.StandardOutput.ReadToEnd();
            //                file.WriteLine(output);
            //                process.WaitForExit();
            //                file.Close();
            //                process.Close();
            //            }
            //            catch (IOException ex)
            //            {
            //                throw new ArgumentException("Error , unable to backup!");
            //            }

            //            connection.Close();

            //        }
        }
    }
}


