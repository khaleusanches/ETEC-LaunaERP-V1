using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaDeFerramentasPerso
{
    public class ButtonP : Button
    {
        public bool atv;
        /// <summary>
        /// Adiciona um objeto Button da biblioteca Forms na tela desejada, left = 999 para centralizar.
        /// Button é uma classe da biblioteca Forms utilizada para criar botões.
        /// </summary>
        /// <param name="atv"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="txt"></param>
        /// <param name="tela"></param>
        public ButtonP(bool atv, int width, int height, int top, int left, string txt, Form tela)
        {
            this.atv = atv;
            Width = width;
            Height = height;
            Top = top;
            Left = left;
            Text = txt;
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
