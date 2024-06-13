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
        public TelaSetorRH()
        {
            InitializeComponent();
        }
        private void Btn_funcionarios_Click(object sender, EventArgs e)
        {
            if (btnFuncionarios.atv == true)
            {
                bancoFuncionarios.exibir(this);
                btnFuncionarios.atv = false;
            }
            else
            {
                bancoFuncionarios.fechar(this);
                btnFuncionarios.atv = true;
            }
        }
    }
}
