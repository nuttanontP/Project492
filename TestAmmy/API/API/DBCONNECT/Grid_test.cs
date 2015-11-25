using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL_2;
using MySql.Data.MySqlClient;
using System.Data;

namespace MODEL_2.Respository
{
    public class Grid_test
    {
        DBConnect dbconnect = new DBConnect();
        public DataTable dt()
        {
            DataTable data = new DataTable();
            string query = "SELECT * FROM my_ammy.users";
            if (dbconnect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(data);
                return data;

            }
            return data;
        }
    }
}
