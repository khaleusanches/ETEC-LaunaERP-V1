using CaixaDeFerramentasPerso;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;
using View.RH;

namespace Sistema.Cargos
{
    public class AuxiliarRH : Funcionarios
    {
        public ButtonP btn_add;
        DataTable dt;
        Banco_Funcionarios banco_funcionario;
        private DAO banco = new DAO();
        public AuxiliarRH(string nome, string tempologado) : base(nome, tempologado)
        {
            Tl_Principal_RH tl = new Tl_Principal_RH(this);
            btn_add = new ButtonP(true, 100, 25, 580, 25, "teste", null);
            tl.ShowDialog();
        }

        public DataTable verTabela(Banco_Funcionarios banco_funcionario)
        {
            this.banco_funcionario = banco_funcionario;
            dt = banco.lerTabela("select * from funcionarios");
            return dt;
        }

        public void Btn_add_Click(TextBoxP[] textBoxPs)
        {
            string sql = "";
            int cont = 0;
            int cont2 = 0;
            foreach(TextBoxP textBoxP in textBoxPs)
            {
                if (textBoxP.Text == "")
                {
                    break;
                }
                else 
                { 
                    if (cont >= 2)
                    {
                        sql = sql + "," + "'"+textBoxP.Text+"'";
                    }
                    else
                    {
                        sql = "'" + textBoxP.Text + "'";
                    }
                    cont++;
                }
            }
            for(int i = 0; i < sql.Length; i++)
            {
                if (sql[i] == ',')
                {
                    cont2 ++;
                    MessageBox.Show(cont2.ToString());
                }
            }
            if (cont2 == 11) 
            {
                sql = sql + ",'20', '1', '1'";
                sql = "insert into funcionarios (nome, email, tel, endereco, rg, cpf, nascimento, admissao, pis, salario, login, psswrd, desconto, idcargofk, idsetorfk) values(" + sql +")";
                banco.updateInsertDelete(sql);
                dt.Clear();
                banco_funcionario.refresh();
            }
           
        }
    }
}
