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
    }
}
