using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funcionarios
{
    public class Funcionario
    {
        int id;
        protected int nv;
        string nome;
        string cpf;
        string data_nascimento;
        string endereco;
        string data_adm;
        int id_setor;
        string func;
        double salario;

        string login;
        string password;
        int desconto;
        public Funcionario()
        {

        }
        public void criarFuncionario(int id, string login, string password, int nv)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.nv = nv;
        }
        public void exibir()
        {
            Console.WriteLine(id.ToString(), nv, nome, cpf, data_nascimento, endereco, data_adm, id_setor, func, salario, login, password, desconto);
        }
        public int getnv()
        {
            return nv;
        }
    }
}
