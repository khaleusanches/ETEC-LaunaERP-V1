using BancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios
{
    public class Repositor : Funcionario
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        public Repositor()
        {
            nv = 4;
        }
        public DataTable exibirProdutos()
        {
            dt = banco.consultar("select * from lotes");
            return dt;
        }
        public void adicionarLote(string nome, int quantidade, int fk_fornecedor, double preco)
        {
            banco.comandar("INSERT INTO lotes(Nome_Produto, Quantidade, FK_Fornecedor, preço) values ('" + nome + "'," + quantidade + "," + fk_fornecedor + "," + preco + ");");
            fechar();
        }
        public void deletarLote(int ID_Lote)
        {
            banco.comandar("Delete from lotes where ID_Lote = " + ID_Lote + "");
            fechar();
        }
        public void atualizarLote(int ID_Lote, string nome, int quantidade, int fk_fornecedor, double preco)
        {
            banco.comandar("UPDATE lotes SET Nome_Produto='" + nome + "', Quantidade='" + quantidade + "',FK_Fornecedor='" + fk_fornecedor + "', preço='" + preco + "' where ID_Lote='" + ID_Lote + "'");
            fechar();
        }
        public void fechar()
        {
            dt.Clear();
        }
    }
}
