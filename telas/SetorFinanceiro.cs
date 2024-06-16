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

namespace SetorFinanceiro
{
    public class SetorFinanceiro : GerMercadorias
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        DataTable DT_consultaID = new DataTable();

        //--------------------------------------------------------------------
        public DataTable ExbFornecedoresNome() 
        {
            dt = banco.consultar(
            "select"
                +" fornecedores.id as 'ID',"
                +" nome as 'Nome',"
                +" razaosocial as 'Razão Social'"               
                +" cnpj as 'CNPJ/CPF',"
                +" email as 'Correio Eletrônico'"
                +" tel as 'Tel',"
                +" obs as '',"
                +" endereco as 'Endereço',"
            +" from fornecedores"
            +" inner join telefones"
            +" on idfornecedorfk = fornecedores.id"
            +"order by fornecedores.id");
            return dt;
        }
        
        public DataTable ExbFornecedoresID() 
        {
            dt = banco.consultar(
            "select"
                +" fornecedores.id as 'ID',"
                +" nome as 'Nome',"
                +" razaosocial as 'Razão Social'"               
                +" cnpj as 'CNPJ/CPF',"
                +" email as 'Correio Eletrônico'"
                +" tel as 'Tel',"
                +" obs as '',"
                +" endereco as 'Endereço',"
            +" from fornecedores"
            +" inner join telefones"
            +" on idfornecedorfk = fornecedores.id"
            +"order by nome");
            return dt;
        }
        //-----------------------------

        // CadFornecedor e CadTel ficam no mesmo lugar mas executam duas funções por ser 2 tabelas diferentes
        public void CadFornecedor(string nome, string razaosocial, string cnpj, string email, string endereco)
        {
          banco.comandar(
            "insert into fornecedores(nome, cnpj, email, endereco) " +
            "values ('"+nome+"', '"+razaosocial+"', '"+cnpj+"', '"+email+"', '"+endereco+"')");
            fechar();
        }
        public void CadTel(int fornecedor, string tel, string obs)
        {
          banco.comandar(
            "insert into telefones(idfornecedorfk, tel, obs) " +
            "values ('"+fornecedor+"', '"+tel+"', '"+obs+"')");
            fechar();
        }
        //-----------------------------      
        public void DelFornecedor(int i)
        {
            banco.comandar("Delete * from telefones where idfornecedoresfk = '"+i+"'");
            fechar();
            banco.comandar("Delete * from fornecedores where id = '"+i+"'");
            fechar();
        }
        
        public void DelTelefone(int i)
        {
            banco.comandar("Delete * from telefones where idfornecedoresfk = '"+i+"'");
            fechar();
        }
        //-----------------------------
        // AtuFornecedor e AtuTel ficam no mesmo lugar mas executam duas funções por ser 2 tabelas diferentes
        public void AtuFornecedor(string nome, steing razaosocial, string cnpj, string email, string endereco) 
        {
            banco.comandar(
                "update fornecedores set"
                    +" nome = '"+nome+"',"
                    +" razaosocial = '"+razaosocial+"',"
                    +" cnpj = '"+cnpj+"',"
                    +" email = '"+email+"',"
                    +" endereco = '"+endereco+"'"
                +" where id = '"+i+"'");
            fechar();
        }
        public void AtuTel(int fornecedor, string tel, string obs)
        {
            banco.comandar(
                "update fornecedores set"
                    +" idfornecedorfk = '"+fornecedor+"',"
                    +" tel = '"+tel+"',"
                    +" obs = '"+obs+"'"
                +" where id = '"+i+"'");
            fechar();
        }
 //--------------------------------------------------------------------        
 //--------------------------------------------------------------------        
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
        public DataTable ExbFuncionariosID() 
        {
            dt = banco.consultar(
            "select"
                +" id as 'ID',"
                +" funcionarios.nome as 'Nome',"
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
            +" order by funcionario.id"
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
                +" idclassefk as 'Classe'"
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
                +" idclassefk as 'Classe'"
                +" email as 'Email',"
                +" tel as 'Telefone', pis as 'PIS',"
                +" admissao as 'Data de admissão',"
                +" salario as 'Salário',"
                +" desconto as 'Desconto de Funcionário'"
            +" from funcionarios"
            +" inner join cargos on idcargofk = cargo.id"
            +" and idsetorfk = '"+i+"'"
            );
            return dt;
        }
        //--------------------------------------------------------------------                    
                         
        public void fechar()
        {
            dt.Clear();
        }
    }
}
