using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.Collections;

namespace Logica
{
    public class DAO
    {
        string strConnection = "server=localhost;user=root;database=atividadecsharp;port=3306;pwd=123";
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
                MessageBox.Show(ex.Message);
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
            {

            }
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

        public string pegaID(string dado, string tabela, string where)
        {
            string sql = $"select {dado} from {tabela} {where}";
            DataTable data = new DataTable();
            data = lerTabela(sql);
            string id;
            if (data.Rows.Count >= 1)
            {
                id = data.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                id = "";
            }
            return id;
        }

        public string[] pegaIDLista(string dado, string tabela, string where)
        {
            string sql = $"select {dado} from {tabela} {where}";
            DataTable data = new DataTable();
            string[] lista;
            data = lerTabela(sql);
            if (data.Rows.Count >= 1)
            {
                lista = new string[data.Rows.Count];
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    lista[i] = data.Rows[i].ItemArray[0].ToString();
                }
            }
            else
            {
                lista = new string[1] { "" };
            }
            return lista;
        }
    }
}
