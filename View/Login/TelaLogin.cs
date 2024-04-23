using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using CaixaFerramentas;
using BancoDados;
using Funcionarios;
using TL_Principal;

namespace TL_Login
{
    public class TelaLogin : TelaPrincipal
    {
        
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        TextBoxPerso TB_Username;
        TextBoxPerso TB_Password;
        int nv;
        public TelaLogin()
        {
            TB_Username = new TextBoxPerso(100, 100, 50, 999, "Username", 15, this);
            TB_Password = new TextBoxPerso(100, 100, 100, 999, "Password", 15, this);
            BtnImage Login = new BtnImage(true, 100, 100, 175, 999, "imgs/img_btnProximo.png", "imgs/img_btnProximoClick.png", null, this);
            Login.PB_btn.Click += new EventHandler(login_Click);
        }

        private void login_Click(object sender, EventArgs e)
        {
            string sql = "select * from usuario where Nome_Usuario='" + TB_Username.tb.Text + "' and Senha_Usuario='" + TB_Password.tb.Text + "'";
            dt = banco.consultar(sql);
            if (dt.Rows.Count > 0)
            {
                nv = int.Parse(dt.Rows[0].ItemArray[4].ToString());
                switch (nv)
                {
                    case 5:
                        Dispose();
                        Gerente gerente = new Gerente();
                        break;
                }
            }
            else
            {
            }
            dt.Rows.Clear();
        }
    }
}
