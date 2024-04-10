using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ProjetoReigns
{
    internal class MenuInicial : Form
    {
        PictureBox imgsEscolhendo = new PictureBox(); // Espaço da imagem
        Image region = new Bitmap("imgs/backgroundEscolha.jpg"); //imagem inicial
        TextBox nome = new TextBox();

        string[] listRegion = new string[2] { "imgs/backgroundEscolha.jpg", "imgs/backgroundEscolha.png" }; //lista com o link das imagens
        int cont = 0;
        public MenuInicial()
        {
            Width = 1000;
            Height = 760;
            StartPosition = FormStartPosition.CenterScreen;

            btnImage btn1 = new btnImage();
            btnImage btn2 = new btnImage();
            btnImage btn3 = new btnImage();
            btn1.criarBTN(true, 72, 54, 290, 350, "imgs/img_btnAnterior.png", "imgs/img_btnAnteriorClick.png");
            btn2.criarBTN(true, 72, 54, 590, 350, "imgs/img_btnProximo.png", "imgs/img_btnProximoClick.png");
            btn3.criarBTN(true, 72, 54, 430, 550, "imgs/img_btn.png", "imgs/img_btnProximoClick.png");
            Controls.Add(btn1.btn);
            Controls.Add(btn2.btn);
            Controls.Add(btn3.btn);
            btn1.btn.Click += new EventHandler(btnAnterior_Click); //evento de click no botao de passar imagem pra tras
            btn2.btn.Click += new EventHandler(btnProximo_Click); //evento de click no botao de passar imagem pra frente
            btn3.btn.Click += new EventHandler(btnIniciar_Click); //evento de click pra criar o reino

            //textbox pra inserir o nome
            nome.Width = 150;
            nome.Height = 50;
            nome.Top = 500;
            nome.Left = 400;
            nome.Text = "Digite o nome do seu reino";
            nome.MouseDown += rmvText_Click; //tirar placeholder
            Controls.Add(nome);

            //Configuração do espaço da imagem
            imgsEscolhendo.SizeMode = PictureBoxSizeMode.StretchImage;
            imgsEscolhendo.Image = region;
            imgsEscolhendo.Top = 280;
            imgsEscolhendo.Left = 375;
            imgsEscolhendo.Width = 200;
            imgsEscolhendo.Height = 200;
            Controls.Add(imgsEscolhendo);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Reino reino1 = new Reino();
            reino1.criarReino(nome.Text, cont, "teste");
            reino1.Salvando();
            Dispose();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (cont + 1 == listRegion.Length) //Se o contador tiver no tamanho da lista - 1, ele volta pra 0, pra criar um loop de imagemns
            {
                cont = 0;
            }
            else
            {
                cont++;
            }
            region = new Bitmap(listRegion[cont]);
            imgsEscolhendo.Image = region;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (cont == 0) //Se o contador estiver 0, ele volta pro tamanho da lista, pra criar um loop de imagemns
            {
                cont = listRegion.Length - 1;
            }
            else
            {
                cont--;
            }
            region = new Bitmap(listRegion[cont]);
            imgsEscolhendo.Image = region;
        }

        private void rmvText_Click(object sender, EventArgs e)
        {
            nome.Text = string.Empty;
        }
    }
}
