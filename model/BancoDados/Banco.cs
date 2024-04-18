using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Collections.ObjectModel;

namespace BancoDados
{
    public class Banco
    {
        private MySqlConnection conection = new MySqlConnection("server=localhost;username=root;database=testeando");
        private MySqlDataAdapter adapter = new MySqlDataAdapter();
        private DataTable dt = new DataTable();
        private DataSet bdDataSet = new DataSet();
        public DataTable AllUsers()
        {
            MySqlDataAdapter adapter = null;
            adapter = new MySqlDataAdapter("Select * from usuarios", conection);
            dt.Rows.Add(adapter);
            conection.Close();
            return dt;
        }

        public DataTable consultar(string sql)
        {
            conection.Open();
            adapter = new MySqlDataAdapter(sql, conection);
            adapter.Fill(dt);
            conection.Close();
            return dt;
        }
    }
}
