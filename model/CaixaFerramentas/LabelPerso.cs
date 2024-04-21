using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaFerramentas
{
    public class LabelPerso : Form
    {
        public Label txt = new Label();
        public LabelPerso(int width, int height, int top, int left, string texto, Form tela) 
        { 
            if(tela != null) { 
                txt.Text = texto;
                txt.Width = width;
                txt.Height = height;
                txt.Top = top;
                txt.Left = left;
                tela.Controls.Add(txt);
            }
        }
    }
}
