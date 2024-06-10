using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CaixaDeFerramentasPerso
{
    public class LabelP : Label
    {
        /// <summary>
        /// Adiciona um objeto Label da biblioteca Forms na tela desejada, left = 999 para centralizar
        /// Label é uma classe da biblioteca Forms utilizada para exibir textos.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="texto"></param>
        /// <param name="tela"></param>
        public LabelP(int width, int height, int top, int left, string texto, Form tela)
        {
            if (tela != null)
            {
                this.Font = new Font("Arial", 10);
                Text = texto;
                Width = width;
                Height = height;
                Top = top;
                Left = left;
                if (left == 999)
                {
                    this.Left = (tela.Width / 2) - width - 25;
                }
                tela.Controls.Add(this);
            }
        }
    }
}
