using CaixaDeFerramentasPerso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class Gerente : Funcionario
    {
        private Form tela;
        private DAO dao = new DAO();
        DataGridViewP dgv;
        
        public Gerente(string id, string nome, string login, string setor) : base(id, nome, login, setor, "Gerente")
        {
            
        }
        public override void FuncionariosSetor(Form tela)
        {
            this.tela = tela;
            b = new ButtonP(true, 100, 50, 25, 875, $"Funcionarios do {this.setor}", tela);
            b.BringToFront();
            b.Click += new EventHandler(B_Click);
        }
        public override void desativarFuncionariosSetor() 
        {
            tela.Controls.Remove(dgv);
            b.atv = true;
        }
        private void B_Click(object sender, EventArgs e)
        {
            if (b.atv == true)
            {
                dgv = new DataGridViewP(300, 200, 125, 500, dao.lerTabela($"Select funcionarios.nome, setores.nome from funcionarios inner join setores on funcionarios.idsetorfk = setores.id where setores.nome = '{this.setor}';"), tela);
                b.atv = false;
            }
            else
            {
                desativarFuncionariosSetor();
            }
        }

    }
}
