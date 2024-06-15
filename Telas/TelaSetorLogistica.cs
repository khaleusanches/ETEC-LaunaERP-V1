using CaixaDeFerramentasPerso;
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
    public partial class TelaSetorLogistica : TelaPadrao
    {
        InterfacesBanco[] abas = new InterfacesBanco[1];

        public TelaSetorLogistica(Funcionario funcionario) : base(funcionario)
        {
            this.funcionario = funcionario;
            InitializeComponent();
            abas[0] = new BancoCatalogoProdutos();
            funcionario.FuncionariosSetor(this);
        }
        private void Btn_Catalogo_Produtos_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(0);
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
