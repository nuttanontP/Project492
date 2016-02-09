using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

public class DBConnect
{
    public MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //Constructor
    public DBConnect()
    {
        Initialize();
    }

    //Initialize values
    public void Initialize()
    {
        server = "localhost";
        database = "energyver1";
        uid = "root";
        password = "1234";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);

    }

    //open connection to database
    public bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            //When handling errors, you can your application's response based 
            //on the error number.
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.
            switch (ex.Number)
            {
                case 0:
                    MessageBox.Show("Cannot connect to server.  Contact administrator");
                    break;

                case 1045:
                    MessageBox.Show("Invalid username/password, please try again");
                    break;
            }
            return false;
        }
    }

    //Close connection
    public bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    //Insert statement
    //public void Insert()
    //{
    //    //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";
    //    if (this.OpenConnection() == true)
    //    {
    //        //create command and assign the query and connection from the constructor
    //        MySqlCommand cmd = new MySqlCommand(query, connection);

    //        //Execute command
    //        cmd.ExecuteNonQuery();

    //        //close connection
    //        this.CloseConnection();
    //    }
    //}

    //Update statement
    //public void Update()
    //{
    //    // string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

    //    //Open connection
    //    if (this.OpenConnection() == true)
    //    {
    //        //create mysql command
    //        MySqlCommand cmd = new MySqlCommand();
    //        //Assign the query using CommandText
    //        cmd.CommandText = query;
    //        //Assign the connection using Connection
    //        cmd.Connection = connection;

    //        //Execute query
    //        cmd.ExecuteNonQuery();

    //        //close connection
    //        this.CloseConnection();
    //    }
    //}

    //Delete statement
    //public void Delete()
    //{
    //    //string query = "DELETE FROM tableinfo WHERE name='John Smith'";

    //    if (this.OpenConnection() == true)
    //    {
    //        MySqlCommand cmd = new MySqlCommand(query, connection);
    //        cmd.ExecuteNonQuery();
    //        this.CloseConnection();
    //    }
    //}

    //Select statement
    //public IList<actor> Select()
    //{
    //    string query = "SELECT * FROM actor";
    //     IList<actor> actorlist =new List<actor>();
    //    //Create a list to store the result
    //    List<string>[] list = new List<string>[3];
    //    list[0] = new List<string>();
    //    list[1] = new List<string>();
    //    list[2] = new List<string>();
       

    //    //Open connection
    //    if (this.OpenConnection() == true)
    //    {
    //        //Create Command
    //        MySqlCommand cmd = new MySqlCommand(query, connection);
    //        //Create a data reader and Execute the command
    //        MySqlDataReader dataReader = cmd.ExecuteReader();

    //        //Read the data and store them in the list
    //        while (dataReader.Read())
    //        {
    //            actor actor = new actor();
    //            list[0].Add(dataReader["actor_id"] + "");
    //            list[1].Add(dataReader["first_name"] + "");
    //            list[2].Add(dataReader["last_name"] + "");
    //            String temp  = (dataReader["actor_id"] + "");
    //            String temp2 =(dataReader["first_name"] + "");
    //            String temp3 =(dataReader["last_name"] + "");
    //            actor.first_name = temp2;
    //            actor.actor_id = Convert.ToInt16(temp);
              
    //            actor.last_name = temp3;
    //            actorlist.Add(actor);

    //        }
           
    //        //close Data Reader
    //        dataReader.Close();

    //        //close Connection
    //        this.CloseConnection();

    //        //return list to be displayed
    //        return actorlist;
    //    }
    //    else
    //    {
    //        return actorlist;
    //    }
    //}

    //Count statement
    //public int Count()
    //{
    //    //string query = "SELECT Count(*) FROM tableinfo";
    //    int Count = -1;

    //    //Open Connection
    //    if (this.OpenConnection() == true)
    //    {
    //        //Create Mysql Command
    //        MySqlCommand cmd = new MySqlCommand(query, connection);

    //        //ExecuteScalar will return one value
    //        Count = int.Parse(cmd.ExecuteScalar() + "");

    //        //close Connection
    //        this.CloseConnection();

    //        return Count;
    //    }
    //    else
    //    {
    //        return Count;
    //    }
    //}

    //Backup
    public void Backup()
    {
    }

    //Restore
    public void Restore()
    {
    }
}
