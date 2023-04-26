using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibrarySystem.Models
{
    internal class DBconnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBconnection()
        {
            Initialize();
            OpenConnection();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "connectcsharptomysql";
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                this.CloseConnection();
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        // Insert a user to users table
        public void InsertAUser(User user)
        {
            string query = $"INSERT INTO users VALUES (NULL, '{user.name}', '{user.password}', '{user.email}');";
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand();

                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }

        }

 

        // Insert reserved Books
        public void InsertReservedBooks(ReservedBookModel reservedBook)

        {
            String Image = reservedBook.Imagesource.ToString();
            String img = Image.Substring(5, Image.IndexOf(".") - 5).Trim();
            string query = $"INSERT INTO reservedbook VALUES (NULL,'{reservedBook.Title}','{reservedBook.Author}','{img}','{reservedBook.Startdate.ToShortDateString()}','{reservedBook.Endate.ToShortDateString()}','{reservedBook.Username}','{reservedBook.Description}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand();

                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }



        //Update books statement
        public async Task UpdateBooksStatus(ReservedBookModel reservedBook)
        {
            string query = $"UPDATE books SET Status=0 WHERE Title='{reservedBook.Title}'";


            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
            this.InsertReservedBooks(reservedBook);
        }


        // login in user info Select statement
        public bool Select(string name, int? age)
        {
            string query = $"SELECT * FROM users WHERE name = '{name}' and password = '{age}'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    return true;
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
            return false;
        }


        // retrive books from database
        public List<BookModel> RetriveBooks()
        {
            string query = $"SELECT * FROM books ORDER BY Last_updated DESC";
            List<BookModel> list = new List<BookModel>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string statusOfBook = dataReader["Status"].ToString() == "1" ? "Available" : "Unavailable";
                    list.Add(new BookModel
                    {
                        Title = $"{dataReader["Title"]}",
                        Author = $"{dataReader["Author"]}",
                        Imagesource = ImageSource.FromFile($"{dataReader["Image"]}.jpg"),
                        Status = statusOfBook,
                        Description = $"{dataReader["Description"]}"
                    });
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
            return list;
        }

        // retrive reserved books from database
        public List<ReservedBookModel> RetriveReservedBooks()
        {
            string query = $"SELECT * FROM reservedbook ORDER BY Last_updated DESC";
            List<ReservedBookModel> list = new List<ReservedBookModel>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list.Add(new ReservedBookModel
                    {
                        Title = $"{dataReader["Title"]}",
                        Author = $"{dataReader["Author"]}",
                        Startdate = dataReader.GetDateTime("Startdate"),
                        Endate = dataReader.GetDateTime("Endate"),
                        Imagesource = ImageSource.FromFile($"{dataReader["Image"]}.jpg"),
                        Description = $"{dataReader["Description"]}",
                        Username = $"{dataReader["Username"]}"
                    });
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
            return list;
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
    }
}
