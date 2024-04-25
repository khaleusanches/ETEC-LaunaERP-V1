using CaixaFerramentas;
using Funcionarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL_Estoque;
using TL_Principal;

namespace TL_Gerente
{
    public class TelaGerente : TelaPrincipalEstoque
    {
        protected Gerente gerente;
        protected BtnImage cadasFornecedor;
        protected BtnImage cadasFuncionarios;
        protected TelaFornecedores telaFornecedores;
        protected TelaFuncionarios telafuncionarios;
        public TelaGerente(Gerente gerente) : base(gerente)
        {
            this.gerente = gerente;
            cadasFornecedor = new BtnImage(true, 100, 50, 0, 0, null, null, "Fornecedores", this);
            cadasFornecedor.btn.Click += new EventHandler(cadasFornecedor_Click);
            cadasFornecedor.btn.BackColor = Color.DarkGray;
            cadasFornecedor.btn.BringToFront();

            Estoque.btn.Click += new EventHandler(btn_estoque_click);

            cadasFuncionarios = new BtnImage(true, 100, 50, 0, 200, null, null, "Funcionarios", this);
            cadasFuncionarios.btn.BackColor = Color.DarkGray;
            cadasFuncionarios.btn.BringToFront();
            cadasFuncionarios.btn.Click += new EventHandler(cadasFuncionarios_Click);
        }

        private void cadasFornecedor_Click(object sender, EventArgs e)
        {
            if (cadasFornecedor.atv == true) {
                if (Estoque.atv == false)
                {
                    tela_acesso_estoque.fechar();
                    Estoque.atv = true;
                }
                if(cadasFuncionarios.atv == false)
                {
                    telafuncionarios.fechar();
                    cadasFuncionarios.atv = true;
                }
                telaFornecedores = new TelaFornecedores(this, gerente);
                cadasFornecedor.atv = false;
            }
            else
            {
                telaFornecedores.fechar();
                cadasFornecedor.atv = true;
            }

        }

        private void cadasFuncionarios_Click(object sender, EventArgs e)
        {
            if (cadasFuncionarios.atv == true)
            {
                if (Estoque.atv == false)
                {
                    tela_acesso_estoque.fechar();
                    Estoque.atv = true;
                }
                if (cadasFornecedor.atv == false)
                {
                    telaFornecedores.fechar();
                    cadasFornecedor.atv = true;
                }
                telafuncionarios = new TelaFuncionarios(this, gerente);
                cadasFuncionarios.atv = false;
            }
            else
            {
                telafuncionarios.fechar();
                cadasFuncionarios.atv = true;
            }

        }
        private void btn_estoque_click(object sender, EventArgs e)
        {
            if (cadasFornecedor.atv == false)
            {
                telaFornecedores.fechar();
                cadasFornecedor.atv = true;
            }
            if (cadasFuncionarios.atv == false)
            {
                telafuncionarios.fechar();
                cadasFuncionarios.atv = true;
            }
        }
    }
}
