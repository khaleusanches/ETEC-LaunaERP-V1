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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            btnMenuBurguer.Visible = false;
        }
        private void Btn_Concluir_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE funcionarios set email = '{textBoxPs[2].Text}', tel = '{textBoxPs[3].Text}', endereco = '{textBoxPs[4].Text}', salario = '{textBoxPs[5].Text}', " +
                $"idcargofk = {dao.pegaID("id", "cargos", $"where nome = '{cbCargos.Text}'")}, idsetorfk = {dao.pegaID("id", "setores", $"where nome = '{cbSetores.Text}'")} where id = {textBoxPs[0].Text};";
            dao.updateInsertDelete(sql);
        }

        private void atualizarFuncionarios_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            for (int i = 1; i < textBoxPs.Length; i++)
            {
                if (textBoxPs[i].Text == "") { cont++; }
            }
            if (cbCargos.SelectedIndex == -1 || cbSetores.SelectedIndex == -1) { cont++; };
            if (cont == 0) { btnUpdate.Enabled = true; }
            else { btnUpdate.Enabled = false; }
        }
    }
}
