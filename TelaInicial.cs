using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoReigns
{
    internal class TelaInicial : Form
    {
        public TelaInicial() {
            Width = 1000;
            Height = 760;
            StartPosition = FormStartPosition.CenterScreen;

            //botões
            btnImage btn1 = new btnImage();  //Nova Run
            btnImage btn2 = new btnImage();  //Continuar de onde parou
            Controls.Add(btn1.btn); // adiciona na tela
            Controls.Add(btn2.btn);

            btn1.criarBTN(true,150, 50, 420, 280, "imgs/img_btn.png", "imgs/img_btnProximoClick.png"); //seta os atributos do objeto
            btn1.btn.Click += new EventHandler(Btn1_Click); // Cria o evento de click

            // Verifica se o arquivo de save ja existe, se sim, libera o botão de continuar
            if (File.Exists("status.txt")){ 
                btn2.criarBTN(true, 150, 50, 420, 350, "imgs/img_btnProximo.png", "imgs/img_btnProximoClick.png");
                btn2.btn.Click += new EventHandler(Btn2_Click);
            }
            else
            {
                btn2.criarBTN(false, 150, 50, 420, 350, "imgs/img_btnProximo.png", "imgs/img_btnProximoClick.png");
            }
        }
        private void Btn1_Click(object sender, EventArgs e)
        {
            Dispose();
            new EscolherRegiao().ShowDialog();
        }
        private void Btn2_Click(object sender, EventArgs e)
        {
        }


    }
}
