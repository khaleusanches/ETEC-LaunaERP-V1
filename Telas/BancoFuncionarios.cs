using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas
{
    public class BancoFuncionarios
    {
        LabelP[] labelPs = new LabelP[15];
        TextBoxP[] textBoxP = new TextBoxP[13];
        DataTable dt;
        DAO dao = new DAO();
        DataGridView dgv = new DataGridView();
        ButtonP btnAdd;
        ComboBoxP cargos;
        ComboBoxP setores;

        string[] listCargo = new string[] { "Gerente", "Assistente", "Auxiliar", "Operador" };
        string[] listSetores = new string[] { "Administrativo", "Recursos Humanos", "Financeiro", "Vendas", "Logística", "TI" };
        public void exibir(Form tela)

        {
            labelPs[0] = new LabelP(30, 20, 125, 25, "ID:", tela);

            labelPs[1] = new LabelP(100, 20, 125, 90, "Nome:", tela);
            labelPs[2] = new LabelP(100, 20, 180, 25, "Email:", tela);
            labelPs[3] = new LabelP(100, 20, 235, 25, "Tel:", tela);

            labelPs[4] = new LabelP(100, 20, 290, 25, "CEP:", tela);
            labelPs[5] = new LabelP(100, 20, 345, 25, "RG:", tela);

            labelPs[6] = new LabelP(100, 20, 345, 160, "CPF:", tela);

            labelPs[7] = new LabelP(100, 20, 400, 25, "Nascimento:", tela);
            labelPs[8] = new LabelP(100, 20, 400, 160, "Admissão:", tela);
            labelPs[9] = new LabelP(100, 20, 465, 25, "PIS:", tela);
            labelPs[10] = new LabelP(100, 20, 465, 160, "Salario:", tela);
            labelPs[11] = new LabelP(100, 20, 525, 25, "Login:", tela);
            labelPs[12] = new LabelP(100, 20, 525, 160, "Password:", tela);
            labelPs[13] = new LabelP(100, 20, 580, 25, "Cargo:", tela);
            labelPs[14] = new LabelP(100, 20, 580, 140, "Setores:", tela);

            textBoxP[0] = new TextBoxP(30, 25, 145, 25, "", 9, tela);
            textBoxP[0].Enabled = false;
            textBoxP[1] = new TextBoxP(50, 25, 145, 90, "", 9, tela);
            textBoxP[2] = new TextBoxP(150, 25, 200, 25, "", 9, tela);
            textBoxP[3] = new TextBoxP(150, 25, 255, 25, "", 9, tela);
            textBoxP[4] = new TextBoxP(150, 25, 310, 25, "", 9, tela);
            textBoxP[5] = new TextBoxP(100, 25, 365, 25, "", 9, tela);
            textBoxP[6] = new TextBoxP(100, 25, 365, 160, "", 9, tela);
            textBoxP[7] = new TextBoxP(100, 25, 420, 25, "", 9, tela);
            textBoxP[8] = new TextBoxP(100, 25, 420, 160, "", 9, tela);
            textBoxP[9] = new TextBoxP(130, 25, 485, 25, "", 9, tela);
            textBoxP[10] = new TextBoxP(100, 25, 485, 160, "", 9, tela);
            textBoxP[11] = new TextBoxP(100, 25, 545, 25, "", 9, tela);
            textBoxP[12] = new TextBoxP(100, 25, 545, 160, "", 9, tela);

            cargos = new ComboBoxP(100, 25, 600, 25, listCargo, tela);
            setores = new ComboBoxP(130, 25, 600, 140, listSetores, tela);
            cargos.SelectedIndexChanged += new EventHandler(BancoFuncionarios_TextChanged);
            setores.SelectedIndexChanged += new EventHandler(BancoFuncionarios_TextChanged);

            foreach (TextBoxP t in textBoxP)
            {
                t.TextChanged += new EventHandler(BancoFuncionarios_TextChanged);
            }

            btnAdd = new ButtonP(true, 100, 25, 650, 25, "Cadastrar funcionario", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += (sender, EventArgs) => Btn_add_Click(textBoxP);
            
            dgv.DataSource = dao.lerTabela("select * from funcionarios");
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Width = 680;
            dgv.Height = 500;
            dgv.Top = 125;
            dgv.Left = 285;
            tela.Controls.Add(dgv);

        }

        public void fechar(Form tela)
        {
            foreach (TextBoxP tbp in textBoxP)
            {
                tela.Controls.Remove(tbp);
            }
            foreach(LabelP labelP in labelPs)
            {
                tela.Controls.Remove(labelP);
            }
            tela.Controls.Remove(dgv);
            tela.Controls.Remove(cargos);
            tela.Controls.Remove(setores);
            tela.Controls.Remove(btnAdd);
        }

        private void Btn_add_Click(TextBoxP[] textBoxP)
        {
            string sql = $"insert into funcionarios (nome, email, tel, endereco, rg, nascimento, admissao, pis, salario, login, senha, idsetorfk, idcargofk) values ('{textBoxP[1].Text}', '{textBoxP[2].Text}', '{textBoxP[3].Text}', '{textBoxP[4].Text}', '{textBoxP[5].Text}', '{textBoxP[7].Text}', '{textBoxP[8].Text}', '{textBoxP[9].Text}', '{textBoxP[10].Text}', '{textBoxP[11].Text}', '{textBoxP[12].Text}', {cargos.SelectedIndex+1}, {setores.SelectedIndex+1})";
            MessageBox.Show(sql);
            dao.updateInsertDelete(sql);
            dgv.DataSource = dao.lerTabela("select * from funcionarios");
        }

        private void BancoFuncionarios_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            for (int i = 1; i < textBoxP.Length; i++)
            {
                if (textBoxP[i].Text == ""){ cont++; }
            }
            if(cargos.SelectedIndex == -1 || setores.SelectedIndex == -1) { cont++; };
            if(cont== 0) { btnAdd.Enabled = true; }
            else { btnAdd.Enabled = false; }
        }


    }

}
