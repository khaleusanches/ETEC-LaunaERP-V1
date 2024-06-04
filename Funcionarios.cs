using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    public abstract class Funcionarios
    {
        string nome;
        string tempologado;
        string setor;

        public Funcionarios(string nome, string tempologado)
        {
            this.nome = nome;
            this.tempologado = tempologado;
        }
    }
}
