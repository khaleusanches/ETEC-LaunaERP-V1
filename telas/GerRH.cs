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

namespace GerRH
{
    public class GerRH 
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        DataTable DT_consultaID = new DataTable();
//-----------------------------
        
        public DataTable ExbFuncionariosNome() 
        {
            dt = banco.consultar(
            "select"
                +" funcionarios.nome as 'Nome',"
                +" id as 'ID',"
                +" cargos.nome as 'Cargo',"
                +" setores.nome as 'Setor',"
                +" classe as 'Classe'"
                +" email as 'Email',"
                +" tel as 'Telefone', pis as 'PIS',"
                +" admissao as 'Data de admissão',"
                +" salario as 'Salário',"
                +" desconto as 'Desconto de Funcionário'"
            +" from funcionarios"
            +" inner join cargos on idcargofk = cargo.id"
            +" inner join setores on idsetorfk = setores.id"
            +" order by funcionario.nome"
            );
            return dt;
        }
        public DataTable ExbFuncionariosSetor() 
        {
            dt = banco.consultar(
            "select"
                +" setores.nome as 'Setor',"
                +" funcionarios.nome as 'Nome',"
                +" id as 'ID',"
                +" cargos.nome as 'Cargo',"
                +" classe as 'Classe'"
                +" email as 'Email',"
                +" tel as 'Telefone', pis as 'PIS',"
                +" admissao as 'Data de admissão',"
                +" salario as 'Salário',"
                +" desconto as 'Desconto de Funcionário'"
            +" from funcionarios"
            +" inner join cargos on idcargofk = cargo.id"
            +" inner join setores on idsetorfk = setores.id"
            +" order by setores.nome"
            );
            return dt;
        }
        public DataTable ExbFuncionariosSetorSelecionado(int i) 
        {
            dt = banco.consultar(
            "select"
                +" funcionarios.nome as 'Nome',"
                +" id as 'ID',"
                +" cargos.nome as 'Cargo',"
                +" classe as 'Classe'"
                +" email as 'Email',"
                +" tel as 'Telefone', pis as 'PIS',"
                +" admissao as 'Data de admissão',"
                +" salario as 'Salário',"
                +" desconto as 'Desconto de Funcionário'"
            +" from funcionarios"
            +" inner join cargos on idcargofk = cargo.id"
            +" inner join setores on idsetorfk = setores.id"
            +" and idsetorfk = '"+i+"'"
            );
            return dt;
        }
        //-----------------------------
        public void CadFuncionario(string nome, string cargo, string classe, string setor, string email, string tel, string rg, int nascimento, string pis, string endereco, int admissao, int salario, string login, string senha, string desconto)
        {
            banco.comandar(
            "insert into funcionarios(nome, idcargofk, idsetorfk, classe, email, tel, rg, nascimento, pis, endereco, admissao, salario, login, senha, desconto) "+
            "values ('"+nome+"','"+cargo+"','"+setor+"','"+classe+"','"+email+"','"tel+"','"+rg+"','"+nascimento+"','"+pis+"','"+endereco+"','"+admissao+"','"+salario,+"','"+login+"','"+senha+"','"+desconto+"')");
            fechar();
        }
        //-----------------------------
        public void DelFuncionario(int i)        
        {
            banco.comandar("Delete * from funcionarios where id = '"+i+"'");
            fechar();
        }
        //-----------------------------
        public void AtuFuncionario(int i, string nome, string cargo, string classe, string setor, string email, string tel, string rg, int nascimento, string pis, string endereco, int admissao, int salario, string login, string senha, string desconto)
        {
            banco.comandar(
                "update funcionarios set"
                    +" nome = '"+nome+"',"
                    +" cargo = '"+cargo+"',"
                    +" setor = '"+setor+"',"
                    +" classe = '"+classe+"',"
                    +" email = '"+email+"',"
                    +" tel = '"+tel+"',"
                    +" rg = '"+rg+"',"
                    +" nascimento = '"+nascimento+"',"
                    +" pis ='"+pis+"',"
                    +" endereco = '"+endereco+"',"
                    +" admissao = '"+admissao+"',"
                    +" salario = '"+salario+"',"
                    +" login ='"+login+"',"
                    +" senha ='"+senha+"',"
                    +" desconto = '"+desconto"
                +" where id = '"+i+"'");
            fechar();
        }
        //--------------------------------------------------------------------
        public DataTable ExbSetoresNome() 
        {
            dt = banco.consultar("select nome as 'Nome', id as 'ID' from setores order by nome");
            return dt;
        }
        
        public DataTable ExbSetoresID() 
        {
            dt = banco.consultar("select id as 'ID', nome as 'Nome' from setores order by id");
            return dt;
        }
        
        public void CadSetor(int id, string nome) 
        {
            banco.comandar(
                "insert into setores(id, nome) values '"+id+"', '"+nome+"'");
            fechar();
        }
        
        public void DelSetor(int i)
        {
            dt = banco.consultar("select idsetorfk from funcionarios where idsetorfk = '"+i+"'");
              if (dt != null) {}
              else { banco.comandar("Delete * from setores where id = '"+i+"'");
            fechar(); }
        }
        
        public void AtuSetor(int i, int id, string nome) 
        {
            banco.comandar("update setores set id = '"+id+"', nome = '"+nome+"' where id = '"+i+"'");
            fechar();
        }
//--------------------------------------------------------------------
        
        public DataTable ExbCargos() 
        {
            dt = banco.consultar("select nome as 'Nome', id as 'ID', descricao as 'Descrição' from cargos order by nome");
            return dt;
        }
        
         public DataTable ExbID() 
        {
            dt = banco.consultar("select id as 'ID', nome as 'Nome', descricao as 'Descrição' from cargos order by id");
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
            dt = banco.consultar("select idcargofk from funcionarios where idsetorfk = '"+i+"'");
              if (dt != null) {}
              else { banco.comandar("Delete * from cargos where id = '"+i+"'");
            fechar(); }
        }
        
        public void AtuCargo(int id, string nome, string descricap) 
        {
            banco.comandar( "update cargos set id = '"+id+"', nome = '"+nome+"', descricao = '"+descricao+"' where id = '"+i+"'");
            fechar();
        }
                           
                         
        public void fechar()
        {
            dt.Clear();
        }
    }
}
