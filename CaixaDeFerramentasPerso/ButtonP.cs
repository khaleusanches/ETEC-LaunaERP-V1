using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaDeFerramentasPerso
{
    public class ButtonP : Button
    {
        public bool atv;
        Form tela;
        public Panel p = new Panel();
        private bool brilho;

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
            this.tela = tela;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(232, 228, 217);
            FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 228, 217);
            Font = new Font("Arial", 9);
            MouseHover += (sender, e) => ButtonP_MouseHover(sender, e);
            MouseLeave += (sender, e) => ButtonP_MouseLeave(sender, e);

            if (left == 999)
            {
                this.Left = (tela.Width / 2) - width - 25;
            }
            if (tela != null)
            {
                tela.Controls.Add(this);
                BringToFront();
            }
        }

        private void ButtonP_MouseLeave(object sender, EventArgs e)
        {
            if(atv == true)
            {
                desselecionado();
            }
        }

        public void ButtonP_MouseHover(object sender, EventArgs e)
        {
            selecionado();
        }
        public void selecionado()
        {
            if (brilho == true) { 
                p.Size = new Size(Width, 3);
                p.Location = new Point(Location.X, Location.Y + Height + 13);
                p.BackColor = Color.FromArgb(164, 190, 243);
                p.Visible = true;
                Font = new Font("Arial", 9, FontStyle.Bold);
                ForeColor = Color.FromArgb(99, 133, 199);
                p.Visible = true;
                p.BringToFront();
            }
        }
        public void desselecionado()
        {
            ForeColor = Color.Black;
            Font = new Font("Arial", 9, FontStyle.Regular);
            ForeColor = Color.Black;
            p.Visible = false;
        }

        public ButtonBorderStyle ButtonBorderStyle { get; }
    }
}
