using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoReigns
{
    internal class btnImage : Form
    {
        public PictureBox btn = new PictureBox();
        public Image imgPrinc;
        public Image imgClick;

        public void criarBTN(bool ativado, int width, int height, int posX, int posY, string img_Principal, string img_Click) //meotodo criador do botão, define o tamanho, posição, e imagem
        {
            btn.Width = width;
            btn.Height = height;
            btn.Top = posY;
            btn.Left = posX;
            imgPrinc = new Bitmap(img_Principal);
            imgPrinc = new Bitmap(imgPrinc, width, height);
            btn.BackgroundImage = imgPrinc;
            if (ativado == true) { 
                btn.MouseDown += Btn_MouseDown;
            }
            btn.MouseUp += Btn_MouseUp;
            imgClick = new Bitmap(img_Click);
            imgClick = new Bitmap(imgClick, width, height);
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            btn.BackgroundImage = imgPrinc;
        }

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            btn.BackgroundImage = imgClick;
        }
    }
}
