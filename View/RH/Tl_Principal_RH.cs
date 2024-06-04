using CaixaDeFerramentasPerso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema;
using Sistema.Cargos;

namespace View.RH
{
    public class Tl_Principal_RH : Tl_Padrao
    {
        ButtonP btn_funcionarios;
        Banco_Funcionarios banco;
        AuxiliarRH auxiliar;
        public Tl_Principal_RH(AuxiliarRH auxiliar)
        {
            btn_funcionarios = new ButtonP(true, 90, 50, 25, 25, "Gerenciar Funcionarios", this);
            btn_funcionarios.BringToFront();
            btn_funcionarios.Click += Btn_funcionarios_Click;
            this.auxiliar = auxiliar;
            banco = new Banco_Funcionarios(auxiliar);
        }
        private void Btn_funcionarios_Click(object sender, EventArgs e)
        {
            if(btn_funcionarios.atv == true) {
                banco.exibir(this);
                btn_funcionarios.atv = false;
            }
            else
            {
                banco.fechar(this);
                btn_funcionarios.atv = true;
            }
        }
    }
}
