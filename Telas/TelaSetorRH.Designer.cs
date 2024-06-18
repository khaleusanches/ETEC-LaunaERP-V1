using CaixaDeFerramentasPerso;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Telas
{
    partial class TelaSetorRH : TelaPadrao
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
        private void InitializeComponent()
        {
            Bitmap hamburguer = new Bitmap("teste.png");

            this.components = new System.ComponentModel.Container();
            this.Text = "TelaSetorRH";
            ButtonP menuBurguer = new ButtonP(true, 20, 20, 15, 25, "", this);
            menuBurguer.BackgroundImage = hamburguer;
            menuBurguer.BackgroundImageLayout = ImageLayout.Stretch;
            menuBurguer.BringToFront();

            btnAbas[0] = new ButtonP(true, 100, 25, 12, 125, "Funcionários", this);
            btnAbas[0].BringToFront();
            btnAbas[0].Click += Btn_funcionarios_Click;

            btnAbas[1] = new ButtonP(true, 115, 25, 12, 235, "Cargos | Setores", this);
            btnAbas[1].BringToFront();
            btnAbas[1].Click += new System.EventHandler(Btn_Cargos_Setores_Click);
            btnAbas[2] = new ButtonP(true, 90, 25, 12, 360, "Usuarios", this);
            btnAbas[2].BringToFront();
            btnAbas[2].Click += new System.EventHandler(Btn_Usuarios_Click);
            if(funcionario.cargo != "Gerente")
            {
                Controls.Remove(btnAbas[2]);
            }
        }
        #endregion
    }
}