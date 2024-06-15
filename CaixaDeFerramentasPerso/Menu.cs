using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaDeFerramentasPerso
{
    public class MenuP: Panel
    {
        ButtonP[] btns;
        public MenuP(ButtonP[] btns, Color BackColor, int top, int left, int width, int height, Form tela) 
        {
            this.BackColor = BackColor;
            this.Top = top;
            this.Width = width;
            this.Height = height;
            this.Left = left;
            this.btns = btns;

            
        }
        public void exibir(Form tela)
        {
            tela.Controls.Add(this);
            this.BringToFront();
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].BackColor = Color.LightSlateGray;
                btns[i].ForeColor = Color.White;
                tela.Controls.Add(btns[i]);
                btns[i].BringToFront();
            }
        }
        public void fechar(Form tela)
        {
            tela.Controls.Remove(this);
            for (int i = 0; i < btns.Length; i++)
            {
                tela.Controls.Remove(btns[i]);
            }
        }
    }
}
