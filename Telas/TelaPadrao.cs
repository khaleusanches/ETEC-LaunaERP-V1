using Logica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas
{
    public abstract class TelaPadrao : Form
    {
        public Funcionario funcionario;
        public TelaPadrao(Funcionario funcionario)
        {
            Width = 1500;
            Height = 720;
            this.funcionario = funcionario;
            BackColor = Color.FromArgb(237, 233, 242);
            Panel barra = new Panel();
            barra.Width = 1500;
            barra.Height = 50;
            barra.BackColor = Color.White;
            Controls.Add(barra);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = true;
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1200, 720);

            FormBorderStyle = FormBorderStyle.None;

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
