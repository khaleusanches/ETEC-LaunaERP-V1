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
        BancoFuncionarios bancoFuncionarios = new BancoFuncionarios();
        BancoCargosSetores bancoCargosSetores = new BancoCargosSetores();
        public TelaSetorRH()
        {
            InitializeComponent();
        }
        private void Btn_funcionarios_Click(object sender, EventArgs e)
        {
            if (btnFuncionarios.atv == true)
            {
                if (btnCargosSetores.atv == false)
                {
                    bancoCargosSetores.fechar(this);
                    btnCargosSetores.atv = true;
                }
                bancoFuncionarios.exibir(this);
                btnFuncionarios.atv = false;
            }
            else
            {
                bancoFuncionarios.fechar(this);
                btnFuncionarios.atv = true;
            }
        }
        private void Btn_Cargos_Setores_Click(object sender, EventArgs e)
        {
            if (btnCargosSetores.atv == true)
            {
                if(btnFuncionarios.atv == false)
                {
                    bancoFuncionarios.fechar(this);
                    btnFuncionarios.atv = true;
                }
                bancoCargosSetores.exibir(this);
                btnCargosSetores.atv=false;
            }
            else
            {
                bancoCargosSetores.fechar(this);
                btnCargosSetores.atv = true;
            }
        }
    }
}
