using CaixaDeFerramentasPerso;
using System.Drawing;
using System.Windows.Forms;

namespace Telas
{
    partial class atualizarFuncionarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(string[] listCargo, string[] listSetores)
        {
            this.SuspendLayout();


            // 
            // atualizarFuncionarios
            // 
            this.Name = "atualizarFuncionarios";
            this.ResumeLayout(false);
            this.PerformLayout();

            container[0] = new PanelP(490, 165, 85, 20, Color.White, this);
            labelPs[1] = new LabelP(250, 20, 100, 35, "DADOS PESSOAIS", this);
            labelPs[1].Font = new Font("Arial", 12, FontStyle.Bold);

            labelPs[2] = new LabelP(30, 20, 130, 35, "ID:", this);
            labelPs[3] = new LabelP(100, 20, 130, 75, "Nome:", this);
            labelPs[4] = new LabelP(100, 20, 130, 175, "Email:", this);
            labelPs[5] = new LabelP(100, 20, 130, 335, "Tel:", this);
            labelPs[6] = new LabelP(100, 20, 195, 35, "CEP:", this);

            textBoxPs[0] = new TextBoxP(30, 25, 150, 35, "", 9, this);
            textBoxPs[0].Enabled = false;

            textBoxPs[1] = new TextBoxP(90, 25, 150, 75, "", 64, this);
            textBoxPs[1].Enabled = false;

            textBoxPs[2] = new TextBoxP(150, 25, 150, 175, "", 100, this);
            textBoxPs[3] = new TextBoxP(150, 25, 150, 335, "", 11, this);
            textBoxPs[4] = new TextBoxP(150, 25, 215, 35, "", 200, this);


            container[1] = new PanelP(490, 165, 315, 20, Color.White, this);
            labelPs[9] = new LabelP(250, 20, 330, 35, "OUTROS DADOS", this);
            labelPs[9].Font = new Font("Arial", 12, FontStyle.Bold);

            labelPs[10] = new LabelP(100, 20, 360, 35, "Salario:", this);
            labelPs[11] = new LabelP(100, 20, 360, 175, "Cargo:", this);
            labelPs[12] = new LabelP(100, 20, 360, 325, "Setores:", this);


            textBoxPs[5] = new TextBoxP(110, 25, 380, 35, "", 9, this);
            cbCargos = new ComboBoxP(100, 25, 380, 175, listCargo, this);
            cbSetores = new ComboBoxP(130, 25, 380, 325, listSetores, this);
            this.ClientSize = new System.Drawing.Size(530, 720);
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        #endregion
        private LabelP[] labelPs = new LabelP[13];
        private PanelP[] container = new PanelP[2];
        private ComboBoxP cbCargos;
        private ComboBoxP cbSetores;
        private ButtonP btnConcluir;
        private TextBoxP[] textBoxPs = new TextBoxP[6];
    }
}