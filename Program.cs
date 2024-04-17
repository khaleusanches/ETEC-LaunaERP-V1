using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Sistema.model;

namespace Sistema
{
    internal class Program : Form
    {
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

            TB_Username.Click += new EventHandler(username_Click);
        }

        private void username_Click(object sender, EventArgs e)
        {
            
        }
    }
}
