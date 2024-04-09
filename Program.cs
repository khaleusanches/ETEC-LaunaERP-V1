using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ProjetoReigns
{
    internal class Program : Form
    {
        static void Main(string[] args) 
        {
            Application.Run (new Program());
        }
        public Program()
        {
            StartPosition = FormStartPosition.CenterScreen;
            new TelaInicial().ShowDialog();
            if (File.Exists("Stats.txt"))
            {

            }
            else
            {

            }
        }
    }
}
