using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BancoDados;
using TL_Principal;
using TL_Gerente;
using TL_Estoque;

namespace SetorRH
{
    public class SetorRH 
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        DataTable DT_consultaID = new DataTable();




        
        public DataTable ExbFuncionarios() 
        {
            dt = banco.consultar(
            "select"
                +" funcionarios.nome as 'Nome',"
                +" id as 'ID', cargos.nome as 'Cargo',"
                +" setores.nome as 'Setor', email as 'Email',"
                +" tel as 'Telefone', pis as 'PIS',"
                +" admissao as 'Data de admissão',"
                +" salario as 'Salário',"
                +" desconto as 'Desconto de Funcionário'"
            +" from funcionarios"
            +" inner join cargos on idcargofk = cargo.id"
            +" inner join setores on idsetorfk = setores.id");
            return dt;
        }
        
        public void CadFuncionario(string nome, string cargo, string setor, string email, string tel, string pis, string admissao, string salario, string desconto)
        {
          banco.comandar(
            "insert into funcionarios(nome, idcargofk, idsetorfk, email, tel, pis, admissao, salario, desconto) "+
            "values ('"+nome+"','"+cargo+"','"+setor+"','"+email+"','"tel+"','"+pis+"','"+admissao+"','"+salario,+"','"+desconto+"')");
            fechar();
        }
        public void DelFuncionario(int i)
        
        {
            banco.comandar("Delete * from funcionarios where id = '"+i+"'");
            fechar();
        }
        
        public void AtuFuncionario(int i, string nome, string cargo, string setor, string email, string tel, string pis, string admissao, string salario, string desconto) 
        {
            banco.comandar(
                "update funcionarios set"
                    +" nome = '"+nome+"',"
                    +" cargo = '"+cargo+"',"
                    +" setor = '"+setor+"',"
                    +" email = '"+email+"',"
                    +" tel = '"+tel+"',"
                    +" pis ='"+pis+"',"
                    +" admissao = '"+admissao+"',"
                    +" salario = '"+salario+"',"
                    +" desconto = '"+desconto"
                +" where id = '"+i+"'");
            fechar();
        }
        
        public DataTable ExbSetores() 
        {
            dt = banco.consultar(
            "select	id as 'ID', nome as 'Nome' from setores");
            return dt;
        }
        
        public void CadSetor(string nome)
        {
          banco.comandar(
            "insert into setores(nome) values ('"+nome+"')");
            fechar();
        }
        
        public void DelSetor(int i)
        {
          dt = banco.consultar(
              "select setores.nome as 'Setor',"
                +" cargos.nome as 'Cargo',"
                +" nome as 'Nome',"
                +" email as 'Email',"
                +" tel as 'Telefone',"
                +" pis as 'PIS',"
                +" admissao as 'Data de admissão',"
                +" salario as 'Salário',"
                +" from funcionarios"
            +" inner join cargos on idcargofk = cargo.id"
            +" inner join setores on idsetorfk = '"+i+"'"
          );
          if (dt != null) {
            Console.WriteLine("Este setor não pode ser deletado. Remova os funcionários pertencentes à este setor.");
          }
          else {
            banco.comandar("Delete * from setores where id = '"+i+"'");
            fechar();
          }
        }
        
        public void AtlSetor(int id, string nome) 
        {
            banco.comandar(
                "update setores set"
                    +" id = '"+id+"',"
                    +" nome = '"+nome+"'");
            fechar();
        }

        
        public DataTable ExbCargos() 
        {
            dt = banco.consultar(
            "select	id as 'ID', nome as 'Nome' from cargos");
            return dt;
        }
        
        public void CadCargo(string nome)
        {
          banco.comandar(
            "insert into cargos(nome) values ('"+nome+"')");
            fechar();
        }
        
        public void DelCargo(int i)
        {
          dt = banco.consultar(
              "select cargos.nome as 'Cargo',"
                  +" setores.nome as 'Setor',"
                  +" nome as 'Nome',"
                  +" email as 'Email',"
                  +" tel as 'Telefone',"
                  +" pis as 'PIS',"
                  +" admissao as 'Data de admissão',"
                  +" salario as 'Salário',"
                  +" from funcionarios"
              +" inner join cargos on idcargofk = cargo.id"
              +" inner join setores on idsetorfk = '"+i+"'");
          if (dt != null) {
            Console.WriteLine("Este cargo não pode ser deletado. Remova os funcionários pertencenter à este cargo.");
          }
          else {
            banco.comandar("Delete * from cargps where id = '"+i+"'");
            fechar();
          }
        }
        
        public void AtlCargo(int id, string nome, string descricap) 
        {
            banco.comandar(
                "update cargos set"
                    +" id = '"+id+"',"
                    +" nome = '"+nome+"',"
                    +" descricao = '"+descricao+"'");
            fechar();
        }
                           
                         
        public void fechar()
        {
            dt.Clear();
        }
    }
}
