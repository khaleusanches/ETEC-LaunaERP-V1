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

namespace GerFinanceiro
{
    public class GerFinanceiro : SetorFinanceiro
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        DataTable DT_consultaID = new DataTable();

        //--------------------------------------------------------------------
        public DataTable ExbOperacoesCaixaBasico() 
        //recentes para antigas
        {
            dt = banco.consultar(
            "select"
                +" id as 'ID',"
                +" idclientefk as 'Cliente',"
                +" total as 'Total',"
                +" troco as 'Troco',"
                +" dataehora as 'Data e hora'"
                +" idfuncionariofk as 'Operador de caixa',"
            +" from operacoes order by dataehora desc");
            return dt;
        }
        //------------------------------------------
                         
        public void fechar()
        {
            dt.Clear();
        }
    }
}
