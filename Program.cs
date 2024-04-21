using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TL_Gerente;
using TL_Principal;
using CaixaFerramentas;
using Funcionarios;

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
            Gerente gerente = new Gerente();
        }
    }
}
