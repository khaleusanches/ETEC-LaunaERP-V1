using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Logica
{
    public class DAO
    {
        string strConnection = "server=localhost;user=root;database=atividade1csharp;port=3306";
        MySqlConnection con;
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

        public void updateInsertDelete(string sql)
        {
            cmd = new MySqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch 
            { }
        }
        public DataTable lerTabela(string sql)
        {
            DataTable dt = new DataTable();
            cmd = new MySqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dr.Close();
            return dt;
        }
    }
}
