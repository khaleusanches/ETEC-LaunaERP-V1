using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas
{
    public partial class TelaLogin : Form
    {
        string op ="";
        DAO dao = new DAO();
        public static Funcionario func;
        public TelaLogin()
        {
            InitializeComponent();
            btnLogar.Enabled = true;
        }

        private void lbUsername_Click(object sender, EventArgs e)
        {
        }

        private void tbUsername_tbSenha_TextChanged(object sender, EventArgs e)
        {
            if(tbUsername.Text != "" && tbSenha.Text != "")
            {
                btnLogar.Enabled = true;
            }
            else 
            {
                btnLogar.Enabled = true;
            }
        }
        private void btnLogar_Click(object sender, EventArgs e)
        {
            DataTable dt = dao.lerTabela($"select * from usuarios where usuarios.login = '{tbUsername.Text}' and usuarios.senha = '{tbSenha.Text}';");
            if(dt.Rows.Count > 0 )
            {
                dt = dao.lerTabela("select id funcionarios.nome, setores.nome, cargos.nome from usuarios " +
                    "left join funcionarios on usuarios.id_func = funcionarios.id " +
                    "left join setores on funcionarios.idsetorfk = setores.id " +
                    "inner join cargos on funcionarios.idcargofk = cargos.id " +
                    $"where usuarios.login = '{tbUsername.Text}' and usuarios.senha = '{tbSenha.Text}';");
                if (dt.Rows[0][2].ToString() == "Gerente") 
                { 
                    func = new Gerente(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), tbUsername.Text, dt.Rows[0][2].ToString()); 
                }
                else
                {
                    func = new Funcionario(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), tbUsername.Text, dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                }
                switch (func.setor)
                {
                    case "Administrativo":
                        break;

                    case "Financeiro":
                        this.Hide();
                        new TelaSetorRH(func).ShowDialog();
                        break;
                    case "Recursos Humanos":
                        this.Hide();
                        new TelaSetorRH(func).ShowDialog();
                        break;
                    case "Logistica":
                        this.Hide();
                        new TelaSetorLogistica(func).ShowDialog();
                        break;
                    case "Vendas":
                        if (func.cargo == "Gerente")
                        {
                            this.Hide();
                            new TelaGerenteVendas(func).ShowDialog();
                        }
                        else
                        {
                            new TelaPrincipalCaixa(func).ShowDialog();
                        }
                        break;
                }
            }
            else
            {
                func = new Gerente("1", "teste", "teste", "Logistica");
                new TelaSetorFinanceiro(func).ShowDialog();
            }
        }
    }
}
