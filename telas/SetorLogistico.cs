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
        //--------------------------------------------------------------------   
        public void CadProduto(string nome, string valor, string estoque, string descricao, string disponivel)
        {
          banco.comandar(
              "insert into Lotes(nome, valor, estoque, descricao, disponivel) "+
              "values('"+nome+"', '"+valor+"', '"+estoque+"',  '"+descricao+"', '"+estoque+')"
          );
          fechar();
        }

        public void AtuProduto(int i, string nome, string valor, string estoque, string descricao, string disponivel)
        {
            banco.comandar(
                "update Produtos set"
                   + " nome = '"+nome+"',"
                   + " valor = '"+valor+"',"
                   + " estoque = '"+estoque+"',"
                   + " descricao = '"+descricao+"',"
                   + " disponivel = '"+disponivel+"'"
                   + " where id = '"+i+"'");
            fechar();
        }

        public void DelProduto(int i)
        {
            dt = banco.consultar(
            "select	id from lotes where idprodutofk = '"+i+"'
            return dt;
            Console.WriteLine("Deletar este produto irá deletar todos os lotes to mesmo. Deseja prosseguir?");
            public void Conf(bool c){
               if (c = true)
                  banco.comandar("Delete * from lotes where idprodutofk = '"+i+"'");
                  banco.comandar("Delete * from Produtos where id = '"+i+"'");
            }
          }
            fechar();
        }                
        //--------------------------------------------------------------
        public void CadLote(int idprodutofk, string quantidade, string fornecedor, string aquisicao, string fabricacao, string validade, string notafiscal, string localizacao)
        {
          banco.comandar(
              "insert into Lotes(idprodutofk, quantidade, fornecedor, aquisicao, fabricacao, validade, notafiscal, localizacao) "+
              "values('"+idprodutofk+"', '"+quantidade+"', '"+fornecedor+"', '"+aquisicao+"', '"+fabricacao+"', '"+validade+"', '"+notafiscal+"', '"+localizacao+')"
          );
          fechar();
        }

        public void AtuLote(idprodutofk, quantidade, fornecedor, aquisicao, fabricacao, validade, notafiscal, localizacao)
        {
            banco.comandar(
                "update Lotes set"
                   + " idprodutofk = '"+nome+"',"
                   + " quantidade = '"+valor+"',"
                   + " fornecedor = '"+estoque+"',"
                   + " aquisicao = '"+descricao+"',"
                   + " fabricacao = '"+descricao+"',"
                   + " validade = '"+descricao+"',"
                   + " notafiscal = '"+descricao+"',"
                   + " localizacao = '"+disponivel+"'"
                + " where id = '"+i+"'");
            fechar();
        }
        
        public void DelLote(int i)
        {
            dt = banco.consultar(
               banco.comandar("Delete * from lotes where idprodutofk = '"+i+"'");
            }
            fechar();
        }
        //--------------------------------------------------------------                
                         
        public void fechar()
        {
            dt.Clear();
        }
    }
}
