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
        public Military militar;
        public btnImage btn = new btnImage(true, 32, 32, 256, 0, "imgs/img_btnProximo.png", "imgs/img_btn.png");
        public kingdom()
        {
            Width = 1000;
            Height = 760;
            StartPosition = FormStartPosition.CenterScreen;
            reino1.Carregando();
            
            btn.btn.Click += new EventHandler(btn_Click);
            Controls.Add(btn.btn);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            militar = new Military(this, reino1);
            Controls.Add(btn.btn);
        }
    }
}
