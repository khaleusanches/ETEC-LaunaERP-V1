﻿using CaixaDeFerramentasPerso;
using System;

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
            this.components = new System.ComponentModel.Container();
            this.Text = "TelaSetorRH";
            btnAbas[0] = new ButtonP(true, 90, 50, 25, 25, "Gerenciar Funcionarios", this);
            btnAbas[0].BringToFront();
            btnAbas[0].Click += Btn_funcionarios_Click;
            btnAbas[1] = new ButtonP(true, 90, 50, 25, 125, "Gerenciar Cargos & Setores", this);
            btnAbas[1].BringToFront();
            btnAbas[1].Click += new System.EventHandler(Btn_Cargos_Setores_Click);
            btnAbas[2] = new ButtonP(true, 90, 50, 25, 225, "Gerenciar Usuarios", this);
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