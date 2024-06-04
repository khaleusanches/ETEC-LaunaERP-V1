using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace View
{
    public abstract class Tl_Padrao : Form
    {
        public Tl_Padrao() 
        {
            Width = 1000;
            Height = 720;
            BackColor = Color.White;
            Panel barra = new Panel();
            barra.Width = 1000;
            barra.Height = 100;
            barra.BackColor = Color.DarkBlue;
            Controls.Add(barra);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
    }
}
