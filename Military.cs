using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoReigns
{
    internal class Military : Form
    {
        Reino reino;
        kingdom tela;
        int soldados_slot1;
        int soldados_slot2;
        int soldados_slot3;
        public PictureBox background = new PictureBox();
        Label lb_slot1 = new Label();
        Label lb_slot2 = new Label();
        Label lb_slot3 = new Label();
        Label lb_total_soldados = new Label();
        btnImage btn_fechar = new btnImage(true, 32, 32, 128, 0, "imgs/img_btnProximo.png", "imgs/img_btn.png");
        btnImage btn_slot1 = new btnImage(true, 32, 32, 64,64, "imgs/img_btnProximo.png", "imgs/img_btn.png");
        btnImage btn_slot2 = new btnImage(false, 32, 32, 256, 64, "imgs/img_btnProximo.png", "imgs/img_btn.png");
        btnImage btn_slot3 = new btnImage(false, 32, 32, 384, 64, "imgs/img_btnProximo.png", "imgs/img_btn.png");
        btnImage btn_salvar = new btnImage(true, 32, 32, 448, 64, "imgs/img_btn.png", "imgs/img_btnProximo.png");

        public Military(kingdom tela, Reino reino)
        {
            if (reino.level >= 2)
            {
                btnImage btn_slot2 = new btnImage(true, 32, 32, 256, 64, "imgs/img_btnProximo.png", "imgs/img_btn.png");
                btn_slot2.btn.Click += new EventHandler(btn_slot2_Click);
            }
            else
            {
                btn_slot2.btn.Click += new EventHandler(btn_bloqueado_Click);
            }
            if (reino.level >= 3)
            {
                btnImage btn_slot3 = new btnImage(false, 32, 32, 256, 64, "imgs/img_btnProximo.png", "imgs/img_btn.png");
                btn_slot3.btn.Click += new EventHandler(btn_slot3_Click);
            }
                this.reino = reino;
                this.tela = tela;
                soldados_slot1 = reino.slot1;
                soldados_slot2 = reino.slot2;
                soldados_slot3 = reino.slot3;

                background.Width = 720;  //background da telinha
                background.Height = 120;
                background.BackColor = System.Drawing.Color.Black;
                tela.Controls.Add(background);

                lb_total_soldados.Text = "Total de soldados: " + reino.total_soldados.ToString();
                lb_total_soldados.ForeColor = System.Drawing.Color.White;
                lb_total_soldados.BackColor = System.Drawing.Color.Black;
                
                lb_slot1.Text = "Grupo 1 de soldados: " + soldados_slot1.ToString();  
                lb_slot2.Text = "Grupo 2 de soldados: " + soldados_slot2.ToString();
                lb_slot3.Text = "Grupo 3 de soldados: " + soldados_slot3.ToString();
                lb_slot1.ForeColor = System.Drawing.Color.White;
                lb_slot1.BackColor = System.Drawing.Color.Black;
                lb_slot2.ForeColor = System.Drawing.Color.White;
                lb_slot2.BackColor = System.Drawing.Color.Black;
                lb_slot3.ForeColor = System.Drawing.Color.White;
                lb_slot3.BackColor = System.Drawing.Color.Black;
                lb_slot3.Top = 64;
                lb_slot3.Left = 320;
                lb_slot2.Left = 128;
                lb_slot2.Top = 64;
                lb_slot1.Top = 64;

                tela.Controls.Add(lb_total_soldados);
                tela.Controls.Add(lb_slot1);
                tela.Controls.Add(lb_slot2);
                tela.Controls.Add(lb_slot3);

                tela.Controls.Add(btn_slot1.btn);
                tela.Controls.Add(btn_slot2.btn);
                tela.Controls.Add(btn_slot3.btn);
                tela.Controls.Add(btn_salvar.btn);
                tela.Controls.Add(btn_fechar.btn);


                lb_total_soldados.BringToFront();
                lb_slot1.BringToFront();
                lb_slot2.BringToFront();
                lb_slot3.BringToFront();
                btn_slot1.btn.BringToFront();
                btn_slot2.btn.BringToFront();
                btn_slot3.btn.BringToFront();
                btn_salvar.btn.BringToFront();
                btn_fechar.btn.BringToFront();

                btn_slot1.btn.Click += new EventHandler(btn_slot1_Click);
                
                btn_salvar.btn.Click += new EventHandler(btn_salvar_Click);
                btn_fechar.btn.Click += new EventHandler(btn_fechar_Click);

            
        }
        private void btn_slot1_Click(object sender, EventArgs e)
        {
            if (soldados_slot1 + soldados_slot2 + soldados_slot3 < reino.total_soldados) { 
                soldados_slot1++;
                lb_slot1.Text = "Grupo 1 de soldados: " + soldados_slot1.ToString();
            }
            else
            {
                soldados_slot1 = 0;
                lb_slot1.Text = "Grupo 1 de soldados: "+soldados_slot1.ToString();
            }
        }

        private void btn_slot2_Click(object sender, EventArgs e)
        {
            if (soldados_slot1 + soldados_slot2 + soldados_slot3 < reino.total_soldados)
            {
                soldados_slot2++;
                lb_slot2.Text = "Grupo 2 de soldados: " + soldados_slot2.ToString();
            }
            else
            {
                soldados_slot2 = 0;
                lb_slot2.Text = "Grupo 2 de soldados: " + soldados_slot2.ToString();
            }
        }

        private void btn_slot3_Click(object sender, EventArgs e)
        {
            if (soldados_slot1 + soldados_slot2 + soldados_slot3 < reino.total_soldados)
            {
                soldados_slot3++;
                lb_slot3.Text = "Grupo 3 de soldados: " + soldados_slot3.ToString();
            }
            else
            {
                soldados_slot3 = 0;
                lb_slot3.Text = "Grupo 3 de soldados: " + soldados_slot3.ToString();
            }
        }
        private void btn_salvar_Click(object sender, EventArgs e)
        {
            reino.slot1 = soldados_slot1;
            reino.slot2 = soldados_slot2;
            reino.slot3 = soldados_slot3;
            reino.Salvando();
        }
        private void btn_fechar_Click(object sender, EventArgs e)
        {
            tela.Controls.Remove(btn_salvar.btn);
            tela.Controls.Remove(background);
            tela.Controls.Remove(btn_slot1.btn);
            tela.Controls.Remove(btn_slot2.btn);
            tela.Controls.Remove(btn_slot3.btn);
            tela.Controls.Remove(lb_total_soldados);
            tela.Controls.Remove(lb_slot1);
            tela.Controls.Remove(lb_slot2);
            tela.Controls.Remove(lb_slot3);
            tela.Controls.Remove(btn_fechar.btn);
            tela.Controls.Add(tela.btn.btn);
        }

        private void btn_bloqueado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você não tem level suficiente");
        }
    }
}
