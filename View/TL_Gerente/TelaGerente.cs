using CaixaFerramentas;
using Funcionarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL_Principal;

namespace TL_Gerente
{
    public class TelaGerente : TelaPrincipal
    {
        public Gerente gerente;
        TelaFornecedores fornecedores;
        BtnImage cadasFornecedor;
        BtnImage Estoque;
        BtnImage cadasFuncionario;
        public TelaGerente(Gerente gerente) 
        {
            this.gerente = gerente;
            Panel panel = new Panel();
            panel.Width = 900;
            panel.Height = 50;
            panel.BackColor = Color.DarkGray;
            Controls.Add(panel);

            cadasFornecedor = new BtnImage(true, 100, 50, 0, 0, null, null, "Fornecedores", this);
            Estoque = new BtnImage(true, 100, 50, 0, 100, null, null, "Estoque", this); 
            cadasFuncionario = new BtnImage(true, 100, 50, 0, 200, null, null, "Funcionarios", this);
            cadasFornecedor.btn.BackColor = Color.Blue;
            cadasFornecedor.btn.BringToFront();

            Estoque.btn.BackColor = Color.Blue;
            Estoque.btn.BringToFront();

            cadasFuncionario.btn.BackColor = Color.Blue;
            cadasFuncionario.btn.BringToFront();

            cadasFornecedor.btn.Click += new EventHandler(cadasFornecedor_Click);
        }

        private void cadasFornecedor_Click(object sender, EventArgs e)
        {
            if (cadasFornecedor.atv == true) {
                fornecedores = new TelaFornecedores(this);
                cadasFornecedor.atv = false;
            }
            else
            {
                fornecedores.fechar();
                cadasFornecedor.atv = true;
            }

        }
    }
}
