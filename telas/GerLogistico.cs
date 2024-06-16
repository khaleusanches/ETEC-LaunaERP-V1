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

namespace GerLogistico
{
    public class GerLogistico : SetorLogistico
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
        public DataTable ExbFuncionariosNesteSetor(int i) 
        {
            dt = banco.consultar(
            "select"
                +" funcionarios.nome as 'Nome',"
                +" id as 'ID',"
                +" cargos.nome as 'Cargo',"
                +" email as 'Email',"
                +" tel as 'Telefone', pis as 'PIS',"
                +" admissao as 'Data de admissão',"
                +" salario as 'Salário',"
            +" from funcionarios inner join cargos"
            +" on idcargofk = cargo.id and idsetorfk = 5"
            +" order by funcionarios.nome"
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
