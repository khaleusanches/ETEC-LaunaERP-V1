using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaDeFerramentasPerso
{
    public class TextBoxP : TextBox
    {
        /// <summary>
        /// Adiciona um objeto TextBox da biblioteca Forms na tela desejada, left = 999 para centralizar.
        /// TextBox é uma classe da biblioteca Forms utilizada para criar caixas onde o usuário pode inserir textos.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="text"></param>
        /// <param name="maxTam"></param>
        /// <param name="tela"></param>
        public TextBoxP(int width, int height, int top, int left, string text, int maxTam, Form tela)
        {
            if (tela != null)
            {
                this.Font = new Font("Arial", 10);
                this.Width = width;
                this.Height = height;
                this.Top = top;
                if (left == 999)
                {
                    this.Left = (tela.Width/2) - width - 25;
                }
                else
                {
                    this.Left = left;
                }
                this.Text = text;
                this.MaxLength = maxTam;
                tela.Controls.Add(this);
            }
        }
    }
}
