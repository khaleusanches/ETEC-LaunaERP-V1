using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using CaixaFerramentas;

namespace TL_Principal
{
    public class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            Width = 900;
            Height = 680;
            Panel panel = new Panel();
            panel.Width = 900;
            panel.Height = 50;
            panel.BackColor = Color.DarkSlateGray;
            Controls.Add(panel);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
    }
}
