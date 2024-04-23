using CaixaFerramentas;
using Funcionarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL_Principal;

namespace TL_Estoque
{
    public class TelaPrincipalEstoque : TelaPrincipal
    {
        protected BtnImage Estoque;
        public Gerente gerente = new Gerente();
        public TelaPrincipalEstoque(Funcionario funcionario) 
        {
            Estoque = new BtnImage(true, 100, 50, 0, 100, null, null, "Estoque", this);
            Estoque.btn.BackColor = Color.DarkGray;
            Estoque.btn.BringToFront();
            int nv = funcionario.getnv();
            if (nv <3)
            {
                Estoque.btn.Visible = false;
            }
            Estoque.btn.Click += new EventHandler(estoque_Click);
        }

        private void estoque_Click(object sender, EventArgs e)
        {
            new TelaAcessoEstoque(this);
        }
    }
}
