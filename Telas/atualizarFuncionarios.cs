using CaixaDeFerramentasPerso;
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
    public partial class atualizarFuncionarios : TelaPadrao
    {
        DAO dao = new DAO();
        public atualizarFuncionarios(string[] teste, string[]listCargo, string[]listSetores, Funcionario funcionario) : base(funcionario)
        {
            InitializeComponent(listCargo, listSetores);
            for(int i = 0; i < teste.Length; i++)
            {
                textBoxPs[i].Text = teste[i];
            }
        }
        private void BtnConcluir_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE funcionarios set email = '{textBoxPs[1].Text}', tel = '{textBoxPs[2].Text}', endereco = '{textBoxPs[3].Text}', salario = '{textBoxPs[4].Text}';";
            dao.updateInsertDelete(sql);
        }
    }
}
