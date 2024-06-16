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

namespace SetorLogistico
{
    public class SetorLogistico : GerMercadorias
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
        //--------------------------------------------------------------------               
        public void CadCategoria(string nome, string descricao)
        {
            banco.comandar("insert into categorias (nome, descricao) values ('"+nome+"', '"+descricao+"')");
            fechar();
        } 
        public void AtuCategoria(int i, string nome, string descricao)
        {
            banco.comandar("update categorias set nome = '"+nome+"', descricao = '"+descricao+"' where id = '"+i+"'");
            fechar();
        }
        public void DelCategoria(int i)
        {
            banco.comandar("update produtos set idcategoriafk = 1 where idcategoriafk = '"+i+"'; Delete * from categorias where id = '"+i+"'");
            fechar();
        }
      //--------------------------------------------------------------------
        public void CadProduto(string nome, string valor, string categoria, string descricao)
        {
          banco.comandar(
            "insert into produtos(nome, valor, idcategoriafk, descricao, disponivel) "
            + "values ('"+nome+"', '"+valor+"', '"+categoria+"', '"+" '"+descricao+"', 's')");
            fechar();
        }   
        public void AtuProduto(int i, string nome, string valor, string categoria, string descricao)
        {
            banco.comandar("update produtos set nome = '"+nome+"', valor = '"+valor+"', idcategoriafk = '"+categoria+"', descricao = '"+descricao+"' where id = '"+i+"'");
            fechar();
        }
        public void DelProduto(int i)
        {
            dt = banco.comandar("select id from lotes where idprodutofk = '"+i+"'");
            if (dt = null) {banco.comandar("Delete * from categorias where id = '"+i+"'"); fechar()}
            else {}
            fechar();
        }
      //--------------------------------------------------------------------      
        public void CadLote(string produto, int quantidade, string fornecedor, int aquisicao, int fabricacao, int validade, int notafiscal, string localizacao)
        {
            banco.comandar("insert into lotes(idprodutofk, quantidade, idfornecedor, aquisicao, fabricacao, validade, notafiscal, localizacao) " +
            "values ('"+idprodutofk+"', '"+quantidade+"', '"+idfornecedor+"', '"+aquisicao+"', '"+fabricacao+"', '"+validade+"', '"+notafiscal+"', '"+localizacao+"')");
            fechar();
        } 
        public void AtuLote(int i, string produto, int quantidade, string fornecedor, int aquisicao, int fabricacao, int validade, int notafiscal, string localizacao)
        {
            banco.comandar("update lotes set idprodutofk = '"+produto+"', quantidade = '"+quantidade+"', fornecedor = '"+idfornecedor+"', aquisicao = '"+aquisicao+"', fabricacao = '"+fabricacao+"', validade = '"+validade+"', notafiscal = '"+notafiscal+"', localizacao = '"+localizacao+"' where id = '"+i+"'");
            fechar();
        }
        public void DelLote(int i)
        {
            banco.comandar("delete * from lotes where idlotefk = '"+i+"')");
            fechar();
        }
        
        public void DelLoteProdutoSel(int i)
        {
            banco.comandar("delete * from lotes where idprodutofk = '"+i+"')");
            fechar();
        }
        
        //--------------------------------------------------------------------      
                         
        public void fechar()
        {
            dt.Clear();
        }
    }
}
