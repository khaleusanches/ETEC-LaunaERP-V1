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

namespace SetorAministrativo
{
    public class SetorAministrativo : SetorFinanceiro
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        DataTable DT_consultaID = new DataTable();

        //--------------------------------------------------------------------                    
                         
        public void fechar()
        {
            dt.Clear();
        }
    }
}
