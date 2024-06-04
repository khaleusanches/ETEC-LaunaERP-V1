using Controller;
using Sistema.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;
using View.RH;

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
            new AuxiliarRH("abelhja", "1");
        }
    }
}
