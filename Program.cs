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
            Width = 1000;
            Height = 750;
            
            BtnImage Login = new BtnImage(true, 100, 100, 50, 150, "imgs/img_btnProximo.png", "imgs/img_btnProximoClick.png", this);
            
            Login.PB_btn.Click += new EventHandler()
        }
       
    }
}
