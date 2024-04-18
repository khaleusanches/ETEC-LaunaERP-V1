using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using BancoDados;
using CaixaFerramentas;

namespace Sistema
{
    internal class Program : Form
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        Label teste = new Label();
        static void Main(string[] args)
        {
            Application.Run(new Program());
        }
        public Program()
        {
            StartPosition = FormStartPosition.CenterScreen;
            Width = 900;
            Height = 680;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            TextBoxPerso TB_Username = new TextBoxPerso(100, 100, 50, "Username", 15, this);
            TextBoxPerso TB_Password = new TextBoxPerso(100, 100, 100, "Password", 15, this);
            BtnImage Login = new BtnImage(true, 100, 100, 175, "imgs/img_btnProximo.png", "imgs/img_btnProximoClick.png", this);
            Login.PB_btn.Click += new EventHandler(login_Click);
            
            teste.Text = "penes";
            Controls.Add(teste);
        }

        private void login_Click(object sender, EventArgs e)
        {
            string sql = "select * from usuario where Nome_Usuario='batata'";
            dt = banco.consultar(sql);
            if (dt.Rows.Count > 0) {
                teste.Text = dt.Rows[0].ItemArray[3].ToString();
            }
        }
    }
}
