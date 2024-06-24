using CaixaDeFerramentasPerso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class Funcionario
    {
        public string id;
        public string nome;
        public string login;
        public string setor;
        public string cargo;
        public ButtonP b;
        public Funcionario(string id, string nome, string login, string setor, string cargo) 
        {
            this.id = id;
            this.nome = nome;
            this.login = login;
            this.setor = setor;
            this.cargo = cargo;
            b = new ButtonP(true, 0, 0, 0, 0, "", null);
        }
        public virtual void desativarFuncionariosSetor() { }
    }
}
