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
        public DataTable ExbFornecedores() 
        {
            dt = banco.consultar(
            "select"
                +" fornecedores.id as 'ID',"
                +" nome as 'Fornecedor',"
                +" cnpj as 'CNPJ',"
                +" email as 'Correio Eletrônico'"
                +" tel as 'Tel',
                +" obs as '',""
                +" endereco as 'Endereço',"
            +" from fornecedores"
            +" inner join telefones on idfornecedorfk = fornecedores.id"
            +"order by fornecedores.id");
            return dt;
        }
        //-----------------------------
        public void CadFornecedor(string nome, string cnpj, string email, string endereco)
        {
          banco.comandar(
            "insert into fornecedores(nome, cnpj, email, endereco) " +
            "values ('"+nome+"','"+cnpj+"','"+email+"','"+endereco+"')");
            fechar();
        }
        
        public void CadTel(int fornecedor, string tel, string obs)
        {
          banco.comandar(
            "insert into fornecedores(idfornecedorfk, tel, obs) " +
            "values ('"+fornecedor+"','"+tel+"','"+obs+"')");
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
        
        public void DelFornecedor(int i)
        {
            banco.comandar("Delete * from telefones where idfornecedoresfk = '"+i+"'");
            fechar();
        }
        //-----------------------------
        public void AtuFornecedor(string nome, string cnpj, string email, string endereco) 
        {
            banco.comandar(
                "update fornecedores set"
                    +" nome = '"+nome+"',"
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
        //-----------------------------
        public void CadFuncionario(string nome, string cargo, string setor, string email, string tel, string pis, string admissao, string salario, string desconto)
        {
          banco.comandar(
            "insert into funcionarios(nome, idcargofk, idsetorfk, email, tel, pis, admissao, salario, desconto) "+
            "values ('"+nome+"','"+cargo+"','"+setor+"','"+email+"','"tel+"','"+pis+"','"+admissao+"','"+salario,+"','"+desconto+"')");
            fechar();
        }
        //-----------------------------
        public void DelFuncionario(int i)        
        {
            banco.comandar("Delete * from funcionarios where id = '"+i+"'");
            fechar();
        }
        //-----------------------------
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
        //--------------------------------------------------------------------                    
                         
        public void fechar()
        {
            dt.Clear();
        }
    }
}
