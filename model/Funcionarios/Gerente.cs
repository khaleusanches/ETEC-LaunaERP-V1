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

namespace Funcionarios
{
    public class Gerente : Funcionario
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        DataTable DT_consultaID = new DataTable();
        public Gerente()
        {
            nv = 5;
        }
        public void criarTela()
        {
            new TelaPrincipalEstoque(this).ShowDialog();
        }
        public DataTable exibirFornecedores() 
        {
            dt = banco.consultar("select * from fornecedores");
            return dt;
        }
        public void cadastrarFornecedores(string nome, string categoria, string telefone, string descricao)
        {
            banco.comandar("INSERT INTO fornecedores (Nome_Fornecedor, Categoria_Fornecedor, Telefone_Fornecedor, Descrição) values ('"+nome+"','"+categoria+"','"+telefone+"','"+descricao+"')");
            fechar();
        }
        public void deletarFornecedor(int i)
        {
            banco.comandar("Delete from fornecedores where ID_Fornecedor =" + i + "");
            fechar();
        }
        public void atualizarFornecedor(int i, string nome, string categoria, string telefone, string descricao) 
        {
            banco.comandar("UPDATE fornecedores set Nome_Fornecedor='" + nome + "',Categoria_Fornecedor='" + categoria + "',Telefone_Fornecedor='" + telefone + "',Descrição='" + descricao + "' where ID_Fornecedor='" + i + "'");
            fechar();
        }
        public DataTable exibirProdutos()
        {
            dt = banco.consultar("select * from lotes");
            return dt;
        }
        public void fechar()
        {
            dt.Clear();
        }
    }
}
