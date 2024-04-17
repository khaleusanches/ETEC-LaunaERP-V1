using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.model
{
    internal class BtnImage : Form
    {
        public PictureBox PB_btn = new PictureBox();
        private Image img;
        private Image img_click;
        private bool atv;
        public BtnImage(bool atv, int width, int height, int top, string img, string img_click, Form tela) { 
            this.atv = atv;
            PB_btn.Width = width;
            PB_btn.Height = height;
            PB_btn.Top = top;
            PB_btn.Left = (tela.Width/2)-width/2-8;
            this.img = new Bitmap(img);
            this.img = new Bitmap(this.img, width, height);
            this.img_click = new Bitmap(img_click);
            this.img_click = new Bitmap(this.img_click, width, height);
            PB_btn.Image = this.img;
            tela.Controls.Add(this.PB_btn);

            PB_btn.MouseDown += pb_Btn_Down;
            PB_btn.MouseUp += pb_Btn_Up;
        }
        private void pb_Btn_Down(object sender, EventArgs e)
        {
            PB_btn.Image = img_click;
        }
        private void pb_Btn_Up(object sender, EventArgs e)
        {
            PB_btn.Image = img;
            if (atv == false)
            {
                MessageBox.Show("Você não tem permissões o suficiente");
            }
        }
    }
}
