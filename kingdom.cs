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
        Reino reino1 = new Reino();
        public kingdom()
        {
            Width = 1000;
            Height = 760;
            StartPosition = FormStartPosition.CenterScreen;

            reino1.Carregando();


        }


    }
}
