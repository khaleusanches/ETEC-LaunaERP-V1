using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.model
{
    internal class TextBoxPerso : Form
    {
        public TextBox tb =  new TextBox();
        public TextBoxPerso(int width, int height, int top, string text, int maxTam, Form tela)
        {
            
            tb.Width = width;
            tb.Height = height;
            tb.Top = top;
            tb.Left = (tela.Width / 2) - width / 2 - 8;
            tb.Text = text;
            tb.MaxLength = maxTam;
            tela.Controls.Add(tb);
        }
    }
}
