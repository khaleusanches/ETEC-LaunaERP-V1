using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Funcionario
    {
        public string nome;
        public string login;
        public string setor;
        public string cargo;
        public Funcionario(string nome, string login, string setor, string cargo) 
        {
            this.nome = nome;
            this.login = login;
            this.setor = setor;
            this.cargo = cargo;
        }
    }
}
