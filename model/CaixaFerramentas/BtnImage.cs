using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CaixaFerramentas
{
    public class BtnImage : Form
    {
        public PictureBox PB_btn = new PictureBox();
        public Button btn = new Button();
        private Image img;
        private Image img_click;
        public bool atv;
        public BtnImage(bool atv, int width, int height, int top, int left, string img, string img_click, string txt, Form tela)
        {
            if (tela != null) { 
                this.atv = atv;
                if (img == null && img_click == null) {
                    btn.Width = width;
                    btn.Height = height;
                    btn.Top = top;
                    btn.Left = left;
                    btn.Text = txt;
                    if (left == 999)
                    {
                        btn.Left = (tela.Width / 2) - width / 2 - 8;
                    }
                    tela.Controls.Add(btn);
                 
                }
                else { 
                    PB_btn.Width = width;
                    PB_btn.Height = height;
                    PB_btn.Top = top;
                    PB_btn.Left = left;
                    if (left == 999)
                    {
                        PB_btn.Left = (tela.Width / 2) - width / 2 - 8;
                    }
                    this.img = new Bitmap(img);
                    this.img = new Bitmap(this.img, width, height);
                    this.img_click = new Bitmap(img_click);
                    this.img_click = new Bitmap(this.img_click, width, height);
                    PB_btn.Image = this.img;
                    tela.Controls.Add(this.PB_btn);
                    PB_btn.MouseDown += pb_Btn_Down;
                    PB_btn.MouseUp += pb_Btn_Up;
                }
            }
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
