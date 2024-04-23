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
        protected BtnImage cadasFornecedor;
        public TelaGerente(Gerente gerente) 
        {
            this.gerente = gerente;
            
            
            cadasFornecedor = new BtnImage(true, 100, 50, 0, 0, null, null, "Fornecedores", this);
            cadasFornecedor.btn.Click += new EventHandler(cadasFornecedor_Click);
            cadasFornecedor.btn.Visible = true;
            cadasFornecedor.btn.BackColor = Color.Blue;
            cadasFornecedor.btn.BringToFront();
            cadasFornecedor.btn.Visible = false;
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
