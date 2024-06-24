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
    public partial class TelaAdministrador : TelaSetorFinanceiro
    {
        public TelaAdministrador(Funcionario funcionario) : base(funcionario)
        {
            
        }
        protected override void Btn_MenuBurguer_Click(object sender, EventArgs e)
        {
            if (btnMenuBurguer.atv == true)
            {
                ButtonP[] teste = new ButtonP[2] { new ButtonP(true, 200, 25, 35, 25, "DESCONECTAR", this), new ButtonP(true, 200, 25, 60, 25, "RH", this) };
                menuPBurguer = new MenuP(teste, Color.LightSlateGray, 35, 25, 200, 85, this);
                menuPBurguer.exibir(this);
                btnMenuBurguer.atv = false;
                teste[0].Click += new EventHandler(Btn_Desconectar_Click);
                teste[1].Click += new EventHandler(Btn_RH_Click);
            }
            else
            {
                menuPBurguer.fechar(this);
                btnMenuBurguer.atv = true;
            }
        }

        private void Btn_RH_Click(object sender, EventArgs e)
        {
            TelaSetorRH RH = new TelaSetorRH(funcionario);
            RH.btnMenuBurguer.Visible = false;
            RH.ShowDialog();
        }
    }
}
