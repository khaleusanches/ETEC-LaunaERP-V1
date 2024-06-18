using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaDeFerramentasPerso
{
    public class PanelP : Panel
    {
        public PanelP(int width, int height, int top, int left, Color color, Form tela)
        {

            BackColor = color;
            Width = width;
            Height = height;
            Top = top;
            Left = left;
            if (left == 999)
            {
                this.Left = (tela.Width / 2) - width - 25;
            }
            if (tela != null)
            {
                tela.Controls.Add(this);
            }
        }
    }
}
