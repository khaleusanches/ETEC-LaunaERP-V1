using CaixaDeFerramentasPerso;
using System;

namespace Telas
{
    partial class TelaSetorFinanceiro
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
            this.Text = "TelaSetorFinanceiro";
            btnAbas[0] = new ButtonP(true, 90, 50, 25, 25, "Gerenciar Fornecedores", this);
            btnAbas[0].BringToFront();
            btnAbas[0].Click += Btn_Fornecedores_Click;
            btnAbas[1] = new ButtonP(true, 90, 50, 25, 140, "Gerenciar Pedidos", this);
            btnAbas[1].BringToFront();
            btnAbas[1].Click += Btn_Pedidos_Click;
            btnAbas[2] = new ButtonP(true, 90, 50, 25, 255, "Estoque", this);
            btnAbas[2].BringToFront();
            btnAbas[2].Click += Btn_Estoque_Click;
            btnAbas[3] = new ButtonP(true, 90, 50, 25, 370, "Operações dos caixa", this);
            btnAbas[3].BringToFront();
            btnAbas[3].Click += Btn_Operacoes_Click;
            btnContas = new ButtonP(true, 90, 50, 25, 485, "Contas", this);
            btnContas.BringToFront();
            btnContas.Click += Btn_Menu_Click;

            btnAbas[4] = new ButtonP(true, 200, 35, 75, 485, "Contas Bancarias", null);
            btnAbas[4].Click += Btn_Bancos_Click;
            btnAbas[5] = new ButtonP(true, 200, 35, 110, 485, "EMPRÉSTIMOS", null);
            btnAbas[5].Click += Btn_Emprestimos_Click;
        }
        #endregion
    }
}