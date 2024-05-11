using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Controller
{
    public class DAO
    {
        string strConnection = "server=localhost;user=root;database=projeto;port=3306";
        MySqlConnection con;
        DataTable dt = new DataTable();
        MySqlCommand cmd;
        MySqlDataReader dr;
        public DAO()
        {
            try
            {
                con = new MySqlConnection(strConnection);
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public void updateDelete(string sql)
        {
            cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
