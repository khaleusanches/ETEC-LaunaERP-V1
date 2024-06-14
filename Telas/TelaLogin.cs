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
        public TelaLogin()
        {
            InitializeComponent();
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
                btnLogar.Enabled = false;
            }
        }
        private void btnLogar_Click(object sender, EventArgs e)
        {
            DataTable dt = dao.lerTabela($"select * from usuarios where usuarios.login = '{tbUsername.Text}' and usuarios.senha = '{tbSenha.Text}';");
            if(dt.Rows.Count > 0 )
            {
                dt = dao.lerTabela("select funcionarios.nome, setores.nome, cargos.nome from usuarios " +
                    "left join funcionarios on usuarios.id_func = funcionarios.id " +
                    "left join setores on funcionarios.idsetorfk = setores.id " +
                    "inner join cargos on funcionarios.idcargofk = cargos.id " +
                    $"where usuarios.login = '{tbUsername.Text}' and usuarios.senha = '{tbSenha.Text}';");
                Funcionario func = new Funcionario(dt.Rows[0][0].ToString(), tbUsername.Text, dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                switch (func.setor)
                {
                    case "Administrativo":
                        if (func.cargo == "Gerente") { };
                        break;

                    case "Recursos Humanos":
                        if (func.cargo == "Gerente")
                        {
                            this.Hide();
                            new TelaGerenteRH().ShowDialog();
                        }
                        else
                        {
                            this.Hide();
                            new TelaSetorRH().ShowDialog();
                        }
                        break;
                }

            }
        }
    }
}
