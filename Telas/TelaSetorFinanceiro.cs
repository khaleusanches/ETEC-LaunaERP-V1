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
    public partial class TelaSetorFinanceiro : TelaPadrao
    {
        InterfacesBanco[] abas = new InterfacesBanco[9];
        ButtonP[] btnAbas = new ButtonP[9];
        ButtonP[] btnContasMenu = new ButtonP[4];
        ButtonP btnContas;
        MenuP menu;
        public TelaSetorFinanceiro(Funcionario funcionario) : base(funcionario)
        {
            this.funcionario = funcionario;
            InitializeComponent();
            abas[0] = new BancoFornecedores();
            abas[1] = new BancoLotes();
            abas[2] = new BancoCatalogoProdutos();
            abas[3] = new BancoOperacoes();
            abas[4] = new BancoContasBancarias();
            abas[5] = new BancoEmprestimos();
            abas[6] = new BancoDespesas();
            abas[7] = new BancoPagarContas();
            abas[8] = new BancoDRE();

            funcionario.FuncionariosSetor(this);
        }
        private void Btn_Fornecedores_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(0);
        }
        private void Btn_Pedidos_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(1);
        }
        private void Btn_Estoque_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(2);
        }
        private void Btn_Operacoes_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(3);
        }
        private void Btn_Bancos_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(4);
        }
        private void Btn_Emprestimos_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(5);
        }
        private void Btn_Despesas_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(6);
        }
        private void Btn_Pagar_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(7);
        }
        private void Btn_DRE_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(8);
        }
        private void Btn_Menu_Click(object sender, EventArgs e)
        {
            if(btnContas.atv == true)
            {
                btnContasMenu[0] = btnAbas[4];
                btnContasMenu[1] = btnAbas[5];
                btnContasMenu[2] = btnAbas[6];
                btnContasMenu[3] = btnAbas[7];
                btnContasMenu[0].atv = false;
                btnContasMenu[1].atv = false;
                btnContasMenu[2].atv = false;
                btnContasMenu[3].atv = false;
                menu = new MenuP(btnContasMenu, Color.LightSlateGray, 37, 525, 200, 60, this);
                menu.exibir(this);
                btnContas.atv = false;
            }
            else
            {
                menu.fechar(this);
                btnContas.atv = true;
            }
        }

        private void Abrir_Fechar_Abas(int nmr)
        {
            if (btnAbas[nmr].atv == false)
            {
                abas[nmr].fechar(this);
                btnAbas[nmr].atv = true;
                btnAbas[nmr].desselecionado();
            }
            else
            {
                for (int i = 0; i < btnAbas.Length; i++)
                {
                    if (btnAbas[i].atv == false)
                    {
                        abas[i].fechar(this);
                        btnAbas[i].atv = true;
                        btnAbas[i].desselecionado();
                    }
                }
                btnAbas[nmr].atv = false;
                abas[nmr].exibir(this);
                btnAbas[nmr].selecionado();
            }

        }
    }
}
