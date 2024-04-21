using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaFerramentas
{
    public class TextBoxPerso : Form
    {
        public TextBox tb = new TextBox();
        public TextBoxPerso(int width, int height, int top, int left, string text, int maxTam, Form tela)
        {
            if (tela != null) { 
                tb.Width = width;
                tb.Height = height;
                tb.Top = top;
                if(left == 999) { 
                    tb.Left = (tela.Width / 2) - width / 2 - 8;
                }
                else
                {
                    tb.Left = left;
                }
                tb.Text = text;
                tb.MaxLength = maxTam;
                tela.Controls.Add(tb);
            }
        }
    }
}
