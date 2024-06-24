using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas
{
    public partial class TelaGerenteVendas : TelaPadrao
    {
        InterfacesBanco[] abas = new InterfacesBanco[2];
        public TelaGerenteVendas(Funcionario funcionario) : base(funcionario) 
        {
            this.funcionario = funcionario;
            InitializeComponent();
            abas[0] = new BancoOperacoes();
            abas[1] = new BancoCatalogoProdutos();
        }
        private void Btn_Operacoes_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(0);
        }

        private void Btn_Produtos_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(1);
        }

        private void Abrir_Fechar_Abas(int nmr)
        {
            funcionario.desativarFuncionariosSetor();
            if (btnAbas[nmr].atv == false)
            {
                abas[nmr].fechar(this);
                btnAbas[nmr].atv = true;
                funcionario.b.Enabled = true;
            }
            else
            {
                for (int i = 0; i < btnAbas.Length; i++)
                {
                    if (btnAbas[i].atv == false)
                    {
                        abas[i].fechar(this);
                        btnAbas[i].atv = true;
                    }
                }
                btnAbas[nmr].atv = false;
                abas[nmr].exibir(this);
                funcionario.b.Enabled = false;
            }
        }

    }
}
