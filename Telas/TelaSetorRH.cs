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
    public partial class TelaSetorRH : TelaPadrao
    {
        InterfacesBanco[] abas = new InterfacesBanco[3];
        ButtonP[] btnAbas = new ButtonP[3];

        public TelaSetorRH(Funcionario funcionario) : base (funcionario)
        {
            this.funcionario = funcionario;
            InitializeComponent();
            abas[0] = new BancoFuncionarios();
            abas[1] = new BancoCargosSetores();
            abas[2] = new BancoUsuarios();
        }
        private void Btn_funcionarios_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(0);
        }
        private void Btn_Cargos_Setores_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(1);
        }
        private void Btn_Usuarios_Click(object sender, EventArgs e)
        {
            Abrir_Fechar_Abas(2);
        }

        private void Abrir_Fechar_Abas(int nmr)
        {
            if (btnAbas[nmr].atv == false)
            {
                abas[nmr].fechar(this);
                btnAbas[nmr].atv = true;
                btnAbas[nmr].desselecionado();
            }
            else { 
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
