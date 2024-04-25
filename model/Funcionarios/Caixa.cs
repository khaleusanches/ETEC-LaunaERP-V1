using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BancoDados;

namespace Funcionarios
{
    public class Caixa : Funcionario
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        public DataTable exibirCaixa(int[] id)
        {
            foreach (int idItem in id) { 
                dt = banco.consultar("select Nome_Produto, preço from lotes  where ID_Lote ="+ idItem +";");
            }
            return dt;
        }
        private void teste()
        {

        }
    }
}
