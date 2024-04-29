using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BancoDados;
using System.Collections.Generic;

namespace Funcionarios
{
    public class Caixa : Funcionario
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        public DataTable exibirCaixa(List<int> id)
        {
            fechar();
            foreach (int idItem in id) { 
                dt = banco.consultar("select Nome_Produto, preço from lotes  where ID_Lote ="+ idItem +";");
            }
            return dt;
            
        }
        public void fechar()
        {
            dt.Clear();
        }
    }
}
