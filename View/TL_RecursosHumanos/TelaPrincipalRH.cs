using CaixaFerramentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using TL_Principal;
using Funcionarios;

namespace TL_RecursosHumanos
{
    public class TelaPrincipalRH : TelaPrincipal
    {
        

        protected BtnImage cadasFuncionario;
        public Gerente gerente = new Gerente();
        public TelaPrincipalRH()
       {
            
            cadasFuncionario = new BtnImage(true, 100, 50, 0, 200, null, null, "Funcionarios", this);
            cadasFuncionario.btn.BackColor = Color.Blue;
            cadasFuncionario.btn.BringToFront();
            cadasFuncionario.btn.Visible = false;

       } 
    }
}
