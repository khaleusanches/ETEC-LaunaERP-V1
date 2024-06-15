using CaixaDeFerramentasPerso;
using System;

namespace Telas
{
    partial class TelaGerenteVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ButtonP[] btnAbas = new ButtonP[1];

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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Text = "TelaGerenteVendas";
            btnAbas[0] = new ButtonP(true, 90, 50, 25, 25, "Gerenciar Produtos", this);
            btnAbas[0].BringToFront();
            btnAbas[0].Click += Btn_Operacoes_Click;
        }

      
        #endregion
    }
}