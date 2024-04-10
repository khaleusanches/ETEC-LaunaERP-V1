using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ProjetoReigns
{
    internal class kingdom : Form
    {
        StreamReader leitor = new StreamReader("Region.txt");
        Regions region;
        public void lendo()
        {
            string linha = leitor.ReadLine();
            switch (linha)
            {
                case "0":
                    region = new Regions(8, 8, 6, 6);
                    break;
                case "1":
                    region = new Regions(3, 4, 2, 7);
                    break;
                case "2":
                    region = new Regions(4,4,4,4);
                    break;
                case "3":
                    region = new Regions(6,4,7,2);
                    break;
            }       
            
        }


    }
}
