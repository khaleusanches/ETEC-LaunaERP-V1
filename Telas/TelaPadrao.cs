using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Telas
{
    public class TelaPadrao : Form
    {
        public Funcionario funcionario;
        public ButtonP btnMenuBurguer;
        protected MenuP menuPBurguer;

        public TelaPadrao(Funcionario funcionario)
        {
            Bitmap hamburguer = new Bitmap("teste.png");
            Image background = new Bitmap("Launa.png");
            Width = 1200;
            Height = 720;
            this.funcionario = funcionario;
            BackgroundImage = background; 
            Panel barra = new Panel();
            barra.Width = 2000;
            barra.Height = 50;
            barra.BackColor = Color.FromArgb(232, 228, 217);
            Controls.Add(barra);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            this.AutoScaleMode = AutoScaleMode.None;
            btnMenuBurguer = new ButtonP(true, 20, 20, 15, 25, "", this);
            btnMenuBurguer.BackgroundImage = hamburguer;
            btnMenuBurguer.BackgroundImageLayout = ImageLayout.Stretch;
            btnMenuBurguer.BringToFront();
            btnMenuBurguer.Click += new EventHandler(Btn_MenuBurguer_Click);
            
            this.ClientSize = new System.Drawing.Size(1200, 720);

        }

        protected virtual void Btn_MenuBurguer_Click(object sender, EventArgs e)
        {
            if(btnMenuBurguer.atv == true)
            {
                ButtonP[] teste = new ButtonP[] { new ButtonP(true, 200, 25, 35, 25, "DESCONECTAR", this) };
                menuPBurguer = new MenuP(teste, Color.LightSlateGray, 35, 25, 200, 25, this);
                menuPBurguer.exibir(this);
                btnMenuBurguer.atv = false;
                teste[0].Click += new EventHandler(Btn_Desconectar_Click);
            }
            else
            {
                menuPBurguer.fechar(this);
                btnMenuBurguer.atv = true;
            }
        }

        protected void Btn_Desconectar_Click(object sender, EventArgs e)
        {
            Dispose();
            new TelaLogin().ShowDialog();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TelaPadrao
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "TelaPadrao";
            this.ResumeLayout(false);

        }
    }
}
